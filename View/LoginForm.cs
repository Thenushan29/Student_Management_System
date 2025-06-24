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
        private LoginController loginController;

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

            var connection = new SQLiteConnection("Data Source=student_management.db;Version=3;");
            connection.Open();
            loginController = new LoginController(connection);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Optional: Any initialization logic
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password." );
                return;
            }

            var (role, user) = loginController.AuthenticateUser(username, password);

            switch (role)
            {
                case LoginController.UserRole.Admin:
                    AdminDashboardForm adminDashboardForm = new AdminDashboardForm();
                    adminDashboardForm.ShowDialog();

                    break;

                case LoginController.UserRole.Staff:
                    StaffDashboardForm staffDashboardForm = new StaffDashboardForm();
                    staffDashboardForm.ShowDialog();
                    break;

                case LoginController.UserRole.Lecturer:
                    StaffDashboardForm staffDashboard = new StaffDashboardForm();
                    staffDashboard.ShowDialog();
                    break;

                case LoginController.UserRole.Student:
                    StudentDashboardForm studentDashboardForm = new StudentDashboardForm();
                    studentDashboardForm.ShowDialog();
                    break;

                case LoginController.UserRole.None:
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            // Optional: Real-time validation or suggestions
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: Handle role-specific behavior here
        }
    }
}
