using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERMS
{
    public partial class MyAccountForm : Form
    {
        public MyAccountForm()
        {
            InitializeComponent();
            TxtName.Text = CurrentUser.FullName;
            TxtUsername.Text = CurrentUser.Username;
            TxtEmail.Text = CurrentUser.Email;


        }

        private void TxtCurrentPassword_TextChanged(object sender, EventArgs e)
        {

        }




        private void MyAccountForm_Load(object sender, EventArgs e)
        {

        }

        private void CbShowPassword_CheckedChanged(object sender, EventArgs e)
        {

            if (CbShowPassword.Checked)
            {
                // Shows password
                TxtNewPassword.UseSystemPasswordChar = false;
                TxtConfirmPassword.UseSystemPasswordChar = false;
                TxtCurrentPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Hides password
                TxtCurrentPassword.UseSystemPasswordChar = true;
                TxtNewPassword.UseSystemPasswordChar = true;
                TxtConfirmPassword.UseSystemPasswordChar = true;
            }
        }

       

        private void BtnSaveNewPassword_Click(object sender, EventArgs e)
        {

            ChangePassword();    

        }
      

        private void ChangePassword()
        {
            // Stores the inputs from the textboxes
            string currentPassword = TxtCurrentPassword.Text;
            string newPassword = TxtNewPassword.Text;
            string confirmPassword = TxtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(TxtCurrentPassword.Text) ||
                string.IsNullOrWhiteSpace(TxtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(TxtConfirmPassword.Text))
            {
                Sound.PlayError();
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            // Stores the current users ID
            int userId = CurrentUser.UserId;  

            // Creates path to db
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");

            // Creates instances of Login and Register service classes
            var userLoginService = new UserLoginService(dbPath);
            var userRegistrationService = new UserRegistrationService(dbPath);

            // Get the stored password hash for the current user from DB
            
            string storedHashBase64 = userRegistrationService.GetPasswordHashFromDb(userId);
            if (storedHashBase64 == null)
            {
                Sound.PlayError();
                MessageBox.Show("Error retrieving current password.");
                return;
            }

            // Verify current password
            if (!userLoginService.VerifyPassword(currentPassword, storedHashBase64))
            {
                Sound.PlayError();
                MessageBox.Show("Current password is incorrect.");
                return;
            }

            // Validate new password rules
            if (!userRegistrationService.ValidatePasswordRules(newPassword, confirmPassword, out string validationError))
            {
                MessageBox.Show(validationError);
                return;
            }

            // Hash new password
            string newHashedPassword = userRegistrationService.EncryptPassword(newPassword);

            // Update password in DB
            bool updated = userRegistrationService.UpdateUserPassword(userId, newHashedPassword);

            if (updated)
            {
                Sound.PlaySuccess();
                MessageBox.Show("Password changed successfully!");
                TxtCurrentPassword.Clear();
                TxtNewPassword.Clear();
                TxtConfirmPassword.Clear();
            }
            else
            {
                Sound.PlayError();
                MessageBox.Show("Failed to update password. Please try again.");
            }
        }

        
        

    }

}
