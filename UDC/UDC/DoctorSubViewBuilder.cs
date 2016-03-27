using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDC {
    public class DoctorSubViewBuilder : SubViewBuilder {

        // create panel
        private System.Windows.Forms.Panel createPanel = new  System.Windows.Forms.Panel();
        private System.Windows.Forms.DateTimePicker dateTimePicker = new System.Windows.Forms.DateTimePicker();
        private System.Windows.Forms.Label label7 = new System.Windows.Forms.Label();
        private System.Windows.Forms.ComboBox to_min = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.Label label6 = new System.Windows.Forms.Label();
        private System.Windows.Forms.ComboBox to_hour = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.ComboBox from_min = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.Label label5 = new System.Windows.Forms.Label();
        private System.Windows.Forms.ComboBox from_hour = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.CheckedListBox checkList = new System.Windows.Forms.CheckedListBox();
        private System.Windows.Forms.Button save = new System.Windows.Forms.Button();
        private System.Windows.Forms.RadioButton recurBtn = new System.Windows.Forms.RadioButton();
        private System.Windows.Forms.RadioButton singleBtn = new System.Windows.Forms.RadioButton();
        private System.Windows.Forms.Button discard = new System.Windows.Forms.Button();

        // agenda panel
        private System.Windows.Forms.Panel agendaPanel = new System.Windows.Forms.Panel();
        private System.Windows.Forms.DataGridView agendaGrid = new System.Windows.Forms.DataGridView();

        // day panel
        private System.Windows.Forms.Panel dayPanel = new System.Windows.Forms.Panel();

        public DoctorSubViewBuilder() {

        }

        public override Panel BuildAgendaView() {
            // 
            // agendaPanel
            // 
            this.agendaPanel.Controls.Add(this.agendaGrid);
            this.agendaPanel.Location = new System.Drawing.Point(263, 61);
            this.agendaPanel.Name = "agendaPanel";
            this.agendaPanel.Size = new System.Drawing.Size(468, 354);
            this.agendaPanel.TabIndex = 20;
            // 
            // agendaGrid
            // 
            this.agendaGrid.BackgroundColor = System.Drawing.Color.White;
            this.agendaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.agendaGrid.Location = new System.Drawing.Point(0, 0);
            this.agendaGrid.Name = "agendaGrid";
            this.agendaGrid.Size = new System.Drawing.Size(465, 351);
            this.agendaGrid.TabIndex = 0;

            this.agendaPanel.ResumeLayout(false);
            this.agendaPanel.SuspendLayout();
            return agendaPanel;
        }

        public override Panel BuildCreateView() {
            // 
            // createPanel
            // 
            this.createPanel.Controls.Add(this.discard);
            this.createPanel.Controls.Add(this.save);
            this.createPanel.Controls.Add(this.recurBtn);
            this.createPanel.Controls.Add(this.singleBtn);
            this.createPanel.Controls.Add(this.checkList);
            this.createPanel.Controls.Add(this.label7);
            this.createPanel.Controls.Add(this.to_min);
            this.createPanel.Controls.Add(this.label6);
            this.createPanel.Controls.Add(this.to_hour);
            this.createPanel.Controls.Add(this.from_min);
            this.createPanel.Controls.Add(this.label5);
            this.createPanel.Controls.Add(this.from_hour);
            this.createPanel.Controls.Add(this.dateTimePicker);
            this.createPanel.Location = new System.Drawing.Point(263, 61);
            this.createPanel.Name = "createPanel";
            this.createPanel.Size = new System.Drawing.Size(468, 354);
            this.createPanel.TabIndex = 20;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Location = new System.Drawing.Point(76, 30);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(322, 23);
            this.dateTimePicker.TabIndex = 0;
            // 
            // from_hour
            // 
            this.from_hour.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_hour.FormattingEnabled = true;
            this.from_hour.Items.AddRange(new object[] {
            "00","01","02","03","04", "05","06","07","08", "09","10", "11","12","13","14",
            "15","16", "17","18","19","20", "21","22","23","24"});
            this.from_hour.Location = new System.Drawing.Point(76, 68);
            this.from_hour.MaxDropDownItems = 25;
            this.from_hour.Name = "from_hour";
            this.from_hour.Size = new System.Drawing.Size(48, 26);
            this.from_hour.Sorted = true;
            this.from_hour.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 22);
            this.label5.TabIndex = 2;
            this.label5.Text = ":";
            // 
            // from_min
            // 
            this.from_min.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_min.FormattingEnabled = true;
            this.from_min.Items.AddRange(new object[] { "00","30"});
            this.from_min.Location = new System.Drawing.Point(137, 68);
            this.from_min.MaxDropDownItems = 3;
            this.from_min.Name = "from_min";
            this.from_min.Size = new System.Drawing.Size(48, 26);
            this.from_min.Sorted = true;
            this.from_min.TabIndex = 0;
            // 
            // to_hour
            // 
            this.to_hour.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_hour.FormattingEnabled = true;
            this.to_hour.Items.AddRange(new object[] {
            "00","01","02","03","04", "05","06","07","08", "09","10", "11","12","13","14",
            "15","16", "17","18","19","20", "21","22","23","24"});
            this.to_hour.Location = new System.Drawing.Point(280, 69);
            this.to_hour.MaxDropDownItems = 25;
            this.to_hour.Name = "to_hour";
            this.to_hour.Size = new System.Drawing.Size(48, 26);
            this.to_hour.Sorted = true;
            this.to_hour.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = ":";
            // 
            // to_min
            // 
            this.to_min.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to_min.FormattingEnabled = true;
            this.to_min.Items.AddRange(new object[] {"00", "30"});
            this.to_min.Location = new System.Drawing.Point(341, 69);
            this.to_min.MaxDropDownItems = 3;
            this.to_min.Name = "to_min";
            this.to_min.Size = new System.Drawing.Size(48, 26);
            this.to_min.Sorted = true;
            this.to_min.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(218, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 22);
            this.label7.TabIndex = 7;
            this.label7.Text = "to";
            // 
            // checkList
            // 
            this.checkList.CheckOnClick = true;
            this.checkList.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkList.FormattingEnabled = true;
            this.checkList.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.checkList.Location = new System.Drawing.Point(216, 113);
            this.checkList.Name = "checkList";
            this.checkList.Size = new System.Drawing.Size(182, 130);
            this.checkList.TabIndex = 21;
            // 
            // singleBtn
            // 
            this.singleBtn.AutoSize = true;
            this.singleBtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleBtn.Location = new System.Drawing.Point(79, 113);
            this.singleBtn.Name = "singleBtn";
            this.singleBtn.Size = new System.Drawing.Size(61, 22);
            this.singleBtn.TabIndex = 22;
            this.singleBtn.TabStop = true;
            this.singleBtn.Text = "Single";
            this.singleBtn.UseVisualStyleBackColor = true;
            // 
            // recurBtn
            // 
            this.recurBtn.AutoSize = true;
            this.recurBtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recurBtn.Location = new System.Drawing.Point(79, 141);
            this.recurBtn.Name = "recurBtn";
            this.recurBtn.Size = new System.Drawing.Size(90, 22);
            this.recurBtn.TabIndex = 23;
            this.recurBtn.TabStop = true;
            this.recurBtn.Text = "Recurrence";
            this.recurBtn.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.save.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.ForeColor = System.Drawing.Color.White;
            this.save.Location = new System.Drawing.Point(116, 264);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(99, 39);
            this.save.TabIndex = 24;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = false;
            // 
            // discard
            // 
            this.discard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.discard.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discard.ForeColor = System.Drawing.Color.White;
            this.discard.Location = new System.Drawing.Point(254, 263);
            this.discard.Name = "discard";
            this.discard.Size = new System.Drawing.Size(97, 40);
            this.discard.TabIndex = 25;
            this.discard.Text = "Discard";
            this.discard.UseVisualStyleBackColor = false;

            this.createPanel.ResumeLayout(false);
            this.createPanel.SuspendLayout();
            return createPanel;

        }

        public override Panel BuildDayView() {
          
            this.dayPanel.ResumeLayout(false);
            this.dayPanel.SuspendLayout();
            return dayPanel;
        }

        public override void Update(ListView parentView, String subView,ListController controller) {
            if (subView.Equals(SubView.CALENDAR_VIEW)) {
                /*(TEST CODE) REPLACE WITH REAL UPDATE OF DOCTOR VIEW DAY VIEW*/
                foreach (Control c in ((DoctorView)parentView).Controls)
                    if (c is Panel) {
                        foreach (Control d in ((Panel)c).Controls)
                            if (d is Label)
                                d.Text = "DOC DAY UP";
                    }
            }
            else if (subView.Equals(SubView.AGENDA_VIEW)) {
                /*(TEST CODE) REPLACE WITH REAL UPDATE OF DOCTOR VIEW AGENDA VIEW*/
                foreach (Control c in ((DoctorView)parentView).Controls)
                    if (c is Panel)
                        foreach (Control d in ((Panel)c).Controls)
                            if (d is Label)
                                d.Text = "DOC AGEN UP";
            }
        }
    }
}
