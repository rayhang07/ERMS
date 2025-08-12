using iText.Kernel.Pdf;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Layout;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.IO.Image;
using iText.Layout.Borders;

namespace ERMS
{


    public partial class ReportForm : Form
    {
        private UserRegistrationService userRegistrationService;
        private int currentUserId = CurrentUser.UserId;
        string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");

        public ReportForm()
        {

            userRegistrationService = new UserRegistrationService(dbPath);
            InitializeComponent();
            DgvReports.Columns.Clear();

            // Add columns with headers
            DgvReports.Columns.Add("AssessmentName", "Assessment Name");
            DgvReports.Columns.Add("Score", "Result");
            DgvReports.Columns.Add("Grade", "Grade");
            DgvReports.AutoGenerateColumns = false;

            // Set column widths
            DgvReports.EnableHeadersVisualStyles = false;

            // Set header styles
            DgvReports.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 64, 0);

            // Set header text color
            DgvReports.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;

            // Set default cell styles
            DgvReports.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            DgvReports.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            // clear rows to make sure empty
            DgvReports.Rows.Clear();

            LoadClasses();

            DgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int colCount = DgvReports.Columns.Count;
            foreach (DataGridViewColumn col in DgvReports.Columns)
            {
                col.FillWeight = 100f / colCount;
            }

        }
        private void LoadClasses()
        {
            using (var conn = userRegistrationService.GetOpenConnection())
            {
                if (conn == null)
                {
                    Sound.PlayError();
                    MessageBox.Show("Failed to connect to the database.");
                    return;
                }

                // Gets all classes that the current user has made
                string query = "SELECT DISTINCT ClassName FROM Class WHERE UserID = ?";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", currentUserId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        CmbSelectClass.Items.Clear();
                        CmbSelectClass.Items.Add("");
                        while (reader.Read())
                        {
                            CmbSelectClass.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            // Stores the selected class as a variable
            string selectedClass = CmbSelectClass.SelectedItem?.ToString() ?? "";

            // Ensures a class has been selected before searching for a specific student
            if (string.IsNullOrEmpty(selectedClass))
            {
                Sound.PlayError();
                MessageBox.Show("Please select a class before searching.");
                return;
            }

            string studentSearch = TxtSearch.Text.Trim();

            // Ensure that the student search isn't empty
            if (string.IsNullOrWhiteSpace(studentSearch))
            {
                Sound.PlayError();
                MessageBox.Show("Please enter a student name.");
                return;
            }
            using (var conn = userRegistrationService.GetOpenConnection())
            {
                if (conn == null)
                {
                    Sound.PlayError();
                    MessageBox.Show("Failed to connect to the database.");
                    return;
                }

                // Finds if the student exists
                string checkStudentQuery = "SELECT COUNT(*) FROM Students WHERE StudentName = ?";
                using (var cmd = new OleDbCommand(checkStudentQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", studentSearch);
                    int count = (int)cmd.ExecuteScalar();

                    if (count == 0)
                    {
                        // If not, displays an error
                        Sound.PlayError();
                        MessageBox.Show("Student does not exist.");
                        return;
                    }
                }

            }

            using (var conn = userRegistrationService.GetOpenConnection())
            {
                if (conn == null)
                {
                    Sound.PlayError();
                    MessageBox.Show("Failed to connect to database.");
                    return;
                }

                // Finds the student based on the search filters
                string checkQuery = @"
                SELECT COUNT(*) 
                FROM ((Students s
                INNER JOIN StudentClasses sc ON s.StudentID = sc.StudentID)
                INNER JOIN Class c ON sc.ClassID = c.ClassID)
                WHERE c.ClassName = ? AND s.StudentName = ?";

                using (var cmd = new OleDbCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", selectedClass);
                    cmd.Parameters.AddWithValue("?", studentSearch);

                    int count = (int)cmd.ExecuteScalar();

                    if (count == 0)
                    {
                        // If not found, displays an error
                        Sound.PlayError();
                        MessageBox.Show($"Student '{studentSearch}' is not enrolled in class '{selectedClass}'.");
                        return;
                    }
                }

                // Calls the method passing the search filters as arguments
                LoadReportResults(selectedClass, studentSearch);
            }
        }
        private void LoadReportResults(string className, string studentName)
        {
            using var conn = userRegistrationService.GetOpenConnection();
            if (conn == null)
            {
                Sound.PlayError();
                MessageBox.Show("Failed to connect to the database.");
                return;
            }

            // Gets the Assesment name, date, score and grade by joining necessary tables
            string query = @"
        SELECT 
            a.AssessmentName, 
            a.AssessmentDate, 
            r.Score, 
            r.Grade
        FROM ((((Results r
        INNER JOIN Assessments a ON r.AssessmentID = a.AssessmentID)
        INNER JOIN StudentClasses sc ON r.EnrollmentID = sc.EnrollmentID)
        INNER JOIN Students s ON sc.StudentID = s.StudentID)
        INNER JOIN Class c ON sc.ClassID = c.ClassID)
        WHERE s.StudentName LIKE ? AND c.ClassName = ?
        ORDER BY a.AssessmentDate";

            using var cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("?", $"%{studentName}%");
            cmd.Parameters.AddWithValue("?", className);

            using var reader = cmd.ExecuteReader();

            DgvReports.Rows.Clear();

            while (reader.Read())
            {
                // Adds the data to the table
                DgvReports.Rows.Add(
                    reader["AssessmentName"].ToString(),
                    reader["Score"].ToString(),
                    reader["Grade"].ToString()
                );
            }

            // Appends the labels with the searched student's information and todays date
            LblClassName.Text = $"Class Name: {className}";
            LblName.Text = $"Student Name: {studentName}";
            LblDate.Text = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void BtnShare_Click(object sender, EventArgs e)
        {
            // Calls method when share is clicked
            ExportReport();
        }



        private void ExportReport()
        {
            // stores the searched students name as a variable
            string studentName = TxtSearch.Text.Trim();
            string className = CmbSelectClass.SelectedItem?.ToString() ?? "";
            // Ensures that a student has been selected and the teachers comment has been filled.
            if (DgvReports.Rows.Count == 0 || string.IsNullOrWhiteSpace(TxtTeachersComment.Text))
            {
                // Otherwise presents an error
                Sound.PlayError();
                MessageBox.Show("Please fill all details before exporting.");
                return;
            }

            // Sets the type of file and its name wwhen exporting
            using (var sfd = new SaveFileDialog() { Filter = "PDF Files|*.pdf", FileName = $"{className}_{studentName}_Report.pdf" })
            {
                // Creates path to the Resources folder to get the Company Logo to place on the report
                string exeFolder = AppDomain.CurrentDomain.BaseDirectory;
                string projectRoot = Path.GetFullPath(Path.Combine(exeFolder, @"..\..\.."));
                string logoPath = Path.Combine(projectRoot, "Resources", "logo.png");
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Creates a writer to write the pdf contents to a file
                    using var writer = new PdfWriter(sfd.FileName);

                    // Uses the writer to create pdf document object 
                    using var pdf = new PdfDocument(writer);
                    using var document = new Document(pdf);

                    // Creates fonts for the report
                    var titleFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    var normalFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                    // Add logo to the top right of the report
                    byte[] logoBytes = File.ReadAllBytes(logoPath);
                    ImageData imageData = ImageDataFactory.Create(logoBytes);
                    iText.Layout.Element.Image logo = new iText.Layout.Element.Image(imageData);
                    logo.ScaleToFit(80, 80);

                    // Adjusts the margins for the page
                    float x = pdf.GetDefaultPageSize().GetWidth() - 90;
                    float y = pdf.GetDefaultPageSize().GetHeight() - 90;
                    logo.SetFixedPosition(x, y);
                    document.Add(logo);

                    // Centre the title
                    document.Add(new Paragraph($"{studentName}'s Report")
                        .SetFont(titleFont)
                        .SetFontSize(18)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetMarginBottom(20));

                    // Sets colours to be used in report
                    var bgColor = new DeviceRgb(128, 64, 0);
                    var white = new DeviceRgb(255, 255, 255);
                    var black = new DeviceRgb(0, 0, 0);

                    document.Add(new Paragraph(LblName.Text).SetFont(normalFont).SetFontSize(12).SetFontColor(black));
                    document.Add(new Paragraph(LblClassName.Text).SetFont(normalFont).SetFontSize(12).SetFontColor(black));
                    document.Add(new Paragraph(LblDate.Text).SetFont(normalFont).SetFontSize(12).SetFontColor(black));
                    document.Add(new Paragraph(""));


                    // Results table with border and background on headers
                    var table = new Table(UnitValue.CreatePercentArray(new float[] { 4, 2, 2 })).UseAllAvailableWidth();
                    table.SetMarginBottom(15);
                    table.SetBorder(new SolidBorder(bgColor, 1));

                    table.AddHeaderCell(new Cell().Add(new Paragraph("Assessment Name").SetFont(titleFont).SetFontColor(white)).SetBackgroundColor(bgColor).SetPadding(5));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Result").SetFont(titleFont).SetFontColor(white)).SetBackgroundColor(bgColor).SetPadding(5));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Grade").SetFont(titleFont).SetFontColor(white)).SetBackgroundColor(bgColor).SetPadding(5));


                    // Adds the information from the DataGridView into the table on the report
                    foreach (DataGridViewRow row in DgvReports.Rows)
                    {
                        if (row.IsNewRow) continue;

                        table.AddCell(new Cell().Add(new Paragraph(row.Cells["AssessmentName"].Value?.ToString() ?? "").SetFont(normalFont).SetFontSize(12)));
                        table.AddCell(new Cell().Add(new Paragraph(row.Cells["Score"].Value?.ToString() ?? "").SetFont(normalFont).SetFontSize(12)));
                        table.AddCell(new Cell().Add(new Paragraph(row.Cells["Grade"].Value?.ToString() ?? "").SetFont(normalFont).SetFontSize(12)));
                    }

                    document.Add(table);

                    // Teacher's comment section with border and background
                    var commentTitle = new Paragraph("Teacher's Comment:")
                        .SetFont(titleFont)
                        .SetFontSize(14)
                        .SetFontColor(white)
                        .SetBackgroundColor(bgColor)
                        .SetPadding(5);
                    document.Add(commentTitle);

                    var commentPara = new Paragraph(TxtTeachersComment.Text)
                        .SetFont(normalFont)
                        .SetFontSize(12)
                        .SetMarginTop(5);
                    document.Add(commentPara);

                    // Closes document
                    document.Close();

                    // Provides success feedback to the user
                    Sound.PlaySuccess();
                    MessageBox.Show("Report exported successfully!");
                    TxtSearch.Clear();
                    TxtTeachersComment.Clear();
                    LblClassName.Text = $"Class Name: ";
                    LblName.Text = $"Student Name";
                    LblDate.Text = "Date: ";
                    CmbSelectClass.SelectedIndex = 0;
                    DgvReports.Rows.Clear();
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}