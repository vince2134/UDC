using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDC {
    public class Appointment {
        private String title;
        private String slot_Number;
        private Color color;
        private DateTime startTime;
        private DateTime endTime;
        private Boolean available;

        public Appointment(String title, String color, DateTime startTime, DateTime endTime,String num) {
            this.title = title;
            this.available = true;
            this.color = Color.FromName(color);
            this.startTime = startTime;
            this.endTime = endTime;
            this.slot_Number = num;
        }

        public Appointment(String title, DateTime startTime, DateTime endTime) {
            this.title = title;
            this.available = true;
            SetColor();
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public String GetTitle() {
            return this.title;
        }

        public String GetStringColor() {
            return this.color.ToString();
        }

        public Color GetColor() {
            return this.color;
        }

        public DateTime GetStartTime() {
            return this.startTime;
        }

        public DateTime GetEndTime() {
            return this.endTime;
        }

        public static Boolean Overlap(Appointment a1, Appointment a2) {
            /*CHECKS IF NEW APPOINTMENT OVERLAPS*/
            DateTime startTime = a1.GetStartTime();

            if (startTime.Date == a2.GetStartTime().Date) {
                DateTime endTime = a1.GetEndTime();

                if (DateTime.Compare(a2.GetStartTime(), startTime) == 0 || (DateTime.Compare(startTime, a2.GetStartTime()) > 0 && DateTime.Compare(startTime, a2.GetEndTime()) < 0) || (DateTime.Compare(endTime, a2.GetStartTime()) > 0 && DateTime.Compare(endTime, a2.GetEndTime()) < 0))
                    return true;
                if (endTime.Hour == 0 && a2.GetEndTime().Hour != 0)
                    if (DateTime.Compare(startTime, a2.GetEndTime()) < 0)
                        return true;
                if (endTime.Hour == 0 && a2.GetEndTime().Hour == 0) {
                    return true;
                }
                if (endTime.Hour != 0 && a2.GetEndTime().Hour == 0) {
                    if (DateTime.Compare(endTime, a2.GetStartTime()) > 0)
                        return true;
                }
            }

            return false;
        }

        public Boolean Available() {
            return this.available;
        }

        public void SetAvailability(Boolean a) {
            this.available = a;
            SetColor();
            
        }

        public void SetColor()
        {
            if (this.available)
                this.color = Color.RoyalBlue;
            else
                this.color = Color.Firebrick;
        }
        public String GetSlotNum()
        {
            return this.slot_Number;
        }

        public void SetSlotNumber(String slotNum)
        { 

            this.slot_Number = slotNum;
        }
        
    }
}
