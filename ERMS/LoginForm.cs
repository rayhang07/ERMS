
using System.Data.OleDb;
using System.Text;
using System.Security.Cryptography;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.ComponentModel.Design.ObjectSelectorEditor;

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
                Sound.PlayError();
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
                Sound.PlayError();
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
                Sound.PlayError();
                message = $"Account is locked. Try again at {lockoutEndTime:T}.";
                return false;
            }

            using (var conn = GetOpenConnection())
            {
                if (conn == null)
                {
                    Sound.PlayError();
                    message = "Unable to connect to the database.";
                    return false;
                }

                // Selects from the database:
                string query = "SELECT UserID, Username, FullName, Email, PasswordHash FROM Users WHERE Username = ?";

                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", username);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userIdFromDb = Convert.ToInt32(reader["UserID"]);
                            string usernameFromDb = reader["Username"].ToString();
                            string fullNameFromDb = reader["FullName"].ToString();
                            string emailFromDb = reader["Email"].ToString();
                            string storedHashBase64 = reader["PasswordHash"].ToString();
                          

                            if (VerifyPassword(password, storedHashBase64))
                            {
                                // Successful login: reset attempts and set current user info
                                loginAttempts = 0;

                                CurrentUser.UserId = userIdFromDb;
                                CurrentUser.Username = usernameFromDb;
                                CurrentUser.FullName = fullNameFromDb;
                                CurrentUser.Email = emailFromDb;

                                return true;
                            }
                            else
                            {
                                // Password incorrect, increment attempts and display error message
                                loginAttempts++;

                                if (loginAttempts >= 3)
                                {
                                    lockoutEndTime = DateTime.Now.AddMinutes(1);
                                    Sound.PlayError();
                                    message = "Account locked due to too many failed attempts. Try again in 1 minute.";
                                }
                                else
                                {
                                    Sound.PlayError();
                                    message = $"Invalid credentials. Attempt {loginAttempts} of 3.";
                                }

                                return false;
                            }
                        }
                        else
                        {
                            // Username not found, attempts don't increment
                            Sound.PlayError();
                            message = "User doesn't exist.";
                            return false;
                        }

                    }
                }
            }
        }


        // Checks if the password matches the stored password hash
        public bool VerifyPassword(string password, string storedHashBase64)
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
            Sound.PlaySuccess();
            MessageBox.Show("Login successful!");

            // Hide the current login form
            startupForm.Hide();

            // Open the Main Application
            MainApplicationForm mainApplicationForm = new MainApplicationForm(startupForm);
            mainApplicationForm.Show();
        }
    }

}



