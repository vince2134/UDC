using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDC {
    public class AppointmentList {
        private List<Appointment> appointments;

        public AppointmentList() {
            this.appointments = new List<Appointment>();
        }

        public void Add(Appointment a) {
            this.appointments.Add(a);
        }

        public void Insert(int index, Appointment a) {
            this.appointments.Insert(index, a);
        }

        public int Count() {
            return this.appointments.Count;
        }

        public void RemoveAt(int i) {
            this.appointments.RemoveAt(i);
        }

        public int IndexOf(Appointment a) {
            return this.appointments.IndexOf(a);
        }

        public Appointment GetByIndex(int i) {
            return this.appointments[i];
        }

        public List<Appointment> GetAppointments() {
            return this.appointments;
        }
    }
}
