namespace UDC {
    partial class DoctorView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.agendaViewBtn = new System.Windows.Forms.Button();
            this.dayViewBtn = new System.Windows.Forms.Button();
            this.createViewBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.doctorName = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dailyBtn = new System.Windows.Forms.RadioButton();
            this.weeklyBtn = new System.Windows.Forms.RadioButton();
            this.currentDate = new System.Windows.Forms.Label();
            this.todayBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // agendaViewBtn
            // 
            this.agendaViewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agendaViewBtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agendaViewBtn.Location = new System.Drawing.Point(631, 12);
            this.agendaViewBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.agendaViewBtn.Name = "agendaViewBtn";
            this.agendaViewBtn.Size = new System.Drawing.Size(87, 39);
            this.agendaViewBtn.TabIndex = 1;
            this.agendaViewBtn.Text = "Agenda";
            this.agendaViewBtn.UseVisualStyleBackColor = true;
            this.agendaViewBtn.Click += new System.EventHandler(this.agendaViewBtn_Click);
            // 
            // dayViewBtn
            // 
            this.dayViewBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dayViewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dayViewBtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayViewBtn.Location = new System.Drawing.Point(558, 12);
            this.dayViewBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dayViewBtn.Name = "dayViewBtn";
            this.dayViewBtn.Size = new System.Drawing.Size(80, 39);
            this.dayViewBtn.TabIndex = 2;
            this.dayViewBtn.Text = "Calendar";
            this.dayViewBtn.UseVisualStyleBackColor = false;
            this.dayViewBtn.Click += new System.EventHandler(this.dayViewBtn_Click);
            // 
            // createViewBtn
            // 
            this.createViewBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.createViewBtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createViewBtn.ForeColor = System.Drawing.Color.White;
            this.createViewBtn.Location = new System.Drawing.Point(20, 75);
            this.createViewBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.createViewBtn.Name = "createViewBtn";
            this.createViewBtn.Size = new System.Drawing.Size(227, 39);
            this.createViewBtn.TabIndex = 3;
            this.createViewBtn.Text = "Set an Appointment Slot";
            this.createViewBtn.UseVisualStyleBackColor = false;
            this.createViewBtn.Click += new System.EventHandler(this.createViewBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hi!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // doctorName
            // 
            this.doctorName.AutoSize = true;
            this.doctorName.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctorName.ForeColor = System.Drawing.Color.Blue;
            this.doctorName.Location = new System.Drawing.Point(54, 22);
            this.doctorName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.doctorName.Name = "doctorName";
            this.doctorName.Size = new System.Drawing.Size(102, 22);
            this.doctorName.TabIndex = 5;
            this.doctorName.Text = "doctorName";
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(21, 119);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(-1, -7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(732, 68);
            this.label4.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(-1, -7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 422);
            this.label3.TabIndex = 15;
            // 
            // dailyBtn
            // 
            this.dailyBtn.AutoSize = true;
            this.dailyBtn.Checked = true;
            this.dailyBtn.Location = new System.Drawing.Point(45, 293);
            this.dailyBtn.Name = "dailyBtn";
            this.dailyBtn.Size = new System.Drawing.Size(63, 26);
            this.dailyBtn.TabIndex = 16;
            this.dailyBtn.TabStop = true;
            this.dailyBtn.Text = "Daily";
            this.dailyBtn.UseVisualStyleBackColor = true;
            // 
            // weeklyBtn
            // 
            this.weeklyBtn.AutoSize = true;
            this.weeklyBtn.Location = new System.Drawing.Point(141, 293);
            this.weeklyBtn.Name = "weeklyBtn";
            this.weeklyBtn.Size = new System.Drawing.Size(80, 26);
            this.weeklyBtn.TabIndex = 17;
            this.weeklyBtn.Text = "Weekly";
            this.weeklyBtn.UseVisualStyleBackColor = true;
            // 
            // currentDate
            // 
            this.currentDate.AutoSize = true;
            this.currentDate.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentDate.Location = new System.Drawing.Point(350, 21);
            this.currentDate.Name = "currentDate";
            this.currentDate.Size = new System.Drawing.Size(43, 22);
            this.currentDate.TabIndex = 18;
            this.currentDate.Text = "date";
            // 
            // todayBtn
            // 
            this.todayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.todayBtn.Location = new System.Drawing.Point(264, 14);
            this.todayBtn.Name = "todayBtn";
            this.todayBtn.Size = new System.Drawing.Size(80, 37);
            this.todayBtn.TabIndex = 19;
            this.todayBtn.Text = "Today";
            this.todayBtn.UseVisualStyleBackColor = true;
            // 
            // DoctorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(728, 411);
            this.Controls.Add(this.todayBtn);
            this.Controls.Add(this.currentDate);
            this.Controls.Add(this.weeklyBtn);
            this.Controls.Add(this.dailyBtn);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.doctorName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createViewBtn);
            this.Controls.Add(this.dayViewBtn);
            this.Controls.Add(this.agendaViewBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DoctorView";
            this.Text = "Doctor View";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DoctorView_FormClosed);
            this.Load += new System.EventHandler(this.DoctorView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button agendaViewBtn;
        private System.Windows.Forms.Button dayViewBtn;
        private System.Windows.Forms.Button createViewBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label doctorName;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton dailyBtn;
        private System.Windows.Forms.RadioButton weeklyBtn;
        private System.Windows.Forms.Label currentDate;
        private System.Windows.Forms.Button todayBtn;
    }
}

