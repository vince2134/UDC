using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDC {
    public class ClientSubViewBuilder : SubViewBuilder {
        public ClientSubViewBuilder() {

        }

        public override Panel BuildAgendaView() {
            Panel panel = new Panel();
            /*INSERT INITIALIZATION OF AGENDA PANEL HERE*/
            Label test = new Label();
            test.Text = "CLIENT AGENDA";
            panel.Controls.Add(test);
            return panel;
        }

        public override Panel BuildCreateView() {
            Panel panel = new Panel();
            /*INSERT INITIALIZATION OF AGENDA PANEL HERE*/
            Label test = new Label();
            test.Text = "CLIENT CREATE";
            panel.Controls.Add(test);
            return panel;
        }

        public override Panel BuildDayView() {
            Panel panel = new Panel();
            /*INSERT INITIALIZATION OF DAY PANEL HERE*/
            Label test = new Label();
            test.Text = "CLIENT DAY";
            panel.Controls.Add(test);
            return panel;
        }

        public override void Update(ListView parentView, String subView,ListController controller) {
            
            if (subView.Equals(SubView.CALENDAR_VIEW)) {
                /*(TEST CODE) REPLACE WITH REAL UPDATE OF DOCTOR VIEW DAY VIEW*/
                foreach (Control c in ((ClientView)parentView).Controls)
                    if (c is Panel) {
                        foreach (Control d in ((Panel)c).Controls)
                            if (d is Label)
                                d.Text = "CLI DAY UP";
                    }
            }
            else if (subView.Equals(SubView.AGENDA_VIEW)) {
                /*(TEST CODE) REPLACE WITH REAL UPDATE OF DOCTOR VIEW AGENDA VIEW*/
                foreach (Control c in ((ClientView)parentView).Controls)
                    if (c is Panel)
                        foreach (Control d in ((Panel)c).Controls)
                            if (d is Label)
                                d.Text = "CLI AGEN UP";
            }
        }
    }
}
