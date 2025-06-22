namespace Student_Management_System.View
{
    partial class TimetableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewTimetable = new System.Windows.Forms.DataGridView();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.btnUpdateTimetable = new System.Windows.Forms.Button();
            this.btnDeleteTimetable = new System.Windows.Forms.Button();
            this.btnAddTimetable = new System.Windows.Forms.Button();
            this.comboBoxSubject = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimetable)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTimetable
            // 
            this.dataGridViewTimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTimetable.Location = new System.Drawing.Point(59, 108);
            this.dataGridViewTimetable.Name = "dataGridViewTimetable";
            this.dataGridViewTimetable.Size = new System.Drawing.Size(578, 204);
            this.dataGridViewTimetable.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(23, 345);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(23, 377);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(30, 13);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "Time";
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(23, 411);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(35, 13);
            this.lblRoom.TabIndex = 1;
            this.lblRoom.Text = "Room";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(257, 349);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(43, 13);
            this.lblSubject.TabIndex = 1;
            this.lblSubject.Text = "Subject";
            // 
            // txtRoom
            // 
            this.txtRoom.Location = new System.Drawing.Point(84, 404);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(125, 20);
            this.txtRoom.TabIndex = 2;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(84, 374);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(125, 20);
            this.txtTime.TabIndex = 2;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(84, 342);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(125, 20);
            this.txtDate.TabIndex = 2;
            // 
            // btnUpdateTimetable
            // 
            this.btnUpdateTimetable.Location = new System.Drawing.Point(525, 379);
            this.btnUpdateTimetable.Name = "btnUpdateTimetable";
            this.btnUpdateTimetable.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateTimetable.TabIndex = 3;
            this.btnUpdateTimetable.Text = "Update";
            this.btnUpdateTimetable.UseVisualStyleBackColor = true;
            // 
            // btnDeleteTimetable
            // 
            this.btnDeleteTimetable.Location = new System.Drawing.Point(626, 379);
            this.btnDeleteTimetable.Name = "btnDeleteTimetable";
            this.btnDeleteTimetable.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTimetable.TabIndex = 3;
            this.btnDeleteTimetable.Text = "Delete";
            this.btnDeleteTimetable.UseVisualStyleBackColor = true;
            // 
            // btnAddTimetable
            // 
            this.btnAddTimetable.Location = new System.Drawing.Point(414, 379);
            this.btnAddTimetable.Name = "btnAddTimetable";
            this.btnAddTimetable.Size = new System.Drawing.Size(75, 23);
            this.btnAddTimetable.TabIndex = 3;
            this.btnAddTimetable.Text = "Add";
            this.btnAddTimetable.UseVisualStyleBackColor = true;
            // 
            // comboBoxSubject
            // 
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.Location = new System.Drawing.Point(325, 345);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSubject.TabIndex = 4;
            // 
            // TimetableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxSubject);
            this.Controls.Add(this.btnAddTimetable);
            this.Controls.Add(this.btnDeleteTimetable);
            this.Controls.Add(this.btnUpdateTimetable);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dataGridViewTimetable);
            this.Name = "TimetableForm";
            this.Text = "TimetableForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimetable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTimetable;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Button btnUpdateTimetable;
        private System.Windows.Forms.Button btnDeleteTimetable;
        private System.Windows.Forms.Button btnAddTimetable;
        private System.Windows.Forms.ComboBox comboBoxSubject;
    }
}