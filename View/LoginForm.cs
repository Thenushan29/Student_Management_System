using Student_Management_System.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            comboBoxRole.Items.Clear();
            comboBoxRole.Items.Add("Admin");
            comboBoxRole.Items.Add("Student");
            comboBoxRole.Items.Add("Lecturer");
            comboBoxRole.Items.Add("Staff");

            if (comboBoxRole.Items.Count > 0)
            {
                comboBoxRole.SelectedIndex = 0;
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
                try
                {
                    // Get the username and password from the text boxes
                    string username = txtUserName.Text.Trim();
                    string password = txtPassword.Text;

                    // Validate inputs
                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Please enter both username and password.", "Validation Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Authenticate user using the LoginController
                    var (role, user) =LoginController.AuthenticateUser(username, password);

                    if (role != LoginController.UserRole.None && user != null)
                    {
                        // Store user info in a static class for session management
                        CurrentUser.Role = role;
                        CurrentUser.UserObject = user;

                        // Hide the login form
                        this.Hide();

                        // Open the appropriate form based on user role
                        switch (role)
                        {
                            case LoginController.UserRole.Admin:
                                var adminForm = new AdminDashboardForm();
                                adminForm.Show();
                                break;
                            case LoginController.UserRole.Staff:
                            var staffForm = new StaffDashboardForm();
                                staffForm.Show();
                                break;
                            case LoginController.UserRole.Lecturer:
                                var lecturerForm = new StaffDashboardForm();
                                lecturerForm.Show();
                                break;
                            case LoginController.UserRole.Student:
                                var studentForm = new StudentDashboardForm();
                           
                                studentForm.Show();
                                break;
                        }
                    }
                    else
                    {
                        // Show error message for invalid credentials
                        MessageBox.Show("Invalid username or password. Please try again.",
                                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtUserName.Focus();
                    }
                }
                catch (SQLiteException ex)
                {
                    // Handle database-related errors
                    MessageBox.Show($"Database error: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Handle any other errors
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            





            this.Hide();
            AdminDashboardForm dashboardForm = new AdminDashboardForm();
            dashboardForm.Show();

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        } 
                                              

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
