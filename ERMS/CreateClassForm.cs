using iText.Layout.Element;
using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERMS
{
    public partial class CreateClassForm : Form
    {
        public CreateClassForm()
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
                LblLastClassCreated,
                LblClassNameLast,
                LblSubjectLast,
                LblYearLast,
                LblLastStudentAdded,
                LblClassNameAddLast,
                LblStudentIDAddLast,
                LblStudentNameAddLast,
                LblLastStudentRemoved,
                LblClassNameRemovedLast,
                LblStudentNameRemovedLast,
                LblStudentIDRemovedLast


             };

            // Calls the method to draw lines above and below the group of labels
            LineDrawer.DrawLinesAroundLabels(this, e, myLabels);
        }

        private void BtnSaveCreate_Click(object sender, EventArgs e)
        {
            // Gets the values from the text boxes
            string className = TxtClassNameCreate.Text.Trim();
            string subject = TxtSubjectCreate.Text.Trim();
            string year = TxtYearCreate.Text.Trim();

            // Creates an instance of the StudentResultsManagementService
            var studentService = new StudentManagementService();
            int currentUserId = CurrentUser.UserId;

            bool success = studentService.AddClass(className, subject, year, currentUserId);
            if (success)
            {
                // Updates the labels with the last created class information
                LblClassNameLast.Text = className;
                LblSubjectLast.Text = subject;
                LblYearLast.Text = year;

                // Clears the text boxes
                TxtClassNameCreate.Clear();
                TxtSubjectCreate.Clear();
                TxtYearCreate.Clear();

            }
            else
            {
                // If the addition fails, resets the labels to default values
                LblClassNameLast.Text = "Class Name";
                LblSubjectLast.Text = "Subject";
                LblYearLast.Text = "Year";
            }
        }

        private void BtnSaveAdd_Click(object sender, EventArgs e)
        {
            // Gets the values from the text boxes
            string className = TxtClassNameAdd.Text.Trim();
            string studentId = TxtStudentIDAdd.Text.Trim();
            string studentName = TxtStudentNameAdd.Text.Trim();


            // Creates an instance of the StudentResultsManagementService
            var studentService = new StudentManagementService();

            bool success = studentService.AddStudent(className, studentName, studentId);

            if (success)
            {
                // Updates the labels with the last added students information
                LblClassNameAddLast.Text = className;
                LblStudentIDAddLast.Text = studentId;
                LblStudentNameAddLast.Text = studentName;

                // Clears the text boxes
                TxtStudentIDAdd.Clear();
                TxtStudentNameAdd.Clear();
                TxtClassNameAdd.Clear();
            }
            else
            {
                // If the addition fails, resets the labels to default values
                LblClassNameAddLast.Text = "Class Name";
                LblStudentIDAddLast.Text = "Student ID";
                LblStudentNameAddLast.Text = "Student Name";
            }



        }

        private void BtnSaveRemove_Click(object sender, EventArgs e)
        {
            // Gets the values from the text boxes
            string className = TxtClassNameRemove.Text.Trim();
            string studentName = TxtStudentNameRemove.Text.Trim();
            string studentId = TxtStudentIDRemove.Text.Trim();

            // Creates an instance of the StudentResultsManagementService
            var studentService = new StudentManagementService();

            bool success = studentService.RemoveStudent(className, studentName, studentId);

            if (success)
            {
                // Updates the labels with the last removed students information
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
                // If the remove fails, resets the labels to default values
                LblClassNameRemovedLast.Text = "Class Name";
                LblStudentNameRemovedLast.Text = "Student Name";
                LblStudentIDRemovedLast.Text = "Student ID";
            }
        }

       

    }
}