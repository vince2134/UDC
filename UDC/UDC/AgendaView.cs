using System;
using System.Collections.Generic;
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
            this.panel = MakeAgendaPanel();
        }
    }
}
