using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDC {
    public class DatabaseSingleton {
        private static DatabaseSingleton db;
        private static String username;
        private static String password;
        private static int maxSlotno;

        private DatabaseSingleton() {
            List<String> acc = new List<String>();

            var lines = File.ReadLines(@"..\..\db_account.txt");
            foreach (var line in lines) {
                acc.Add(line);
            }

            SetUsername(acc[0]);
            SetPassword(acc[1]);
            SetMaxSlotNo();
        }

        public static DatabaseSingleton GetInstance() {
            if (db == null)
                db = new DatabaseSingleton();

            return db;
        }

        private void SetMaxSlotNo() {
            MySqlConnection myConn;
            MySqlDataReader reader;

            String username = GetUsername();
            String password = GetPassword();
            String dbname = "udc_database";
            String myConnection = "datasource=localhost;database=" + dbname + ";port=3306;username=" + username + ";password=" + password;

            try {
                myConn = new MySqlConnection(myConnection);
                Console.WriteLine("Success");

                MySqlCommand command = myConn.CreateCommand();
                command.CommandText = "select max(slotno) from time_slots;";
                myConn.Open();

                reader = command.ExecuteReader();
                while (reader.Read()) {
                    maxSlotno = Int32.Parse(reader["max(slotno)"].ToString());
                }

                Console.WriteLine("MAX SLOT NO: " + maxSlotno);
            }
            catch (Exception e) {
                Console.WriteLine("Connection Failed");
            }
        }

        public int GetMaxSlotNo() {
            SetMaxSlotNo();
            return maxSlotno;
        }

        private void SetUsername(String u) {
            username = u;
        }

        private void SetPassword(String p) {
            password = p;
        }

        public String GetUsername() {
            return username;
        }

        public String GetPassword() {
            return password;
        }
    }
}
