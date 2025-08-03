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
        private StartupForm mainForm;
        public RegisterForm(StartupForm form)
        {
            InitializeComponent();
            mainForm = form;

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
            mainForm.OpenChildForm(new LoginForm(mainForm));
            this.TopLevel = false;
            
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
    
