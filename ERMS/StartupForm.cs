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

        public StartupForm()
        {
            InitializeComponent();
            this.Load += StartupForm_Load;
            OpenChildForm(new LoginForm(this));
        }
        public void OpenChildForm(Form childForm)
        {
            // Close previous child form if any
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;

            // Configure child form to be embedded
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Clear existing controls and add the new child form
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
