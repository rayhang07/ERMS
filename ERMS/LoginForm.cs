
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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            
            mainForm.Hide();


            MainApplicationForm mainApplicationForm = new MainApplicationForm(mainForm);
            mainApplicationForm.Show();
        }
    }
}


