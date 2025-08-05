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
    public partial class MyClassesForm : Form
    {
        public MyClassesForm()
        {
            InitializeComponent();
            SetPlaceholder(TxtSearch, "Student");

        }
        public void SetPlaceholder(TextBox textBox, string placeholderText, bool isPassword = false)
        {
            char originalPasswordChar = textBox.PasswordChar;
            bool isShowingPlaceholder = true;

            // Apply initial placeholder
            void ShowPlaceholder()
            {
                textBox.Text = placeholderText;
                textBox.ForeColor = Color.Black;

                if (isPassword)
                {
                    textBox.UseSystemPasswordChar = false;
                }
                isShowingPlaceholder = true;
            }

            void HidePlaceholder()
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
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

        private void MyClassesForm_Load(object sender, EventArgs e)
        {

        }
    }


}
