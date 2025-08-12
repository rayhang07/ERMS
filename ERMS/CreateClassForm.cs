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

            // Creates a list of labels
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
            //draws labels around the labels
            LineDrawer.DrawLinesAroundLabels(this, e, myLabels);
        }

        private void BtnSaveCreate_Click(object sender, EventArgs e)
        {
            string className = TxtClassNameCreate.Text.Trim();
            string subject = TxtSubjectCreate.Text.Trim();
            string year = TxtYearCreate.Text.Trim();

            var studentService = new StudentManagementService();
            int currentUserId = CurrentUser.UserId;

            bool success = studentService.AddClass(className, subject, year, currentUserId);
            if (success)
            {
                LblClassNameLast.Text = className;
                LblSubjectLast.Text = subject;
                LblYearLast.Text = year;

                TxtClassNameCreate.Clear();
                TxtSubjectCreate.Clear();
                TxtYearCreate.Clear();

            }
            else
            {
                LblClassNameLast.Text = "Class Name";
                LblSubjectLast.Text = "Subject";
                LblYearLast.Text = "Year";
            }
        }

        private void BtnSaveAdd_Click(object sender, EventArgs e)
        {
            string className = TxtClassNameAdd.Text.Trim();
            string studentId = TxtStudentIDAdd.Text.Trim();
            string studentName = TxtStudentNameAdd.Text.Trim();

            var studentService = new StudentManagementService();

            bool success = studentService.AddStudent(className, studentName, studentId);

            if (success)
            {
                LblClassNameAddLast.Text = className;
                LblStudentIDAddLast.Text = studentId;
                LblStudentNameAddLast.Text = studentName;

                TxtStudentIDAdd.Clear();
                TxtStudentNameAdd.Clear();
                TxtClassNameAdd.Clear();
            }
            else
            {
                LblClassNameAddLast.Text = "Class Name";
                LblStudentIDAddLast.Text = "Student ID";
                LblStudentNameAddLast.Text = "Student Name";
            }



        }

        private void BtnSaveRemove_Click(object sender, EventArgs e)
        {
            string className = TxtClassNameRemove.Text.Trim();
            string studentName = TxtStudentNameRemove.Text.Trim();
            string studentId = TxtStudentIDRemove.Text.Trim();

            var studentService = new StudentManagementService();

            bool success = studentService.RemoveStudent(className, studentName, studentId);

            if (success)
            {
                LblClassNameRemovedLast.Text = className;
                LblStudentNameRemovedLast.Text = studentName;
                LblStudentIDRemovedLast.Text = studentId;

                TxtClassNameRemove.Clear();
                TxtStudentNameRemove.Clear();
                TxtStudentIDRemove.Clear();
            }
            else
            {
                LblClassNameRemovedLast.Text = "Class Name";
                LblStudentNameRemovedLast.Text = "Student Name";
                LblStudentIDRemovedLast.Text = "Student ID";
            }
        }

       

    }
}