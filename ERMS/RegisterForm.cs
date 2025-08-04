using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERMS
{
    public partial class RegisterForm : Form
    {
        // Reference to the main StartupForm to allow communication between the register form and the parent container
        private StartupForm mainForm;
        public RegisterForm(StartupForm form)
        {
            InitializeComponent();
            SetPlaceholder(TxtUsername, "Username");
            SetPlaceholder(TxtPassword, "Password", isPassword: true);
            SetPlaceholder(TxtEmail, "Email");
            SetPlaceholder(TxtName, "Name");
            SetPlaceholder(TxtConfirmPassword, "Confirm Password", isPassword: true);

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

        public void SetPlaceholder(TextBox textBox, string placeholderText, bool isPassword = false)
        {
            char originalPasswordChar = textBox.PasswordChar;
            bool isShowingPlaceholder = true;

            // Apply initial placeholder
            void ShowPlaceholder()
            {
                textBox.Text = placeholderText;
                textBox.ForeColor = Color.FromArgb(245, 245, 245); 
                if (isPassword)
                {
                    textBox.UseSystemPasswordChar = false;
                }
                isShowingPlaceholder = true;
            }

            void HidePlaceholder()
            {
                textBox.Text = "";
                textBox.ForeColor = Color.White;
                if (isPassword)
                {
                    textBox.UseSystemPasswordChar = true;
                }
                isShowingPlaceholder = false;
            }

            // Set initial placeholder on startup
            ShowPlaceholder();

            textBox.Enter += (sender, e) =>
            {
                if (isShowingPlaceholder)
                {
                    HidePlaceholder();
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    ShowPlaceholder();
                }
            };
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
    }
}
    
