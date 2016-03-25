using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            ((ListView)this).InitializeView();
            InitializeComponent();
            Show();
        }

        void ListView.InitializeView() {
            this.currentView = SubView.MakeView(controller, CLIENT_VIEW, SubView.DAY_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
        }

        void ListView.Update() {
            /*CALLED WHEN NOTIFY() IS CALLED, UPDATES SUBVIEWS*/
            this.currentView.Update(this, SubView.DAY_VIEW);
            this.currentView.Update(this, SubView.AGENDA_VIEW);
        }

        private void ClientView_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        private void dayViewBtn_Click(object sender, EventArgs e) {
            /*ACTION LISTENER FOR DAY VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, CLIENT_VIEW, SubView.DAY_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
        }

        private void agendaViewBtn_Click(object sender, EventArgs e) {
            /*ACTION LISTENER FOR AGENDA VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, CLIENT_VIEW, SubView.AGENDA_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
        }

        private void createViewBtn_Click(object sender, EventArgs e) {
            /*ACTION LISTENER FOR CREATE VIEW*/
            this.Controls.Remove(currentPanel);
            this.currentView = SubView.MakeView(controller, CLIENT_VIEW, SubView.CREATE_VIEW);
            this.currentPanel = this.currentView.GetPanel();
            this.Controls.Add(currentPanel);
            this.currentPanel.Show();
        }
    }
}
