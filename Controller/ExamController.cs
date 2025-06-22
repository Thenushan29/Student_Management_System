using Student_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Controller
{
    internal class ExamController
    {
        private readonly string _connectionString;

        public ExamController(string connectionString)
        {
            _connectionString = connectionString;
        }           

        public List<Exam> GetAllExams()
        {
            List<Exam> exams = new List<Exam>();

            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                string query = "SELECT * FROM Exams";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                conn.Open();

                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    exams.Add(new Exam
                    {
                        ExamID = (int)reader["ExamId"],
                        ExamName = reader["ExamName"].ToString(),
                        SubjectID = (int)reader["SubjectId"],
                        SubjectName = reader["SubjectName"].ToString()
                    });
                }
            }

            return exams;
        }

        public bool AddExam(Exam exam)
        {
            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                string query = "INSERT INTO Exams (ExamName, SubjectId,  SubjectName ) VALUES (@examname, @subjectid, @subjectname)";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@examname", exam.ExamName);
                cmd.Parameters.AddWithValue("@subjectid", exam.SubjectID);
                cmd.Parameters.AddWithValue("@subjectname", exam.SubjectName);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateExam(Exam exam)
        {
            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                string query = "UPDATE Exams SET ExamName = @examname,  SubjectId = @SubjectId WHERE ExamId = @examid";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@examname", exam.ExamName);
                cmd.Parameters.AddWithValue("@subjectid", exam.SubjectID);
                cmd.Parameters.AddWithValue("@examid", exam.ExamID);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteExam(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                string query = "DELETE FROM Exams WHERE ExamId = @examid";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@examid", id);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Exam GetExamById(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                string query = "SELECT * FROM Exams WHERE ExamId = @examid";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@examid", id);

                conn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Exam
                    {
                        ExamID = (int)reader["ExamId"],
                        ExamName = reader["ExamName"].ToString(),
                        SubjectID = (int)reader["SubjectId"],
                        SubjectName = reader["SubjectName"].ToString()
                    };
                }
            }

            return null;
        }
    }
}

