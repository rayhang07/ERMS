
namespace ERMS

{
    public partial class LoginForm : Form
    {
        private StartupForm mainForm;
        public LoginForm(StartupForm form)
        {
           InitializeComponent();
           mainForm= form;
          

        }
       

       
        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void PnlLogin_Paint(object sender, PaintEventArgs e)
        {
            using (Pen thickPen = new Pen(Color.Black, 2))
            {
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
                TxtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                TxtPassword.UseSystemPasswordChar = true;
            }
        }

        private void BtnRegisterForm_Click(object sender, EventArgs e)
        {

            mainForm.OpenChildForm(new RegisterForm(mainForm));
            this.TopLevel = false;
            
        }
   
    
       
    }
}


