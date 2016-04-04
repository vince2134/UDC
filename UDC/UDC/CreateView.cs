using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDC {
    public class CreateView : SubView{
        private System.Windows.Forms.Button create = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button discard = new System.Windows.Forms.Button();
        private System.Windows.Forms.ListView listView1 = new System.Windows.Forms.ListView();
        public CreateView(ListController c) {
            this.controller = c;
            InitializeView();
        }

        protected override void InitializeView() {
            this.panel = new Panel();
            this.panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel.Controls.Add(this.create);
            this.panel.Controls.Add(this.discard);
            this.panel.Controls.Add(this.listView1);
            this.panel.Location = new System.Drawing.Point(248, 84);
            this.panel.Name = "createPanel";
            this.panel.Size = new System.Drawing.Size(391, 253);
            this.panel.TabIndex = 9;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(391, 207);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // discard
            // 
            this.discard.BackColor = System.Drawing.Color.Firebrick;
            this.discard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.discard.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discard.ForeColor = System.Drawing.SystemColors.ControlText;
            this.discard.Location = new System.Drawing.Point(301, 213);
            this.discard.Name = "discard";
            this.discard.Size = new System.Drawing.Size(75, 30);
            this.discard.TabIndex = 1;
            this.discard.Text = "Discard";
            this.discard.UseVisualStyleBackColor = false;
            // 
            // appoint
            // 
            this.create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.create.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create.ForeColor = System.Drawing.Color.Firebrick;
            this.create.UseVisualStyleBackColor = true;
            this.create.Location = new System.Drawing.Point(220, 213);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(75, 30);
            this.create.TabIndex = 2;
            this.create.Text = "Create";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);

            this.panel.ResumeLayout(false);

            this.panel.SuspendLayout();
        }

        private void create_Click(object sender, EventArgs e)
        {
            Appointment appt = null;





        }

    }
}
