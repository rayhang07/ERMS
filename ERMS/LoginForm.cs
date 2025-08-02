
namespace ERMS

{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
           InitializeComponent();
           this.Load += LoginForm_Load;

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
            
            RegisterForm registerForm = new RegisterForm(this);
            registerForm.Show();
            this.Hide();
           
        }
   
    private async void LoginForm_Load(object sender, EventArgs e)
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
    }
}


