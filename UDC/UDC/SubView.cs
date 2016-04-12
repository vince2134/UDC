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
        private Boolean availableOnly;
        protected abstract void InitializeView();

        public void Update(List<String> doctors, List<DateTime> dates, Boolean availableOnly) {
            AppointmentList apList1 = ((AppointmentModelController)controller).GetAppointments(doctors, dates, availableOnly);
            this.doctors = doctors;
            this.dates = dates;
           this.availableOnly = availableOnly;
            int k = 1;

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
                    tableView.Columns[1].Width = 400;
                    tableView.Columns["Time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    tableView.AllowUserToResizeColumns = false;
                    tableView.AllowUserToResizeRows = false;
                    tableView.AllowUserToAddRows = false;

                    foreach (Appointment t in apList1.GetAppointments()) {
                   
                        String startTime = t.GetStartTime().ToString("HH:mm");
                        for (int i = 0; i < 48; i++) {
                          
                            if ((startTime.Equals(tableView.Rows[i].Cells[0].Value.ToString()))) {
                                tableView.Rows[i].Cells[k].Value = "Slot No. " + t.GetSlotNum() + " | " + t.GetTitle() + " | " + t.GetStartTime().ToString("M/d/yyyy") + " | " + t.GetStartTime().ToString("HH:mm") + " - " + t.GetEndTime().ToString("HH:mm");
                                tableView.Rows[i].Cells[k].Style.BackColor = t.GetColor();
                                int j = i + 1;
                                String endTime = (t.GetEndTime().ToString("HH:mm"));
                                while (!endTime.Equals(tableView.Rows[j].Cells[0].Value.ToString())) {
                                    tableView.Rows[j].Cells[1].Style.BackColor = t.GetColor();
                                    tableView.Rows[j].Cells[1].Value = "Slot No. " + t.GetSlotNum() + " | " + t.GetTitle() + " | " + t.GetStartTime().ToString("M/d/yyyy") + " | " + t.GetStartTime().ToString("HH:mm") + " - " + t.GetEndTime().ToString("HH:mm");
                                        tableView.Rows[j].Cells[1].Style.ForeColor = t.GetColor();

                                    j++;

                                    if (j == 48)
                                        break;
                                }

                            }
                        }

                    }
                }
                else if (dates.Count > 1) {
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
                    tableView.Columns[2].DefaultCellStyle.ForeColor = Color.White;
                    tableView.Columns[3].DefaultCellStyle.ForeColor = Color.White;
                    tableView.Columns[4].DefaultCellStyle.ForeColor = Color.White;
                    tableView.Columns[5].DefaultCellStyle.ForeColor = Color.White;
                    tableView.Columns[6].DefaultCellStyle.ForeColor = Color.White;
                    tableView.Columns[7].DefaultCellStyle.ForeColor = Color.White;

                    foreach (Appointment t in apList1.GetAppointments()) {
                        String startTime = t.GetStartTime().ToString("HH:mm");
                        for (int i = 0; i < 48; i++) {

                            if ((startTime.Equals(tableView.Rows[i].Cells[0].Value.ToString()))) {

                                String day = t.GetStartTime().ToString("ddd");

                                while (!tableView.Columns[k].HeaderText.ToString().Contains(day) && k < 7) {
                                    Console.Write(tableView.Columns[k].HeaderText.ToString());
                                    k++;
                                }

                                tableView.Rows[i].Cells[k].Value = "Slot No. " + t.GetSlotNum() + " | " + t.GetTitle() + " | " + t.GetStartTime().ToString("M/d/yyyy") + " | " + t.GetStartTime().ToString("HH:mm") + " - " + t.GetEndTime().ToString("HH:mm");
                                tableView.Rows[i].Cells[k].Style.BackColor = t.GetColor();
                                int j = i+1;
                                String endTime = (t.GetEndTime().ToString("HH:mm"));
                                while (!endTime.Equals(tableView.Rows[j].Cells[0].Value.ToString())) {

                                    tableView.Rows[j].Cells[k].Style.BackColor = t.GetColor();
                                    tableView.Rows[j].Cells[k].Value = "Slot No. " + t.GetSlotNum() + " | " + t.GetTitle() + " | " + t.GetStartTime().ToString("M/d/yyyy") + " | " + t.GetStartTime().ToString("HH:mm") + " - " + t.GetEndTime().ToString("HH:mm");
                                    tableView.Rows[j].Cells[k].Style.ForeColor = t.GetColor();
                                    j++;
                                    if (j == 48)
                                        break;
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
            else if (this is AgendaView) {
                tableView.AllowUserToResizeColumns = false;
                tableView.AllowUserToResizeRows = false;
                tableView.ReadOnly = true;

                DataTable dt = new DataTable();
                dt.Columns.Add("Time");
                dt.Columns.Add("Todo");

                tableView.GridColor = Color.White;
                if (apList1.Count() == 0)
                {
                    dt.Rows.Add("No Appointments to show");
                }

                foreach (Appointment t in apList1.GetAppointments()) {
                    dt.Rows.Add("  ");
                }

                tableView.DataSource = dt;

                tableView.Columns[0].Width = 260;

                int i = 0;
                foreach (Appointment t in apList1.GetAppointments()) {
                    tableView.Rows[i].Cells[0].Value = "Slot " + t.GetSlotNum() + " " + t.GetStartTime().ToString("M/d/yyyy HH:mm") + " - " + t.GetEndTime().ToString("HH:mm");
                    tableView.Rows[i].Cells[1].Value = t.GetTitle();

                    Console.WriteLine(t.GetStartTime());

                    if (t.Available())
                        tableView.Rows[i].Cells[1].Value += " (Available)";
                    else
                        tableView.Rows[i].Cells[1].Value += " (Unavailable)";

                    tableView.Rows[i].Cells[1].Style.ForeColor = t.GetColor();

                    i++;
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

            return null;
        }

        protected Panel MakeCreatePanel() {
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

                AppointmentList apList1 = ((AppointmentModelController)controller).GetAppointments(doctors, dates, availableOnly);

                foreach (Appointment t in apList1.GetAppointments()) {
                    String day = t.GetStartTime().ToString("ddd");

                    if (e.ColumnIndex != 0) {
                        if (((e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 - 1 && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && (day.Contains("Sun") && e.ColumnIndex == 1))
                            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

                        else if (((e.RowIndex >= t.GetStartTime().Hour * 2 && (e.RowIndex < t.GetEndTime().Hour * 2 - 1 || t.GetEndTime().Hour == 0) && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && (day.Contains("Mon") && e.ColumnIndex == 2))
                            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                        else if (((e.RowIndex >= t.GetStartTime().Hour * 2 && (e.RowIndex < t.GetEndTime().Hour * 2 - 1 || t.GetEndTime().Hour == 0) && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && (day.Contains("Tue") && e.ColumnIndex == 3))
                            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                        else if (((e.RowIndex >= t.GetStartTime().Hour * 2 && (e.RowIndex < t.GetEndTime().Hour * 2 - 1 || t.GetEndTime().Hour == 0) && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && (day.Contains("Wed") && e.ColumnIndex == 4))
                            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                        else if (((e.RowIndex >= t.GetStartTime().Hour * 2 && (e.RowIndex < t.GetEndTime().Hour * 2 - 1 || t.GetEndTime().Hour == 0) && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && (day.Contains("Thu") && e.ColumnIndex == 5))
                            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                        else if (((e.RowIndex >= t.GetStartTime().Hour * 2 && (e.RowIndex < t.GetEndTime().Hour * 2 - 1 || t.GetEndTime().Hour == 0) && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && (day.Contains("Fri") && e.ColumnIndex == 6))
                            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                        else if (((e.RowIndex >= t.GetStartTime().Hour * 2 && (e.RowIndex < t.GetEndTime().Hour * 2 - 1 || t.GetEndTime().Hour == 0) && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && (day.Contains("Sat") && e.ColumnIndex == 7))
                            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                        else if (((e.RowIndex >= t.GetStartTime().Hour * 2 && (e.RowIndex < t.GetEndTime().Hour * 2 - 1 || t.GetEndTime().Hour == 0) && t.GetEndTime().Minute == 0) || (e.RowIndex >= t.GetStartTime().Hour * 2 && e.RowIndex < t.GetEndTime().Hour * 2 && t.GetEndTime().Minute == 30)) && dates.Count < 2)
                            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                    }
                }
            }
        }

        public Panel GetPanel() {
            return this.panel;
        }
    }
}
