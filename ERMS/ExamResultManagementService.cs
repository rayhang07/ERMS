using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ERMS
{
    public class ExamResultsManagementService
    {
        public bool CreateAssessment(string className, string subject, string year, string assessmentName, string date)
        {
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
            var userRegService = new UserRegistrationService(dbPath);

            // Validate inputs: Can't be empty
            if (string.IsNullOrWhiteSpace(className) ||
                string.IsNullOrWhiteSpace(subject) ||
                string.IsNullOrWhiteSpace(year) ||
                string.IsNullOrWhiteSpace(assessmentName) ||
                string.IsNullOrWhiteSpace(date))
            {
                Sound.PlayError();
                MessageBox.Show("All fields must be filled.");
                return false;
            }

            // Validate Class Name: can only contain letters, numbers, and spaces
            if (!Regex.IsMatch(className, @"^[A-Za-z0-9\s]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Class Name can only contain letters and numbers.");
                return false;
            }

            // Validate Subject: can only contain letters and spaces
            if (!Regex.IsMatch(subject, @"^[A-Za-z\s]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Subject can only contain letters.");
                return false;
            }

            // Validate Year: must be exactly 4 digits
            if (!Regex.IsMatch(year, @"^\d{4}$"))
            {
                Sound.PlayError();
                MessageBox.Show("Year must be exactly 4 digits.");
                return false;
            }

            // Validate Assessment Name: can only contain letters, spaces, colon (:), or hyphen (-)
            if (!Regex.IsMatch(assessmentName, @"^[A-Za-z\s:\-]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Assessment Name can only contain letters, spaces, colon (:), or hyphen (-).");
                return false;
            }

            // Validate Date: must be in format dd/mm/yyyy
            if (!Regex.IsMatch(date, @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$"))
            {
                Sound.PlayError();
                MessageBox.Show("Date must be in format dd/mm/yyyy.");
                return false;
            }

            using (var conn = userRegService.GetOpenConnection())
            {
                if (conn == null) return false;

                // Look up ClassID
                int? classId = null;
                string getClassQuery = "SELECT ClassID FROM Class WHERE ClassName = ? AND Subject = ? AND ClassYear = ?";
                using (var getClassCmd = new OleDbCommand(getClassQuery, conn))
                {
                    getClassCmd.Parameters.AddWithValue("?", className);
                    getClassCmd.Parameters.AddWithValue("?", subject);
                    getClassCmd.Parameters.AddWithValue("?", year);

                    object result = getClassCmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        classId = Convert.ToInt32(result);
                }

                if (classId == null)
                {
                    Sound.PlayError();
                    MessageBox.Show("Class not found. Please ensure Class Name, Subject, and Year are correct.");
                    return false;
                }

                // Check for duplicate assessment
                string checkQuery = "SELECT COUNT(*) FROM Assessments WHERE ClassID = ? AND AssessmentName = ? AND AssessmentDate = ?";
                using (var checkCmd = new OleDbCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("?", classId.Value);
                    checkCmd.Parameters.AddWithValue("?", assessmentName);
                    checkCmd.Parameters.AddWithValue("?", date);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        Sound.PlayError();
                        MessageBox.Show("Assessment already exists for this class on this date.");
                        return false;
                    }
                }

                // Insert into Assessments if there are no duplicates
                string insertQuery = "INSERT INTO Assessments (AssessmentName, AssessmentDate, ClassID) VALUES (?, ?, ?)";
                using (var cmd = new OleDbCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", assessmentName);
                    cmd.Parameters.AddWithValue("?", date);
                    cmd.Parameters.AddWithValue("?", classId.Value);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Sound.PlaySuccess();
                            MessageBox.Show("Assessment created successfully!");
                            return true;
                        }
                        else
                        {
                            Sound.PlayError();
                            MessageBox.Show("Insert operation failed.");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Sound.PlayError();
                        MessageBox.Show("Database error: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public List<(string AssessmentName, string AssessmentDate)> GetTopUpcomingAssessments(int currentUserId)
        {
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
            var userRegService = new UserRegistrationService(dbPath);

            var upcomingAssessments = new List<(string, string)>();

            using (var conn = userRegService.GetOpenConnection())
            {
                if (conn == null) return upcomingAssessments;

                string query = @"
            SELECT TOP 2 a.AssessmentName, a.AssessmentDate
            FROM Assessments a
            INNER JOIN Class c ON a.ClassID = c.ClassID
            WHERE c.UserID = ?
              AND CDate(a.AssessmentDate) >= Date()
            ORDER BY CDate(a.AssessmentDate) ASC";

                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", currentUserId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["AssessmentName"].ToString();
                            string date = reader["AssessmentDate"].ToString();
                            upcomingAssessments.Add((name, date));
                        }
                    }
                }
            }

            return upcomingAssessments;
        }

        public bool AddResult(string studentName, string studentId, string className, string assessmentName, string score, string grade)
        {
             string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
             var userRegService = new UserRegistrationService(dbPath);

            // Validate inputs: can't be empty
            if (string.IsNullOrWhiteSpace(studentName) ||
            string.IsNullOrWhiteSpace(studentId) ||
            string.IsNullOrWhiteSpace(className) ||
            string.IsNullOrWhiteSpace(assessmentName) ||
            string.IsNullOrWhiteSpace(score) ||
            string.IsNullOrWhiteSpace(grade))
        {
            Sound.PlayError();
            MessageBox.Show("All fields must be filled.");
            return false;
        }

        // Validate Student Name: letters, spaces, hyphens
        if (!Regex.IsMatch(studentName, @"^[A-Za-z\s\-]+$"))
        {
            Sound.PlayError();
            MessageBox.Show("Student name can only contain letters, spaces, and hyphens.");
            return false;
        }

        // Validate Student ID: numbers only
        if (!Regex.IsMatch(studentId, @"^\d+$"))
        {
            Sound.PlayError();
            MessageBox.Show("Student ID must be numeric.");
            return false;
        }

        // Validate Class Name: letters, numbers, spaces
        if (!Regex.IsMatch(className, @"^[A-Za-z0-9\s]+$"))
        {
            Sound.PlayError();
            MessageBox.Show("Class Name can only contain letters, numbers, and spaces.");
            return false;
        }

        // Validate Assessment Name: letters, spaces, colon, hyphen
        if (!Regex.IsMatch(assessmentName, @"^[A-Za-z\s:\-]+$"))
        {
            Sound.PlayError();
            MessageBox.Show("Assessment name can only contain letters, spaces, colon (:), or hyphen (-).");
            return false;
        }

        // Validate Score: numbers only
        if (!Regex.IsMatch(score, @"^\d+$"))
        {
            Sound.PlayError();
            MessageBox.Show("Score must be numeric.");
            return false;
        }

        // Validate Grade: must be A*, A, B, C, D, E, F
        if (!Regex.IsMatch(grade, @"^(A\*|A|B|C|D|E|F)$"))
        {
            Sound.PlayError();
            MessageBox.Show("Grade must be A*, A, B, C, D, E, or F.");
            return false;
        }

        using (var conn = userRegService.GetOpenConnection())
        {
            if (conn == null) return false;

            // Get ClassID from Class table using ClassName only
            int? classId = null;
            string classQuery = @"SELECT ClassID FROM Class WHERE ClassName = ?";
            using (var classCmd = new OleDbCommand(classQuery, conn))
            {
                classCmd.Parameters.AddWithValue("?", className);

                object classResult = classCmd.ExecuteScalar();
                if (classResult != null && classResult != DBNull.Value)
                    classId = Convert.ToInt32(classResult);
                else
                {
                    Sound.PlayError();
                    MessageBox.Show("Class not found.");
                    return false;
                }
            }

            // Get EnrollmentID for studentId and classId
            int? enrollmentId = null;
            string enrollmentQuery = @"SELECT EnrollmentID FROM StudentClasses WHERE StudentID = ? AND ClassID = ?";
            using (var enrollCmd = new OleDbCommand(enrollmentQuery, conn))
            {
                enrollCmd.Parameters.AddWithValue("?", studentId);
                enrollCmd.Parameters.AddWithValue("?", classId.Value);

                object enrollResult = enrollCmd.ExecuteScalar();
                if (enrollResult != null && enrollResult != DBNull.Value)
                    enrollmentId = Convert.ToInt32(enrollResult);
                else
                {
                    Sound.PlayError();
                    MessageBox.Show("Student is not enrolled in the specified class.");
                    return false;
                }
            }

            // Get AssessmentID from Assessments via AssessmentName and ClassID
            int? assessmentId = null;
            string assessmentQuery = @"SELECT AssessmentID FROM Assessments WHERE AssessmentName = ? AND ClassID = ?";
            using (var assessCmd = new OleDbCommand(assessmentQuery, conn))
            {
                assessCmd.Parameters.AddWithValue("?", assessmentName);
                assessCmd.Parameters.AddWithValue("?", classId.Value);

                object assessResult = assessCmd.ExecuteScalar();
                if (assessResult != null && assessResult != DBNull.Value)
                    assessmentId = Convert.ToInt32(assessResult);
                else
                {
                    Sound.PlayError();
                    MessageBox.Show("Assessment not found for the specified class.");
                    return false;
                }
            }

            // Check for duplicate result (AssessmentID + EnrollmentID)
            string checkQuery = @"SELECT COUNT(*) FROM Results WHERE AssessmentID = ? AND EnrollmentID = ?";
            using (var checkCmd = new OleDbCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("?", assessmentId.Value);
                checkCmd.Parameters.AddWithValue("?", enrollmentId.Value);

                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    Sound.PlayError();
                    MessageBox.Show("Result already exists for this student in this assessment.");
                    return false;
                }
            }

            // Insert into Results table
            string insertQuery = @"INSERT INTO Results (AssessmentID, Score, Grade, ClassID, EnrollmentID) VALUES (?, ?, ?, ?, ?)";
            using (var insertCmd = new OleDbCommand(insertQuery, conn))
            {
                insertCmd.Parameters.AddWithValue("?", assessmentId.Value);
                insertCmd.Parameters.AddWithValue("?", int.Parse(score));
                insertCmd.Parameters.AddWithValue("?", grade.ToUpper());
                insertCmd.Parameters.AddWithValue("?", classId.Value);
                insertCmd.Parameters.AddWithValue("?", enrollmentId.Value);

                try
                {
                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Sound.PlaySuccess();
                        MessageBox.Show("Result added successfully!");
                        return true;
                    }
                    else
                    {
                        Sound.PlayError();
                        MessageBox.Show("Insert operation failed.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Sound.PlayError();
                    MessageBox.Show("Database error: " + ex.Message);
                    return false;
                }
            }
        }
    }


        public bool RemoveResult(string studentName, string studentId, string className, string assessmentName, string score, string grade)
        {
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
            var userRegService = new UserRegistrationService(dbPath);

            // Validate inputs: can't be empty
            if (string.IsNullOrWhiteSpace(studentName) ||
                string.IsNullOrWhiteSpace(studentId) ||
                string.IsNullOrWhiteSpace(className) ||
                string.IsNullOrWhiteSpace(assessmentName) ||
                string.IsNullOrWhiteSpace(score) ||
                string.IsNullOrWhiteSpace(grade))
            {
                Sound.PlayError();
                MessageBox.Show("All fields must be filled.");
                return false;
            }

            // Validate Student Name: letters, spaces, hyphens
            if (!Regex.IsMatch(studentName, @"^[A-Za-z\s\-]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Student name can only contain letters, spaces, and hyphens.");
                return false;
            }

            // Validate Student ID: numbers only
            if (!Regex.IsMatch(studentId, @"^\d+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Student ID must be numeric.");
                return false;
            }

            // Validate Class Name: letters, numbers, spaces
            if (!Regex.IsMatch(className, @"^[A-Za-z0-9\s]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Class Name can only contain letters, numbers, and spaces.");
                return false;
            }

            // Validate Assessment Name: letters, spaces, colon, hyphen
            if (!Regex.IsMatch(assessmentName, @"^[A-Za-z\s:\-]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Assessment name can only contain letters, spaces, colon (:), or hyphen (-).");
                return false;
            }

            // Validate Score: numbers only
            if (!Regex.IsMatch(score, @"^\d+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Score must be numeric.");
                return false;
            }

            // Validate Grade: must be A*, A, B, C, D, E, F
            if (!Regex.IsMatch(grade, @"^(A\*|A|B|C|D|E|F)$"))
            {
                Sound.PlayError();
                MessageBox.Show("Grade must be A*, A, B, C, D, E, or F.");
                return false;
            }

            using (var conn = userRegService.GetOpenConnection())
            {
                if (conn == null) return false;

                // Get ClassID from Class table using ClassName only
                int? classId = null;
                string classQuery = @"SELECT ClassID FROM Class WHERE ClassName = ?";
                using (var classCmd = new OleDbCommand(classQuery, conn))
                {
                    classCmd.Parameters.AddWithValue("?", className);

                    object classResult = classCmd.ExecuteScalar();
                    if (classResult != null && classResult != DBNull.Value)
                        classId = Convert.ToInt32(classResult);
                    else
                    {
                        Sound.PlayError();
                        MessageBox.Show("Class not found.");
                        return false;
                    }
                }

                // Get EnrollmentID for studentId and classId
                int? enrollmentId = null;
                string enrollmentQuery = @"SELECT EnrollmentID FROM StudentClasses WHERE StudentID = ? AND ClassID = ?";
                using (var enrollCmd = new OleDbCommand(enrollmentQuery, conn))
                {
                    enrollCmd.Parameters.AddWithValue("?", studentId);
                    enrollCmd.Parameters.AddWithValue("?", classId.Value);

                    object enrollResult = enrollCmd.ExecuteScalar();
                    if (enrollResult != null && enrollResult != DBNull.Value)
                        enrollmentId = Convert.ToInt32(enrollResult);
                    else
                    {
                        Sound.PlayError();
                        MessageBox.Show("Student is not enrolled in the specified class.");
                        return false;
                    }
                }

                // Get AssessmentID from Assessments via AssessmentName and ClassID
                int? assessmentId = null;
                string assessmentQuery = @"SELECT AssessmentID FROM Assessments WHERE AssessmentName = ? AND ClassID = ?";
                using (var assessCmd = new OleDbCommand(assessmentQuery, conn))
                {
                    assessCmd.Parameters.AddWithValue("?", assessmentName);
                    assessCmd.Parameters.AddWithValue("?", classId.Value);

                    object assessResult = assessCmd.ExecuteScalar();
                    if (assessResult != null && assessResult != DBNull.Value)
                        assessmentId = Convert.ToInt32(assessResult);
                    else
                    {
                        Sound.PlayError();
                        MessageBox.Show("Assessment not found for the specified class.");
                        return false;
                    }
                }

                // Check if any result exists for given AssessmentID and EnrollmentID (ignore score/grade)
                string anyResultQuery = @"SELECT COUNT(*) FROM Results WHERE AssessmentID = ? AND EnrollmentID = ?";
                using (var anyCheckCmd = new OleDbCommand(anyResultQuery, conn))
                {
                    anyCheckCmd.Parameters.AddWithValue("?", assessmentId.Value);
                    anyCheckCmd.Parameters.AddWithValue("?", enrollmentId.Value);

                    int anyCount = (int)anyCheckCmd.ExecuteScalar();
                    if (anyCount == 0)
                    {
                        Sound.PlayError();
                        MessageBox.Show("Result does not exist.");
                        return false;
                    }
                }

                // Check if the score and grade match for the given result
                string exactMatchQuery = @"SELECT COUNT(*) FROM Results WHERE AssessmentID = ? AND EnrollmentID = ? AND Score = ? AND Grade = ?";
                using (var exactCheckCmd = new OleDbCommand(exactMatchQuery, conn))
                {
                    exactCheckCmd.Parameters.AddWithValue("?", assessmentId.Value);
                    exactCheckCmd.Parameters.AddWithValue("?", enrollmentId.Value);
                    exactCheckCmd.Parameters.AddWithValue("?", score);
                    exactCheckCmd.Parameters.AddWithValue("?", grade.ToUpper());

                    int exactCount = (int)exactCheckCmd.ExecuteScalar();
                    if (exactCount == 0)
                    {
                        Sound.PlayError();
                        MessageBox.Show("The score or grade provided does not match the existing result.");
                        return false;
                    }
                }

                // Delete the Result
                string deleteQuery = @"DELETE FROM Results WHERE AssessmentID = ? AND EnrollmentID = ? AND Score = ? AND Grade = ?";
                using (var deleteCmd = new OleDbCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("?", assessmentId.Value);
                    deleteCmd.Parameters.AddWithValue("?", enrollmentId.Value);
                    deleteCmd.Parameters.AddWithValue("?", score);
                    deleteCmd.Parameters.AddWithValue("?", grade.ToUpper());

                    try
                    {
                        int rowsDeleted = deleteCmd.ExecuteNonQuery();
                        if (rowsDeleted > 0)
                        {
                            Sound.PlaySuccess();
                            MessageBox.Show("Result deleted successfully.");
                            return true;
                        }
                        else
                        {
                            Sound.PlayError();
                            MessageBox.Show("Delete operation failed.");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Sound.PlayError();
                        MessageBox.Show("Database error: " + ex.Message);
                        return false;
                    }
                }
            }
        }

    }
}
