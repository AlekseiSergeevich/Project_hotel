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
<<<<<<< HEAD
            startOfBooking = DateTime.Now;
        }
        public override string ToString()
        {
            return (System.String.Format("Занят с: {0}  по: {1}", startOfBooking, startOfBooking));
=======
            endOfBooking = DateTime.Now;
>>>>>>> d7f4bb9e7b80d19cbddc04be2a21d5f484f21513
        }
    }
}
