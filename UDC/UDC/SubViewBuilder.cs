using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDC {
    public abstract class SubViewBuilder {
        public static SubViewBuilder BuildSubView(String parentView) {
            if (parentView.Equals(DoctorView.DOCTOR_VIEW))
                return new DoctorSubViewBuilder();
            else if (parentView.Equals(ClientView.CLIENT_VIEW))
                return new ClientSubViewBuilder();
            else if (parentView.Equals(SecretaryView.SECRETARY_VIEW))
                return new SecretarySubViewBuilder();

            return null;
        }

        public abstract Panel BuildCreateView();
        public abstract Panel BuildDayView();
        public abstract Panel BuildAgendaView();
        public abstract void Update(ListView parentView, String subView, ListController c);
    }
}
