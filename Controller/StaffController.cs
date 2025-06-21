using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Student_Management_System.Model;

namespace Student_Management_System.Controller
{
    internal class StaffController
    {
        private SQLiteConnection connection;

        public StaffController(SQLiteConnection dbConnection)
        {
            connection = dbConnection;
        }

        // Add new Staff
        public void AddStaff(Staff staff)
        {
            if (staff.PhoneNumber == null || staff.PhoneNumber.Length != 10 || !staff.PhoneNumber.All(char.IsDigit))
            {
                throw new ArgumentException("Phone number must be exactly 10 digits and numeric.");
            }

            string query = @"
                INSERT INTO Staffs (StaffName, UserName, Password, PhoneNumber, Address)
                VALUES (@StaffName, @UserName, @Password, @PhoneNumber, @Address)";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@StaffName", staff.StaffName);
                cmd.Parameters.AddWithValue("@UserName", staff.UserName);
                cmd.Parameters.AddWithValue("@Password", staff.Password);
                cmd.Parameters.AddWithValue("@PhoneNumber", staff.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", staff.Address);
                cmd.ExecuteNonQuery();
            }
        }

        // Update existing Staff
        public void UpdateStaff(Staff staff)
        {
            string query = @"
                UPDATE Staffs SET 
                    StaffName = @StaffName,
                    UserName = @UserName,
                    Password = @Password,
                    PhoneNumber = @PhoneNumber,
                    Address = @Address
                WHERE StaffID = @StaffID";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@StaffName", staff.StaffName);
                cmd.Parameters.AddWithValue("@UserName", staff.UserName);
                cmd.Parameters.AddWithValue("@Password", staff.Password);
                cmd.Parameters.AddWithValue("@PhoneNumber", staff.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", staff.Address);
                cmd.Parameters.AddWithValue("@StaffID", staff.StaffID);
                cmd.ExecuteNonQuery();
            }
        }

        // Delete Staff by ID
        public void DeleteStaff(int staffID)
        {
            string query = "DELETE FROM Staffs WHERE StaffID = @StaffID";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@StaffID", staffID);
                cmd.ExecuteNonQuery();
            }
        }

        // Get Staff by ID
        public Staff GetStaffById(int staffID)
        {
            string query = "SELECT StaffID, StaffName, UserName, Password, PhoneNumber, Address FROM Staffs WHERE StaffID = @StaffID";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@StaffID", staffID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Staff
                        {
                            StaffID = reader.GetInt32(0),
                            StaffName = reader.GetString(1),
                            UserName = reader.GetString(2),
                            Password = reader.GetString(3),
                            PhoneNumber = reader.GetString(4),
                            Address = reader.GetString(5)
                        };
                    }
                }
            }

            return null; // Not found
        }

        // Get all Staffs
        public List<Staff> GetAllStaffs()
        {
            var staffs = new List<Staff>();
            string query = "SELECT StaffID, StaffName, UserName, Password, PhoneNumber, Address FROM Staffs";

            using (var cmd = new SQLiteCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    staffs.Add(new Staff
                    {
                        StaffID = reader.GetInt32(0),
                        StaffName = reader.GetString(1),
                        UserName = reader.GetString(2),
                        Password = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        Address = reader.GetString(5)
                    });
                }
            }
            return staffs;
        }
    }
}
