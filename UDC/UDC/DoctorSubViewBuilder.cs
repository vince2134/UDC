using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDC {
    public class DoctorSubViewBuilder : SubViewBuilder {
        public DoctorSubViewBuilder() {

        }

        public override Panel BuildAgendaView() {
            Panel panel = new Panel();
            /*INSERT INITIALIZATION OF AGENDA PANEL HERE*/
            Label test = new Label();
            test.Text = "DOCT AGENDA";
            panel.Controls.Add(test);
            return panel;
        }

        public override Panel BuildCreateView() {
            Panel panel = new Panel();
            /*INSERT INITIALIZATION OF CREATE PANEL HERE*/
            Label test = new Label();
            test.Text = "DOCTOR CREATE";
            panel.Controls.Add(test);
            return panel;
        }

        public override Panel BuildDayView() {
            Panel panel = new Panel();
            /*INSERT INITIALIZATION OF DAY PANEL HERE*/
            Label test = new Label();
            test.Text = "DOCTOR DAY";
            panel.Controls.Add(test);
            return panel;
        }

        public override void Update(ListView parentView, String subView) {
            if (subView.Equals(SubView.DAY_VIEW)) {
                /*(TEST CODE) REPLACE WITH REAL UPDATE OF DOCTOR VIEW DAY VIEW*/
                foreach (Control c in ((DoctorView)parentView).Controls)
                    if (c is Panel) {
                        foreach (Control d in ((Panel)c).Controls)
                            if (d is Label)
                                d.Text = "DOC DAY UP";
                    }
            }
            else if (subView.Equals(SubView.AGENDA_VIEW)) {
                /*(TEST CODE) REPLACE WITH REAL UPDATE OF DOCTOR VIEW AGENDA VIEW*/
                foreach (Control c in ((DoctorView)parentView).Controls)
                    if (c is Panel)
                        foreach (Control d in ((Panel)c).Controls)
                            if (d is Label)
                                d.Text = "DOC AGEN UP";
            }
        }
    }
}
