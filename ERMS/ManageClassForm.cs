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
    public partial class ManageClassForm : Form
    {
        public ManageClassForm()
        {
            InitializeComponent();
            this.Resize += (s, e) => this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Initialise the list of labels to include all labels that need lines drawn around them
            List<System.Windows.Forms.Label> myLabels = new List<System.Windows.Forms.Label>
            {
                LblLastClassDeleted,
                LblClassNameLast,
                LblSubjectLast,
                LblYearLast,
                LblLastStudentAdded,
                LblStudentNameAddLast,
                LblStudentIDAddLast,
                LblClassNameAddLast,
                LblLastStudentRemoved,
                LblStudentNameRemovedLast,
                LblClassNameRemovedLast,
                LblStudentIDRemovedLast


            };
            
            // Calls the method to draw lines above and below the group of labels
            LineDrawer.DrawLinesAroundLabels(this, e, myLabels);
        }

        private void BtnSaveDelete_Click(object sender, EventArgs e)
        {
            // Gets the values from the text boxes
            string className = TxtClassNameDelete.Text.Trim();
            string subject = TxtSubjectDelete.Text.Trim();
            string year = TxtYearDelete.Text.Trim();

            // Creates an instance of the StudentManagementService
            var studentService = new StudentManagementService();

            
            bool success = studentService.DeleteClass(className, subject, year);

            if (success)
            {
                // Updates the labels with the last deleted class information

                LblClassNameLast.Text = className;
                LblSubjectLast.Text = subject;
                LblYearLast.Text = year;

                // Clears the text boxes
                TxtClassNameDelete.Clear();
                TxtSubjectDelete.Clear();
                TxtYearDelete.Clear();
            }

            else
            {
                // If the deletion fails, resets the labels to default values

                LblYearLast.Text = "Year";
                LblSubjectLast.Text = "Subject";
                LblClassNameLast.Text = "Class Name";

            }
        }

        private void BtnSaveAdd_Click(object sender, EventArgs e)
        {
            // Gets the values from the text boxes

            string className = TxtClassNameAdd.Text.Trim();
            string subject = TxtStudentNameAdd.Text.Trim();
            string year = TxtStudentIDAdd.Text.Trim();

            // Creates an instance of the StudentManagementService
            var studentService = new StudentManagementService();

            bool success = studentService.AddStudent(className, subject, year);

            if (success)
            {
                // Updates the labels with the last added student information
                LblClassNameAddLast.Text = className;
                LblStudentNameAddLast.Text = subject;
                LblStudentIDAddLast.Text = year;

                // Clears the text boxes
                TxtClassNameAdd.Clear();
                TxtStudentNameAdd.Clear();
                TxtStudentIDAdd.Clear();
            }
            else
            { 
                // If the addition fails, resets the labels to default values
                LblClassNameAddLast.Text = "Class Name";
                LblStudentNameAddLast.Text = "Subject";
                LblStudentIDAddLast.Text = "Year";

               
            }
        }

        private void BtnSaveRemove_Click(object sender, EventArgs e)
        {
            // Gets the values from the text boxes

            string className = TxtClassNameRemove.Text.Trim();
            string studentId = TxtStudentIDRemove.Text.Trim();
            string studentName = TxtStudentNameRemove.Text.Trim();

            // Creates an instance of the StudentManagementService
            var studentService = new StudentManagementService();

            bool success = studentService.RemoveStudent(className, studentName, studentId);

            if (success)

            {
                // Updates the labels with the last removed student information

                LblClassNameRemovedLast.Text = className;
                LblStudentNameRemovedLast.Text = studentName;
                LblStudentIDRemovedLast.Text = studentId;

                // Clears the text boxes 
                TxtClassNameRemove.Clear();
                TxtStudentNameRemove.Clear();
                TxtStudentIDRemove.Clear();
            }
            else
            {
                // If the removal fails, resets the labels to default values

                LblClassNameRemovedLast.Text = "Class Name";
                LblStudentNameRemovedLast.Text = "Student Name";
                LblStudentIDRemovedLast.Text = "Student ID";


            }
        }
    }
}
    
