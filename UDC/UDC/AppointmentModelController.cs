using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDC {
    public class AppointmentModelController : ListController {
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

        public void AddToDatabase(Appointment a) {
            ((AppointmentModel)this.model).AddToDatabase(a);

        }
        public void UpdateDatabase(Appointment a, String status) {
            ((AppointmentModel)this.model).UpdateDatabase(a, status);
        }

        public void DeleteToDatabase(Appointment a) {
            ((AppointmentModel)this.model).DeleteToDatabase(a);
        }

        public void UpdateAppInDatabase(Appointment a) {
            ((AppointmentModel)this.model).UpdateAppInDatabase(a);
        }

        public void Delete(Appointment a) {
            ((AppointmentModel)this.model).Delete(a.GetSlotNum());
        }

        public AppointmentList GetAppointments(List<String> doctors, List<DateTime> dates, Boolean availableOnly) {
            DateTime curDate;
            AppointmentList filteredAppointments = new AppointmentList();
            AppointmentList appointments = ((AppointmentModel)this.model).GetAppointments();

            if (!availableOnly) {

                if (dates.Count == 1) {
                    curDate = dates[0].Date;

                    foreach (Appointment t in appointments.GetAppointments()) {
                        if ((DateTime.Compare(t.GetStartTime().Date, curDate.Date) == 0)) {
                            foreach (String dr in doctors) {
                                if (t.GetTitle().Equals(dr))
                                    filteredAppointments.Add(t);
                            }
                        }

                    }
                }
                else {
                    foreach (Appointment t in appointments.GetAppointments()) {
                        if (t.GetStartTime().Date >= dates[0].Date && t.GetStartTime().Date <= dates[1].Date)
                            foreach (String dr in doctors) {
                                if (t.GetTitle().Equals(dr))
                                    filteredAppointments.Add(t);
                            }
                    }
                }

            }
            else {
                if (dates.Count == 1) {
                    curDate = dates[0].Date;

                    foreach (Appointment t in appointments.GetAppointments()) {
                        if (t.Available()) {
                            if ((DateTime.Compare(t.GetStartTime().Date, curDate.Date) == 0)) {
                                foreach (String dr in doctors) {
                                    if (t.GetTitle().Equals(dr))
                                        filteredAppointments.Add(t);
                                }
                            }
                        }
                    }
                }
                else {
                    foreach (Appointment t in appointments.GetAppointments()) {
                        if (t.Available()) {
                            if (t.GetStartTime().Date >= dates[0].Date && t.GetStartTime().Date <= dates[1].Date)
                                foreach (String dr in doctors) {
                                    if (t.GetTitle().Equals(dr))
                                        filteredAppointments.Add(t);
                                }
                        }
                    }
                }

            }

            return filteredAppointments;
        }

        public AppointmentList GetAllAppointments() {
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
