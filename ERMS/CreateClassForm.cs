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

            LineDrawer.DrawLinesAroundLabels(this, e, myLabels);
        }

    }
}
