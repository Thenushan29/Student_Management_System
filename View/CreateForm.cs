using Student_Management_System.Controller;
using Student_Management_System.Model;
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
    public partial class CreateForm : Form
    {

        private RoleController roleController;
       

        private void CreateForm_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }
        private void LoadRole() 
        {
            List<string> roleNames = new List<string> { "Admin", "Teacher", "Student", "Lecture" };
            comboBoxRole.DataSource = roleNames;

        }
        private void btnAddRole_Click(object sender, EventArgs e)
        {
            string roleName = txtName.Text.Trim();

            if (string.IsNullOrEmpty(roleName))
            {
                MessageBox.Show("Please enter a role name.");
                return;
            }

            try
            {
                var role = new Role { RoleName = roleName };
                roleController.AddRole(role);

                MessageBox.Show("Role saved!");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving role: " + ex.Message);
            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
     
        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            string roleName = txtName.Text.Trim();

            if (string.IsNullOrEmpty(roleName))
            {
                MessageBox.Show("Please enter a role name.");
                return;
            }

            try
            {
                var role = new Role {  RoleName = roleName };
                roleController.UpdateRole(role);

                MessageBox.Show("Role updated!");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating role: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            var confirm = MessageBox.Show("Are you sure you want to delete this role?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                
            }
        }
    }
}
