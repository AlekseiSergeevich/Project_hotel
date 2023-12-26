using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMP
{
    public class BookingRequest
    {
        private string name;
        private DateTime startOfBooking;
        private DateTime endOfBooking;
        public BookingDates bookingDates = new BookingDates();
        private string telephoneNumber;
        private DateTime timeOfReceiptOfApplication;
        public HotelRoom room;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
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
        public string TelephoneNumber
        {
            get { return telephoneNumber; }
            set { telephoneNumber = value; }
        }
        public DateTime TimeOfReceiptOfApplication
        {
            get { return timeOfReceiptOfApplication; }
            set { timeOfReceiptOfApplication = value; }
        }

        public BookingRequest()
        {

        }
    }
}