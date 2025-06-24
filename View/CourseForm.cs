using Student_Management_System.Controller;
using Student_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System.View
{
    public partial class CourseForm : Form
    {
        private CourseController courseController;
        public CourseForm()
        {
            InitializeComponent();

            LoadCourses();

        }
        private void LoadCourses()
        {
            var courses = courseController.GetAllCourses();
            dataGridViewCourse.DataSource = null;
            dataGridViewCourse.DataSource = courses;

            // Optional: Hide CourseID column or make read-only
            dataGridViewCourse.Columns["CourseID"].Visible = false;
            dataGridViewCourse.Columns["CourseName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dataGridViewCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCourse.CurrentRow != null)
            {
                txtCourse.Text = dataGridViewCourse.CurrentRow.Cells["CourseName"].Value.ToString();
            }


        }

        private void CourseForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            string courseName = txtCourse.Text.Trim();

            if (string.IsNullOrEmpty(courseName))
            {
                MessageBox.Show("Please enter a course name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var course = new Course { CourseName = courseName };

            try
            {
                courseController.AddCourse(course);
                LoadCourses();
                txtCourse.Clear();
                MessageBox.Show("Course added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding course: " + ex.Message);
            }
        }

        private void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourse.CurrentRow == null)
            {
                MessageBox.Show("Please select a course to update.");
                return;
            }

            int courseId = (int)dataGridViewCourse.CurrentRow.Cells["CourseID"].Value;
            string courseName = txtCourse.Text.Trim();

            if (string.IsNullOrEmpty(courseName))
            {
                MessageBox.Show("Please enter a course name.");
                return;
            }

            var course = new Course
            {
                CourseID = courseId,
                CourseName = courseName
            };

            try
            {
                courseController.UpdateCourse(course);
                LoadCourses();
                txtCourse.Clear();
                MessageBox.Show("Course updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating course: " + ex.Message);
            }
        }

        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourse.CurrentRow == null)
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }

            int courseId = (int)dataGridViewCourse.CurrentRow.Cells["CourseID"].Value;

            var confirmResult = MessageBox.Show("Are you sure to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    courseController.DeleteCourse(courseId);
                    LoadCourses();
                    txtCourse.Clear();
                    MessageBox.Show("Course deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting course: " + ex.Message);
                }
            }
        }
    }
}

