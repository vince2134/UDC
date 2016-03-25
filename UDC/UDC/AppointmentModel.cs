using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDC {
    public class AppointmentModel : ListModel{
        private AppointmentList appointments;

        public AppointmentModel() {
            this.appointments = new AppointmentList();
            this.views = new List<ListView>();
        }

        public void Add(Appointment a) {
            /*SORTS AND ADDS APPOINTMENT BY STARTTIME*/
            int index = 0;

            if (appointments.Count() == 0) {
                this.appointments.Add(a);
            }
            else if (appointments.Count() == 1) {
                if (DateTime.Compare(a.GetStartTime(), appointments.GetAppointments()[index].GetStartTime()) < 0)
                    this.appointments.Insert(index, a);
                else
                    this.appointments.Add(a);
            }
            else if (appointments.Count() > 1) {
                int count = appointments.Count();

                while (index < count) {
                    if (DateTime.Compare(a.GetStartTime(), appointments.GetAppointments()[index].GetStartTime()) < 0) {
                        appointments.Insert(index, a);
                        break;
                    }
                    else if (DateTime.Compare(a.GetStartTime(), appointments.GetAppointments()[appointments.Count() - 1].GetStartTime()) > 0) {
                        appointments.Add(a);
                        break;
                    }
                    else if (DateTime.Compare(a.GetStartTime(), appointments.GetAppointments()[index].GetStartTime()) > 0) {
                        if (DateTime.Compare(a.GetStartTime(), appointments.GetAppointments()[index + 1].GetStartTime()) < 0) {
                            appointments.Insert(index + 1, a);
                            break;
                        }
                        else
                            index++;

                    }
                }
            }

            this.Notify();
        }

        public void AddToDatabase(Appointment a) {
            /*INSERT MYSQL HERE*/
            Add(a);
            this.Notify();
        }

        public AppointmentList GetAppointments() {
            return this.appointments;
        }

        public int GetAppointmentSize() {
            return this.appointments.Count();
        }

        public Boolean Overlap(Appointment a1) {
            foreach(Appointment a2 in appointments.GetAppointments()) {
                if (Appointment.Overlap(a1, a2))
                    return true;
            }

            return false;
        }

        public void ImportAppointments() {
            /*INSERT MYSQL HERE*/
            /*Add(a);*/
            this.Notify();
        }
    }
}
