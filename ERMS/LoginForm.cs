
using System.Data.OleDb;
using System.Text;
using System.Security.Cryptography;

namespace ERMS

{
    public partial class LoginForm : Form
    {
       
        // Reference to the main StartupForm to allow communication between the register form and the parent container
        private StartupForm mainForm;

        public LoginForm(StartupForm form)
        {
            InitializeComponent();
            TxtPassword.UseSystemPasswordChar = true;



            // Stores the passed in reference to the main StartupForm so this child form can interact with it later
            mainForm = form;
            this.Shown += LoginForm_Shown;

        }
        private void LoginForm_Shown(object sender, EventArgs e)
        {

            this.ActiveControl = null;
        }





        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void PnlLogin_Paint(object sender, PaintEventArgs e)
        {
            using (Pen thickPen = new Pen(Color.Black, 2))
            {
                // Draws a line to segment the Login and Register buttons from the input fields
                e.Graphics.DrawLine(thickPen, 350, 780, 982, 780);
            }
        }



        private void PnlWelcomePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CbShowPassword.Checked)
            {
                // Password is obfuscated by defualt, shows password on click
                TxtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Hides password
                TxtPassword.UseSystemPasswordChar = true;
            }
        }

        private void BtnRegisterForm_Click(object sender, EventArgs e)
        {
            // Opens the Register Form within the panel container and hides the Login Form contents
            mainForm.OpenChildForm(new RegisterForm(mainForm));
            this.TopLevel = false;

        }
        private string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            string username = TxtUsername.Text.Trim();
            string password = TxtPassword.Text;

            // Create instance of UserLoginService, pass your DB path here
            var loginService = new UserLoginService(dbPath);

            // Optional: Validate inputs (you can add your own validateInput method)
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Try to authenticate user
            bool isAuthenticated = loginService.AuthenticateUser(username, password, ref mainForm.loginAttempts,ref mainForm.lockoutEndTime, out string message);

            if (isAuthenticated)
            {
                // Successful login - call confirmLogin to proceed
                loginService.ConfirmLogin(mainForm);
                TxtUsername.Clear();
                TxtPassword.Clear();

            }
            else
            {
                // Show error message (invalid credentials or locked out)
                MessageBox.Show(message);
            }
        }  


    }

   
    public class UserLoginService
    {
        // Connection string to connect to the database
        private readonly string connectionString;

        // Variable to see how many failed login attempts have occurred
        

        // Stores the time until which the account is locked
        

        // Builds connection string using database path
        public UserLoginService(string dbPath)
        {
            connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};Persist Security Info=False;";
        }
        
        // Opens and returns a connection to the database
        private OleDbConnection GetOpenConnection()
        {   
            // Try to establish a connection
            try
            {
                var conn = new OleDbConnection(connectionString);
                conn.Open(); 
                return conn;
            }
            catch (Exception ex)
            {
                // Handle the result/error
                MessageBox.Show("Database connection failed: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Attempts to authenticate a user by username and password
        public bool AuthenticateUser(string username, string password, ref int loginAttempts, ref DateTime lockoutEndTime, out string message)
        {
            message = "";

            // Check if account is currently locked due to too many failed attempts
            if (DateTime.Now < lockoutEndTime)
            {
                message = $"Account is locked. Try again at {lockoutEndTime:T}.";
                return false;
            }

            using (var conn = GetOpenConnection())
            {
                if (conn == null) 
                {
                    message = "Unable to connect to the database.";
                    return false;
                }

                // Query to get stored password hash for the given username
                string query = "SELECT PasswordHash FROM Users WHERE Username = ?";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    // Parameterised query for security
                    cmd.Parameters.AddWithValue("?", username);

                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string storedHashBase64 = result.ToString();

                        // Verify the entered password against the stored hash and salt
                        if (VerifyPassword(password, storedHashBase64))
                        {
                            // Successful login: reset attempts and allow login
                            loginAttempts = 0;
                            return true;
                        }
                    }
                }
            }

            // Login failed, add one to login attempts
            loginAttempts++;

            if (loginAttempts >= 3)
            {
                // Lock the account for 1 minute after 3 failed attempts
                lockoutEndTime = DateTime.Now.AddMinutes(1);
                message = "Account locked due to too many failed attempts. Try again in 1 minute.";
            }
            else
            {
                message = $"Invalid credentials. Attempt {loginAttempts} of 3.";
            }

            return false;
        }

        // Checks if the password matches the stored password hash
        private bool VerifyPassword(string password, string storedHashBase64)
        {
            // Convert stored Base64 string back to bytes
            byte[] storedBytes = Convert.FromBase64String(storedHashBase64);

            // Extract the salt
            byte[] salt = new byte[16];
            Buffer.BlockCopy(storedBytes, storedBytes.Length - 16, salt, 0, 16);

            // Add salt to the hash
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] passwordWithSalt = new byte[passwordBytes.Length + salt.Length];
            Buffer.BlockCopy(passwordBytes, 0, passwordWithSalt, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, passwordWithSalt, passwordBytes.Length, salt.Length);

            using (var sha = SHA256.Create())
            {
                // Hash the salted password
                byte[] computedHash = sha.ComputeHash(passwordWithSalt);

                // Compare hash bytes with stored hash bytes 
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedBytes[i])
                        return false; 
                }

                return true; 
            }
        }
        

        public void ConfirmLogin(Form startupForm)
        {
            
            MessageBox.Show("Login successful!");

            // Hide the current login form
            startupForm.Hide();

            // Open the Main Application
            MainApplicationForm mainApplicationForm = new MainApplicationForm(startupForm);
            mainApplicationForm.Show();
        }
    }

}



