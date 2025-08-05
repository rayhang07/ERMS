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
            LineDrawer.DrawLinesAroundLabels(this, e, myLabels);
        }
    }
}
    
