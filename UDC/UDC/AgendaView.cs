using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDC {
    public class AgendaView : SubView{
        public AgendaView(ListController c) {
            this.controller = c;
            InitializeView();
        }

        protected override void InitializeView() {
            this.panel = new Panel();
            this.tableView = new DataGridView();
            this.panel.Controls.Add(this.tableView);
            this.panel.Location = new System.Drawing.Point(248, 84);
            this.panel.Name = "agendaPanel";
            this.panel.Size = new System.Drawing.Size(391, 244);
            this.panel.TabIndex = 12;
            // 
            // agendaGrid
            // 
            this.tableView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.tableView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableView.GridColor = Color.White;
            this.tableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableView.GridColor = System.Drawing.Color.WhiteSmoke;
            this.tableView.Location = new System.Drawing.Point(0, 0);
            this.tableView.Name = "agendaGrid";
            this.tableView.Size = new System.Drawing.Size(391, 244);
            this.tableView.TabIndex = 0;
            ((System.ComponentModel.ISupportInitialize)(this.tableView)).BeginInit();
            this.tableView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableView)).EndInit();

            this.tableView.SuspendLayout();
        }
    }
}
