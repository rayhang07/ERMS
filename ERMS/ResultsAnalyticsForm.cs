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
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;

namespace ERMS
{
    public partial class ResultsAnalyticsForm : Form
    {
        

        private int currentUserId = CurrentUser.UserId;
        private UserRegistrationService userRegistrationService;
        public ResultsAnalyticsForm()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
            userRegistrationService = new UserRegistrationService(dbPath);
            

        }

        private void ResultsAnalyticsForm_Load(object sender, EventArgs e)
        {



            // Set up the tables columns
            DgvResultsAnalytics.Columns.Clear();
            DgvResultsAnalytics.Columns.Add("StudentName", "Student Name");
            DgvResultsAnalytics.Columns.Add("StudentID", "Student ID");
            DgvResultsAnalytics.Columns.Add("ClassName", "Class Name");
            DgvResultsAnalytics.Columns.Add("Subject", "Subject");
            DgvResultsAnalytics.Columns.Add("Year", "Year");
            DgvResultsAnalytics.Columns.Add("AssessmentName", "Assessment Name");
            DgvResultsAnalytics.Columns.Add("AssessmentDate", "Assesment Date");
            DgvResultsAnalytics.Columns.Add("Result", "Result");
            DgvResultsAnalytics.Columns.Add("Grade", "Grade");

            DgvResultsAnalytics.AutoGenerateColumns = false;
            DgvResultsAnalytics.EnableHeadersVisualStyles = false;
            DgvResultsAnalytics.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128, 64, 0);
            DgvResultsAnalytics.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgvResultsAnalytics.DefaultCellStyle.BackColor = Color.White;
            DgvResultsAnalytics.DefaultCellStyle.ForeColor = Color.Black;
            DgvResultsAnalytics.ColumnHeadersDefaultCellStyle.Font =
            new Font(DgvResultsAnalytics.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            // Show all information in the table by default
            LoadUserClasses();
            LoadUserSubjects("");
            LoadAssessments("", "");
            LoadResults("", "", "", "");
            UpdateGradeDistributionChart();
            UpdatePassFailChart();
            InitializeEmptyStudentProgressionChart();


        }
        private void LoadUserClasses()
        {
            // Establish connection to db
            using (var conn = userRegistrationService.GetOpenConnection())
            {
                if (conn == null)
                {
                    Sound.PlayError();
                    MessageBox.Show("Failed to connect to the database.");
                    return;
                }
                // Load the current users classes
                string query = "SELECT DISTINCT ClassName FROM Class WHERE UserID = ?";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", currentUserId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        CmbSelectClass.Items.Clear();

                        // Allow empty selection
                        CmbSelectClass.Items.Add("Select Class");
                        while (reader.Read())
                        {
                            CmbSelectClass.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }
        private void LoadUserSubjects(string className)
        {

            // Establish connection to db
            using (var conn = userRegistrationService.GetOpenConnection())
            {
                if (conn == null)
                {
                    Sound.PlayError();
                    MessageBox.Show("Failed to connect to the database.");
                    return;
                }

                // Load the current users subjects if class isn't selected
                string query;
                if (string.IsNullOrEmpty(className))
                    query = "SELECT DISTINCT Subject FROM Class WHERE UserID = ?";

                // Load the current users subjects based on the class that is selected
                else
                    query = "SELECT DISTINCT Subject FROM Class WHERE UserID = ? AND ClassName = ?";

                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", currentUserId);
                    if (!string.IsNullOrEmpty(className))
                        cmd.Parameters.AddWithValue("?", className);

                    using (var reader = cmd.ExecuteReader())
                    {
                        CmbSelectSubject.Items.Clear();

                        // Allow empty selection
                        CmbSelectSubject.Items.Add("Select Subject");
                        while (reader.Read())
                        {
                            CmbSelectSubject.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }
        private void UpdateGradeDistributionChart()
        {
            // Set all  grades and colours
            var allGrades = new Dictionary<string, OxyColor>()
    {
        { "A*",OxyColors.DarkGreen },
        { "A", OxyColors.LightGreen },
        { "B", OxyColors.Blue },
        { "C", OxyColors.LightBlue },
        { "D", OxyColors.Purple },
        { "E", OxyColors.Orange },
        { "F", OxyColors.Red }
    };

            // Count total of each grade from DataGridView
            var gradeCounts = allGrades.Keys.ToDictionary(g => g, g => 0);

            foreach (DataGridViewRow row in DgvResultsAnalytics.Rows)
            {
                // Finds new row
                if (row.IsNewRow) continue;

                // Searches the Grade column
                var gradeObj = row.Cells["Grade"].Value;
                if (gradeObj != null)
                {
                    // Gets the grade in that row and converts it to a string
                    string grade = gradeObj.ToString();

                    // Adds one to the count of grades
                    if (gradeCounts.ContainsKey(grade))
                        gradeCounts[grade]++;
                }
            }

            // Creates the model with its title
            var model = new PlotModel { Title = "Grade Distribution" };

            // Sets the legends for the pie chart
            var legend = new Legend
            {
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.RightTop,
                LegendOrientation = LegendOrientation.Vertical,
                LegendBorderThickness = 0
            };

            // Adds the legend to the model
            model.Legends.Add(legend);

            // Creates the pie chart 
            var pieSeries = new PieSeries
            {
                Diameter = 0.6,
                InsideLabelPosition = 0.8,
                StrokeThickness = 0.25,
                AngleSpan = 360,
                StartAngle = 0,
            };

            // Add slices to the pie chart
            foreach (var kvp in gradeCounts)
            {
                if (kvp.Value > 0)
                {
                    pieSeries.Slices.Add(new PieSlice(kvp.Key, kvp.Value)
                    {
                        Fill = allGrades[kvp.Key]
                    });
                }
            }

            model.Series.Add(pieSeries);

            ChtGradeDistribution.Model = model;
        }
        private void UpdatePassFailChart()
        {
            // Initialises variables to track both pass and fail count
            int passCount = 0;
            int failCount = 0;

            // Searches every row in the DataGridView
            foreach (DataGridViewRow row in DgvResultsAnalytics.Rows)
            {
                if (row.IsNewRow) continue;

                // Searches for the value in the Grade column
                var gradeObj = row.Cells["Grade"].Value;
                if (gradeObj != null)
                {
                    // Converts it to a string
                    string grade = gradeObj.ToString();

                    // Increments the fail count if the grade is an F
                    if (grade == "F")
                        failCount++;

                    // Every other grade counts as a pass
                    else
                        passCount++;
                }
            }

            // Instantiates the model with its title
            var model = new PlotModel { Title = "Pass/Fail Rate" };

            // Category axis on X axis
            var categoryAxis = new OxyPlot.Axes.CategoryAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                Key = "CategoryAxis",
                ItemsSource = new[] { "Pass", "Fail" }
            };

            // Linear axis on Y 
            var valueAxis = new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Minimum = 0,
                AbsoluteMinimum = 0
            };

            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);

            // Creates bar for Pass at category index 0
            var passSeries = new RectangleBarSeries
            {
                FillColor = OxyColors.Green,
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };
            passSeries.Items.Add(new RectangleBarItem(0 - 0.3, 0, 0 + 0.3, passCount));

            // Creates bar for Fail at category index 1
            var failSeries = new RectangleBarSeries
            {
                FillColor = OxyColors.Red,
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };
            failSeries.Items.Add(new RectangleBarItem(1 - 0.3, 0, 1 + 0.3, failCount));

            model.Series.Add(passSeries);
            model.Series.Add(failSeries);

            ChtPassFail.Model = model;
        }


        private void UpdateStudentProgressionChart(string className, string subject, string studentName)
        {
            if (string.IsNullOrWhiteSpace(studentName))
            {
                // Clears the chart if there is no student
                ClearChart(ChtStudentProgression);
                return;
            }

            using var conn = userRegistrationService.GetOpenConnection();
            if (conn == null)
            {
                Sound.PlayError();
                MessageBox.Show("Failed to connect to the database.");
                return;
            }

            // Gets the assessment name, date and students score by joining tables.
            string query = @"
        SELECT 
            a.AssessmentName, 
            a.AssessmentDate, 
            r.Score
        FROM 
            ((((Results r
            INNER JOIN Assessments a ON r.AssessmentID = a.AssessmentID)
            INNER JOIN StudentClasses sc ON r.EnrollmentID = sc.EnrollmentID)
            INNER JOIN Students s ON sc.StudentID = s.StudentID)
            INNER JOIN Class c ON sc.ClassID = c.ClassID)
        WHERE 
            s.StudentName = ?";

            var parameters = new List<OleDbParameter> { new OleDbParameter("StudentName", studentName) };

            if (!string.IsNullOrEmpty(className))
            {
                query += " AND c.ClassName = ?";
                parameters.Add(new OleDbParameter("ClassName", className));
            }

            if (!string.IsNullOrEmpty(subject))
            {
                query += " AND c.Subject = ?";
                parameters.Add(new OleDbParameter("Subject", subject));
            }

            query += " ORDER BY a.AssessmentDate";

            using var cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddRange(parameters.ToArray());

            using var reader = cmd.ExecuteReader();

            var plotModel = new PlotModel { Title = $"{studentName}'s Progression" };
            var lineSeries = new LineSeries
            {
                Title = studentName,
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.DarkBlue
            };

            // Assessment names in order
            var assessmentNames = new List<string>();
            var scores = new List<double>();

            while (reader.Read())
            {
                string assessmentName = reader["AssessmentName"].ToString();
                double score = Convert.ToDouble(reader["Score"]);

                // Add Assessment names and scores in order from db
                assessmentNames.Add(assessmentName);
                scores.Add(score);
            }

            // Add assessment names to the CategoryAxis labels
            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Assessment Name"
            };
            categoryAxis.Labels.AddRange(assessmentNames);

            // Add points: X = individual assessment name, Y = score
            for (int i = 0; i < scores.Count; i++)
            {
                lineSeries.Points.Add(new DataPoint(i, scores[i]));
            }

            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = 0,
                Maximum = 100,
                Title = "Score"
            };

            plotModel.Axes.Add(categoryAxis);
            plotModel.Axes.Add(valueAxis);
            plotModel.Series.Add(lineSeries);

            ChtStudentProgression.Model = plotModel;
            ChtStudentProgression.InvalidatePlot(true);

        }

        private void InitializeEmptyStudentProgressionChart()
        {
            var model = new PlotModel { Title = "Student Progression" };

            // Add axes
            model.Axes.Add(new OxyPlot.Axes.CategoryAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                Title = "Assessment Name"
            });

            model.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Title = "Score"
            });

            // No series added so chart is empty
            ChtStudentProgression.Model = model;
            ChtStudentProgression.InvalidatePlot(true);
        }



        private void LoadAssessments(string className, string subject)
        {
            // Establish connection to db
            using (var conn = userRegistrationService.GetOpenConnection())
            {
                if (conn == null)
                {
                    Sound.PlayError();
                    MessageBox.Show("Failed to connect to the database.");
                    return;
                }

                // Query joins Assessments with Class to filter by ClassName and Subject
                string query = @"
            SELECT a.AssessmentName 
            FROM Assessments a
            INNER JOIN Class c ON a.ClassID = c.ClassID
            WHERE c.UserID = ?";

                if (!string.IsNullOrEmpty(className))
                    query += " AND c.ClassName = ?";
                if (!string.IsNullOrEmpty(subject))
                    query += " AND c.Subject = ?";

                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", currentUserId);
                    if (!string.IsNullOrEmpty(className))
                        cmd.Parameters.AddWithValue("?", className);
                    if (!string.IsNullOrEmpty(subject))
                        cmd.Parameters.AddWithValue("?", subject);

                    using (var reader = cmd.ExecuteReader())
                    {
                        CmbSelectAssessment.Items.Clear();

                        // Allow empty selection
                        CmbSelectAssessment.Items.Add("Select Assessment");
                        while (reader.Read())
                        {
                            CmbSelectAssessment.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private void LoadResults(string className, string subject, string assessmentName, string studentName)
        {
            // Establish connection to db
            using (var conn = userRegistrationService.GetOpenConnection())
            {
                // Create query using inner joins
                string query = @"
    SELECT 
        s.[StudentName],
        s.[StudentID],
        c.[ClassName],
        c.[Subject],
        c.[ClassYear],
        a.[AssessmentName],
        a.[AssessmentDate],
        r.[Score],
        r.[Grade]
    FROM 
        (((( [Students] s
        INNER JOIN [StudentClasses] sc ON s.[StudentID] = sc.[StudentID])
        INNER JOIN [Class] c ON sc.[ClassID] = c.[ClassID])
        INNER JOIN [Assessments] a ON a.[ClassID] = c.[ClassID])
        INNER JOIN [Results] r ON r.[EnrollmentID] = sc.[EnrollmentID] AND r.[AssessmentID] = a.[AssessmentID])
    WHERE 
        c.[UserID] = ?";

                // Parameterised queries for safety
                var parameters = new List<OleDbParameter> { new OleDbParameter("UserID", currentUserId) };

                if (!string.IsNullOrEmpty(className))
                {
                    query += " AND c.[ClassName] = ?";
                    parameters.Add(new OleDbParameter("ClassName", className));
                }

                if (!string.IsNullOrEmpty(subject))
                {
                    query += " AND c.[Subject] = ?";
                    parameters.Add(new OleDbParameter("Subject", subject));
                }

                if (!string.IsNullOrEmpty(assessmentName))
                {
                    query += " AND a.[AssessmentName] = ?";
                    parameters.Add(new OleDbParameter("AssessmentName", assessmentName));
                }

                if (!string.IsNullOrWhiteSpace(studentName))
                {
                    query += " AND s.[StudentName] LIKE ?";
                    parameters.Add(new OleDbParameter("StudentName", $"%{studentName}%"));
                }

                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());

                    using (var reader = cmd.ExecuteReader())
                    {
                        DgvResultsAnalytics.Rows.Clear();

                        while (reader.Read())
                        {
                            // Format the assessment date to dd/mm/yyyy
                            string assessmentDateFormatted = Convert.ToDateTime(reader["AssessmentDate"]).ToString("dd/MM/yyyy");
                            DgvResultsAnalytics.Rows.Add(
                                reader["StudentName"].ToString(),
                                reader["StudentID"].ToString(),
                                reader["ClassName"].ToString(),
                                reader["Subject"].ToString(),
                                reader["ClassYear"].ToString(),
                                reader["AssessmentName"].ToString(),
                                assessmentDateFormatted,
                                reader["Score"].ToString(),
                                reader["Grade"].ToString()
                            );
                        }
                    }
                }
            }
        }



        private void ClearChart(PlotView plotView)
        {
            if (plotView.Model != null)
            {
                plotView.Model.Series.Clear();
                plotView.Model.Annotations.Clear();

                // Clear labels on CategoryAxis 
                var categoryAxis = plotView.Model.Axes
                    .OfType<OxyPlot.Axes.CategoryAxis>()
                    .FirstOrDefault();
                if (categoryAxis != null)
                {
                    categoryAxis.Labels.Clear();
                }

                plotView.InvalidatePlot(true);
            }
        }



        private void CmbSelectClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Converts the selection to a string
            string selectedClass = CmbSelectClass.SelectedItem?.ToString() ?? "";
            string selectedSubject = CmbSelectSubject.SelectedItem?.ToString() ?? "";
            string studentName = TxtSearch.Text.Trim();

            // Calls methods that are required
            LoadUserSubjects(selectedClass);
            LoadAssessments(selectedClass, "");
            LoadResults(selectedClass, "", "", "");
            UpdateGradeDistributionChart();
            UpdatePassFailChart();

            if (!string.IsNullOrWhiteSpace(studentName))
            {
                if (!string.IsNullOrEmpty(selectedClass) && string.IsNullOrEmpty(selectedSubject))
                {
                    // Class filter only selected
                    UpdateStudentProgressionChart(selectedClass, "", studentName);
                }
                else if (!string.IsNullOrEmpty(selectedClass) && !string.IsNullOrEmpty(selectedSubject))
                {
                    // Both class and subject selected
                    UpdateStudentProgressionChart(selectedClass, selectedSubject, studentName);
                }
                else
                {
                    // No filters or just student
                    UpdateStudentProgressionChart("", "", studentName);
                }

            }
        }

        private void CmbSelectSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string studentName = TxtSearch.Text.Trim();
            // Converts selections to strings
            string selectedClass = CmbSelectClass.SelectedItem?.ToString() ?? "";
            string selectedSubject = CmbSelectSubject.SelectedItem?.ToString() ?? "";

            // Calls methods that are required
            LoadAssessments(selectedClass, selectedSubject);
            LoadResults(selectedClass, selectedSubject, "", "");
            UpdateGradeDistributionChart();
            UpdatePassFailChart();


            if (!string.IsNullOrWhiteSpace(studentName))
            {
                if (!string.IsNullOrEmpty(selectedSubject) && string.IsNullOrEmpty(selectedClass))
                {
                    // Only subject is selected
                    // Call your progression update with only subject filter
                    UpdateStudentProgressionChart("", selectedSubject, studentName);
                }
                else if (!string.IsNullOrEmpty(selectedClass))
                {
                    // Class is selected (with or without subject)
                    UpdateStudentProgressionChart(selectedClass, selectedSubject, studentName);
                }
                else
                {
                    // Neither class nor subject selected, show all progression for student
                    UpdateStudentProgressionChart("", "", studentName);
                }
            }

        }

        private void CmbSelectAssessment_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Converts selection to a string
            string selectedClass = CmbSelectClass.SelectedItem?.ToString() ?? "";
            string selectedSubject = CmbSelectSubject.SelectedItem?.ToString() ?? "";
            string selectedAssessment = CmbSelectAssessment.SelectedItem?.ToString() ?? "";

            // calls methods that are required
            LoadResults(selectedClass, selectedSubject, selectedAssessment, "");
            UpdateGradeDistributionChart();
            UpdatePassFailChart();

        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            // Stores input as a variable
            string studentSearch = TxtSearch.Text.Trim();


            // Validate input: can't be empty
            if (string.IsNullOrWhiteSpace(studentSearch))
            {
                Sound.PlayError();
                MessageBox.Show("Please enter a student name to search.");
                return;
            }

            // Validate input: can only contain letters, spaces, hyphens
            if (!Regex.IsMatch(studentSearch, @"^[A-Za-z\s\-]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Student name can only contain letters, spaces, and hyphens.");
                return;
            }

            string selectedClass = CmbSelectClass.SelectedItem?.ToString() ?? "";
            string selectedSubject = CmbSelectSubject.SelectedItem?.ToString() ?? "";
            string selectedAssessment = CmbSelectAssessment.SelectedItem?.ToString() ?? "";

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

                    // Displays error if the student doesn't exist
                    if (count == 0)
                    {
                        Sound.PlayError();
                        MessageBox.Show("Student does not exist.");
                        return;
                    }
                }

                string checkAssessmentQuery = @"
                SELECT COUNT(*)
                FROM ((((Results AS r
                INNER JOIN StudentClasses AS sc ON r.EnrollmentID = sc.EnrollmentID)
                INNER JOIN [Class] AS c ON sc.ClassID = c.ClassID)
                INNER JOIN Students AS s ON sc.StudentID = s.StudentID)
                INNER JOIN Assessments AS a ON r.AssessmentID = a.AssessmentID)
                WHERE (s.StudentName = ?) AND (c.ClassName = ?)";

                ;


                using (var cmd = new OleDbCommand(checkAssessmentQuery, conn))
                {
                    cmd.Parameters.AddWithValue(" ? ", studentSearch);
                    cmd.Parameters.AddWithValue("?", selectedClass);

                    int assessmentCount = (int)cmd.ExecuteScalar();

                    if (assessmentCount == 0)
                    {
                        Sound.PlayError();
                        MessageBox.Show("This student has no assessments for the selected class.");
                        return;
                    }
                }


            }

            // If student exists, load the results with filters
            LoadResults(selectedClass, selectedSubject, selectedAssessment, studentSearch);
            UpdateGradeDistributionChart();
            UpdatePassFailChart();
            UpdateStudentProgressionChart(selectedClass, selectedSubject, studentSearch);
        }

        private void ChtGradeDistribution_Click(object sender, EventArgs e)
        {

        }

       
       
    }
}

