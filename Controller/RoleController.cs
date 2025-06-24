using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Management_System.Model;

namespace Student_Management_System.Controller
{
    internal class RoleController
    {

        private SQLiteConnection connection;

        public RoleController(SQLiteConnection dbConnection)
        {
            connection = dbConnection;
        }

        // Add a new role
        public void AddRole(Role role)
        {
            string query = "INSERT INTO Roles (RoleName) VALUES (@RoleName)";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
                cmd.ExecuteNonQuery();
            }
        }

        // Update existing role
        public void UpdateRole(Role role)
        {
            string query = "UPDATE Roles SET RoleName = @RoleName WHERE RoleID = @RoleID";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
                cmd.Parameters.AddWithValue("@RoleID", role.RoleID);
                cmd.ExecuteNonQuery();
            }
        }

        // Delete a role by ID
        public void DeleteRole(int roleID)
        {
            string query = "DELETE FROM Roles WHERE RoleID = @RoleID";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@RoleID", roleID);
                cmd.ExecuteNonQuery();
            }
        }

        // Get all roles
        public List<Role> GetAllRoles()
        {
            var roles = new List<Role>();
            string query = "SELECT RoleID, RoleName FROM Roles";
            using (var cmd = new SQLiteCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    roles.Add(new Role
                    {
                        RoleID = reader.GetInt32(0),
                        RoleName = reader.GetString(1)
                    });
                }
            }
            return roles;
        }

        // Get role by ID
        public Role GetRoleById(int roleID)
        {
            string query = "SELECT RoleID, RoleName FROM Roles WHERE RoleID = @RoleID";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@RoleID", roleID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Role
                        {
                            RoleID = reader.GetInt32(0),
                            RoleName = reader.GetString(1)
                        };
                    }
                }
            }
            return null; // Not found
        }
    }
}

