using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Student_Management_System.Model;

namespace Student_Management_System.Controller
{
    internal class StudentController
    {
        private SQLiteConnection connection;

        public StudentController(SQLiteConnection dbConnection)
        {
            connection = dbConnection;
        }

        // Add new Student with course and subject info
        public void AddStudent(Student student)
        {
            if (student.PhoneNumber == null || student.PhoneNumber.Length != 10 || !student.PhoneNumber.All(char.IsDigit))
            {
                throw new ArgumentException("Phone number must be exactly 10 digits and numeric.");
            }

            string query = @"
                INSERT INTO Students 
                (StudentName, UserName, Password, PhoneNumber, Address) 
                VALUES 
                (@StudentName, @UserName, @Password, @PhoneNumber, @Address)";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                cmd.Parameters.AddWithValue("@UserName", student.UserName);
                cmd.Parameters.AddWithValue("@Password", student.Password);
                cmd.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                cmd.ExecuteNonQuery();
            }
        }

        // Update student info (except course and subject because those link in Marks table)
        public void UpdateStudent(Student student)
        {
            string query = @"
                UPDATE Students SET 
                StudentName = @StudentName,
                UserName = @UserName,
                Password = @Password,
                PhoneNumber = @PhoneNumber,
                Address = @Address
                WHERE StudentID = @StudentID";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                cmd.Parameters.AddWithValue("@UserName", student.UserName);
                cmd.Parameters.AddWithValue("@Password", student.Password);
                cmd.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                cmd.ExecuteNonQuery();
            }
        }

        // Delete student by ID
        public void DeleteStudent(int studentID)
        {
            string query = "DELETE FROM Students WHERE StudentID = @StudentID";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.ExecuteNonQuery();
            }
        }

        // Get student by ID, including Course and Subject info via Marks and join tables
        public Student GetStudentById(int studentID)
        {
            string query = @"
                SELECT s.StudentID, s.StudentName, s.UserName, s.Password, s.PhoneNumber, s.Address,
                       m.CourseID, m.SubjectID,
                       c.CourseName,
                       sub.SubjectName
                FROM Students s
                LEFT JOIN Marks m ON s.StudentID = m.StudentID
                LEFT JOIN Courses c ON m.CourseID = c.CourseID
                LEFT JOIN Subjects sub ON m.SubjectID = sub.SubjectID
                WHERE s.StudentID = @StudentID
                LIMIT 1";  // Assuming one course/subject here, if multiple you may want a different approach

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Student
                        {
                            StudentID = reader.GetInt32(0),
                            StudentName = reader.GetString(1),
                            UserName = reader.GetString(2),
                            Password = reader.GetString(3),
                            PhoneNumber = reader.GetString(4),
                            Address = reader.GetString(5),
                            CourseID = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                            SubjectID = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                            CourseName = reader.IsDBNull(8) ? null : reader.GetString(8),
                            SubjectName = reader.IsDBNull(9) ? null : reader.GetString(9)
                        };
                    }
                }
            }

            return null; // Not found
        }

        // Get all students (basic info only)
        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();
            string query = "SELECT StudentID, StudentName, UserName, Password, PhoneNumber, Address FROM Students";

            using (var cmd = new SQLiteCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        StudentID = reader.GetInt32(0),
                        StudentName = reader.GetString(1),
                        UserName = reader.GetString(2),
                        Password = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        Address = reader.GetString(5)
                    });
                }
            }
            return students;
        }

        // Assign course and subject to student via Marks table (add or update mark record)
        public void AssignCourseSubjectToStudent(int studentID, int courseID, int subjectID, string studentName, int mark = 0)
        {
            // Check if record exists
            string checkQuery = "SELECT COUNT(*) FROM Marks WHERE StudentID = @StudentID AND CourseID = @CourseID AND SubjectID = @SubjectID";
            using (var cmdCheck = new SQLiteCommand(checkQuery, connection))
            {
                cmdCheck.Parameters.AddWithValue("@StudentID", studentID);
                cmdCheck.Parameters.AddWithValue("@CourseID", courseID);
                cmdCheck.Parameters.AddWithValue("@SubjectID", subjectID);

                long count = (long)cmdCheck.ExecuteScalar();

                if (count == 0)
                {
                    // Insert new record
                    string insertQuery = @"
                        INSERT INTO Marks (CourseID, SubjectID, StudentID, StudentName, Mark)
                        VALUES (@CourseID, @SubjectID, @StudentID, @StudentName, @Mark)";
                    using (var cmdInsert = new SQLiteCommand(insertQuery, connection))
                    {
                        cmdInsert.Parameters.AddWithValue("@CourseID", courseID);
                        cmdInsert.Parameters.AddWithValue("@SubjectID", subjectID);
                        cmdInsert.Parameters.AddWithValue("@StudentID", studentID);
                        cmdInsert.Parameters.AddWithValue("@StudentName", studentName);
                        cmdInsert.Parameters.AddWithValue("@Mark", mark);
                        cmdInsert.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Update existing record (optional, maybe update mark or studentName)
                    string updateQuery = @"
                        UPDATE Marks SET StudentName = @StudentName, Mark = @Mark
                        WHERE StudentID = @StudentID AND CourseID = @CourseID AND SubjectID = @SubjectID";
                    using (var cmdUpdate = new SQLiteCommand(updateQuery, connection))
                    {
                        cmdUpdate.Parameters.AddWithValue("@StudentName", studentName);
                        cmdUpdate.Parameters.AddWithValue("@Mark", mark);
                        cmdUpdate.Parameters.AddWithValue("@StudentID", studentID);
                        cmdUpdate.Parameters.AddWithValue("@CourseID", courseID);
                        cmdUpdate.Parameters.AddWithValue("@SubjectID", subjectID);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
