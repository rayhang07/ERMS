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
    public partial class ExamResultsForm : Form
    {
        public ExamResultsForm()
        {
            InitializeComponent();
            this.Resize += (s, e) => this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            List<System.Windows.Forms.Label> myLabels = new List<System.Windows.Forms.Label>
            {
                LblLastAssessmentCreated,
                LblClassNameLast,
                LblSubjectLast,
                LblYearLast,
                LblAssessmentNameLast,
                LblLastResultAdded,
                LblStudentNameAddLast,
                LblStudentIDAddLast,
                LblAssessmentNameAddLast,
                LblScoreAddLast,
                LblGradeAddLast,
                LblLastResultRemoved,
                LblStudentNameRemovedLast,
                LblStudentIDRemovedLast,
                LblAssessmentNameRemovedLast,
                LblScoreRemovedLast,
                LblGradeRemovedLast,



            };
            LineDrawer.DrawLinesAroundLabels(this, e, myLabels);
        }

        private void BtnSaveCreate_Click(object sender, EventArgs e)
        {
            // Gets the values from the text boxes
            string className = TxtClassNameCreate.Text.Trim();
            string subject = TxtSubjectCreate.Text.Trim();
            string year = TxtYearCreate.Text.Trim();
            string assessmentName = TxtAssessmentNameCreate.Text.Trim();
            string date = TxtDateCreate.Text.Trim();


            // Creates an instance of the ExamResultsManagementService
            var examService = new ExamResultsManagementService();

            bool success = examService.CreateAssessment(className, subject, year, assessmentName, date);

            if (success)
            {
                // Updates the labels with the last added assessment information
                LblClassNameLast.Text = className;
                LblSubjectLast.Text = subject;
                LblYearLast.Text = year;
                LblAssessmentNameLast.Text = assessmentName;
                LblDateLast.Text = date;


                // Clears the text boxes
                TxtClassNameCreate.Clear();
                TxtSubjectCreate.Clear();
                TxtYearCreate.Clear();
                TxtAssessmentNameCreate.Clear();
                TxtDateCreate.Clear();



            }
            else
            {
                // If the addition fails, resets the labels to default values
                LblClassNameLast.Text = "Class Name";
                LblSubjectLast.Text = "Subject";
                LblYearLast.Text = "Year";
                LblAssessmentNameLast.Text = "Assessment Name";
                LblDateLast.Text = "Date";

            }
        }

        private void BtnSaveAdd_Click(object sender, EventArgs e)
        {
            // Gets the values from the text boxes
            string studentName = TxtStudentNameAdd.Text.Trim();
            string studentId = TxtStudentIDAdd.Text.Trim();
            string className = TxtClassNameAdd.Text.Trim();
            string assessmentName = TxtAssessmentNameAdd.Text.Trim();
            string score = TxtScoreAdd.Text.Trim();
            string grade = TxtGradeAdd.Text.Trim();


            // Creates an instance of the ExamResultsManagementService
            var examService = new ExamResultsManagementService();

            bool success = examService.AddResult(studentName, studentId, className, assessmentName, score, grade);

            if (success)
            {
                // Updates the labels with the last added students information
                LblStudentNameAddLast.Text = studentName;
                LblStudentIDAddLast.Text = studentId;
                LblClassNameAddLast.Text = className;
                LblAssessmentNameAddLast.Text = assessmentName;
                LblScoreAddLast.Text = score;
                LblGradeAddLast.Text = grade;


                // clears textboxes
                TxtStudentNameAdd.Clear();
                TxtStudentIDAdd.Clear();
                TxtClassNameAdd.Clear();
                TxtAssessmentNameAdd.Clear();
                TxtScoreAdd.Clear();
                TxtGradeAdd.Clear();
            }
            else
            {
                // If the addition fails, resets the labels to default values
                LblStudentNameAddLast.Text = "Student Name";
                LblStudentIDAddLast.Text = "Student ID";
                LblClassNameAddLast.Text = "Class Name";
                LblAssessmentNameAddLast.Text = "Assessment Name";
                LblScoreAddLast.Text = "Score";
                LblGradeAddLast.Text = "Grade";
            }
        }

        private void BtnSaveRemove_Click(object sender, EventArgs e)
        {
            // Gets the values from the text boxes
            string studentName = TxtStudentNameRemove.Text.Trim();
            string studentId = TxtStudentIDRemove.Text.Trim();
            string className = TxtClassNameRemove.Text.Trim();
            string assessmentName = TxtAssessmentNameRemove.Text.Trim();
            string score = TxtScoreRemove.Text.Trim();
            string grade = TxtGradeRemove.Text.Trim();

            // Creates an instance of the ExamResultsManagementService
            var examService = new ExamResultsManagementService();

            bool success = examService.RemoveResult(studentName, studentId, className, assessmentName, score, grade);

            if (success)
            {
                // Updates the labels with the last removed students information
                LblStudentNameRemovedLast.Text = studentName;
                LblStudentIDRemovedLast.Text = studentId;
                LblClassNameRemovedLast.Text = className;
                LblAssessmentNameRemovedLast.Text = assessmentName;
                LblScoreRemovedLast.Text = score;
                LblGradeRemovedLast.Text = grade;

                // Clears texboxes
                TxtStudentNameRemove.Clear();
                TxtStudentIDRemove.Clear();
                TxtClassNameRemove.Clear();
                TxtAssessmentNameRemove.Clear();
                TxtScoreRemove.Clear();
                TxtGradeRemove.Clear();
            }
            else
            {
                // If the removal fails, resets the labels to default values
                LblStudentNameRemovedLast.Text = "Student Name";
                LblStudentIDRemovedLast.Text = "Student ID";
                LblClassNameRemovedLast.Text = "Class Name";
                LblAssessmentNameRemovedLast.Text = "Assessment Name";
                LblScoreRemovedLast.Text = "Score";
                LblGradeRemovedLast.Text = "Grade";
            }
        }
    }
}