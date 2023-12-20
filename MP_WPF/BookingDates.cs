using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMP
{
    public class BookingDates
    {
        private DateTime startOfBooking;
        private DateTime endOfBooking;
        private bool typeOfBusyness;//busyness - true;booking - false
        public DateTime StartOfBooking
        {
            get { return startOfBooking; }
            set { startOfBooking = value; }
        }
        public DateTime EndOfBooking
        {
            get { return endOfBooking; }
            set { endOfBooking = value; }
        }
        public bool TypeOfBusyness
        {
            get { return typeOfBusyness; }
            set { typeOfBusyness = value; }
        }
        public BookingDates()
        {
            startOfBooking = DateTime.Now;
            endOfBooking = DateTime.Now;
            typeOfBusyness = false;
        }
        public string ToStringBusyness()
        {
            return (System.String.Format("Занят:\r\nс {0}\r\nпо {1}", startOfBooking, endOfBooking));
        }
        public string ToStringBooking()
        {
            return (System.String.Format("Забронирован:\r\nс {0}\r\nпо {1}", startOfBooking, endOfBooking));
        }
    }
}