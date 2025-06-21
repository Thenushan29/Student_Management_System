using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Student_Management_System.Model;

namespace Student_Management_System.Controller
{
    internal class MarkController
    {
        private SQLiteConnection connection;

        public MarkController(SQLiteConnection dbConnection)
        {
            connection = dbConnection;
        }

        // Add a new Mark
        public void AddMark(Mark mark)
        {
            string query = @"
                INSERT INTO Marks (CourseID, SubjectID, StudentID, StudentName, Mark)
                VALUES (@CourseID, @SubjectID, @StudentID, @StudentName, @MarkValue)";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CourseID", mark.CourseID);
                cmd.Parameters.AddWithValue("@SubjectID", mark.SubjectID);
                cmd.Parameters.AddWithValue("@StudentID", mark.StudentId);
                cmd.Parameters.AddWithValue("@StudentName", mark.StudentName);
                cmd.Parameters.AddWithValue("@MarkValue", mark.MarkValue);
                cmd.ExecuteNonQuery();
            }
        }

        // Update existing Mark
        public void UpdateMark(Mark mark)
        {
            string query = @"
                UPDATE Marks SET 
                    Mark = @MarkValue
                WHERE StudentID = @StudentID AND CourseID = @CourseID AND SubjectID = @SubjectID";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@MarkValue", mark.MarkValue);
                cmd.Parameters.AddWithValue("@StudentID", mark.StudentId);
                cmd.Parameters.AddWithValue("@CourseID", mark.CourseID);
                cmd.Parameters.AddWithValue("@SubjectID", mark.SubjectID);
                cmd.ExecuteNonQuery();
            }
        }

        // Delete a mark record
        public void DeleteMark(int studentId, int courseId, int subjectId)
        {
            string query = @"
                DELETE FROM Marks
                WHERE StudentID = @StudentID AND CourseID = @CourseID AND SubjectID = @SubjectID";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                cmd.Parameters.AddWithValue("@CourseID", courseId);
                cmd.Parameters.AddWithValue("@SubjectID", subjectId);
                cmd.ExecuteNonQuery();
            }
        }

        // Get all marks (optionally with student, course, subject info)
        public List<Mark> GetAllMarks()
        {
            var marks = new List<Mark>();
            string query = @"
                SELECT m.StudentID, m.StudentName, m.Mark, m.CourseID, c.CourseName,
                       m.SubjectID, sub.SubjectName
                FROM Marks m
                LEFT JOIN Courses c ON m.CourseID = c.CourseID
                LEFT JOIN Subjects sub ON m.SubjectID = sub.SubjectID";

            using (var cmd = new SQLiteCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    marks.Add(new Mark
                    {
                        StudentId = reader.GetInt32(0),
                        StudentName = reader.GetString(1),
                        MarkValue = reader.GetInt32(2),
                        CourseID = reader.GetInt32(3),
                        // CourseName property is missing in your model but you can add it if needed
                        SubjectID = reader.GetInt32(5),
                        SubjectName = reader.IsDBNull(6) ? null : reader.GetString(6)
                    });
                }
            }
            return marks;
        }

        // Get marks for a specific student
        public List<Mark> GetMarksByStudent(int studentId)
        {
            var marks = new List<Mark>();
            string query = @"
                SELECT m.StudentID, m.StudentName, m.Mark, m.CourseID, c.CourseName,
                       m.SubjectID, sub.SubjectName
                FROM Marks m
                LEFT JOIN Courses c ON m.CourseID = c.CourseID
                LEFT JOIN Subjects sub ON m.SubjectID = sub.SubjectID
                WHERE m.StudentID = @StudentID";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        marks.Add(new Mark
                        {
                            StudentId = reader.GetInt32(0),
                            StudentName = reader.GetString(1),
                            MarkValue = reader.GetInt32(2),
                            CourseID = reader.GetInt32(3),
                            SubjectID = reader.GetInt32(5),
                            SubjectName = reader.IsDBNull(6) ? null : reader.GetString(6)
                        });
                    }
                }
            }
            return marks;
        }

        // Get marks for a specific course and subject
        public List<Mark> GetMarksByCourseSubject(int courseId, int subjectId)
        {
            var marks = new List<Mark>();
            string query = @"
                SELECT m.StudentID, m.StudentName, m.Mark, m.CourseID, c.CourseName,
                       m.SubjectID, sub.SubjectName
                FROM Marks m
                LEFT JOIN Courses c ON m.CourseID = c.CourseID
                LEFT JOIN Subjects sub ON m.SubjectID = sub.SubjectID
                WHERE m.CourseID = @CourseID AND m.SubjectID = @SubjectID";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CourseID", courseId);
                cmd.Parameters.AddWithValue("@SubjectID", subjectId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        marks.Add(new Mark
                        {
                            StudentId = reader.GetInt32(0),
                            StudentName = reader.GetString(1),
                            MarkValue = reader.GetInt32(2),
                            CourseID = reader.GetInt32(3),
                            SubjectID = reader.GetInt32(5),
                            SubjectName = reader.IsDBNull(6) ? null : reader.GetString(6)
                        });
                    }
                }
            }
            return marks;
        }
    }
}
