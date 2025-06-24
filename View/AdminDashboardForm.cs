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
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
        }
        public void LoadForm(object formObj)
        {
            if (this.AdminPanel.Controls.Count > 0)
            {
                this.AdminPanel.Controls.RemoveAt(0);
            }

            Form form = formObj as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.AdminPanel.Controls.Add(form);
            this.AdminPanel.Tag = form;
            form.Show();
        }
        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
           
            
           this.Close();
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            LoadForm(new SubjectForm());
        }

        private void btnTimeTable_Click(object sender, EventArgs e)
        {
            LoadForm(new TimetableForm());
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            LoadForm(new CreateForm());
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
           LoadForm(new CourseForm());
        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            LoadForm(new CourseForm());
        }

        private void btnMarks_Click(object sender, EventArgs e)
        {
            LoadForm(new MarksAddForm());
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            LoadForm(new CreateForm());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
