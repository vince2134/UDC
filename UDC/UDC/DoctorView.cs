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
    public partial class DoctorView : Form, ListView {
        private ListController controller;
        private SubViewList subViews;
        private SubView currentView;
        private Panel currentPanel;
        private List<String> doctors;
        private List<DateTime> dates;
        public const String DOCTOR_VIEW = "DoctorView";
        private DatabaseSingleton dbSettings = DatabaseSingleton.GetInstance();
        private Boolean deleteAdded = false;

        public DoctorView(ListController c) {
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
            addDelete();
            this.currentPanel.Show();
            dailyBtn.Checked = false;
            dailyBtn.Checked = false;
            currentDate.Text = monthCalendar.SelectionRange.Start.ToString("MMM d, yyyy");
            InitializeTimeComboBox();
        }

        private void InitializeTimeComboBox() {
            startHourCB.DropDownStyle = ComboBoxStyle.DropDownList;
            startMinuteCB.DropDownStyle = ComboBoxStyle.DropDownList;
            endHourCB.DropDownStyle = ComboBoxStyle.DropDownList;
            endMinuteCB.DropDownStyle = ComboBoxStyle.DropDownList;

            for (int i = 0; i < 24; i++) {
                startHourCB.Items.Add(i.ToString("00"));
                endHourCB.Items.Add(i.ToString("00"));
            }

            startMinuteCB.Items.Add("00");
            startMinuteCB.Items.Add("30");
            endMinuteCB.Items.Add("00");
            endMinuteCB.Items.Add("30");
        }

        void ListView.Update() {
            /*CALLED WHEN NOTIFY() IS CALLED, UPDATES SUBVIEWS*/
            this.currentView.Update(doctors, dates, false);
        }

        private void UpdateDate() {
            this.dates.Clear();

            if (this.dailyBtn.Checked)
                this.dates.Add(this.monthCalendar.SelectionRange.Start);
            else if (this.weeklyBtn.Checked) {
                DateTime date = monthCalendar.SelectionRange.Start.Date;
                DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
                int offset = fdow - date.DayOfWeek;
                DateTime startDateOfWeek = date.AddDays(offset);
                DateTime endDateOfWeek = startDateOfWeek.AddDays(6);
                this.dates.Add(startDateOfWeek);
                this.dates.Add(endDateOfWeek);
            }
        }

        private void UpdateDoctor() {
            this.doctors.Clear();
            doctors.Add(doctorName.Text);
            this.currentView.Update(doctors, dates, false);

        }

        private void DoctorView_FormClosed(object sender, FormClosedEventArgs e) {
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

        private void agendaViewBtn_Click(object sender, EventArgs e)
        {
            /*ACTION LISTENER FOR AGENDA VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = subViews.GenerateSubView(controller, SubView.AGENDA_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            if (!deleteAdded)
            {
                addDelete();
                deleteAdded = true;
            }
            this.currentPanel.Show();
            this.currentView.Update(doctors, dates, false);
        }

        private void label1_Click(object sender, EventArgs e) {
            //
        }

        private void DoctorView_Load(object sender, EventArgs e) {
            dailyBtn.Checked = true;
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e) {
            currentDate.Text = monthCalendar.SelectionRange.Start.ToString("MMM d, yyyy");
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

            currentDate.Text = date.ToString("MMMM") + " - Week " + GetWeekNumberOfMonth(date).ToString();
        }

        private void dailyBtn_CheckedChanged(object sender, EventArgs e) {
            UpdateDate();
            this.currentView.Update(doctors, dates, false);

            if (dailyBtn.Checked) {
                this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
                currentDate.Text = monthCalendar.SelectionRange.Start.ToString("MMM d, yyyy");
            }
            else if (weeklyBtn.Checked) {
                DateTime date = monthCalendar.SelectionRange.Start.Date;
                this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected_1);
                currentDate.Text = date.ToString("MMMM") + " - Week " + GetWeekNumberOfMonth(date).ToString();
            }
        }

        private void addDelete() {
            foreach (Control c in this.currentPanel.Controls) {
                if (c is DataGridView)
                    ((DataGridView)c).CellDoubleClick += new DataGridViewCellEventHandler(this.tableView_CellDoubleClick);
            }
        }

        private void tableView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            MessageBox.Show("DELEETE");
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

        private void weeklyBtn_CheckedChanged(object sender, EventArgs e) {
            UpdateDate();
            this.currentView.Update(doctors, dates, false);
        }

        private void endHourCB_SelectedIndexChanged(object sender, EventArgs e) {
            if (endHourCB.SelectedIndex == 0) {//remove
                endMinuteCB.Items.Clear();
                endMinuteCB.Items.Add("00");
            }
            else {
                endMinuteCB.Items.Clear();
                endMinuteCB.Items.Add("00");
                endMinuteCB.Items.Add("30");
            }
        }

        private void loginBtn_Click(object sender, EventArgs e) {
            String username = dbSettings.GetUsername();
            String password = dbSettings.GetPassword();
            String dbname = "udc_database";
            String myConnection = "datasource=localhost;database=" + dbname + ";port=3306;username=" + username + ";password=" + password;

            if (string.IsNullOrWhiteSpace(this.username.Text) || string.IsNullOrWhiteSpace(this.password.Text)) //checks if all fields are filled in
                MessageBox.Show("Please enter username and/or password.");
            else {
                try {
                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlCommand SelectCommand = new MySqlCommand("select * from doctors where doctorid = '" + this.username.Text + "' and password = '" + this.password.Text + "';", myConn);
                    MySqlDataReader reader;
                    myConn.Open();
                    reader = SelectCommand.ExecuteReader();
                    int count = 0;
                    while (reader.Read()) {
                        count += 1;
                    }
                    if (count == 1) { //if there is exactly one result from database, it means the username and password matched
                        loginPanel.Hide();
                        this.doctorName.Text = reader["name"].ToString();
                    }
                    else
                        MessageBox.Show("Incorrect username and/or password.");
                }
                catch (Exception e1) {
                    MessageBox.Show(e1.Message);
                }
            }

            UpdateDoctor();
            Update();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.loginPanel.Show();
            this.username.Text = "";
            this.password.Text = "";
        }

        private void save_Click(object sender, EventArgs e) {
            if (startHourCB.SelectedIndex > -1 && startMinuteCB.SelectedIndex > -1 && (((endHourCB.SelectedIndex > -1 && endMinuteCB.SelectedIndex > -1)))) {
                Appointment app = null;

                int year = dateTimePicker.Value.Year;
                int month = dateTimePicker.Value.Month;
                int day = dateTimePicker.Value.Day;
                int hour = 0;
                int minutes = 0;

                if (startHourCB.SelectedItem.ToString()[0] == '0')
                    hour = Int32.Parse(startHourCB.SelectedItem.ToString().Substring(1, 1));
                else
                    hour = Int32.Parse(startHourCB.SelectedItem.ToString());

                if (startMinuteCB.SelectedItem.ToString()[0] == '0')
                    minutes = Int32.Parse(startMinuteCB.SelectedItem.ToString().Substring(1, 1));
                else
                    minutes = Int32.Parse(startMinuteCB.SelectedItem.ToString());

                DateTime startDate = new DateTime(year, month, day, hour, minutes, 0);

                int yearEnd = dateTimePicker.Value.Year;
                int monthEnd = dateTimePicker.Value.Month;
                int dayEnd = dateTimePicker.Value.Day;
                int hourEnd = 0;
                int minutesEnd = 0;

                if (endHourCB.SelectedItem.ToString()[0] == '0')
                    hourEnd = Int32.Parse(endHourCB.SelectedItem.ToString().Substring(1, 1));
                else
                    hourEnd = Int32.Parse(endHourCB.SelectedItem.ToString());

                if (endMinuteCB.SelectedItem.ToString()[0] == '0')
                    minutesEnd = Int32.Parse(endMinuteCB.SelectedItem.ToString().Substring(1, 1));
                else
                    minutesEnd = Int32.Parse(endMinuteCB.SelectedItem.ToString());

                DateTime endDate = new DateTime(yearEnd, monthEnd, dayEnd, hourEnd, minutesEnd, 0);

                if (DateTime.Compare(endDate, startDate) > 0 && endDate.Hour != 0 || endDate.Hour == 0) {
                    if (recurringText.Text.ToString().Length == 0) {
                        app = new Appointment(doctorName.Text, startDate, endDate);

                        if (app != null && !((AppointmentModelController)controller).Overlap(app)) {
                            ((AppointmentModelController)controller).AddToDatabase(app);
                            MessageBox.Show("Time slot added!");
                        }
                        else
                            MessageBox.Show("Overlap task.");
                    }
                    else {
                        try {
                            Int32.Parse(recurringText.Text.ToString());
                            DateTime tempStartDate = startDate;
                            DateTime tempEndDate = endDate;

                            for (int i = 0; i < Int32.Parse(recurringText.Text.ToString()); i++) {
                                app = new Appointment(doctorName.Text, tempStartDate, tempEndDate);

                                if (app != null && !((AppointmentModelController)controller).Overlap(app)) {
                                    ((AppointmentModelController)controller).AddToDatabase(app);
                                }

                                tempStartDate = tempStartDate.AddDays(7);
                                tempEndDate = tempEndDate.AddDays(7);
                            }
                        }
                        catch (Exception ex) {
                            MessageBox.Show("Invalid input.");
                        }
                    }
                }
                else
                    MessageBox.Show("Invalid time. End time should be later than start time.");
            }
            else
                MessageBox.Show("Please fill up all the fields.");
        }

        private void todayBtn_Click(object sender, EventArgs e) {
            monthCalendar.SetDate(DateTime.Today);
            if (dailyBtn.Checked)
                currentDate.Text = monthCalendar.SelectionRange.Start.ToString("MMM d, yyyy");
            else if (weeklyBtn.Checked)
                currentDate.Text = monthCalendar.SelectionRange.Start.ToString("MMMM") + " - Week " + GetWeekNumberOfMonth(monthCalendar.SelectionRange.Start).ToString();
            UpdateDate();
            ((ListView)this).Update();
            
        }

        private void discard_Click(object sender, EventArgs e) {
            startHourCB.SelectedIndex = -1;
            startMinuteCB.SelectedIndex = -1;
            endHourCB.SelectedIndex = -1;
            endMinuteCB.SelectedIndex = -1;
        }
    }
}
