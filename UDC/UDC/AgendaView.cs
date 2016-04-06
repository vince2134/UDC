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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();

            this.panel = new System.Windows.Forms.Panel();
            this.tableView = new System.Windows.Forms.DataGridView();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableView)).BeginInit();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableView)).EndInit();

            this.tableView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableView.BackgroundColor = System.Drawing.Color.White;
            this.tableView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableView.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableView.DefaultCellStyle = dataGridViewCellStyle1;
            this.tableView.Location = new System.Drawing.Point(0, 0);
            this.tableView.Name = "dataGridView1";
            this.tableView.RowHeadersVisible = false;
            this.tableView.Size = new System.Drawing.Size(458, 316);
            this.tableView.TabIndex = 0;
            this.tableView.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);

            this.panel.Controls.Add(this.tableView);
            this.panel.Location = new System.Drawing.Point(251, 66);
            this.panel.Name = "dayPanel";
            this.panel.Size = new System.Drawing.Size(458, 316);
            this.panel.TabIndex = 1;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) {
            tableView.ClearSelection();
        }
    }
}
