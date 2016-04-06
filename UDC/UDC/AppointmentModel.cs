using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDC {
    public class AppointmentModel : ListModel {
        private AppointmentList appointments;
        private AppointmentList filteredAppointments;
        MySqlConnection myConn;
        MySqlDataReader reader;
        DatabaseSingleton dbSettings = DatabaseSingleton.GetInstance();

        public AppointmentModel() {
            this.appointments = new AppointmentList();
            this.filteredAppointments = new AppointmentList();
            this.views = new List<ListView>();
            String username = dbSettings.GetUsername();
            String password = dbSettings.GetPassword();
            String dbname = "udc_database";
            String myConnection = "datasource=localhost;database=" + dbname + ";port=3306;username=" + username + ";password=" + password;

            try {
                myConn = new MySqlConnection(myConnection);
                Console.WriteLine("Success");
            }
            catch (Exception e) {
                Console.WriteLine("Connection Failed");
            }
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
            try {
                myConn.Close();
                String docID = null;

                MySqlCommand command = myConn.CreateCommand();
                command.CommandText = "select * from doctors where name = "+ "'" + a.GetTitle() + "';";
                myConn.Open();

                reader = command.ExecuteReader();
                while (reader.Read()) {
                    docID = reader["doctorid"].ToString();
                }

                Console.WriteLine(docID);
                myConn.Close();

                DateTime start = a.GetStartTime();
                DateTime end = a.GetEndTime();
                String available = "Available";
                String startTime = start.Year + "-" + start.Month + "-" + start.Day + " " + start.Hour + ":" + start.Minute + ":" + start.Second;
                String endTime = end.Year + "-" + end.Month + "-" + end.Day + " " + end.Hour + ":" + end.Minute + ":" + end.Second;

                command.CommandText = "INSERT INTO time_slots (doctorid,startTime,endTime,status) values ('" + docID + "','" + startTime + "','" + endTime + "','" + available + "');";

                Add(a);
                myConn.Open();
                reader = command.ExecuteReader();

                myConn.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            this.Notify();
        }

        public void ToggleAvailability() {

        }

        public AppointmentList GetAppointments() {

            return appointments;

        }

        public int GetAppointmentSize() {
            return this.appointments.Count();
        }

        public Boolean Overlap(Appointment a1) {
            foreach (Appointment a2 in appointments.GetAppointments()) {
                if (Appointment.Overlap(a1, a2))
                    return true;
            }

            return false;
        }

        public void ImportAppointments() {
            /*INSERT MYSQL HERE*/
            try {
                MySqlCommand command = myConn.CreateCommand();
                command.CommandText = "select time_slots.slotno,time_slots.startTime, time_slots.endTime,name,time_slots.status from time_slots inner join doctors on time_slots.doctorID = doctors.doctorID ;";

                myConn.Open();
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    DateTime startTime = new DateTime();
                    DateTime.TryParse(reader["startTime"].ToString(), out startTime);
                    DateTime endTime = new DateTime();
                    DateTime.TryParse(reader["endTime"].ToString(), out endTime);


                    Appointment appointment = new Appointment(reader["name"].ToString(), "blue", startTime, endTime);


                    if (reader["status"].ToString().Equals("Occupied"))
                        appointment.SetAvailability(false);
                    else
                        appointment.SetAvailability(true);

                    AddFromDatabase(appointment);
                }
                myConn.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            this.Notify();

        }

        public void AddFromDatabase(Appointment a) {
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
        }
    }
}
