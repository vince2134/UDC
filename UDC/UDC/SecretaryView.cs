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

namespace UDC
{
    public partial class SecretaryView : Form, ListView
    {
        private ListController controller;
        private SubView currentView;
        private Panel currentPanel;
        private List<String> doctors;
        private List<DateTime> dates;
        public const String SECRETARY_VIEW = "SecretaryView";
        MySqlConnection myConn;
        MySqlDataReader reader;

        public SecretaryView(ListController c)
        {
            this.controller = c;
            InitializeComponent();
           
            ((ListView)this).InitializeView();
           
                
            Show();
            
        }

        void ListView.InitializeView()
        {
            this.doctors = new List<String>();
            this.dates = new List<DateTime>();
            this.currentView = SubView.MakeView(controller, SubView.CALENDAR_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
            this.dayRadio.Checked = true;
            dateLabel.Text = monthCalendar1.SelectionRange.Start.ToString("MMM d, yyyy");
            InitializeDoctors();

        }

       private void InitializeDoctors()
        {
            String username = "root";
            String password = "mysqldev";
            String dbname = "udc_database";
            String myConnection = "datasource=localhost;database=" + dbname + ";port=3306;username=" + username + ";password=" + password;
            try
            {
                myConn = new MySqlConnection(myConnection);
                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection Failed");
            }
            try
            {
                MySqlCommand command = myConn.CreateCommand();
                command.CommandText = "select * from doctors";

                myConn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {

                    drListBox.Items.Add(reader["name"].ToString());


                }
                myConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
          

        }

        void ListView.Update(){
            /*CALLED WHEN NOTIFY() IS CALLED, UPDATES SUBVIEWS*/
            this.currentView.Update(doctors, dates);
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

        private void UpdateDoctor() {
            this.doctors.Clear();


        }

        private void SecretaryView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dayViewBtn_Click(object sender, EventArgs e)
        {
            /*ACTION LISTENER FOR DAY VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, SubView.CALENDAR_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
            this.currentView.Update(doctors, dates);
        }

        private void agendaViewBtn_Click(object sender, EventArgs e)
        {
            /*ACTION LISTENER FOR AGENDA VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, SubView.AGENDA_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
        }

        private void createViewBtn_Click(object sender, EventArgs e)
        {
            /*ACTION LISTENER FOR CREATE VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, SubView.CREATE_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
        }

        private void todayButton_Click(object sender, EventArgs e){

            dateLabel.Text = DateTime.Today.ToString("MMM d, yyyy");
            
        }

        private void filter_Click(object sender, EventArgs e)
        {

        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            dateLabel.Text = monthCalendar1.SelectionRange.Start.ToString("MMM d, yyyy");
        }

        private void drListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dayRadio_CheckedChanged(object sender, EventArgs e) {
            UpdateDate();
            this.currentView.Update(doctors, dates);

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
    }
}
