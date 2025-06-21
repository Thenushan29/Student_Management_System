using Student_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Controller
{
    internal class MarksController
    {
        private readonly string _connectionString;

        public MarksController(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Mark> GetAllMarks()
        {
            var marks = new List<Mark>();

            using (var conn = new SQLiteConnection(_connectionString))
            {
                string query = "SELECT * FROM Marks";
                var cmd = new SQLiteCommand(query, conn);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        marks.Add(new Mark
                        {

                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            ExamID = Convert.ToInt32(reader["ExamId"]),
                            SubjectID = Convert.ToInt32(reader["SubjectId"]),
                            SubjectName = Convert.ToString(reader["SubjectName"]),
                            StudentName = Convert.ToString(reader["StudentName"]),
                            ExamName = Convert.ToString(reader["ExameName"]),
                            MarkValue = Convert.ToInt32(reader["Mark"])
                        });
                    }
                }
            }

            return marks;
        }

        public Mark GetMarkById(int id)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                string query = "SELECT * FROM Marks ";
                var cmd = new SQLiteCommand(query, conn);
                //cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Mark
                        {

                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            StudentName = Convert.ToString(reader["StudentName"]),
                            ExamID = Convert.ToInt32(reader["ExamId"]),
                            ExamName = Convert.ToString(reader["ExamName"]),
                            SubjectID = Convert.ToInt32(reader["SubjectID"]),
                            SubjectName = Convert.ToString(reader["SubjectName"]),
                            MarkValue = Convert.ToInt32(reader["Mark"])
                        };
                    }
                }
            }
            return null;
        }

        public bool AddMark(Mark mark)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                string query = "INSERT INTO Marks (StudentId, StudentName, ExamId, ExamName, SubjectId, SubjectName, Mark) VALUES (@studentid, @studentname, @examid, @examname,@subjectid, @subjectname, @mark)";
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@studentid", mark.StudentId);
                cmd.Parameters.AddWithValue("@ExamId", mark.ExamID);
                cmd.Parameters.AddWithValue("@Score", mark.MarkValue);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateMark(Mark mark)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                string query = "UPDATE Marks SET StudentId = @StudentId, ExamId = @ExamId, Score = @Score WHERE Id = @Id";
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", mark.StudentId);
                cmd.Parameters.AddWithValue("@ExamId", mark.ExamID);
                cmd.Parameters.AddWithValue("@Score", mark.MarkValue);


                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteMark(int id)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                string query = "DELETE FROM Marks WHERE Id = @Id";
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}


