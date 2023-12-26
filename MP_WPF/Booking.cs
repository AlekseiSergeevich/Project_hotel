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
        private bool flagOfBooking;
        private int roomNumber;
        private bool flagOfBusyness;
        public List<BookingDates> bookings = new List<BookingDates>(); //лист чтобы записывать даты, в которые этот номер будет забронирован
        public bool FlagOfBooking
        {
            get { return flagOfBooking; }
            set { flagOfBooking = value; }
        }
        public bool FlagOfBusyness
        {
            get { return flagOfBusyness; }
            set { flagOfBusyness = value; }
        }
        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }
        public Booking(HotelRoom room, bool flagOfBusyness, bool flagOfBooking, int roomNumber)
        {
            this.room = room;
            this.flagOfBusyness = flagOfBusyness;
            this.flagOfBooking = flagOfBooking;
            this.roomNumber = roomNumber;
        }
    }
}