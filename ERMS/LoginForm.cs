
namespace ERMS

{
    public partial class LoginForm : Form
    {
        // Reference to the main StartupForm to allow communication between the register form and the parent container
        private StartupForm mainForm;
        public LoginForm(StartupForm form)
        {
            InitializeComponent();
            SetPlaceholder(TxtUsername, "Username");
            SetPlaceholder(TxtPassword, "Password", isPassword: true);



            // Stores the passed in reference to the main StartupForm so this child form can interact with it later
            mainForm = form;
            this.Shown += LoginForm_Shown;

        }
        private void LoginForm_Shown(object sender, EventArgs e)
        {

            this.ActiveControl = null;
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

        private void BtnLoginForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainApplicationForm mainApplicationForm = new MainApplicationForm();
            mainApplicationForm.Show();
        }
    }
}


