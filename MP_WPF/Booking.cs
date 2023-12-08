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
        public bool flagOfBusyness;
<<<<<<< HEAD
        public List<BookingDates> bookings = new List<BookingDates>(); //лист чтобы записывать даты, в которые этот номер будет забронирован
=======
        public List<BookingDates> bookings =new List<BookingDates>(); //лист чтобы записывать даты, в которые этот номер будет забронирован
>>>>>>> d7f4bb9e7b80d19cbddc04be2a21d5f484f21513
        public Booking(HotelRoom room, bool flagOfBusyness, bool flagOfBooking, int roomNumber)
        {
            this.room = room;
            this.flagOfBusyness = flagOfBusyness;
            this.flagOfBooking = flagOfBooking;
            this.roomNumber = roomNumber;
        }
    }
}