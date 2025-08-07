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
    public partial class DashboardForm : Form
    {
        // List to hold references to labels around which lines will be drawn
        private List<System.Windows.Forms.Label> myLabels;

        // Reference to main application form
        private MainApplicationForm mainAppForm;


        public DashboardForm()
        {
            InitializeComponent();


            this.Resize += (s, e) => this.Invalidate();
        }

        // Override the OnPaint method to draw custom graphics (lines) around labels
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Initialize the list of labels to include all labels that need lines drawn around them
            List<System.Windows.Forms.Label> myLabels = new List<System.Windows.Forms.Label>
            {
                LblImportantDates,
                LblExamDate1,
                LblExamDate2,
                LblTopClasses,
                LblTopClass1,
                LblTopClass2,
                LblTopPerformers,
                LblTopPerformer1,
                LblTopPerformer2
            };

            // Call the helper method to draw lines above and below the group of labels
            LineDrawer.DrawLinesAroundLabels(this, e, myLabels);
        }


        
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LblWelcomeBackMessage.Text = $"Welcome back {CurrentUser.FullName}";
            LblWelcomeBackMessage.Left = (this.ClientSize.Width - LblWelcomeBackMessage.Width) / 2;
            // Display the current date in the LblDateTime label as a long date string
            LblDateTime.Text = DateTime.Now.ToString("D");

            // Center the LblDateTime label horizontally within the form's client area
            LblDateTime.Left = (this.ClientSize.Width - LblDateTime.Width) / 2;
        }
        
    }
    // Static helper class  for drawing lines around a list of labels so can be inherited
    public static class LineDrawer
    {
        // Method to draw two horizontal lines above and below the group of labels passed in
        public static void DrawLinesAroundLabels(Control container, PaintEventArgs e, List<System.Windows.Forms.Label> labels)

        {   
            // If the label list is null or empty, nothing to draw
            if (labels == null || labels.Count == 0)
                return;

            // Initialize variables to find the bounding rectangle around all labels
            int left = int.MaxValue;
            int right = int.MinValue;
            int top = int.MaxValue;
            int bottom = int.MinValue;

            // Calculate the outer bounds of all labels
            foreach (var lbl in labels)
            {
                if (lbl.Left < left) left = lbl.Left;
                if (lbl.Right > right) right = lbl.Right;
                if (lbl.Top < top) top = lbl.Top;
                if (lbl.Bottom > bottom) bottom = lbl.Bottom;
            }

            // Get the top level parent form (MainApplicatinForm) that contains this control
            var parent = container.TopLevelControl as Form;

            // Check if the parent form is fullscreened
            bool isParentMaximized = parent != null && parent.WindowState == FormWindowState.Maximized;

            int formWidth = container.ClientSize.Width;

            int startX, endX;

            if (isParentMaximized)
            {
                // If fullscreen, draw the lines to be 60% of the form width and centered horizontally
                int lineLength = (int)(formWidth * 0.6);
                startX = (formWidth - lineLength) / 2;
                endX = startX + lineLength;
            }
            else
            {
                // Otherwise, draw lines exactly spanning the leftmost to rightmost label edges
                startX = left;
                endX = right;
            }

            int lineThickness = 3;
            int padding = 5;

            int yAbove = top - padding - lineThickness / 2;
            int yBelow = bottom + padding + lineThickness / 2;

            using (Pen pen = new Pen(Color.Black, lineThickness))
            {
                e.Graphics.DrawLine(pen, startX, yAbove, endX, yAbove);
                e.Graphics.DrawLine(pen, startX, yBelow, endX, yBelow);
            }
        }
    }

}



