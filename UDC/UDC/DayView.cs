using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDC {
    public class DayView : SubView{
        public DayView(ListController c, String parentView) {
            this.controller = c;
            this.viewBuilder = SubViewBuilder.BuildSubView(parentView);
            InitializeView();
        }

        protected override void InitializeView() {
            this.panel = this.viewBuilder.BuildDayView();
        }

        public override void Update(ListView parentView, String subView) {
            this.viewBuilder.Update(parentView, subView);
        }
    }
}
