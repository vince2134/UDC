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
        private List<String> doctors;
        private List<DateTime> dates;
        protected abstract void InitializeView();
        int k = 1;
      
   

        public void Update(List<String> doctors, List<DateTime> dates) {
            AppointmentList apList1 = ((AppointmentModelController)controller).GetAppointments(doctors, dates,false);
            this.doctors = doctors;
            this.dates = dates;
            if (this is CalendarView) {
                if (dates.Count == 1) {
                   
                    this.tableView.ColumnHeadersVisible = false;
                    DataTable dt = new DataTable();
                    DateTime curDate = dates[0];
                
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
             
                    foreach (Appointment t in apList1.GetAppointments())
                    {
                            String startTime = t.GetStartTime().ToString("HH:mm");
                       
                        for (int i = 0; i < 48; i++)
                        {

                            if ((startTime.Equals(tableView.Rows[i].Cells[0].Value.ToString())))
                            {
                                tableView.Rows[i].Cells[1].Value = t.GetTitle();
                                int j = i;
                                String endTime = (t.GetEndTime().ToString("HH:mm"));
                                while (!endTime.Equals(tableView.Rows[j].Cells[0].Value.ToString()))
                                {
                                    tableView.Rows[j].Cells[1].Style.BackColor = t.GetColor();
                                    j++;

                                }

                            }
                        }
                        
                    }
                }
                else if(dates.Count>1){
                    this.tableView.ColumnHeadersVisible = true;
                   
                    DataTable dt = new DataTable();
                   
                    this.tableView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.tableView_CellPainting_1);

                    DateTime d = dates[0];


                    dt.Columns.Add("Time");

                    dt.Columns.Add(d.Day.ToString() + "-Sunday");
                    d = d.AddDays(1);
                    dt.Columns.Add(d.Day.ToString() + "-Monday");
                    d = d.AddDays(1);
                    dt.Columns.Add(d.Day.ToString() + "-Tuesday");
                    d = d.AddDays(1);
                    dt.Columns.Add(d.Day.ToString() + "-Wednesday");
                    d = d.AddDays(1);
                    dt.Columns.Add(d.Day.ToString() + "-Thursday");
                    d = d.AddDays(1);
                    dt.Columns.Add(d.Day.ToString() + "-Friday");
                    d = d.AddDays(1);
                    dt.Columns.Add(d.Day.ToString() + "-Saturday");

                    for (int i = 0; i < 24; i++) {
                        dt.Rows.Add(i.ToString("00") + ":00");
                        dt.Rows.Add(i.ToString("00") + ":30");
                    }

                    tableView.DataSource = dt;
                    

                    tableView.Columns[1].DefaultCellStyle.ForeColor = Color.White;

                    foreach (Appointment t in apList1.GetAppointments())
                    {
                        String startTime = t.GetStartTime().ToString("HH:mm");
                        for (int i = 0; i < 48; i++)
                        {

                            if ((startTime.Equals(tableView.Rows[i].Cells[0].Value.ToString())))
                            {
                                
                                String day = t.GetStartTime().ToString("ddd");
                               
                                while (!day.Contains(tableView.Rows[0].Cells[k].Value.ToString()) && k < 7){
                                    k++;
                                }
                                tableView.Rows[i].Cells[k+1].Value = t.GetTitle();
                                int j = i;
                                String endTime = (t.GetEndTime().ToString("HH:mm"));
                                while (!endTime.Equals(tableView.Rows[j].Cells[0].Value.ToString()))
                                {
                                    tableView.Rows[j].Cells[k+1].Style.BackColor = t.GetColor();
                                    j++;

                                }

                            }
                        }

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



                AppointmentList apList1 = ((AppointmentModelController)controller).GetAppointments(doctors, dates, false);
              

                foreach (Appointment t in apList1.GetAppointments())
                {
                 
                    String day = t.GetStartTime().ToString("ddd");
                  
      
                        if (((e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 - 1 && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) &&(day.Contains("Sun") && e.ColumnIndex==1))
                            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

                        else if(((e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 - 1 && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && (day.Contains("Mon") && e.ColumnIndex == 2))
                           e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                        else if (((e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 - 1 && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && (day.Contains("Tue") && e.ColumnIndex ==3))
                           e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                        else if (((e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 - 1 && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && (day.Contains("Wed") && e.ColumnIndex == 4))
                           e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                        else if (((e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 - 1 && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && (day.Contains("Thu") && e.ColumnIndex == 5))
                           e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                        else if (((e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 - 1 && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && (day.Contains("Fri") && e.ColumnIndex == 6))
                           e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                        else if (((e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 - 1 && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && (day.Contains("Sat") && e.ColumnIndex == 7))
                           e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                        else if (((e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 - 1 && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && dates.Count  <2)
                           e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

                } 
              




            }
        }

        public Panel GetPanel() {
            return this.panel;
        }
    }
}
