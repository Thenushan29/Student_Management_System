using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Student_Management_System.Model;

namespace Student_Management_System.Controller
{
    internal class LecturerController
    {
        private SQLiteConnection connection;

        public LecturerController(SQLiteConnection dbConnection)
        {
            connection = dbConnection;
        }

        // Add new Lecturer
        public void AddLecturer(Lecturer lecturer)
        {
            if (lecturer.PhoneNumber == null || lecturer.PhoneNumber.Length != 10 || !lecturer.PhoneNumber.All(char.IsDigit))
            {
                throw new ArgumentException("Phone number must be exactly 10 digits and numeric.");
            }

            string query = @"
                INSERT INTO Lecturers (LecturersName, UserName, Password, PhoneNumber, Address)
                VALUES (@LecturersName, @UserName, @Password, @PhoneNumber, @Address)";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@LecturersName", lecturer.LecturersName);
                cmd.Parameters.AddWithValue("@UserName", lecturer.UserName);
                cmd.Parameters.AddWithValue("@Password", lecturer.Password);
                cmd.Parameters.AddWithValue("@PhoneNumber", lecturer.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", lecturer.Address);
                cmd.ExecuteNonQuery();
            }
        }

        // Update existing Lecturer
        public void UpdateLecturer(Lecturer lecturer)
        {
            string query = @"
                UPDATE Lecturers SET 
                    LecturersName = @LecturersName,
                    UserName = @UserName,
                    Password = @Password,
                    PhoneNumber = @PhoneNumber,
                    Address = @Address
                WHERE LecturersID = @LecturersID";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@LecturersName", lecturer.LecturersName);
                cmd.Parameters.AddWithValue("@UserName", lecturer.UserName);
                cmd.Parameters.AddWithValue("@Password", lecturer.Password);
                cmd.Parameters.AddWithValue("@PhoneNumber", lecturer.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", lecturer.Address);
                cmd.Parameters.AddWithValue("@LecturersID", lecturer.LecturersID);
                cmd.ExecuteNonQuery();
            }
        }

        // Delete Lecturer by ID
        public void DeleteLecturer(int lecturerId)
        {
            string query = "DELETE FROM Lecturers WHERE LecturersID = @LecturersID";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@LecturersID", lecturerId);
                cmd.ExecuteNonQuery();
            }
        }

        // Get Lecturer by ID
        public Lecturer GetLecturerById(int lecturerId)
        {
            string query = @"
                SELECT LecturersID, LecturersName, UserName, Password, PhoneNumber, Address 
                FROM Lecturers 
                WHERE LecturersID = @LecturersID";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@LecturersID", lecturerId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Lecturer
                        {
                            LecturersID = reader.GetInt32(0),
                            LecturersName = reader.GetString(1),
                            UserName = reader.GetString(2),
                            Password = reader.GetString(3),
                            PhoneNumber = reader.GetString(4),
                            Address = reader.GetString(5)
                        };
                    }
                }
            }
            return null;
        }

        // Get all Lecturers
        public List<Lecturer> GetAllLecturers()
        {
            var lecturers = new List<Lecturer>();
            string query = "SELECT LecturersID, LecturersName, UserName, Password, PhoneNumber, Address FROM Lecturers";

            using (var cmd = new SQLiteCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lecturers.Add(new Lecturer
                    {
                        LecturersID = reader.GetInt32(0),
                        LecturersName = reader.GetString(1),
                        UserName = reader.GetString(2),
                        Password = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        Address = reader.GetString(5)
                    });
                }
            }
            return lecturers;
        }
    }
}
