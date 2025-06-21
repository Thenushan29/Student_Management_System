using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Student_Management_System.Model;

namespace Student_Management_System.Controller
{
    internal class AdminController
    {
        private SQLiteConnection connection;

        public AdminController(SQLiteConnection dbConnection)
        {
            connection = dbConnection;
        }

        // Add new Admin
        public void AddAdmin(Admin admin)
        {
            string query = @"
                INSERT INTO Admins (AdminName, UserName, Password, PhoneNumber, Address)
                VALUES (@AdminName, @UserName, @Password, @PhoneNumber, @Address)";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AdminName", admin.AdminName);
                cmd.Parameters.AddWithValue("@UserName", admin.UserName);
                cmd.Parameters.AddWithValue("@Password", admin.Password);
                cmd.Parameters.AddWithValue("@PhoneNumber", admin.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", admin.Address);
                cmd.ExecuteNonQuery();
            }
        }

        // Update existing Admin
        public void UpdateAdmin(Admin admin)
        {

            if (admin.PhoneNumber == null || admin.PhoneNumber.Length != 10 || !admin.PhoneNumber.All(char.IsDigit))
            {
                throw new ArgumentException("Phone number must be exactly 10 digits and numeric.");
            }

            string query = @"
                UPDATE Admins SET 
                    AdminName = @AdminName,
                    UserName = @UserName,
                    Password = @Password,
                    PhoneNumber = @PhoneNumber,
                    Address = @Address
                WHERE AdminID = @AdminID";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AdminName", admin.AdminName);
                cmd.Parameters.AddWithValue("@UserName", admin.UserName);
                cmd.Parameters.AddWithValue("@Password", admin.Password);
                cmd.Parameters.AddWithValue("@PhoneNumber", admin.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", admin.Address);
                cmd.Parameters.AddWithValue("@AdminID", admin.AdminID);
                cmd.ExecuteNonQuery();
            }
        }

        // Delete Admin by ID
        public void DeleteAdmin(int adminID)
        {
            string query = "DELETE FROM Admins WHERE AdminID = @AdminID";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AdminID", adminID);
                cmd.ExecuteNonQuery();
            }
        }

        // Get Admin by ID
        public Admin GetAdminById(int adminID)
        {
            string query = @"
                SELECT AdminID, AdminName, UserName, Password, PhoneNumber, Address 
                FROM Admins 
                WHERE AdminID = @AdminID";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@AdminID", adminID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Admin
                        {
                            AdminID = reader.GetInt32(0),
                            AdminName = reader.GetString(1),
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

        // Get all Admins
        public List<Admin> GetAllAdmins()
        {
            var admins = new List<Admin>();
            string query = "SELECT AdminID, AdminName, UserName, Password, PhoneNumber, Address FROM Admins";

            using (var cmd = new SQLiteCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    admins.Add(new Admin
                    {
                        AdminID = reader.GetInt32(0),
                        AdminName = reader.GetString(1),
                        UserName = reader.GetString(2),
                        Password = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        Address = reader.GetString(5)
                    });
                }
            }
            return admins;
        }
    }
}
                                        