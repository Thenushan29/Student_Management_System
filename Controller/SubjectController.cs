using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Student_Management_System.Model;

namespace Student_Management_System.Controller
{
    internal class SubjectController
    {
        private SQLiteConnection connection;

        public SubjectController(SQLiteConnection dbConnection)
        {
            connection = dbConnection;
        }

        // Add a new subject
        public void AddSubject(Subject subject)
        {
            string query = "INSERT INTO Subjects (SubjectName, CourseID) VALUES (@SubjectName, @CourseID)";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                cmd.Parameters.AddWithValue("@CourseID", subject.CourseID);
                cmd.ExecuteNonQuery();
            }
        }

        // Update existing subject
        public void UpdateSubject(Subject subject)
        {
            string query = "UPDATE Subjects SET SubjectName = @SubjectName, CourseID = @CourseID WHERE SubjectID = @SubjectID";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                cmd.Parameters.AddWithValue("@CourseID", subject.CourseID);
                cmd.Parameters.AddWithValue("@SubjectID", subject.SubjectID);
                cmd.ExecuteNonQuery();
            }
        }

        // Delete subject by ID
        public void DeleteSubject(int subjectID)
        {
            string query = "DELETE FROM Subjects WHERE SubjectID = @SubjectID";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                cmd.ExecuteNonQuery();
            }
        }

        // Get all subjects
        public List<Subject> GetAllSubjects()
        {
            var subjects = new List<Subject>();
            string query = "SELECT SubjectID, SubjectName, CourseID FROM Subjects";
            using (var cmd = new SQLiteCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    subjects.Add(new Subject
                    {
                        SubjectID = reader.GetInt32(0),
                        SubjectName = reader.GetString(1),
                        CourseID = reader.GetInt32(2)
                    });
                }
            }
            return subjects;
        }

        // Get subjects by course ID
        public List<Subject> GetSubjectsByCourse(int courseID)
        {
            var subjects = new List<Subject>();
            string query = "SELECT SubjectID, SubjectName, CourseID FROM Subjects WHERE CourseID = @CourseID";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CourseID", courseID);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(new Subject
                        {
                            SubjectID = reader.GetInt32(0),
                            SubjectName = reader.GetString(1),
                            CourseID = reader.GetInt32(2)
                        });
                    }
                }
            }
            return subjects;
        }

        // Get subject by ID
        public Subject GetSubjectById(int subjectID)
        {
            string query = "SELECT SubjectID, SubjectName, CourseID FROM Subjects WHERE SubjectID = @SubjectID";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Subject
                        {
                            SubjectID = reader.GetInt32(0),
                            SubjectName = reader.GetString(1),
                            CourseID = reader.GetInt32(2)
                        };
                    }
                }
            }
            return null; // Not found
        }
    }
}
