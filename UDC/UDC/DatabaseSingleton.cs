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

        private DatabaseSingleton() {
            List<String> acc = new List<String>();

            var lines = File.ReadLines(@"C:\Users\avggo\Documents\UDC\db_account.txt");
            foreach (var line in lines) {
                acc.Add(line);
            }

            SetUsername(acc[0]);
            SetPassword(acc[1]);
        }

        public static DatabaseSingleton GetInstance() {
            if (db == null)
                db = new DatabaseSingleton();

            return db;
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
