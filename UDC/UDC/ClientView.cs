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
        public const String CLIENT_VIEW = "ClientView";

        public ClientView(ListController c) {
            this.controller = c;
            InitializeComponent();
            ((ListView)this).InitializeView();
            Show();
        }

        void ListView.InitializeView() {
            this.currentView = SubView.MakeView(controller, CLIENT_VIEW, SubView.CALENDAR_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
            dayRadioBtn.Checked = true;
            dateLabel.Text = monthCalendar.SelectionRange.Start.ToString("MMM d, yyyy");
        }

        void ListView.Update() {
            /*CALLED WHEN NOTIFY() IS CALLED, UPDATES SUBVIEWS*/
            if(currentView is CalendarView)
                this.currentView.Update(this, SubView.CALENDAR_VIEW, controller);
            if(currentView is AgendaView)
                this.currentView.Update(this, SubView.AGENDA_VIEW, controller);
            Console.WriteLine("Update");
        }

        private void ClientView_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        private void calendarViewBtn_Click(object sender, EventArgs e) {
            /*ACTION LISTENER FOR DAY VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, CLIENT_VIEW, SubView.CALENDAR_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
            this.currentView.Update(this, SubView.CALENDAR_VIEW, controller);
        }

        private void agendaViewBtn_Click(object sender, EventArgs e) {
            /*ACTION LISTENER FOR AGENDA VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, CLIENT_VIEW, SubView.AGENDA_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
            this.currentView.Update(this, SubView.AGENDA_VIEW, controller);
        }

        private void createViewBtn_Click(object sender, EventArgs e) {
            /*ACTION LISTENER FOR CREATE VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, CLIENT_VIEW, SubView.CREATE_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
        }

        private void todayBtn_Click(object sender, EventArgs e) {
            monthCalendar.SetDate(DateTime.Today);
            if(dayRadioBtn.Checked)
                dateLabel.Text = monthCalendar.SelectionRange.Start.ToString("MMM d, yyyy");
            else if(weekRadioBtn.Checked)
                dateLabel.Text = monthCalendar.SelectionRange.Start.ToString("MMMM") + " - Week " + GetWeekNumberOfMonth(monthCalendar.SelectionRange.Start).ToString();
            ((ListView)this).Update();
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e) {
            dateLabel.Text = monthCalendar.SelectionRange.Start.ToString("MMM d, yyyy");
            monthCalendar.SelectionRange.Start = DateTime.Today;
            ((ListView)this).Update();
        }

        private void dayRadioBtn_CheckedChanged(object sender, EventArgs e) {
            if(currentView is CalendarView)
                this.currentView.Update(this, SubView.CALENDAR_VIEW, controller);
            if (dayRadioBtn.Checked) {
                this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
                dateLabel.Text = monthCalendar.SelectionRange.Start.ToString("MMM d, yyyy");
            }
            if (weekRadioBtn.Checked) {
                DateTime date = monthCalendar.SelectionRange.Start.Date;
                this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected_1);
                dateLabel.Text = date.ToString("MMMM") + " - Week " + GetWeekNumberOfMonth(date).ToString();
            }
        }

        private void weekRadioBtn_CheckedChanged(object sender, EventArgs e) {
            if(currentView is CalendarView)
                this.currentView.Update(this, SubView.CALENDAR_VIEW, controller);
        }

        private void monthCalendar_DateSelected_1(object sender, DateRangeEventArgs e) {
            DateTime date = monthCalendar.SelectionRange.Start.Date;

            dateLabel.Text = date.ToString("MMMM") + " - Week " + GetWeekNumberOfMonth(date).ToString();

            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime startDateOfWeek = date.AddDays(offset);
            DateTime endDateOfWeek = startDateOfWeek.AddDays(6);

            Console.WriteLine(startDateOfWeek.ToString("MMMM d - dddd")); /*GET START OF WEEK*/
            Console.WriteLine(endDateOfWeek.ToString("MMMM d - dddd"));
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
