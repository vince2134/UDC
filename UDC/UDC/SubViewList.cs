using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDC {
    public class SubViewList {
        private List<SubView> subViews;

        public SubViewList() {
            this.subViews = new List<SubView>();
        }

        public void Add(SubView subView) {
            this.subViews.Add(subView);
        }

        public SubView GenerateSubView(ListController c, String subView) {
            if(subViews.Count == 0) {
                subViews.Add(SubView.MakeView(c, subView));
                return subViews[0];
            }
            else {
                if (subView.Equals(SubView.AGENDA_VIEW)) {
                    foreach (SubView s in subViews) {
                        if (s is AgendaView)
                            return s;
                    }
                    subViews.Add(SubView.MakeView(c, SubView.AGENDA_VIEW));
                    return subViews[subViews.Count - 1];
                }
                else if (subView.Equals(SubView.CALENDAR_VIEW)) {
                    foreach (SubView s in subViews) {
                        if (s is CalendarView)
                            return s;
                    }
                    subViews.Add(SubView.MakeView(c, SubView.CALENDAR_VIEW));
                    return subViews[subViews.Count - 1];
                }
            }

            return null;
        }
    }
}
