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
            this.SuspendLayout();
            // 
            // agendaViewBtn
            // 
            this.agendaViewBtn.Location = new System.Drawing.Point(106, 226);
            this.agendaViewBtn.Name = "agendaViewBtn";
            this.agendaViewBtn.Size = new System.Drawing.Size(75, 23);
            this.agendaViewBtn.TabIndex = 1;
            this.agendaViewBtn.Text = "agendaView";
            this.agendaViewBtn.UseVisualStyleBackColor = true;
            this.agendaViewBtn.Click += new System.EventHandler(this.agendaViewBtn_Click);
            // 
            // dayViewBtn
            // 
            this.dayViewBtn.Location = new System.Drawing.Point(25, 226);
            this.dayViewBtn.Name = "dayViewBtn";
            this.dayViewBtn.Size = new System.Drawing.Size(75, 23);
            this.dayViewBtn.TabIndex = 2;
            this.dayViewBtn.Text = "dayView";
            this.dayViewBtn.UseVisualStyleBackColor = true;
            this.dayViewBtn.Click += new System.EventHandler(this.dayViewBtn_Click);
            // 
            // createViewBtn
            // 
            this.createViewBtn.Location = new System.Drawing.Point(187, 226);
            this.createViewBtn.Name = "createViewBtn";
            this.createViewBtn.Size = new System.Drawing.Size(75, 23);
            this.createViewBtn.TabIndex = 3;
            this.createViewBtn.Text = "createView";
            this.createViewBtn.UseVisualStyleBackColor = true;
            this.createViewBtn.Click += new System.EventHandler(this.createViewBtn_Click);
            // 
            // DoctorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.createViewBtn);
            this.Controls.Add(this.dayViewBtn);
            this.Controls.Add(this.agendaViewBtn);
            this.Name = "DoctorView";
            this.Text = "DoctorView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DoctorView_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button agendaViewBtn;
        private System.Windows.Forms.Button dayViewBtn;
        private System.Windows.Forms.Button createViewBtn;
    }
}

