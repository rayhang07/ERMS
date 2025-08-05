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
    public partial class MainApplicationForm : Form
    {
        private Form _startupForm;
        public MainApplicationForm(Form startupForm)
        {
            InitializeComponent();
            _startupForm = startupForm;
            // calls the method to hide submenus on startup
            CustomiseDesign();
            OpenChildForm(new DashboardForm());
            this.FormClosing += MainApplicationForm_FormClosing;

        }

        private void MainApplicationForm_Load(object sender, EventArgs e)
        {

        }

        private void CustomiseDesign()
        {
            // Hides the submenus by defualt
            PnlClassesSubMenu.Visible = false;
            PnlGradeBookSubMenu.Visible = false;
        }

        private void HideSubMenu()
        {
            // Checks if submenu is visible, and if it is hides it
            if (PnlClassesSubMenu.Visible == true)
                PnlClassesSubMenu.Visible = false;
            if (PnlGradeBookSubMenu.Visible == true)
                PnlGradeBookSubMenu.Visible = false;
        }
        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                // If the submenu is hidden, hide all other submenus then show the submenu
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                // Hides the submenu if it was visible (closes it)
                subMenu.Visible = false;

            }
        }

        private void MainApplicationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Optional: confirm exit
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to exit?",
                    "Exit Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancel closing
                    return;
                }

                // Exit application (optional, but safe)
                Application.Exit();
            }
        }



        // Keeps track of the currently active child form inside the container panel
        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            // If there is already an active child form open, close it before opening a new one
            if (activeForm != null)
                activeForm.Close();

            // Set the new child form as the active form
            activeForm = childForm;

            // Configure the child form to be embedded inside the parent form
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Add the child form to the panel container controls and set it as the tag for easy access
            PnlContainer.Controls.Add(childForm);
            PnlContainer.Tag = childForm;

            // Bring the child form to the front and show it
            childForm.BringToFront();
            childForm.Show();
        }
        private void BtnClasses_Click(object sender, EventArgs e)
        {
            // Drops down the class submenu/hides it
            ShowSubMenu(PnlClassesSubMenu);

        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            // Hides all submenus
            HideSubMenu();
            OpenChildForm(new DashboardForm());
        }

        private void BtnGradeBook_Click(object sender, EventArgs e)
        {
            // Drops down the gradebook submenu/hides it
            ShowSubMenu(PnlGradeBookSubMenu);
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            // Hides all submenus
            HideSubMenu();
            OpenChildForm(new ReportForm());    
        }

        private void BtnStudentRankings_Click(object sender, EventArgs e)
        {
            // Hides all submenus
            HideSubMenu();
            OpenChildForm(new StudentRankingsForm());
        }

        private void BtnMyAccount_Click(object sender, EventArgs e)
        {
            // Hides all submenus
            HideSubMenu();
            OpenChildForm(new MyAccountForm()); 
        }

        private void BtnMyClasses_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MyClassesForm());
        }

        private void BtnCreateClass_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CreateClassForm());
        }

        private void BtnManageClass_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManageClassForm());
        }

        private void BtnExamResults_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ExamResultsForm());   
        }

        private void BtnResultsAnalytics_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ResultsAnalyticsForm());  
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show
                (
                "Do you want to logout?",         
                "Confirm Logout",                 
                MessageBoxButtons.YesNo,          
                 MessageBoxIcon.Question           
                );

            if (result == DialogResult.Yes)
            {
                this.Hide();
                _startupForm.Show();
            }
            else
            {

            }
        }
    }
}
