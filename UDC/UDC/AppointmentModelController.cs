using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDC {
    public class AppointmentModelController : ListController{
        public AppointmentModelController() {
            this.model = new AppointmentModel();
            this.AttachViews();
            this.ImportAppointments();
        }

        public void AttachViews() {
            ListView doctorView = new DoctorView(this);
            ListView clientView = new ClientView(this);
            ListView secretaryView = new SecretaryView(this);

            this.model.Attach(doctorView);
            this.model.Attach(clientView);
            this.model.Attach(secretaryView);
        }

        public void Add(Appointment a) {
            ((AppointmentModel)this.model).Add(a);
        }

        public AppointmentList GetAppointments() {
            return ((AppointmentModel)this.model).GetAppointments();
        }

        public Boolean Overlap(Appointment a) {
            return ((AppointmentModel)this.model).Overlap(a);
        }

        public void ImportAppointments() {
            ((AppointmentModel)this.model).ImportAppointments();
        }

        public int GetAppointmentSize() {
            return ((AppointmentModel)this.model).GetAppointmentSize();
        }
    }
}
