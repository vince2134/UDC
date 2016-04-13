using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDC {
    public partial class SecretaryView : Form, ListView {
        private ListController controller;
        private SubViewList subViews;
        private SubView currentView;
        private Panel currentPanel;
        private List<String> doctors;
        private List<DateTime> dates;
        public const String SECRETARY_VIEW = "SecretaryView";
        MySqlConnection myConn;
        MySqlDataReader reader;
        private List<String> names = new List<string>();
        private DatabaseSingleton dbSettings = DatabaseSingleton.GetInstance();
        private Boolean deleteAdded = false;

        public SecretaryView(ListController c) {
            this.controller = c;
            InitializeComponent();
            ((ListView)this).InitializeView();
            Show();
        }

        void ListView.InitializeView() {
            this.subViews = new SubViewList();
            this.doctors = new List<String>();
            this.dates = new List<DateTime>();
            this.currentView = subViews.GenerateSubView(controller, SubView.CALENDAR_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
            this.dayRadio.Checked = true;
            addDelete();
            dateLabel.Text = monthCalendar1.SelectionRange.Start.ToString("MMM d, yyyy");
            InitializeDoctors();

        }

        private void InitializeDoctors() {
            String username = dbSettings.GetUsername();
            String password = dbSettings.GetPassword();
            String dbname = "udc_database";
            String myConnection = "datasource=localhost;database=" + dbname + ";port=3306;username=" + username + ";password=" + password;

            try {
                myConn = new MySqlConnection(myConnection);
                Console.WriteLine("Success");
            }
            catch (Exception e) {
                Console.WriteLine("Connection Failed");
            }
            try {
                MySqlCommand command = myConn.CreateCommand();
                command.CommandText = "select * from doctors";

                myConn.Open();
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    drListBox.Items.Add(reader["name"].ToString());
                }

                myConn.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        void ListView.Update() {
            /*CALLED WHEN NOTIFY() IS CALLED, UPDATES SUBVIEWS*/
            this.currentView.Update(doctors, dates, false);
        }

        private void UpdateDate() {
            this.dates.Clear();

            if (this.dayRadio.Checked)
                this.dates.Add(this.monthCalendar1.SelectionRange.Start);
            else if (this.weekRadio.Checked) {
                DateTime date = monthCalendar1.SelectionRange.Start.Date;
                DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
                int offset = fdow - date.DayOfWeek;
                DateTime startDateOfWeek = date.AddDays(offset);
                DateTime endDateOfWeek = startDateOfWeek.AddDays(6);
                this.dates.Add(startDateOfWeek);
                this.dates.Add(endDateOfWeek);
            }
        }

        private void UpdateDoctor(List<String> checkedItems) {
            this.doctors.Clear();

            foreach (String t in checkedItems) {
                doctors.Add(t);
                Console.Write(t);
            }

            this.currentView.Update(doctors, dates, false);

        }

        private void SecretaryView_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        private void dayViewBtn_Click(object sender, EventArgs e) {

            /*ACTION LISTENER FOR DAY VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = subViews.GenerateSubView(controller, SubView.CALENDAR_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
            this.currentView.Update(doctors, dates, false);
        }

        private void agendaViewBtn_Click(object sender, EventArgs e) {
            /*ACTION LISTENER FOR AGENDA VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = subViews.GenerateSubView(controller, SubView.AGENDA_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            if (!deleteAdded) {
                addDelete();
                deleteAdded = true;
            }

            this.currentPanel.Show();
            this.currentView.Update(doctors, dates, false);
        }

        private void todayButton_Click(object sender, EventArgs e) {
            monthCalendar1.SetDate(DateTime.Today);
            if (dayRadio.Checked)
                dateLabel.Text = monthCalendar1.SelectionRange.Start.ToString("MMM d, yyyy");
            else if (weekRadio.Checked)
                dateLabel.Text = monthCalendar1.SelectionRange.Start.ToString("MMMM") + " - Week " + GetWeekNumberOfMonth(monthCalendar1.SelectionRange.Start).ToString();
            UpdateDate();
            ((ListView)this).Update();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e) {
            dateLabel.Text = monthCalendar1.SelectionRange.Start.ToString("MMM d, yyyy");
        }

        private void addDelete() {
            foreach (Control c in this.currentPanel.Controls) {
                if (c is DataGridView)
                    ((DataGridView)c).CellDoubleClick += new DataGridViewCellEventHandler(this.tableView_CellDoubleClick);
            }
        }

        private void tableView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            AppointmentList apList1 = ((AppointmentModelController)controller).GetAppointments(doctors, dates, false);
            foreach (Control c in this.currentPanel.Controls) {
                if (c is DataGridView) {

                    foreach (Appointment t in apList1.GetAppointments()) {
                        if ((((DataGridView)c).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).Contains(t.GetEndTime().ToString("HH:mm")) && (((DataGridView)c).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).Contains(t.GetStartTime().ToString("HH:mm")) && (((DataGridView)c).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).Contains(t.GetStartTime().ToString("M/d/yyyy"))) {
                            if (t.Available()) {
                                t.SetAvailability(false);
                                ((AppointmentModelController)controller).UpdateDatabase(t, "Occupied");
                                MessageBox.Show("Appointment with " + t.GetTitle() + " confirmed!");
                                break;
                            }
                            else {
                                MessageBox.Show("Unable to cancel appointment with " + t.GetTitle() + ".");
                                break;
                            }
                        }
                        else if ((((DataGridView)c).Rows[e.RowIndex].Cells[0].Value.ToString()).Contains(t.GetEndTime().ToString("HH:mm")) && (((DataGridView)c).Rows[e.RowIndex].Cells[0].Value.ToString()).Contains(t.GetStartTime().ToString("HH:mm")) && (((DataGridView)c).Rows[e.RowIndex].Cells[0].Value.ToString()).Contains(t.GetStartTime().ToString("M/d/yyyy")) && (((DataGridView)c).Rows[e.RowIndex].Cells[1].Value.ToString()).Contains(t.GetTitle())) {
                            if (t.Available()) {
                                t.SetAvailability(false);
                                ((AppointmentModelController)controller).UpdateDatabase(t, "Occupied");
                                MessageBox.Show("Appointment with " + t.GetTitle() + " confirmed!");
                                break;
                            }
                            else {
                                MessageBox.Show("Unable to cancel appointment with " + t.GetTitle() + ".");
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void dayRadio_CheckedChanged(object sender, EventArgs e) {
            UpdateDate();
            this.currentView.Update(doctors, dates, false);

            if (dayRadio.Checked) {
                this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
                dateLabel.Text = monthCalendar1.SelectionRange.Start.ToString("MMM d, yyyy");
            }
            else if (weekRadio.Checked) {
                DateTime date = monthCalendar1.SelectionRange.Start.Date;
                this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected_1);
                dateLabel.Text = date.ToString("MMMM") + " - Week " + GetWeekNumberOfMonth(date).ToString();
            }
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e) {
            dateLabel.Text = monthCalendar1.SelectionRange.Start.ToString("MMM d, yyyy");
            monthCalendar1.SelectionRange.Start = DateTime.Today;
            UpdateDate();
            ((ListView)this).Update();
        }

        private void monthCalendar_DateSelected_1(object sender, DateRangeEventArgs e) {
            DateTime date = monthCalendar1.SelectionRange.Start.Date;

            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime startDateOfWeek = date.AddDays(offset);
            DateTime endDateOfWeek = startDateOfWeek.AddDays(6);

            dateLabel.Text = date.ToString("MMMM") + " - Week " + GetWeekNumberOfMonth(date).ToString();
        }

        private int GetWeekNumberOfMonth(DateTime date) {
            date = date.Date;
            DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Sunday + 7 - firstMonthDay.DayOfWeek) % 7);
            if (firstMonthMonday > date) {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Sunday + 7 - firstMonthDay.DayOfWeek) % 7);
            }

            return (date - firstMonthMonday).Days / 7 + 1;
        }

        private void drListBox_SelectedIndexChanged_1(object sender, ItemCheckEventArgs e) {
            if (e.NewValue == CheckState.Checked)
                names.Add(drListBox.Items[e.Index].ToString());

            if (e.NewValue == CheckState.Unchecked) {
                for (int i = 0; i < names.Count; i++) {
                    if (drListBox.Items[e.Index].ToString().Equals(names[i]))
                        names.RemoveAt(i);
                }
            }

            UpdateDoctor(names);
        }

        private void drListBox_SelectedIndexChanged_1(object sender, EventArgs e) {

        }
    }
}
