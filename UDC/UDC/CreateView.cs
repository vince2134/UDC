using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDC {
    public class CreateView : SubView{
        public CreateView(ListController c, String parentView) {
            this.controller = c;
            this.viewBuilder = SubViewBuilder.BuildSubView(parentView);
            InitializeView();
        }

        protected override void InitializeView() {
            this.panel = this.viewBuilder.BuildCreateView();
        }

        public override void Update(ListView parentView, String subView, ListController c) {
            this.viewBuilder.Update(parentView, subView, c);
        }
    }
}
