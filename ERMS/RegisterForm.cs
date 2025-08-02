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
        private LoginForm _loginForm;
        public RegisterForm(LoginForm loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
            this.Load += RegisterForm_Load;
        }

       
        private async void RegisterForm_Load(object sender, EventArgs e)
        {
            string[] messages = new string[]
            {
                "Welcome to ERMS!",
                "Manage Your Exams Easily.",
                "Track Your Students’ Progress."
            };

            await TypewriterCycle(LblWelcomeMessage, messages);
        }

        private async Task TypewriterCycle(Label label, string[] messages, int typeDelay = 70, int pauseDelay = 1500)
        {
            while (true)  // Infinite loop to cycle messages
            {
                foreach (string message in messages)
                {
                    // Type out the message
                    label.Text = "";
                    foreach (char c in message)
                    {
                        label.Text += c;
                        await Task.Delay(typeDelay);
                    }

                    await Task.Delay(pauseDelay);  // Pause after typing

                    // Delete the message
                    while (label.Text.Length > 0)
                    {
                        label.Text = label.Text.Substring(0, label.Text.Length - 1);
                        await Task.Delay(typeDelay);
                    }
                }
            }
        }
    


        private void PnlRegister_Paint(object sender, PaintEventArgs e)
        {
            using (Pen thickPen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawLine(thickPen, 350, 780, 982, 780);
            }
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnLoginForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            _loginForm.Show();
        }

        private void CbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CbShowPassword.Checked)
            {
                TxtPassword.UseSystemPasswordChar = false;
                TxtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                TxtPassword.UseSystemPasswordChar = true;
                TxtConfirmPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
    
