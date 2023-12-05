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
        public BookingDates(DateTime s, DateTime e)
        {
            startOfBooking = s;
            endOfBooking = e;
        }
    }
}
