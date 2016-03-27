using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDC {
    public abstract class ListModel {
        protected List<ListView> views;

        public void Attach(ListView observer) {
            this.views.Add(observer);
        }

        public void Detach(ListView observer) {
            this.views.Remove(observer);
        }

        public void Notify() {
            foreach (ListView v in views)
                v.Update();
        }
    }
}
