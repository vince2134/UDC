using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDC {
    public class SecretarySubViewBuilder : SubViewBuilder
    {
        private System.Windows.Forms.Panel createPanel = new System.Windows.Forms.Panel();
        private System.Windows.Forms.Button appoint = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button discard = new System.Windows.Forms.Button();
        private System.Windows.Forms.ListView listView1= new System.Windows.Forms.ListView();
        private System.Windows.Forms.Panel agendaPanel = new System.Windows.Forms.Panel();
        private System.Windows.Forms.DataGridView agendaGrid = new System.Windows.Forms.DataGridView();
        private System.Windows.Forms.Panel calendarPanel = new System.Windows.Forms.Panel();
        private System.Windows.Forms.DataGridView calendarGrid = new System.Windows.Forms.DataGridView();



        public SecretarySubViewBuilder() {

        }

        public override Panel BuildAgendaView() {
            // 
            // agendaPanel
            // 
            this.agendaPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.agendaPanel.Controls.Add(this.agendaGrid);
            this.agendaPanel.Location = new System.Drawing.Point(248, 84);
            this.agendaPanel.Name = "agendaPanel";
            this.agendaPanel.Size = new System.Drawing.Size(391, 244);
            this.agendaPanel.TabIndex = 12;
            // 
            // agendaGrid
            // 
            this.agendaGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.agendaGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.agendaGrid.GridColor = Color.White;
            this.agendaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.agendaGrid.GridColor = System.Drawing.Color.WhiteSmoke;
            this.agendaGrid.Location = new System.Drawing.Point(0, 0);
            this.agendaGrid.Name = "agendaGrid";
            this.agendaGrid.Size = new System.Drawing.Size(391, 244);
            this.agendaGrid.TabIndex = 0;
            ((System.ComponentModel.ISupportInitialize)(this.agendaGrid)).BeginInit();
            this.agendaPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agendaGrid)).EndInit();


      
            this.agendaPanel.SuspendLayout();
            return agendaPanel;
        }

        public override Panel BuildCreateView() {
         
            // createPanel
            // 
            this.createPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.createPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.createPanel.Controls.Add(this.appoint);
            this.createPanel.Controls.Add(this.discard);
            this.createPanel.Controls.Add(this.listView1);
            this.createPanel.Location = new System.Drawing.Point(248, 84);
            this.createPanel.Name = "createPanel";
            this.createPanel.Size = new System.Drawing.Size(391, 253);
            this.createPanel.TabIndex = 9;
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
            this.appoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.appoint.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appoint.ForeColor = System.Drawing.Color.Firebrick;
            this.appoint.UseVisualStyleBackColor = true;
            this.appoint.Location = new System.Drawing.Point(220, 213);
            this.appoint.Name = "appoint";
            this.appoint.Size = new System.Drawing.Size(75, 30);
            this.appoint.TabIndex = 2;
            this.appoint.Text = "Appoint";
            this.appoint.UseVisualStyleBackColor = true;
            this.appoint.Click += new System.EventHandler(this.appoint_Click);

            this.createPanel.ResumeLayout(false);

            this.createPanel.SuspendLayout();


            return createPanel;
        }

        public override Panel BuildDayView() {
            // 
            // calendarPanel
            // 
            this.calendarPanel.Controls.Add(this.calendarGrid);
            this.calendarPanel.Location = new System.Drawing.Point(248, 84);
            this.calendarPanel.Name = "calendarPanel";
            this.calendarPanel.Size = new System.Drawing.Size(391, 244);
            this.calendarPanel.TabIndex = 12;
            // 
            // calendarGrid
            // 
            this.calendarGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.calendarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.calendarGrid.Location = new System.Drawing.Point(0, 0);
            this.calendarGrid.Name = "calendarGrid";
            this.calendarGrid.Size = new System.Drawing.Size(391, 244);
            this.calendarGrid.TabIndex = 0;
            ((System.ComponentModel.ISupportInitialize)(this.calendarGrid)).BeginInit();
            this.calendarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calendarGrid)).EndInit();

            this.calendarPanel.SuspendLayout();
            return calendarPanel;
        }

    public override void Update(ListView parentView, String subView, ListController controller)
       {


          //  if (subView.Equals(SubView.CALENDAR_VIEW))
          //  {

                /*(TEST CODE) REPLACE WITH REAL UPDATE OF DOCTOR VIEW DAY VIEW*/



            //
          //  }
         //   else if (subView.Equals(SubView.AGENDA_VIEW))
         //   {

            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("Time");
             //   dt.Columns.Add("Todo");
                /*(TEST CODE) REPLACE WITH REAL UPDATE OF DOCTOR VIEW AGENDA VIEW*/
          //      AppointmentList apList = ((AppointmentModelController)controller).GetAppointments();
                
               
            //   // foreach (Appointment t in apList.GetAppointments())
             //   {
             //     

            //        dt.Rows.Add("  ");

           //     }

        //        agendaGrid.DataSource = dt;
                
            //    AppointmentList apList1 = ((AppointmentModelController)controller).GetAppointments();

          //      int i = 0;
            //    foreach (Appointment t in apList1.GetAppointments())
             //   {

 
                    
                 
                //    i++;
                   
          //      }




       //     }
    }

        private void appoint_Click(object sender, EventArgs e){
            Appointment appt = null;





        }





        
    }
}
