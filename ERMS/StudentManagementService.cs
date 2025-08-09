using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ERMS
{
    public class StudentManagementService
    {

        public bool AddClass(string className, string subject, string year, int currentUserId)
        {
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
            var userRegService = new UserRegistrationService(dbPath);

            // Validate inputs: can't be empty
            if (string.IsNullOrWhiteSpace(className) || string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(year))
            {
                Sound.PlayError();
                MessageBox.Show("Class Name, Subject, and/or Year cannot be empty.");
                return false;
            }

            // Validate ClassName: letters and numbers only
            if (!Regex.IsMatch(className, @"^[A-Za-z0-9\s]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Class Name can only contain letters and numbers.");
                return false;
            }

            // Validate Subject: letters only
            if (!Regex.IsMatch(subject, @"^[A-Za-z\s]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Subject can only contain letters.");
                return false;
            }

            // Validate Year: exactly 4 digits
            if (!Regex.IsMatch(year, @"^\d{4}$"))
            {
                Sound.PlayError();
                MessageBox.Show("Year must be exactly 4 digits.");
                return false;
            }

            using (var conn = userRegService.GetOpenConnection())
            {
                if (conn == null)
                {
                    return false;
                }
                string checkQuery = "SELECT COUNT(*) FROM Class WHERE ClassName = ? AND Subject = ? AND ClassYear = ?";
                using (var checkCmd = new OleDbCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("?", className);
                    checkCmd.Parameters.AddWithValue("?", subject);
                    checkCmd.Parameters.AddWithValue("?", year);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        Sound.PlayError();
                        MessageBox.Show("Class already exists.");
                        return false;
                    }
                }


                // Prepare the SQL query to insert the class
                string query = "INSERT INTO Class (ClassName, Subject, ClassYear, UserID) VALUES (?, ?, ?, ?)";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", className);
                    cmd.Parameters.AddWithValue("?", subject);
                    cmd.Parameters.AddWithValue("?", year);
                    cmd.Parameters.AddWithValue("?", CurrentUser.UserId);

                    try
                    {   // Execute the command
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Sound.PlaySuccess();
                            MessageBox.Show("Class added successfully!");
                            return true;
                        }
                        else
                        {
                            Sound.PlayError();
                            MessageBox.Show("Insert operation failed.");
                            return false;
                        }
                    }
                    // Catch any exceptions that occur during the operation
                    catch (Exception ex)
                    {
                        Sound.PlayError();
                        MessageBox.Show("Database error: " + ex.Message);
                        return false;
                    }
                }
            }
        }




        public bool DeleteClass(string className, string subject, string year)
        {
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
            var userRegService = new UserRegistrationService(dbPath);

            // Validate inputs: can't be empty
            if (string.IsNullOrWhiteSpace(className) || string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(year))
            {
                Sound.PlayError();
                MessageBox.Show("Class Name, Subject, and/or Year cannot be empty.");
                return false;
            }

            // Validate ClassName: letters and numbers only
            if (!Regex.IsMatch(className, @"^[A-Za-z0-9\s]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Class Name can only contain letters and numbers.");
                return false;
            }

            // Validate Subject: letters only
            if (!Regex.IsMatch(subject, @"^[A-Za-z\s]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Subject can only contain letters.");
                return false;
            }

            // Validate Year: exactly 4 digits
            if (!Regex.IsMatch(year, @"^\d{4}$"))
            {
                Sound.PlayError();
                MessageBox.Show("Year must be exactly 4 digits.");
                return false;
            }

            using (var conn = userRegService.GetOpenConnection())
            {
                if (conn == null)
                {

                    return false;
                }

                // Prepare the SQL query to delete the class
                string query = "DELETE FROM Class WHERE ClassName = ? AND Subject = ? AND ClassYear = ?";
                using (var cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", className);
                    cmd.Parameters.AddWithValue("?", subject);
                    cmd.Parameters.AddWithValue("?", year);

                    try
                    {
                        // Execute the command
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Sound.PlaySuccess();
                            MessageBox.Show("Class deleted successfully!");
                            return true;
                        }
                        else
                        {
                            Sound.PlayError();
                            MessageBox.Show("No matching class found.");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Catch any exceptions that occur during the operation
                        Sound.PlayError();
                        MessageBox.Show("Database error: " + ex.Message);
                        return false;
                    }
                }
            }


        }
        public bool AddStudent(string className, string studentName, string studentId)
        {
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
            var userRegService = new UserRegistrationService(dbPath);

            // Validate inputs: can't be empty
            if (string.IsNullOrWhiteSpace(className) || string.IsNullOrWhiteSpace(studentName) || string.IsNullOrWhiteSpace(studentId))
            {
                Sound.PlayError();
                MessageBox.Show("Class Name, Student Name, and/or Student ID cannot be empty.");
                return false;
            }

            // Validate ClassName: letters and numbers only
            if (!Regex.IsMatch(className, @"^[a-zA-Z0-9\s]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Class Name can only contain letters and numbers.");
                return false;
            }
            // Validate StudentName: letters, spaces and hyphens only   
            if (!Regex.IsMatch(studentName, @"^[A-Za-z\-\s]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Student Name can only contain letters, spaces and hyphens.");
                return false;
            }

            // Validate StudentID: numbers only
            if (!Regex.IsMatch(studentId, @"^\d+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Student ID can only contain numbers.");
                return false;
            }
            if (!int.TryParse(studentId, out int studentIdInt))
            {
                Sound.PlayError();
                MessageBox.Show("Student ID is not a valid number.");
                return false;
            }

            using (var conn = userRegService.GetOpenConnection())
            {
                if (conn == null)
                {
                    return false;
                }

                // Get ClassID from className
                int classId = -1;
                string getClassIdQuery = "SELECT ClassID FROM Class WHERE ClassName = ?";
                using (var cmd = new OleDbCommand(getClassIdQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", className);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        classId = Convert.ToInt32(result);
                    }
                    else
                    {
                        Sound.PlayError();
                        MessageBox.Show("Class not found.");
                        return false;
                    }
                }

                // Normalize studentName (trim whitespace)
                string normalizedStudentName = studentName.Trim();

                // Check if the student already exists in Students table by StudentID
                bool studentExists = false;
                string checkStudentQuery = "SELECT COUNT(*) FROM Students WHERE StudentID = ?";
                using (var cmd = new OleDbCommand(checkStudentQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", studentId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    studentExists = count > 0;
                }

                // If student does NOT exist, insert student into Students table
                if (!studentExists)
                {
                    string insertStudentQuery = "INSERT INTO Students (StudentName, StudentID) VALUES (?, ?)";
                    using (var cmd = new OleDbCommand(insertStudentQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("?", normalizedStudentName);
                        cmd.Parameters.AddWithValue("?", studentId);

                        try
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected == 0)
                            {
                                Sound.PlayError();
                                MessageBox.Show("Failed to add new student.");
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            Sound.PlayError();
                            MessageBox.Show("Database error inserting student: " + ex.Message);
                            return false;
                        }
                    }
                }

                // Check if enrollment already exists (student in class)
                string checkEnrollmentQuery = "SELECT COUNT(*) FROM StudentClasses WHERE StudentID = ? AND ClassID = ?";
                using (var cmd = new OleDbCommand(checkEnrollmentQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", studentId);
                    cmd.Parameters.AddWithValue("?", classId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        Sound.PlayError();
                        MessageBox.Show("This student is already enrolled in this class.");
                        return false;
                    }
                }

                // Insert enrollment (student-class link)
                string insertEnrollmentQuery = "INSERT INTO StudentClasses (StudentID, ClassID) VALUES (?, ?)";
                using (var cmd = new OleDbCommand(insertEnrollmentQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", studentId);
                    cmd.Parameters.AddWithValue("?", classId);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Sound.PlaySuccess();
                            MessageBox.Show("Student added to class successfully!");
                            return true;
                        }
                        else
                        {
                            Sound.PlayError();
                            MessageBox.Show("Failed to enroll student in class.");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Sound.PlayError();
                        MessageBox.Show("Database error enrolling student: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public bool RemoveStudent(string className, string studentName, string studentId)
        {
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
            var userRegService = new UserRegistrationService(dbPath);

            // Validate inputs: can't be empty
            if (string.IsNullOrWhiteSpace(className) || string.IsNullOrWhiteSpace(studentName) || string.IsNullOrWhiteSpace(studentId))
            {
                Sound.PlayError();
                MessageBox.Show("Class Name, Student Name, and/or Student ID cannot be empty.");
                return false;
            }

            // Validate ClassName: letters and numbers only
            if (!Regex.IsMatch(className, @"^[a-zA-Z0-9\s]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Class Name can only contain letters and numbers.");
                return false;
            }

            // Validate StudentName: letters, spaces and hyphens only
            if (!Regex.IsMatch(studentName, @"^[a-zA-Z\-\s]+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Student Name can only contain letters, spaces and hyphens.");
                return false;
            }

            // Validate StudentID: numbers only
            if (!Regex.IsMatch(studentId, @"^\d+$"))
            {
                Sound.PlayError();
                MessageBox.Show("Student ID can only contain numbers.");
                return false;
            }

            using (var conn = userRegService.GetOpenConnection())
            {
                if (conn == null)
                {
                    return false;
                }

                // Get ClassID from className
                int classId = -1;
                string getClassIdQuery = "SELECT ClassID FROM Class WHERE ClassName = ?";
                using (var cmd = new OleDbCommand(getClassIdQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", className);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        classId = Convert.ToInt32(result);
                    }
                    else
                    {
                        Sound.PlayError();
                        MessageBox.Show("Class not found.");
                        return false;
                    }
                }

                // Check if the enrollment exists (optional but useful)
                string checkEnrollmentQuery = "SELECT COUNT(*) FROM StudentClasses WHERE StudentID = ? AND ClassID = ?";
                using (var cmd = new OleDbCommand(checkEnrollmentQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", studentId);
                    cmd.Parameters.AddWithValue("?", classId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        Sound.PlayError();
                        MessageBox.Show("This student is not enrolled in this class.");
                        return false;
                    }
                }

                // Delete the enrollment record (remove student from class)
                string deleteEnrollmentQuery = "DELETE FROM StudentClasses WHERE StudentID = ? AND ClassID = ?";
                using (var cmd = new OleDbCommand(deleteEnrollmentQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", studentId);
                    cmd.Parameters.AddWithValue("?", classId);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Sound.PlaySuccess();
                            MessageBox.Show("Student removed from class successfully!");
                            return true;
                        }
                        else
                        {
                            Sound.PlayError();
                            MessageBox.Show("No matching enrollment found.");
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
