using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDC {
    public class CreateView : SubView{
        public CreateView(ListController c) {
            this.controller = c;
            InitializeView();
        }

        protected override void InitializeView() {
            this.panel = MakeCreatePanel();
        }
    }
}
