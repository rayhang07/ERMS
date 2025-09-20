using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;


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

            // Initialise the list of labels to include all labels that need lines drawn around them
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

            // Call the method to draw lines above and below the group of labels
            LineDrawer.DrawLinesAroundLabels(this, e, myLabels);
        }



        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Presents a welcome back message with the users fullname
            LblWelcomeBackMessage.Text = $"Welcome back {CurrentUser.FullName}";

            // Center the LblWelcomeBackMessage label horizontally 
            LblWelcomeBackMessage.Left = (this.ClientSize.Width - LblWelcomeBackMessage.Width) / 2;

            // Display the current date in the LblDateTime label as a long date string
            LblDateTime.Text = DateTime.Now.ToString("D");

            // Center the LblDateTime label horizontally within the form's client area
            LblDateTime.Left = (this.ClientSize.Width - LblDateTime.Width) / 2;

            PbLogo.Left = (this.ClientSize.Width - PbLogo.Width) / 2;

            LoadDashboardSummary();
        }
        private void LoadDashboardSummary()
        {
            LoadUpcomingAssessments();
            LoadTopClasses();
            LoadTopStudents();
        }

        private void LoadTopClasses()
        {
            int currentUserId = CurrentUser.UserId;

            // Get all class names for this user
            List<string> myClasses = GetMyClasses(currentUserId);

            // Get all rankings
            DataTable classRankings = RankingService.GetClassRankings();

            // Filter rankings to only classes that belong to the current user
            var filteredRows = classRankings.AsEnumerable()
                .Where(row => myClasses.Contains(row["Class"].ToString()))
                .ToList();

            // Append the class names to the labels
            if (filteredRows.Count > 0)
                LblTopClass1.Text = filteredRows[0]["Class"].ToString();

            if (filteredRows.Count > 1)
                LblTopClass2.Text = filteredRows[1]["Class"].ToString();
        }

        private void LoadTopStudents()
        {
            int currentUserId = CurrentUser.UserId;

            // Get all student names for this user
            List<string> myStudents = GetMyStudents(currentUserId);

            // Get all student rankings
            DataTable studentRankings = RankingService.GetStudentRankings();

            // Filter rankings to only students that belong to the current user
            var filteredRows = studentRankings.AsEnumerable()
                .Where(row => myStudents.Contains(row["Student"].ToString()))
                .ToList();

            // Append the student names to the labels
            if (filteredRows.Count > 0)
                LblTopPerformer1.Text = filteredRows[0]["Student"].ToString();

            if (filteredRows.Count > 1)
                LblTopPerformer2.Text = filteredRows[1]["Student"].ToString();
        }

        private void LoadUpcomingAssessments()
        {
            // Gets current users ID 
            int currentUserId = CurrentUser.UserId;

            // Create an instance of ExamResultsManagementService to access exam data
            var erms = new ExamResultsManagementService();

            // Get the top upcoming assessments for the current user
            var examDates = erms.GetTopUpcomingAssessments(currentUserId);

            DataTable studentRankings = RankingService.GetStudentRankings();

            // Appends the exam date and the assessment name to the labels
            if (examDates.Count > 0)
                LblExamDate1.Text = $"{examDates[0].AssessmentName} - {DateTime.Parse(examDates[0].AssessmentDate):dd/MM/yyyy}";
            if (examDates.Count > 1)
                LblExamDate2.Text = $"{examDates[1].AssessmentName} - {DateTime.Parse(examDates[1].AssessmentDate):dd/MM/yyyy}";
        }

        private List<string> GetMyClasses(int currentUserId)
        {
            // Gets the path to the database file
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");

            // Creates an instance of UserRegistrationService to access user data
            var userRegistrationService = new UserRegistrationService(dbPath);

            // Initialises a list to hold class names
            var classes = new List<string>();
            using (var conn = userRegistrationService.GetOpenConnection())
            {
                if (conn == null)
                {
                    Sound.PlayError();
                    MessageBox.Show("Failed to connect to the database.");
                    return null;
                }


                // SQL query to get class names for the current user
                string query = "SELECT ClassName FROM Class WHERE UserID = ?";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", currentUserId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            classes.Add(reader["ClassName"].ToString());
                    }
                }
            }
            return classes;
        }

        private List<string> GetMyStudents(int currentUserId)
        {
            // Gets the path to the database file
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");

            // Creates an instance of UserRegistrationService to access user data
            var userRegistrationService = new UserRegistrationService(dbPath);

            // Initialises a list to hold student names
            var students = new List<string>();
            using (var conn = userRegistrationService.GetOpenConnection())
            {
                if (conn == null)
                {
                    Sound.PlayError();
                    MessageBox.Show("Failed to connect to the database.");
                    return null;
                }


                // SQL query to get student names for the current user
                string query = @"
            SELECT DISTINCT Students.StudentName
            FROM (Students
            INNER JOIN StudentClasses 
                ON Students.StudentID = StudentClasses.StudentID)
            INNER JOIN Class 
                ON StudentClasses.ClassID = Class.ClassID
            WHERE Class.UserID = ?";


                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue(" ? ", currentUserId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            students.Add(reader["StudentName"].ToString());
                    }
                }
            }
            return students;
        }

        private void PbLogo_Click(object sender, EventArgs e)
        {

        }
    }
    // Static class for drawing lines around a list of labels so can be inherited
    public static class LineDrawer
    {
        // Method to draw two horizontal lines above and below the group of labels passed in
        public static void DrawLinesAroundLabels(Control container, PaintEventArgs e, List<System.Windows.Forms.Label> labels)

        {   
            // If the label list is null or empty there is nothing to draw
            if (labels == null || labels.Count == 0)
                return;

            // Initialise variables to find the size needed around the labels
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
                // If fullscreen, draw the lines to be 60% of the form width and centered 
                int lineLength = (int)(formWidth * 0.6);
                startX = (formWidth - lineLength) / 2;
                endX = startX + lineLength;
            }
            else
            {
                // Otherwise, draw lines the fill the size that the user has resized to
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



