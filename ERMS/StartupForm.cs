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
    public partial class StartupForm : Form
    {
        private Form activeForm = null;
        public int loginAttempts = 0;
        public DateTime lockoutEndTime = DateTime.MinValue;
        public StartupForm()
        {
            InitializeComponent();

            // Attach the Load event handler method 'StarupForm_Load'
            this.Load += StartupForm_Load;

            // Immediately loads the LoginForm in the panel container, so it is shown by default on startup
            OpenChildForm(new LoginForm(this));
        }
        public void OpenChildForm(Form childForm)
        {
            // Close previous child form if any
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;

            // Configure child form to be embedded to fill the panel container
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Clear existing controls and add the new child form within the panel container
            PnlContainer.Controls.Clear();
            PnlContainer.Controls.Add(childForm);

            childForm.Show();
        }
        private void PnlWelcomePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LblWelcomeMessage_Click(object sender, EventArgs e)
        {

        }

        private async void StartupForm_Load(object sender, EventArgs e)
        {
            // Stores 3 messages in a list for the dynamic welcome message
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
            // Infinite loop to cycle messages
            while (true)
                foreach (string message in messages)
                {
                    // Type out the message letter by letter
                    label.Text = "";
                    foreach (char c in message)
                    {
                        label.Text += c;
                        await Task.Delay(typeDelay);
                    }

                    // Pause after typing out the message
                    await Task.Delay(pauseDelay);

                    // Delete the message letter by letter
                    while (label.Text.Length > 0)
                    {
                        label.Text = label.Text.Substring(0, label.Text.Length - 1);
                        await Task.Delay(typeDelay);
                    }
                }
        }

        private void PnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

