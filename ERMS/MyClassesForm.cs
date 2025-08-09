using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERMS
{
    public partial class MyClassesForm : Form
    {
        private int currentUserId = CurrentUser.UserId;
        private UserRegistrationService userRegService;

        public MyClassesForm()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
            userRegService = new UserRegistrationService(dbPath);


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

            DgvMyClasses.EnableHeadersVisualStyles = false;
            DgvMyClasses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128, 64, 0);
            DgvMyClasses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DgvMyClasses.DefaultCellStyle.BackColor = Color.White;
            DgvMyClasses.DefaultCellStyle.ForeColor = Color.Black;

            LoadUserClasses();
            LoadUserSubjects();

            // Optionally load all students for this user initially (no filter)
            LoadStudents("", "", "");
        }



        private void LoadUserClasses()
        {
            using (var conn = userRegService.GetOpenConnection())
            {
                if (conn == null)
                {
                    MessageBox.Show("Failed to connect to the database.");
                    return;
                }

                string query = "SELECT DISTINCT ClassName FROM Class WHERE UserID = ?";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", currentUserId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        CmbSelectClass.Items.Clear();
                        CmbSelectClass.Items.Add(""); // allow empty selection
                        while (reader.Read())
                        {
                            CmbSelectClass.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private void LoadUserSubjects()
        {
            using (var conn = userRegService.GetOpenConnection())
            {
                if (conn == null)
                {
                    MessageBox.Show("Failed to connect to the database.");
                    return;
                }

                string query = "SELECT DISTINCT Subject FROM Class WHERE UserID = ?";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", currentUserId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        CmbSelectSubject.Items.Clear();
                        CmbSelectSubject.Items.Add(""); // Allow empty selection
                        while (reader.Read())
                        {
                            CmbSelectSubject.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }



        private void LoadStudents(string className, string subject, string studentName)
        {
            using (var conn = userRegService.GetOpenConnection())
            {
                if (conn == null)
                {
                    MessageBox.Show("Failed to connect to the database.");
                    return;
                }

                // Base query joining Students, StudentClasses, and Class with proper parentheses
                string query = @"
            SELECT s.StudentName, s.StudentID, c.ClassName, c.Subject, c.ClassYear
            FROM (Students s
            INNER JOIN StudentClasses sc ON s.StudentID = sc.StudentID)
            INNER JOIN Class c ON sc.ClassID = c.ClassID
            WHERE c.UserID = ?";

                var parameters = new List<OleDbParameter> { new OleDbParameter("UserID", currentUserId) };

                if (!string.IsNullOrWhiteSpace(className))
                {
                    query += " AND c.ClassName = ?";
                    parameters.Add(new OleDbParameter("ClassName", className));
                }

                if (!string.IsNullOrWhiteSpace(subject))
                {
                    query += " AND c.Subject = ?";
                    parameters.Add(new OleDbParameter("Subject", subject));
                }

                if (!string.IsNullOrWhiteSpace(studentName))
                {
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
                        query += " AND s.StudentName LIKE ?";
                        parameters.Add(new OleDbParameter("StudentName", $"%{studentName}%"));
                    }
                }

                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());

                    using (var reader = cmd.ExecuteReader())
                    {
                        DgvMyClasses.Rows.Clear();

                        while (reader.Read())
                        {
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

            if (string.IsNullOrWhiteSpace(studentSearch))
            {
                Sound.PlayError();
                MessageBox.Show("Please enter a student name to search.");
                return;
            }

            if (!Regex.IsMatch(studentSearch, @"^[A-Za-z\s\-]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Student name can only contain letters, spaces, and hyphens.");
                return;
            }

            string selectedClass = CmbSelectClass.SelectedItem?.ToString() ?? "";
            string selectedSubject = CmbSelectSubject.SelectedItem?.ToString() ?? "";

            // Filter by class, subject and student name
            LoadStudents(selectedClass, selectedSubject, studentSearch);
        }
    }

}
