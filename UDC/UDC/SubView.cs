using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDC {
    public abstract class SubView {
        protected ListController controller;
        protected SubViewBuilder viewBuilder;
        protected Panel panel;
        public const String CALENDAR_VIEW = "CalendarView";
        public const String AGENDA_VIEW = "AgendaView";
        public const String CREATE_VIEW = "CreateView";

        protected abstract void InitializeView();
        public abstract void Update(ListView parentView, String subView, ListController c);

        public static SubView MakeView(ListController c, String parentView, String subView) {
            if (subView.Equals(CALENDAR_VIEW)) {
                return new CalendarView(c, parentView);
            }
            else if (subView.Equals(AGENDA_VIEW)) {
                return new AgendaView(c, parentView);
            }
            else if (subView.Equals(CREATE_VIEW)) {
                return new CreateView(c, parentView);
            }

            return null;
        }

        public Panel GetPanel() {
            return this.panel;
        }
    }
}
