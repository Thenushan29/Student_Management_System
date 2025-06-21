using System.Data.SQLite;
using Student_Management_System.Model;

namespace Student_Management_System.Controller
{
    internal class LoginController
    {
        private SQLiteConnection connection;

        public LoginController(SQLiteConnection conn)
        {
            connection = conn;
        }

        // User role enum
        public enum UserRole
        {
            Admin,
            Staff,
            Lecturer,
            Student,
            None
        }

        public (UserRole role, object user) AuthenticateUser(string username, string password)
        {
            // You can add password hashing checks here instead of plain text comparison

            // Check Admins
            var admin = CheckAdmin(username, password);
            if (admin != null) return (UserRole.Admin, admin);

            // Check Staffs
            var staff = CheckStaff(username, password);
            if (staff != null) return (UserRole.Staff, staff);

            // Check Lecturers
            var lecturer = CheckLecturer(username, password);
            if (lecturer != null) return (UserRole.Lecturer, lecturer);

            // Check Students
            var student = CheckStudent(username, password);
            if (student != null) return (UserRole.Student, student);

            return (UserRole.None, null);
        }

        private Admin CheckAdmin(string username, string password)
        {
            string query = "SELECT * FROM Admins WHERE UserName = @UserName AND Password = @Password";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Admin
                        {
                            AdminID = reader.GetInt32(0),
                            AdminName = reader.GetString(1),
                            UserName = reader.GetString(3),
                            Password = reader.GetString(4),
                            PhoneNumber = reader.GetString(5),
                            Address = reader.GetString(6)
                        };
                    }
                }
            }
            return null;
        }

        private Staff CheckStaff(string username, string password)
        {
            string query = "SELECT * FROM Staffs WHERE UserName = @UserName AND Password = @Password";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Staff
                        {
                            StaffID = reader.GetInt32(0),
                            StaffName = reader.GetString(1),
                            UserName = reader.GetString(3),
                            Password = reader.GetString(4),
                            PhoneNumber = reader.GetString(5),
                            Address = reader.GetString(6)
                        };
                    }
                }
            }
            return null;
        }

        private Lecturer CheckLecturer(string username, string password)
        {
            string query = "SELECT * FROM Lecturers WHERE UserName = @UserName AND Password = @Password";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Lecturer
                        {
                            LecturersID = reader.GetInt32(0),
                            LecturersName = reader.GetString(1),
                            UserName = reader.GetString(3),
                            Password = reader.GetString(4),
                            PhoneNumber = reader.GetString(5),
                            Address = reader.GetString(6)
                        };
                    }
                }
            }
            return null;
        }

        private Student CheckStudent(string username, string password)
        {
            string query = "SELECT * FROM Students WHERE UserName = @UserName AND Password = @Password";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Student
                        {
                            StudentID = reader.GetInt32(0),
                            StudentName = reader.GetString(1),
                            UserName = reader.GetString(2),
                            Password = reader.GetString(5),
                            PhoneNumber = reader.GetString(3),
                            Address = reader.GetString(4),
                            // You can fetch CourseID and SubjectID if needed
                        };
                    }
                }
            }
            return null;
        }
    }
}
