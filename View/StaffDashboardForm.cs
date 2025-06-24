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
    public partial class StaffDashboardForm : Form
    {
        public StaffDashboardForm()
        {
            InitializeComponent();
        }
        public void LoadForm(object formObj)
        {
            if (this.StaffPanel.Controls.Count > 0)
            {
                this.StaffPanel.Controls.RemoveAt(0);
            }

            Form form = formObj as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.StaffPanel.Controls.Add(form);
            this.StaffPanel.Tag = form;
            form.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StaffDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            LoadForm(new TimetableViewForm());
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            LoadForm(new StudentCreateForm());
        }

        private void btnMarks_Click(object sender, EventArgs e)
        {
            LoadForm(new MarksAddForm());
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            LoadForm(new SubjectForm());    
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            LoadForm(new CourseForm());
        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            LoadForm(new ExamForm());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
