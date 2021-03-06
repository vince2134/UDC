﻿namespace UDC {
    partial class SecretaryView {
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
            this.calendarViewBtn = new System.Windows.Forms.Button();
            this.agendaViewBtn = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.dateLabel = new System.Windows.Forms.Label();
            this.todayButton = new System.Windows.Forms.Button();
            this.dayRadio = new System.Windows.Forms.RadioButton();
            this.weekRadio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.drListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // calendarViewBtn
            // 
            this.calendarViewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calendarViewBtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendarViewBtn.ForeColor = System.Drawing.Color.Firebrick;
            this.calendarViewBtn.Location = new System.Drawing.Point(526, 12);
            this.calendarViewBtn.Name = "calendarViewBtn";
            this.calendarViewBtn.Size = new System.Drawing.Size(75, 35);
            this.calendarViewBtn.TabIndex = 0;
            this.calendarViewBtn.Text = "Calendar";
            this.calendarViewBtn.UseVisualStyleBackColor = true;
            this.calendarViewBtn.Click += new System.EventHandler(this.dayViewBtn_Click);
            // 
            // agendaViewBtn
            // 
            this.agendaViewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agendaViewBtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agendaViewBtn.ForeColor = System.Drawing.Color.Firebrick;
            this.agendaViewBtn.Location = new System.Drawing.Point(600, 12);
            this.agendaViewBtn.Name = "agendaViewBtn";
            this.agendaViewBtn.Size = new System.Drawing.Size(75, 35);
            this.agendaViewBtn.TabIndex = 1;
            this.agendaViewBtn.Text = "Agenda";
            this.agendaViewBtn.UseVisualStyleBackColor = true;
            this.agendaViewBtn.Click += new System.EventHandler(this.agendaViewBtn_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.ForeColor = System.Drawing.Color.Firebrick;
            this.monthCalendar1.Location = new System.Drawing.Point(9, 84);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            this.monthCalendar1.TitleForeColor = System.Drawing.Color.Firebrick;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.dateLabel.Location = new System.Drawing.Point(356, 24);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(51, 24);
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "Date";
            // 
            // todayButton
            // 
            this.todayButton.BackColor = System.Drawing.Color.Firebrick;
            this.todayButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.todayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.todayButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todayButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.todayButton.Location = new System.Drawing.Point(251, 16);
            this.todayButton.Name = "todayButton";
            this.todayButton.Size = new System.Drawing.Size(75, 32);
            this.todayButton.TabIndex = 5;
            this.todayButton.Text = "Today";
            this.todayButton.UseVisualStyleBackColor = false;
            this.todayButton.Click += new System.EventHandler(this.todayButton_Click);
            // 
            // dayRadio
            // 
            this.dayRadio.AutoSize = true;
            this.dayRadio.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayRadio.ForeColor = System.Drawing.Color.Firebrick;
            this.dayRadio.Location = new System.Drawing.Point(12, 294);
            this.dayRadio.Name = "dayRadio";
            this.dayRadio.Size = new System.Drawing.Size(51, 24);
            this.dayRadio.TabIndex = 7;
            this.dayRadio.TabStop = true;
            this.dayRadio.Text = "Day";
            this.dayRadio.UseVisualStyleBackColor = true;
            this.dayRadio.CheckedChanged += new System.EventHandler(this.dayRadio_CheckedChanged);
            // 
            // weekRadio
            // 
            this.weekRadio.AutoSize = true;
            this.weekRadio.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weekRadio.ForeColor = System.Drawing.Color.Firebrick;
            this.weekRadio.Location = new System.Drawing.Point(12, 317);
            this.weekRadio.Name = "weekRadio";
            this.weekRadio.Size = new System.Drawing.Size(63, 24);
            this.weekRadio.TabIndex = 8;
            this.weekRadio.TabStop = true;
            this.weekRadio.Text = "Week";
            this.weekRadio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 35);
            this.label1.TabIndex = 10;
            this.label1.Text = "Secretary View";
            // 
            // drListBox
            // 
            this.drListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.drListBox.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drListBox.ForeColor = System.Drawing.Color.Firebrick;
            this.drListBox.FormattingEnabled = true;
            this.drListBox.Location = new System.Drawing.Point(93, 258);
            this.drListBox.Name = "drListBox";
            this.drListBox.Size = new System.Drawing.Size(143, 120);
            this.drListBox.TabIndex = 11;
            this.drListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.drListBox_SelectedIndexChanged_1);
            this.drListBox.SelectedIndexChanged += new System.EventHandler(this.drListBox_SelectedIndexChanged_1);
            // 
            // SecretaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(728, 411);
            this.Controls.Add(this.drListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.weekRadio);
            this.Controls.Add(this.dayRadio);
            this.Controls.Add(this.todayButton);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.agendaViewBtn);
            this.Controls.Add(this.calendarViewBtn);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "SecretaryView";
            this.Text = "SecretaryView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SecretaryView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calendarViewBtn;
        private System.Windows.Forms.Button agendaViewBtn;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button todayButton;
        private System.Windows.Forms.RadioButton dayRadio;
        private System.Windows.Forms.RadioButton weekRadio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox drListBox;
    }
}