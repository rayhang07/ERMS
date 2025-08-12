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
                bool shouldCheckUnsaved = false;

                Type[] formsToCheck = new Type[]
                { typeof(CreateClassForm), typeof(ManageClassForm), typeof(ExamResultsForm), typeof(MyAccountForm), typeof(ReportForm)
                };

                if (activeForm != null)
                {
                    foreach (var formType in formsToCheck)
                    {
                        if (formType.IsInstanceOfType(activeForm))
                        {
                            shouldCheckUnsaved = true;
                            break;
                        }
                    }
                }

                if (shouldCheckUnsaved && UnsavedChangesService.HasUnsavedChanges(activeForm))
                {
                    Sound.PlayError();
                    var unsavedResult = MessageBox.Show(
                        "You have unsaved changes. Are you sure you want to exit without saving?",
                        "Unsaved Changes",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (unsavedResult == DialogResult.No)
                    {   
                        // Cancel closing
                        e.Cancel = true; 
                        return;
                    }
                }
                else
                {
                    Sound.PlayError();
                    var exitResult = MessageBox.Show(
                        "Are you sure you want to exit?",
                        "Exit Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (exitResult == DialogResult.No)
                    {   
                        // Cancel closing
                        e.Cancel = true; 
                        return;
                    }
                }

               
                Application.Exit();
            }
        }


        // Keeps track of the currently active child form inside the container panel
        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                Type[] formsToCheck = new Type[]
                {
            // Checks these forms for unsaved data
            typeof(CreateClassForm),
            typeof(ExamResultsForm),
            typeof(ManageClassForm),
            typeof(MyAccountForm),
            typeof(ReportForm)
                    
                };

                if (formsToCheck.Contains(activeForm.GetType()))
                {
                    bool canClose = UnsavedChangesService.ConfirmCloseIfUnsaved(activeForm);
                    if (!canClose)
                    {
                        // User cancelled switching
                        return;
                    }
                }

                // Close the current form
                activeForm.Close();

                // Check if activeForm is still open (Close can be canceled in FormClosing)
                if (!activeForm.IsDisposed && activeForm.Visible)
                {
                    // Close was canceled, do not switch
                    return;
                }
            }

            // Now open the new child form
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            PnlContainer.Controls.Add(childForm);
            PnlContainer.Tag = childForm;

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
            bool canLogout = false;

            // List or array of types to check
            Type[] formsToCheck = new Type[]
            { typeof(CreateClassForm), typeof(ManageClassForm), typeof(ExamResultsForm), typeof(MyAccountForm), typeof(ReportForm)

                // add any other forms you want to check here
            };

            bool shouldCheckUnsaved = false;

            if (activeForm != null)
            {
                foreach (var formType in formsToCheck)
                {
                    if (formType.IsInstanceOfType(activeForm))
                    {
                        shouldCheckUnsaved = true;
                        break;
                    }
                }
            }

            if (shouldCheckUnsaved && UnsavedChangesService.HasUnsavedChanges(activeForm))
            {
                Sound.PlayError(); 
                var unsavedResult = MessageBox.Show(
                    "You have unsaved changes. Do you want to logout anyway?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    
                );

                if (unsavedResult == DialogResult.Yes)
                    canLogout = true; // User confirmed despite unsaved changes
            }
            else
            {
                // No unsaved changes, or form doesn't require check - ask regular logout confirmation
                Sound.PlayError();
                var logoutResult = MessageBox.Show(
                    "Do you want to logout?",
                    "Confirm Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (logoutResult == DialogResult.Yes)
                    canLogout = true;
            }

            if (canLogout)
            {
                // Proceed with logout
                this.Hide();
                _startupForm.Show();

                // Clear current user data
                CurrentUser.UserId = 0;
                CurrentUser.Username = null;
                CurrentUser.FullName = null;
                CurrentUser.Email = null;
            }
            // else user cancelled logout — do nothing
        }


    }

}