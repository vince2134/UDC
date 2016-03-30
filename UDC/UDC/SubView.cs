using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDC {
    public abstract class SubView {
        protected ListController controller;
        protected Panel panel;
        protected DataGridView tableView;
        public const String CALENDAR_VIEW = "CalendarView";
        public const String AGENDA_VIEW = "AgendaView";
        public const String CREATE_VIEW = "CreateView";

        protected abstract void InitializeView();
        
        public void Update(List<String> doctors, List<DateTime> dates) {
            if (this is CalendarView) {
                if (dates.Count == 1) {
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
                else {
                    this.tableView.ColumnHeadersVisible = true;
                    DataTable dt = new DataTable();
                    tableView.DataSource = dt;

                    dt.Columns.Add("Time");

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
                    for (int i = 1; i < tableView.Columns.Count; i++)
                        tableView.Columns[i].Width = 100;
                    tableView.Columns["Time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    tableView.AllowUserToResizeColumns = false;
                    tableView.AllowUserToResizeRows = false;
                    tableView.AllowUserToAddRows = false;
                }
            }
        }

        public static SubView MakeView(ListController c, String subView) {
            if (subView.Equals(CALENDAR_VIEW)) {
                return new CalendarView(c);
            }
            else if (subView.Equals(AGENDA_VIEW)) {
                return new AgendaView(c);
            }
            else if (subView.Equals(CREATE_VIEW)) {
                return new CreateView(c);
            }

            return null;
        }

        protected Panel MakeCreatePanel() {
            return null;
        }

        protected Panel MakeAgendaPanel() {
            // 
            // agendaPanel
            // 
            /*this.panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.agendaPanel.Controls.Add(this.agendaGrid);
            this.agendaPanel.Location = new System.Drawing.Point(248, 84);
            this.agendaPanel.Name = "agendaPanel";
            this.agendaPanel.Size = new System.Drawing.Size(391, 244);
            this.agendaPanel.TabIndex = 12;
            // 
            // agendaGrid
            // 
            this.agendaGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.agendaGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.agendaGrid.GridColor = Color.White;
            this.agendaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.agendaGrid.GridColor = System.Drawing.Color.WhiteSmoke;
            this.agendaGrid.Location = new System.Drawing.Point(0, 0);
            this.agendaGrid.Name = "agendaGrid";
            this.agendaGrid.Size = new System.Drawing.Size(391, 244);
            this.agendaGrid.TabIndex = 0;
            ((System.ComponentModel.ISupportInitialize)(this.agendaGrid)).BeginInit();
            this.agendaPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agendaGrid)).EndInit();



            this.agendaPanel.SuspendLayout();
            return agendaPanel;*/
            return null;
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

        public Panel GetPanel() {
            return this.panel;
        }
    }
}
