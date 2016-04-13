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
            editPanel.Hide();
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
            newStartHourCB.DropDownStyle = ComboBoxStyle.DropDownList;
            newStartMinCB.DropDownStyle = ComboBoxStyle.DropDownList;
            newEndHourCB.DropDownStyle = ComboBoxStyle.DropDownList;
            newEndMinCB.DropDownStyle = ComboBoxStyle.DropDownList;
            oldStartHourCB.DropDownStyle = ComboBoxStyle.DropDownList;
            oldStartMinCB.DropDownStyle = ComboBoxStyle.DropDownList;
            oldEndHourCB.DropDownStyle = ComboBoxStyle.DropDownList;
            oldEndMinCB.DropDownStyle = ComboBoxStyle.DropDownList;


            for (int i = 0; i < 24; i++) {
                startHourCB.Items.Add(i.ToString("00"));
                endHourCB.Items.Add(i.ToString("00"));

                newStartHourCB.Items.Add(i.ToString("00"));
                newEndHourCB.Items.Add(i.ToString("00"));
                oldStartHourCB.Items.Add(i.ToString("00"));
                oldEndHourCB.Items.Add(i.ToString("00"));
            }

            startMinuteCB.Items.Add("00");
            startMinuteCB.Items.Add("30");
            endMinuteCB.Items.Add("00");
            endMinuteCB.Items.Add("30");

            newStartMinCB.Items.Add("00");
            newEndMinCB.Items.Add("00");
            oldStartMinCB.Items.Add("00");
            oldEndMinCB.Items.Add("00");
            newStartMinCB.Items.Add("30");
            newEndMinCB.Items.Add("30");
            oldStartMinCB.Items.Add("30");
            oldEndMinCB.Items.Add("30");

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
                {
                    ((DataGridView)c).CellDoubleClick += new DataGridViewCellEventHandler(this.tableView_CellDoubleClick);
                    ((DataGridView)c).CellClick += new DataGridViewCellEventHandler(this.tableView_CellClick);
                }
                    
            }
        }
        
        private void tableView_CellClick (object sender, DataGridViewCellEventArgs e) {
            // display dun lol (display app info) HHHAHAHAHA

            AppointmentList apList1 = ((AppointmentModelController)controller).GetAppointments(doctors, dates, false);

            foreach (Control c in this.currentPanel.Controls)
            {
                if (c is DataGridView)
                {
                    foreach (Appointment t in apList1.GetAppointments())
                    {
                        if ((((DataGridView)c).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).Contains(t.GetEndTime().ToString("HH:mm")) && (((DataGridView)c).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).Contains(t.GetStartTime().ToString("HH:mm")) && (((DataGridView)c).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).Contains(t.GetStartTime().ToString("M/d/yyyy")))
                        {
                            if (t.Available())
                            {
                                save.Visible = false;
                                editBtn.Visible = true;
                                Cancel.Visible = true;

                                //set comboboxes
                                startHourCB.SelectedIndex = t.GetStartTime().Hour;
                                endHourCB.SelectedIndex = t.GetEndTime().Hour;
                                String SM = t.GetStartTime().Minute.ToString();
                                if (SM.Equals("0"))
                                    startMinuteCB.SelectedIndex = 0;
                                else if (SM.Equals("30"))
                                    startMinuteCB.SelectedIndex = 1;
                                String EM = t.GetEndTime().Minute.ToString();
                                if (EM.Equals("0"))
                                    endMinuteCB.SelectedIndex = 0;
                                else if (EM.Equals("30"))
                                    endMinuteCB.SelectedIndex = 1;
                            }
                            else
                            {
                                MessageBox.Show("Slot cannot be edited.");
                            }
                        }
                        else if ((((DataGridView)c).Rows[e.RowIndex].Cells[0].Value.ToString()).Contains(t.GetEndTime().ToString("HH:mm")) && (((DataGridView)c).Rows[e.RowIndex].Cells[0].Value.ToString()).Contains(t.GetStartTime().ToString("HH:mm")) && (((DataGridView)c).Rows[e.RowIndex].Cells[0].Value.ToString()).Contains(t.GetStartTime().ToString("M/d/yyyy")) && (((DataGridView)c).Rows[e.RowIndex].Cells[1].Value.ToString()).Contains(t.GetTitle()))
                        {
                            if (t.Available())
                            {
                                save.Visible = false;
                                editBtn.Visible = true;
                                Cancel.Visible = true;

                                //set comboboxes
                                startHourCB.SelectedIndex = t.GetStartTime().Hour;
                                endHourCB.SelectedIndex = t.GetEndTime().Hour;
                                String SM = t.GetStartTime().Minute.ToString();
                                if (SM.Equals("0"))
                                    startMinuteCB.SelectedIndex = 0;
                                else if (SM.Equals("30"))
                                    startMinuteCB.SelectedIndex = 1;
                                String EM = t.GetEndTime().Minute.ToString();
                                if (EM.Equals("0"))
                                    endMinuteCB.SelectedIndex = 0;
                                else if (EM.Equals("30"))
                                    endMinuteCB.SelectedIndex = 1;
                            }
                            else
                            {
                                MessageBox.Show("Slot cannot be edited."); //cannot edit
                            }
                        }
                    }
                }
            }
        }

        private void tableView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            AppointmentList apList1 = ((AppointmentModelController)controller).GetAppointments(doctors, dates, false);

            foreach (Control c in this.currentPanel.Controls) {
                if (c is DataGridView) {
                    foreach (Appointment t in apList1.GetAppointments()) {
                        if ((((DataGridView)c).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).Contains(t.GetEndTime().ToString("HH:mm")) && (((DataGridView)c).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).Contains(t.GetStartTime().ToString("HH:mm")) && (((DataGridView)c).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).Contains(t.GetStartTime().ToString("M/d/yyyy"))) {
                            if (t.Available()) {
                                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Delete Appointment", MessageBoxButtons.YesNo);

                                if (dialogResult == DialogResult.Yes) {
                                    ((AppointmentModelController)controller).DeleteToDatabase(t);
                                    MessageBox.Show("Slot deleted!");
                                }
                                //else if (dialogResult)
                                else if (dialogResult == DialogResult.No) {
                                    //do something else
                                }
                                


                            }
                            else {
                                MessageBox.Show("Slot cannot be deleted.");
                            }
                        }
                        else if ((((DataGridView)c).Rows[e.RowIndex].Cells[0].Value.ToString()).Contains(t.GetEndTime().ToString("HH:mm")) && (((DataGridView)c).Rows[e.RowIndex].Cells[0].Value.ToString()).Contains(t.GetStartTime().ToString("HH:mm")) && (((DataGridView)c).Rows[e.RowIndex].Cells[0].Value.ToString()).Contains(t.GetStartTime().ToString("M/d/yyyy")) && (((DataGridView)c).Rows[e.RowIndex].Cells[1].Value.ToString()).Contains(t.GetTitle())) {
                            if (t.Available()) {
                                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Delete Appointment", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes) {
                                    ((AppointmentModelController)controller).DeleteToDatabase(t);
                                    MessageBox.Show("Slot deleted!");
                                }
                                else if (dialogResult == DialogResult.No) {
                                    //do something else
                                }
                            }
                            else {
                                MessageBox.Show("Slot cannot be deleted.");
                            }
                        }
                    }
                }
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

        private void weeklyBtn_CheckedChanged(object sender, EventArgs e) {
            UpdateDate();
            this.currentView.Update(doctors, dates, false);
        }

        private void endHourCB_SelectedIndexChanged(object sender, EventArgs e) {
            if (endHourCB.SelectedIndex == 0 && startHourCB.SelectedIndex != 0) {//remove
                endMinuteCB.Items.Clear();
                endMinuteCB.Items.Add("00");
            }
            else {
                endMinuteCB.Items.Clear();
                endMinuteCB.Items.Add("00");
                endMinuteCB.Items.Add("30");
            }
        }

        private void startHourCB_SelectedIndexChanged(object sender, EventArgs e) {
            if (endHourCB.SelectedIndex == 0 && startHourCB.SelectedIndex != 0) {//remove
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

                if (ValidTime(startDate, endDate)) {
                    if (recurringText.Text.ToString().Length == 0 || recurringText.Text.ToString().Equals("0")) {
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
                            if (Int32.Parse(recurringText.Text.ToString()) > -1) {
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
                            else
                                MessageBox.Show("Invalid input.");
                        }
                        catch (Exception ex) {
                            MessageBox.Show("Invalid input.");
                        }
                    }
                }
                else
                    MessageBox.Show("Invalid time.");
            }
            else
                MessageBox.Show("Please fill up all the fields.");
        }

        private Boolean ValidTime(DateTime startDate, DateTime endDate) {
            if (endDate.Hour == 0 && endDate.Minute == 30 && DateTime.Compare(endDate, startDate) > 0 || DateTime.Compare(endDate, startDate) != 0 && DateTime.Compare(endDate, startDate) > 0 && endDate.Hour != 0 || startDate.Hour == 0 && endDate.Hour == 0 && startDate.Minute == 0 && endDate.Minute == 0)
                return true;
            if (endDate.Hour == 0 && endDate.Minute == 0 && DateTime.Compare(startDate, endDate) > 0)
                return true;

            return false;
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

        private void editBtn_Click(object sender, EventArgs e)
        {
            // get values
            // change to database
            // sort all
            oldStartHourCB.SelectedIndex = startHourCB.SelectedIndex;
            oldStartMinCB.SelectedIndex = startMinuteCB.SelectedIndex;
            oldEndHourCB.SelectedIndex = endHourCB.SelectedIndex;
            oldEndMinCB.SelectedIndex = endMinuteCB.SelectedIndex;

            //editPanel.Visible = true;
            this.Controls.Remove(currentPanel);
            this.Controls.Add(editPanel);
            editPanel.Show();

            Cancel.Visible = false;
            editBtn.Visible = false;
            save.Visible = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            AppointmentList apList1 = ((AppointmentModelController)controller).GetAppointments(doctors, dates, false);
            Appointment chosenApp = null;
            String chosenSlotNum = null; //slot num needs to be the same
            int year = dateTimePicker.Value.Year;
            int month = dateTimePicker.Value.Month;
            int day = dateTimePicker.Value.Day;

            var oldStartDate = new DateTime(year, month, day, Int32.Parse(oldStartHourCB.Text), Int32.Parse(oldStartMinCB.Text), 0);
            var oldEndDate = new DateTime(year, month, day, Int32.Parse(oldEndHourCB.Text), Int32.Parse(oldEndMinCB.Text), 0);


            Console.WriteLine("oldDate: " + oldStartDate + " - " + oldEndDate);



            if (newStartHourCB.SelectedItem == null || newStartMinCB.SelectedItem == null || newEndHourCB.SelectedItem == null || newEndMinCB.SelectedItem == null)
            {
                MessageBox.Show("Please enter a new timeslot");
            }
            else
            {
                //look for the matching appointment
                for (int i = 0; i < apList1.Count(); i++)
                {
                    Appointment a = apList1.GetByIndex(i);
                    DateTime tempStart = a.GetStartTime();
                    DateTime tempEnd = a.GetEndTime();
                    int result1 = DateTime.Compare(tempStart, oldStartDate);
                    int result2 = DateTime.Compare(tempEnd, oldEndDate);
                    if (result1 == 0 && result2 == 0)
                    {
                        chosenApp = a;
                        break;
                    }
                }
                Console.WriteLine("current Appoint: " + chosenApp.GetStartTime() + " - " + chosenApp.GetEndTime()); //appointment that was clicked
                chosenSlotNum = chosenApp.GetSlotNum();

                //delete
                ((AppointmentModelController)controller).DeleteToDatabase(chosenApp);

                //add but same slot num (use chosenSlotNum then set it at the end)
                Appointment app = null;

                int yearStart = newDatePicker.Value.Year;
                int monthStart = newDatePicker.Value.Month;
                int dayStart = newDatePicker.Value.Day;
                int hourStart = 0;
                int minutesStart = 0;

                if (newStartHourCB.SelectedItem.ToString()[0] == '0')
                    hourStart = Int32.Parse(newStartHourCB.SelectedItem.ToString().Substring(1, 1));
                else
                    hourStart = Int32.Parse(newStartHourCB.SelectedItem.ToString());

                if (startMinuteCB.SelectedItem.ToString()[0] == '0')
                    minutesStart = Int32.Parse(newStartMinCB.SelectedItem.ToString().Substring(1, 1));
                else
                    minutesStart = Int32.Parse(newStartMinCB.SelectedItem.ToString());

                DateTime startDate = new DateTime(yearStart, monthStart, dayStart, hourStart, minutesStart, 0);

                int yearEnd = newDatePicker.Value.Year;
                int monthEnd = newDatePicker.Value.Month;
                int dayEnd = newDatePicker.Value.Day;
                int hourEnd = 0;
                int minutesEnd = 0;

                if (endHourCB.SelectedItem.ToString()[0] == '0')
                    hourEnd = Int32.Parse(newEndHourCB.SelectedItem.ToString().Substring(1, 1));
                else
                    hourEnd = Int32.Parse(newEndHourCB.SelectedItem.ToString());

                if (endMinuteCB.SelectedItem.ToString()[0] == '0')
                    minutesEnd = Int32.Parse(newEndMinCB.SelectedItem.ToString().Substring(1, 1));
                else
                    minutesEnd = Int32.Parse(newEndMinCB.SelectedItem.ToString());

                DateTime endDate = new DateTime(yearEnd, monthEnd, dayEnd, hourEnd, minutesEnd, 0);

                if (ValidTime(startDate, endDate))
                {
                    if (recurringText.Text.ToString().Length == 0 || recurringText.Text.ToString().Equals("0"))
                    {
                        app = new Appointment(doctorName.Text, startDate, endDate);
                        app.SetSlotNumber(chosenSlotNum); //copy original slot num

                        if (app != null && !((AppointmentModelController)controller).Overlap(app))
                        {
                            ((AppointmentModelController)controller).AddToDatabase(app);
                            //MessageBox.Show("Time slot added!");
                        }
                        else
                            MessageBox.Show("Overlap task.");
                    }
                    else
                    {
                        try
                        {
                            if (Int32.Parse(recurringText.Text.ToString()) > -1)
                            {
                                DateTime tempStartDate = startDate;
                                DateTime tempEndDate = endDate;

                                for (int i = 0; i < Int32.Parse(recurringText.Text.ToString()); i++)
                                {
                                    app = new Appointment(doctorName.Text, tempStartDate, tempEndDate);
                                    app.SetSlotNumber(chosenSlotNum); //copy original slot num


                                    if (app != null && !((AppointmentModelController)controller).Overlap(app))
                                    {
                                        ((AppointmentModelController)controller).AddToDatabase(app);
                                    }

                                    tempStartDate = tempStartDate.AddDays(7);
                                    tempEndDate = tempEndDate.AddDays(7);
                                }
                            }
                            else
                                MessageBox.Show("Invalid input.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Invalid input.");
                        }
                    }
                }
                else
                    MessageBox.Show("Invalid time.");




                //go back to grid view
                this.Controls.Remove(editPanel);
                this.Controls.Add(currentPanel);
                this.currentView.Update(doctors, dates, false);
                editPanel.Hide();

                MessageBox.Show("Appointment Edited");
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(editPanel);
            this.Controls.Add(currentPanel);
            this.currentView.Update(doctors, dates, false);
            editPanel.Hide();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            save.Visible = true;
            editBtn.Visible = false;
        }
    }
}
