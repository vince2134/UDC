namespace UDC {
    partial class ClientView {
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
            this.label4 = new System.Windows.Forms.Label();
            this.agendaBtn = new System.Windows.Forms.Button();
            this.dayBtn = new System.Windows.Forms.Button();
            this.dateLabel = new System.Windows.Forms.Label();
            this.todayBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.dayRadioBtn = new System.Windows.Forms.RadioButton();
            this.weekRadioBtn = new System.Windows.Forms.RadioButton();
            this.drListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(-7, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(780, 2);
            this.label4.TabIndex = 24;
            // 
            // agendaBtn
            // 
            this.agendaBtn.BackColor = System.Drawing.Color.White;
            this.agendaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agendaBtn.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agendaBtn.ForeColor = System.Drawing.Color.Black;
            this.agendaBtn.Location = new System.Drawing.Point(658, 10);
            this.agendaBtn.Name = "agendaBtn";
            this.agendaBtn.Size = new System.Drawing.Size(82, 33);
            this.agendaBtn.TabIndex = 23;
            this.agendaBtn.Text = "Agenda";
            this.agendaBtn.UseVisualStyleBackColor = false;
            this.agendaBtn.Click += new System.EventHandler(this.agendaViewBtn_Click);
            this.agendaBtn.MouseEnter += new System.EventHandler(this.agendaBtn_MouseEnter);
            this.agendaBtn.MouseLeave += new System.EventHandler(this.agendaBtn_MouseLeave);
            // 
            // dayBtn
            // 
            this.dayBtn.BackColor = System.Drawing.Color.LightBlue;
            this.dayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dayBtn.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayBtn.ForeColor = System.Drawing.Color.Black;
            this.dayBtn.Location = new System.Drawing.Point(577, 10);
            this.dayBtn.Name = "dayBtn";
            this.dayBtn.Size = new System.Drawing.Size(82, 33);
            this.dayBtn.TabIndex = 22;
            this.dayBtn.Text = "Calendar";
            this.dayBtn.UseVisualStyleBackColor = false;
            this.dayBtn.Click += new System.EventHandler(this.calendarViewBtn_Click);
            this.dayBtn.MouseEnter += new System.EventHandler(this.dayBtn_MouseEnter);
            this.dayBtn.MouseLeave += new System.EventHandler(this.dayBtn_MouseLeave);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(331, 16);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(42, 20);
            this.dateLabel.TabIndex = 21;
            this.dateLabel.Text = "Date";
            // 
            // todayBtn
            // 
            this.todayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.todayBtn.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todayBtn.Location = new System.Drawing.Point(250, 10);
            this.todayBtn.Name = "todayBtn";
            this.todayBtn.Size = new System.Drawing.Size(75, 32);
            this.todayBtn.TabIndex = 20;
            this.todayBtn.Text = "Today";
            this.todayBtn.UseVisualStyleBackColor = true;
            this.todayBtn.Click += new System.EventHandler(this.todayBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 22);
            this.label2.TabIndex = 17;
            this.label2.Text = "Client View";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "View";
            // 
            // monthCalendar
            // 
            this.monthCalendar.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar.Location = new System.Drawing.Point(10, 97);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 14;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected_1);
            // 
            // dayRadioBtn
            // 
            this.dayRadioBtn.AutoSize = true;
            this.dayRadioBtn.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayRadioBtn.Location = new System.Drawing.Point(12, 293);
            this.dayRadioBtn.Name = "dayRadioBtn";
            this.dayRadioBtn.Size = new System.Drawing.Size(51, 24);
            this.dayRadioBtn.TabIndex = 25;
            this.dayRadioBtn.TabStop = true;
            this.dayRadioBtn.Text = "Day";
            this.dayRadioBtn.UseVisualStyleBackColor = true;
            this.dayRadioBtn.CheckedChanged += new System.EventHandler(this.dayRadioBtn_CheckedChanged);
            // 
            // weekRadioBtn
            // 
            this.weekRadioBtn.AutoSize = true;
            this.weekRadioBtn.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weekRadioBtn.Location = new System.Drawing.Point(12, 323);
            this.weekRadioBtn.Name = "weekRadioBtn";
            this.weekRadioBtn.Size = new System.Drawing.Size(63, 24);
            this.weekRadioBtn.TabIndex = 26;
            this.weekRadioBtn.TabStop = true;
            this.weekRadioBtn.Text = "Week";
            this.weekRadioBtn.UseVisualStyleBackColor = true;
            this.weekRadioBtn.CheckedChanged += new System.EventHandler(this.weekRadioBtn_CheckedChanged);
            // 
            // drListBox
            // 
            this.drListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.drListBox.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drListBox.FormattingEnabled = true;
            this.drListBox.Location = new System.Drawing.Point(94, 268);
            this.drListBox.Name = "drListBox";
            this.drListBox.Size = new System.Drawing.Size(143, 120);
            this.drListBox.TabIndex = 27;
            this.drListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.drListBox_SelectedIndexChanged_1);
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(756, 448);
            this.Controls.Add(this.drListBox);
            this.Controls.Add(this.weekRadioBtn);
            this.Controls.Add(this.dayRadioBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.agendaBtn);
            this.Controls.Add(this.dayBtn);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.todayBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar);
<<<<<<< HEAD
            this.MaximumSize = new System.Drawing.Size(772, 450);
            this.MinimumSize = new System.Drawing.Size(772, 450);
=======
            this.MaximumSize = new System.Drawing.Size(772, 487);
            this.MinimumSize = new System.Drawing.Size(772, 487);
>>>>>>> 98e93a734695764e633c3445ad1c26a84aa51013
            this.Name = "ClientView";
            this.Text = "ClientView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button agendaBtn;
        private System.Windows.Forms.Button dayBtn;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button todayBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.MonthCalendar monthCalendar;
        public System.Windows.Forms.RadioButton dayRadioBtn;
        public System.Windows.Forms.RadioButton weekRadioBtn;
        private System.Windows.Forms.CheckedListBox drListBox;
    }
}