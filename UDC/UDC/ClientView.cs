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
    public partial class ClientView : Form, ListView {
        private ListController controller;
        private SubView currentView;
        private Panel currentPanel;
        private List<String> doctors;
        private List<DateTime> dates;
        public const String CLIENT_VIEW = "ClientView";
        MySqlConnection myConn;
        MySqlDataReader reader;
        List<String> names = new List<string>();
        DatabaseSingleton dbSettings = DatabaseSingleton.GetInstance();

        public ClientView(ListController c) {
            this.controller = c;
            InitializeComponent();
            ((ListView)this).InitializeView();
            Show();
        }

        void ListView.InitializeView() {
            this.doctors = new List<String>();
            this.dates = new List<DateTime>();
            this.currentView = SubView.MakeView(controller, SubView.CALENDAR_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            addDelete();
            this.currentPanel.Show();
            dayRadioBtn.Checked = true;
            dateLabel.Text = monthCalendar.SelectionRange.Start.ToString("MMM d, yyyy");
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
            this.currentView.Update(doctors, dates, true);
            Console.WriteLine("Update");
        }

        private void UpdateDate() {
            this.dates.Clear();
            if (this.dayRadioBtn.Checked)
                this.dates.Add(this.monthCalendar.SelectionRange.Start);
            else if (this.weekRadioBtn.Checked) {
                DateTime date = monthCalendar.SelectionRange.Start.Date;
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

            this.currentView.Update(doctors, dates, true);
        }

        private void ClientView_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        private void calendarViewBtn_Click(object sender, EventArgs e) {
            /*ACTION LISTENER FOR DAY VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, SubView.CALENDAR_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            addDelete();
            this.currentPanel.Show();
            this.currentView.Update(doctors, dates, true);
        }

        private void agendaViewBtn_Click(object sender, EventArgs e) {
            /*ACTION LISTENER FOR AGENDA VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, SubView.AGENDA_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
            this.currentView.Update(doctors, dates, true);
        }

        private void createViewBtn_Click(object sender, EventArgs e) {
            /*ACTION LISTENER FOR CREATE VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, SubView.CREATE_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
        }

        private void todayBtn_Click(object sender, EventArgs e) {
            monthCalendar.SetDate(DateTime.Today);
            if (dayRadioBtn.Checked)
                dateLabel.Text = monthCalendar.SelectionRange.Start.ToString("MMM d, yyyy");
            else if (weekRadioBtn.Checked)
                dateLabel.Text = monthCalendar.SelectionRange.Start.ToString("MMMM") + " - Week " + GetWeekNumberOfMonth(monthCalendar.SelectionRange.Start).ToString();
            ((ListView)this).Update();
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e) {
            dateLabel.Text = monthCalendar.SelectionRange.Start.ToString("MMM d, yyyy");
            monthCalendar.SelectionRange.Start = DateTime.Today;
            UpdateDate();
            ((ListView)this).Update();
        }

        private void monthCalendar_DateSelected_1(object sender, DateRangeEventArgs e) {
            DateTime date = monthCalendar.SelectionRange.Start.Date;

            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime startDateOfWeek = date.AddDays(offset);
            DateTime endDateOfWeek = startDateOfWeek.AddDays(6);

            dateLabel.Text = date.ToString("MMMM") + " - Week " + GetWeekNumberOfMonth(date).ToString();
        }

        private void dayRadioBtn_CheckedChanged(object sender, EventArgs e) {
            UpdateDate();
            this.currentView.Update(doctors, dates, true);

            if (dayRadioBtn.Checked) {
                this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
                dateLabel.Text = monthCalendar.SelectionRange.Start.ToString("MMM d, yyyy");
            }
            else if (weekRadioBtn.Checked) {
                DateTime date = monthCalendar.SelectionRange.Start.Date;
                this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected_1);
                dateLabel.Text = date.ToString("MMMM") + " - Week " + GetWeekNumberOfMonth(date).ToString();
            }
        }

        private void weekRadioBtn_CheckedChanged(object sender, EventArgs e) {
            UpdateDate();
            this.currentView.Update(doctors, dates, true);
        }

        private void addDelete() {
            foreach (Control c in this.currentPanel.Controls) {
                if (c is DataGridView)
                    ((DataGridView)c).CellDoubleClick += new DataGridViewCellEventHandler(this.tableView_CellDoubleClick);
            }
        }

        private void tableView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            foreach (Control c in this.currentPanel.Controls) {
                if (c is DataGridView)
                    MessageBox.Show(((DataGridView)c).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        static int GetWeekNumberOfMonth(DateTime date) {
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
    }
}
