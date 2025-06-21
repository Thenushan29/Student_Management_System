using Student_Management_System.Data;
using Student_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Controller
{
    internal class CourseController
    {



        private SQLiteConnection connection;

        public CourseController(SQLiteConnection dbConnection)
        {
            connection = dbConnection;
        }

        // Add a new course
        public void AddCourse(Course course)
        {
            string query = "INSERT INTO Courses (CourseName) VALUES (@CourseName)";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.ExecuteNonQuery();
            }
        }

        // Update existing course
        public void UpdateCourse(Course course)
        {
            string query = "UPDATE Courses SET CourseName = @CourseName WHERE CourseID = @CourseID";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.Parameters.AddWithValue("@CourseID", course.CourseID);
                cmd.ExecuteNonQuery();
            }
        }

        // Delete a course by ID
        public void DeleteCourse(int courseID)
        {
            string query = "DELETE FROM Courses WHERE CourseID = @CourseID";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CourseID", courseID);
                cmd.ExecuteNonQuery();
            }
        }

        // Get all courses
        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>();
            string query = "SELECT CourseID, CourseName FROM Courses";
            using (var cmd = new SQLiteCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    courses.Add(new Course
                    {
                        CourseID = reader.GetInt32(0),
                        CourseName = reader.GetString(1)
                    });
                }
            }
            return courses;
        }

        // Get course by ID
        public Course GetCourseById(int courseID)
        {
            string query = "SELECT CourseID, CourseName FROM Courses WHERE CourseID = @CourseID";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@CourseID", courseID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Course
                        {
                            CourseID = reader.GetInt32(0),
                            CourseName = reader.GetString(1)
                        };
                    }
                }
            }
            return null; // not found
        }
    }
}



   
