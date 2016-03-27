using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDC {
    public class ClientSubViewBuilder : SubViewBuilder {
        private ListController controller;
        private System.Windows.Forms.Panel dayPanel;
        private System.Windows.Forms.DataGridView tableView;
        private DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        private DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        private DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

        public ClientSubViewBuilder() {

        }

        public override Panel BuildAgendaView() {
            Panel panel = new Panel();
            /*INSERT INITIALIZATION OF AGENDA PANEL HERE*/
            Label test = new Label();
            test.Text = "CLIENT AGENDA";
            panel.Controls.Add(test);
            return panel;
        }

        public override Panel BuildCreateView() {
            Panel panel = new Panel();
            /*INSERT INITIALIZATION OF AGENDA PANEL HERE*/
            Label test = new Label();
            test.Text = "CLIENT CREATE";
            panel.Controls.Add(test);
            return panel;
        }

        public override Panel BuildDayView() {
            /*INSERT INITIALIZATION OF DAY PANEL HERE*/
            this.dayPanel = new System.Windows.Forms.Panel();
            this.tableView = new System.Windows.Forms.DataGridView();
            this.dayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableView)).BeginInit();
            this.dayPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableView)).EndInit();
            this.tableView.AllowUserToAddRows = false;
            this.tableView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableView.BackgroundColor = System.Drawing.Color.White;
            this.tableView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableView.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableView.DefaultCellStyle = dataGridViewCellStyle3;
            this.tableView.Location = new System.Drawing.Point(0, 0);
            this.tableView.Name = "tableView";
            this.tableView.ReadOnly = true;
            this.tableView.RowHeadersVisible = false;
            this.tableView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tableView.Size = new System.Drawing.Size(458, 316);
            this.tableView.TabIndex = 14;
            this.tableView.SelectionChanged += new System.EventHandler(this.tableView_SelectionChanged);
            this.tableView.RowTemplate.Height = 31;


            this.dayPanel.Controls.Add(this.tableView);
            this.dayPanel.Location = new System.Drawing.Point(251, 66);
            this.dayPanel.Name = "dayPanel";
            this.dayPanel.Size = new System.Drawing.Size(457, 316);
            this.dayPanel.TabIndex = 1;

            return dayPanel;
        }

        private void tableView_SelectionChanged(object sender, EventArgs e) {
            tableView.ClearSelection();
        }

        private void tableView_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e) {
            if (e.RowIndex % 2 == 0 && e.ColumnIndex == 0)
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

            for (int j = 1; j < 48; j += 2) {
                tableView.Rows[j].Cells[0].Style.ForeColor = Color.White;

            }
        }

        public override void Update(ListView parentView, String subView, ListController controller) {
            this.controller = controller;
            Console.WriteLine(subView);
            if (subView.Equals(SubView.CALENDAR_VIEW)) {
                /*(TEST CODE) REPLACE WITH REAL UPDATE OF DOCTOR VIEW DAY VIEW*/
                Console.WriteLine("WAAT");
                if (((ClientView)parentView).dayRadioBtn.Checked) {
                    this.tableView.ColumnHeadersVisible = false;
                    DataTable dt = new DataTable();

                    this.tableView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.tableView_CellPainting_1);

                    dt.Columns.Add("Time");
                    dt.Columns.Add("Todo");

                    for (int i = 0; i < 24; i++) {
                        dt.Rows.Add(i.ToString("00") + ":00");
                        dt.Rows.Add(i.ToString("00") + ":30");
                    }

                    tableView.DataSource = dt;

                    tableView.Columns[1].DefaultCellStyle.ForeColor = Color.White;
                    tableView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    tableView.Columns[0].Width = 70;
                    tableView.Columns[1].Width = 360;
                    tableView.Columns["Time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    tableView.AllowUserToResizeColumns = false;
                    tableView.AllowUserToResizeRows = false;
                    tableView.AllowUserToAddRows = false;
                }
                else if(((ClientView)parentView).weekRadioBtn.Checked) {
                    this.tableView.ColumnHeadersVisible = true;
                    DataTable dt = new DataTable();
                    tableView.DataSource = dt;

                    dt.Columns.Add("Time");

                    /*DateTime date = ((ClientView)parentView).monthCalendar.SelectionRange.Start.Date;
                    DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
                    int offset = fdow - date.DayOfWeek;
                    DateTime fdowDate = date.AddDays(offset);

                    for (int i = 0; i < 7; i++) {
                        dt.Columns.Add(fdowDate.ToString("MMMM - d"));
                        fdowDate.AddDays()
                    }*/
              
                    dt.Columns.Add("Sunday");
                    dt.Columns.Add("Monday");
                    dt.Columns.Add("Tuesday");
                    dt.Columns.Add("Wednesday");
                    dt.Columns.Add("Thursday");
                    dt.Columns.Add("Friday");
                    dt.Columns.Add("Saturday");

                    for (int i = 0; i < 24; i++) {
                        dt.Rows.Add(i.ToString("00") + ":00");
                        dt.Rows.Add(i.ToString("00") + ":30");
                    }

                    tableView.Columns[1].DefaultCellStyle.ForeColor = Color.White;
                    tableView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    tableView.Columns[0].Width = 70;
                    for(int i = 1; i < tableView.Columns.Count; i++)
                        tableView.Columns[i].Width = 100;
                    tableView.Columns["Time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    tableView.AllowUserToResizeColumns = false;
                    tableView.AllowUserToResizeRows = false;
                    tableView.AllowUserToAddRows = false;
                }
            }
            else if (subView.Equals(SubView.AGENDA_VIEW)) {
                /*(TEST CODE) REPLACE WITH REAL UPDATE OF DOCTOR VIEW AGENDA VIEW*/
                foreach (Control c in ((ClientView)parentView).Controls)
                    if (c is Panel)
                        foreach (Control d in ((Panel)c).Controls)
                            if (d is Label)
                                d.Text = "CLI AGEN UP";
            }
        }
    }
}
