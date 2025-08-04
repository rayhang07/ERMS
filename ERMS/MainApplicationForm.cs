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
        public MainApplicationForm()
        {
            InitializeComponent();
            CustomiseDesign();
        }

        private void MainApplicationForm_Load(object sender, EventArgs e)
        {

        }

        private void CustomiseDesign()
        {
            PnlClassesSubMenu.Visible = false;
            PnlGradeBookSubMenu.Visible = false;
        }

        private void HideSubMenu()
        {
            if (PnlClassesSubMenu.Visible == true)
                PnlClassesSubMenu.Visible = false;
            if (PnlGradeBookSubMenu.Visible == true)
                PnlGradeBookSubMenu.Visible = false;
        }
        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;

            }
        }



        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
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
            ShowSubMenu(PnlClassesSubMenu);

        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void BtnGradeBook_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PnlGradeBookSubMenu);
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void BtnStudentRankings_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void BtnMyAccount_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void BtnMyClasses_Click(object sender, EventArgs e)
        {

        }

        private void BtnCreateClass_Click(object sender, EventArgs e)
        {

        }

        private void BtnManageClass_Click(object sender, EventArgs e)
        {

        }

        private void BtnExamResults_Click(object sender, EventArgs e)
        {

        }

        private void BtnResultsAnalytics_Click(object sender, EventArgs e)
        {

        }
    }
}
