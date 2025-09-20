using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Media;
using ERMS;





namespace ERMS
{
   

    public partial class RegisterForm : Form
    {
        // Reference to the main StartupForm to allow communication between the register form and the parent container
        private StartupForm mainForm;
        public RegisterForm(StartupForm form)
        {
            InitializeComponent();
            TxtPassword.UseSystemPasswordChar = true;
            TxtConfirmPassword.UseSystemPasswordChar = true;


            // Stores the passed in reference to the main StartupForm so this child form can interact with it later
            mainForm = form;

        }

        private void PnlRegister_Paint(object sender, PaintEventArgs e)
        {
            using (Pen thickPen = new Pen(Color.Black, 2))
            {
                // Draws a line to segment the Login and Register buttons from the input fields
                e.Graphics.DrawLine(thickPen, 350, 780, 982, 780);
            }


        }



        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnLoginForm_Click(object sender, EventArgs e)
        {
            // Opens the Login Form within the panel container and hides the Register Form contents
            mainForm.OpenChildForm(new LoginForm(mainForm));
            this.TopLevel = false;

        }

        private void CbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CbShowPassword.Checked)
            {
                // Password is obfuscated by defualt, shows password on click
                TxtPassword.UseSystemPasswordChar = false;
                TxtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Hides password
                TxtPassword.UseSystemPasswordChar = true;
                TxtConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {

            // Get input values from input fields
            string name = TxtName.Text.Trim();
            string username = TxtUsername.Text.Trim();
            string email = TxtEmail.Text.Trim();

            // do NOT trim passwords as it changes the password
            string password = TxtPassword.Text;  
            string confirmPassword = TxtConfirmPassword.Text;

            // Create an instance of the class 
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
            var userService = new UserRegistrationService(dbPath);



            // Call RegisterUser method and handle process using the inputs
            if (userService.RegisterUser(name, username, email, password, confirmPassword, out string errorMessage))
            {
                Sound.PlaySuccess();
                MessageBox.Show("Registration successful!", "Success");

                // Clear the form fields
                TxtName.Clear();
                TxtUsername.Clear();
                TxtEmail.Clear();
                TxtPassword.Clear();
                TxtConfirmPassword.Clear();
            }
            else
            {
                // Show the error
                Sound.PlayError();
                MessageBox.Show(errorMessage, "Registration Failed");
            }
           

        }

    }
}

    // Class for registrating users
    public class UserRegistrationService
    {
        // String to connect to DB
        private readonly string connectionString;

        // constructs full connection string for DB connection
        public UserRegistrationService(string dbPath)
        {
            connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};Persist Security Info=False;";
        }


        public OleDbConnection GetOpenConnection()
        {
            try
            {
                var conn = new OleDbConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
            // Handle exception
            Sound.PlayError();
            MessageBox.Show("Database connection failed: " + ex.Message);
                return null;
                
            }
        }
    public bool ValidateInput(string name, string username, string email, string password, string confirmPassword, out string errorMessage)
    {
        errorMessage = "";

        // Check if any inputs are empty
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
        {
            Sound.PlayError();
            errorMessage = "All fields are required.";
            return false;
        }

        // Validate email format
        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(email, emailPattern))
        {
            Sound.PlayError();
            errorMessage = "Invalid email format.";
            return false;
        }

        // Validate name: letters and hyphens only
        if (!Regex.IsMatch(name, @"^[A-Za-z\-\s]+$"))
        {
            Sound.PlayError();
            errorMessage = "Name can only contain letters and hyphens.";
            return false;
        }

        // Validate username: letters, numbers, and hyphens only
        if (!Regex.IsMatch(username, @"^[A-Za-z0-9\-]+$"))
        {
            Sound.PlayError();
            errorMessage = "Username can only contain letters, numbers, and hyphens.";
            return false;
        }

        // Validate password rules using the new method
        if (!ValidatePasswordRules(password, confirmPassword, out errorMessage))
        {
            return false;
        }

        return true;
    }

    public bool ValidatePasswordRules(string password, string confirmPassword, out string errorMessage)
    {
        errorMessage = "";

        // Check passwords are not empty
        if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
        {
            Sound.PlayError();
            errorMessage = "Password fields cannot be empty.";
            return false;
        }

        // Check passwords match
        if (password != confirmPassword)
        {
            Sound.PlayError();
            errorMessage = "Password and Confirm Password do not match.";
            return false;
        }

        // Check length and uppercase letter
        if (password.Length < 8 || !Regex.IsMatch(password, @"[A-Z]"))
        {
            Sound.PlayError();
            errorMessage = "Password must be at least 8 characters and contain at least one uppercase letter.";
            return false;
        }

        return true;
    }
    public string GetPasswordHashFromDb(int userId)
    {
        string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
        var userService = new UserRegistrationService(dbPath);


        using (var conn = userService.GetOpenConnection())
        {
            if (conn == null) return null;

            string query = "SELECT PasswordHash FROM Users WHERE UserID = ?";

            using (var cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("?", userId);

                var result = cmd.ExecuteScalar();
                return result?.ToString();  // returns null if no user found
            }
        }
    }
    public bool UpdateUserPassword(int userId, string newHashedPassword)
    {
        using (var conn = GetOpenConnection())
        {
            string updateQuery = "UPDATE Users SET PasswordHash = ? WHERE UserID = ?";
            using (var cmd = new OleDbCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("?", newHashedPassword);
                cmd.Parameters.AddWithValue("?", userId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    
    public string EncryptPassword(string password)
        {
            // Create a random salt for the hash
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Combine password and salt 
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] passwordWithSalt = new byte[passwordBytes.Length + salt.Length];

            // Places the salt after the password in the array passwordBytes to create the salted password
            Buffer.BlockCopy(passwordBytes, 0, passwordWithSalt, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, passwordWithSalt, passwordBytes.Length, salt.Length);

            // Hash the combination of the password and salt
            using (var sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(passwordWithSalt);

                // Combine hash and salt for later verification
                byte[] storedHash = new byte[hash.Length + salt.Length];
                Buffer.BlockCopy(hash, 0, storedHash, 0, hash.Length);
                Buffer.BlockCopy(salt, 0, storedHash, hash.Length, salt.Length);

                // Convert to Base64 string to store in the database
                return Convert.ToBase64String(storedHash);
            }
        }

        public bool CheckUserExists(string username, string email)
        {
            // Creates a connection to the database
            using (var conn = GetOpenConnection())
            {
                // Creates a query to check amount of records with the given username and email
                string query = "SELECT COUNT(*) FROM Users WHERE Username = ? OR Email = ?";

                // Creates command to execute query
                using (var cmd = new OleDbCommand(query, conn))
                {
                    // Uses parameters to add values safely
                    cmd.Parameters.AddWithValue("?", username);
                    cmd.Parameters.AddWithValue("?", email);

                    // Executes the command to return if there are pre existing records with the given credentials
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public bool RegisterUser(string name, string username, string email, string password, string confirmPassword, out string errorMessage)
        {
            errorMessage = "";

            // Validate inputs
            if (!ValidateInput(name, username, email, password, confirmPassword, out errorMessage))
                return false;

            // Check if user exists
            if (CheckUserExists(username, email))
        {
            Sound.PlayError();
            errorMessage = "Username or Email already exists.";
                return false;
            }

            // Encrypt password
            string passwordHash = EncryptPassword(password);

            // Insert into DB
            using (var conn = GetOpenConnection())
            {
                string insertQuery = "INSERT INTO Users (fullName, Username, Email, PasswordHash) VALUES (?, ?, ?, ?)";
                using (var cmd = new OleDbCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", name);
                    cmd.Parameters.AddWithValue("?", username);
                    cmd.Parameters.AddWithValue("?", email);
                    cmd.Parameters.AddWithValue("?", passwordHash);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }


    }


