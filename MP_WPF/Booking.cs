using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMP
{
    public class Booking //массив этого класса надо сделать
    {
        public HotelRoom room;
        //public BookingDates dates;
        public bool flagOfBooking;
        public int roomNumber;
        public List<BookingDates> bookings; //лист чтобы записывать даты, в которые этот номер будет забронирован
    }
}
