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
        public BookingDates()
        {
            startOfBooking = DateTime.Now;
            startOfBooking = DateTime.Now;
        }
        public override string ToString()
        {
            return (System.String.Format("Занят с: {0}  по: {1}", startOfBooking, startOfBooking));
        }
    }
}
