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
    public partial class StudentDashboardForm : Form
    {
        public StudentDashboardForm()
        {
            InitializeComponent();
        }
        public void LoadForm(object formObj)
        {
            if (this.StudentPanel.Controls.Count > 0)
            {
                this.StudentPanel.Controls.RemoveAt(0);
            }

            Form form = formObj as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.StudentPanel.Controls.Add(form);
            this.StudentPanel.Tag = form;
            form.Show();
        }

        private void StudentDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            LoadForm(new TimetableViewForm());
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            LoadForm(new SubjectViewForm());
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            LoadForm(new CourseViewForm());
        }

        private void btnMarks_Click(object sender, EventArgs e)
        {
            LoadForm(new MarksViewForm());
        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            LoadForm(new ExamViewForm());   
        }
    }
}
