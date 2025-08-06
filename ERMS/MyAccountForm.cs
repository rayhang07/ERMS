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
    public partial class MyAccountForm : Form
    {
        public MyAccountForm()
        {
            InitializeComponent();

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
    }
}
