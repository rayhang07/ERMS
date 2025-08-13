using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERMS
{
    public partial class MyClassesForm : Form
    {
        
        // Stores the current user ID for filtering classes and students 
        private int currentUserId = CurrentUser.UserId;

        // Service to handle user registration and database operations
        private UserRegistrationService userRegistrationService;

        public MyClassesForm()
        {
            this.Resize += resize;
            InitializeComponent();

            // Initialize the user registration service with the database path
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
            userRegistrationService = new UserRegistrationService(dbPath);


        }

        private void MyClassesForm_Load(object sender, EventArgs e)
        {
            // Setup DataGridView columns and styles
            DgvMyClasses.Columns.Clear();
            DgvMyClasses.Columns.Add("StudentName", "Student Name");
            DgvMyClasses.Columns.Add("StudentID", "Student ID");
            DgvMyClasses.Columns.Add("ClassName", "Class Name");
            DgvMyClasses.Columns.Add("Subject", "Subject");
            DgvMyClasses.Columns.Add("Year", "Year");

            DgvMyClasses.AutoGenerateColumns = false;

            // Set column widths
            DgvMyClasses.EnableHeadersVisualStyles = false;

            // Set header styles
            DgvMyClasses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128, 64, 0);

            // Set header text color
            DgvMyClasses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Set default cell styles
            DgvMyClasses.DefaultCellStyle.BackColor = Color.White;
            DgvMyClasses.DefaultCellStyle.ForeColor = Color.Black;
            DgvMyClasses.ColumnHeadersDefaultCellStyle.Font =
            new Font(DgvMyClasses.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            // Load user classes and subjects into combo boxes
            LoadUserClasses();
            LoadUserSubjects();

            // Load all students for this user initially without any filter
            LoadStudents("", "", "");

            DgvMyClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int colCount = DgvMyClasses.Columns.Count;
            foreach (DataGridViewColumn col in DgvMyClasses.Columns)
            {
                col.FillWeight = 100f / colCount;
            }
        }


        private void resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Calculate 60% size
                int newWidth = (int)(this.ClientSize.Width * 0.6);
                int newHeight = (int)(this.ClientSize.Height * 0.6);

                // Set DataGridView size
                DgvMyClasses.Size = new Size(newWidth, newHeight);

                // Center the DataGridView
                DgvMyClasses.Location = new Point(
                    (this.ClientSize.Width - DgvMyClasses.Width) / 2,
                    (this.ClientSize.Height - DgvMyClasses.Height) / 2
                );
            }
        }


        private void LoadUserClasses()
        {
            using (var conn = userRegistrationService.GetOpenConnection())
            {
                if (conn == null)
                {
                    Sound.PlayError();
                    MessageBox.Show("Failed to connect to the database.");
                    return;
                }

                // Query to get distinct class names for the current user
                string query = "SELECT DISTINCT ClassName FROM Class WHERE UserID = ?";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    // Add the current user ID as a parameter to the query
                    cmd.Parameters.AddWithValue("?", currentUserId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        CmbSelectClass.Items.Clear();

                        // allow empty selection
                        CmbSelectClass.Items.Add("Select Class"); 
                        while (reader.Read())
                        {
                            // Add each class name to the combo box
                            CmbSelectClass.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private void LoadUserSubjects()
        {
            using (var conn = userRegistrationService.GetOpenConnection())
            {
                if (conn == null)
                {
                    Sound.PlayError();
                    MessageBox.Show("Failed to connect to the database.");
                    return;
                }

                // Query to get distinct subjects for the current user's classes
                string query = "SELECT DISTINCT Subject FROM Class WHERE UserID = ?";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", currentUserId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        CmbSelectSubject.Items.Clear();

                        // Allow empty selection
                        CmbSelectSubject.Items.Add("Select Subject"); 
                        while (reader.Read())
                        {
                            // Add each subject to the combo box
                            CmbSelectSubject.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }



        private void LoadStudents(string className, string subject, string studentName)
        {
            using (var conn = userRegistrationService.GetOpenConnection())
            {
                if (conn == null)
                {
                    Sound.PlayError();
                    MessageBox.Show("Failed to connect to the database.");
                    return;
                }

                // Base query joining Students, StudentClasses, and Class 
                string query = @"
                SELECT s.StudentName, s.StudentID, c.ClassName, c.Subject, c.ClassYear
                FROM (Students s
                INNER JOIN StudentClasses sc ON s.StudentID = sc.StudentID)
                INNER JOIN Class c ON sc.ClassID = c.ClassID
                WHERE c.UserID = ?";

                // Prepare parameters for the query
                var parameters = new List<OleDbParameter> { new OleDbParameter("UserID", currentUserId) };

                if (!string.IsNullOrWhiteSpace(className))
                {
                    // If class name is provided, filter by class
                    query += " AND c.ClassName = ?";
                    parameters.Add(new OleDbParameter("ClassName", className));
                }

                if (!string.IsNullOrWhiteSpace(subject))
                {
                    // If subject is provided, filter by subject
                    query += " AND c.Subject = ?";
                    parameters.Add(new OleDbParameter("Subject", subject));
                }

                if (!string.IsNullOrWhiteSpace(studentName))
                {
                    // If student name is provided, filter by student name
                    if (string.IsNullOrWhiteSpace(className) && string.IsNullOrWhiteSpace(subject))
                    {
                        // If no class or subject filter, search across all classes for student name
                        query = @"
                    SELECT s.StudentName, s.StudentID, c.ClassName, c.Subject, c.ClassYear
                    FROM (Students s
                    INNER JOIN StudentClasses sc ON s.StudentID = sc.StudentID)
                    INNER JOIN Class c ON sc.ClassID = c.ClassID
                    WHERE c.UserID = ? AND s.StudentName LIKE ?";
                        parameters.Clear();
                        parameters.Add(new OleDbParameter("UserID", currentUserId));
                        parameters.Add(new OleDbParameter("StudentName", $"%{studentName}%"));
                    }
                    else
                    {
                        // If class or subject filter is applied, search within those filters
                        query += " AND s.StudentName LIKE ?";
                        parameters.Add(new OleDbParameter("StudentName", $"%{studentName}%"));
                    }
                }

                using (var cmd = new OleDbCommand(query, conn))
                {

                    // Add the user ID parameter first
                    cmd.Parameters.AddRange(parameters.ToArray());

                    using (var reader = cmd.ExecuteReader())
                    {
                        DgvMyClasses.Rows.Clear();

                        // Read the results and populate the DataGridView
                        while (reader.Read())
                        {
                            // Add each student to the DataGridView
                            DgvMyClasses.Rows.Add(
                                reader["StudentName"].ToString(),
                                reader["StudentID"].ToString(),
                                reader["ClassName"].ToString(),
                                reader["Subject"].ToString(),
                                reader["ClassYear"].ToString()
                            );
                        }
                    }
                }
            }
        }




        private void CmbSelectClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedClass = CmbSelectClass.SelectedItem?.ToString() ?? "";
            string selectedSubject = CmbSelectSubject.SelectedItem?.ToString() ?? "";

            // Update students grid filtering by class and subject only
            LoadStudents(selectedClass, selectedSubject, "");
        }

        private void CmbSelectSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedClass = CmbSelectClass.SelectedItem?.ToString() ?? "";
            string selectedSubject = CmbSelectSubject.SelectedItem?.ToString() ?? "";

            // Update students grid filtering by class and subject only
            LoadStudents(selectedClass, selectedSubject, "");
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string studentSearch = TxtSearch.Text.Trim();

            // Validate the student search input
            if (string.IsNullOrWhiteSpace(studentSearch))
            {
                Sound.PlayError();
                MessageBox.Show("Please enter a student name to search.");
                return;
            }

            // Check if the student name contains only valid characters (letters, spaces, hyphens)
            if (!Regex.IsMatch(studentSearch, @"^[A-Za-z\s\-]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Student name can only contain letters, spaces, and hyphens.");
                return;
            }

            string selectedClass = CmbSelectClass.SelectedItem?.ToString() ?? "";
            string selectedSubject = CmbSelectSubject.SelectedItem?.ToString() ?? "";

            // Check if student exists in the Students table
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
            var userRegService = new UserRegistrationService(dbPath);

            using (var conn = userRegService.GetOpenConnection())
            {
                if (conn == null)
                {
                    Sound.PlayError();
                    MessageBox.Show("Failed to connect to the database.");
                    return;
                }

                string checkStudentQuery = "SELECT COUNT(*) FROM Students WHERE StudentName = ?";
                using (var cmd = new OleDbCommand(checkStudentQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", studentSearch);

                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        Sound.PlayError();
                        MessageBox.Show("Student does not exist.");
                        return;
                    }
                }
            }

            // If student exists, proceed with loading students
            LoadStudents(selectedClass, selectedSubject, studentSearch);
        }

    }

}
