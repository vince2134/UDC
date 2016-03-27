using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
           
            this.currentView = SubView.MakeView(controller, SECRETARY_VIEW, SubView.CALENDAR_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
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
        void ListView.Update()
        {
            /*CALLED WHEN NOTIFY() IS CALLED, UPDATES SUBVIEWS*/
           
            this.currentView.Update(this, SubView.CALENDAR_VIEW,controller);
            this.currentView.Update(this, SubView.AGENDA_VIEW, controller);
        }

        private void SecretaryView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dayViewBtn_Click(object sender, EventArgs e)
        {
            /*ACTION LISTENER FOR DAY VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, SECRETARY_VIEW, SubView.CALENDAR_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
        }

        private void agendaViewBtn_Click(object sender, EventArgs e)
        {
            /*ACTION LISTENER FOR AGENDA VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, SECRETARY_VIEW, SubView.AGENDA_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
     
        }

        private void createViewBtn_Click(object sender, EventArgs e)
        {
            /*ACTION LISTENER FOR CREATE VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, SECRETARY_VIEW, SubView.CREATE_VIEW);
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
    }
}
