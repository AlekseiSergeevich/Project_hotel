using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMP
{
    public class BookingDates
    {
        public DateTime startOfBooking;
        public DateTime endOfBooking;
        public bool typeOfBusyness;//busyness - true;booking - false
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
            return (System.String.Format("Забронирован:\r\nс {0}\r\nпо {1}\r\n", startOfBooking, endOfBooking));
        }
    }
}