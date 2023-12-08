using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMP
{
    public class BookingRequest
    {
        public string name;
        public DateTime startOfBooking;
        public DateTime endOfBooking;
        public BookingDates bookingDates = new BookingDates();
        public string telephoneNumber;
        public DateTime timeOfReceiptOfApplication;
        public HotelRoom room;
        public BookingRequest()
        {

        }
    }
}