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
    }

}