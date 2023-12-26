using ProjectMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_WPF
{
    public class AnswerAboutBooking
    {
        private bool resultOfBookibg;
        public HotelRoom hotelRoom;
        private bool discount;
        public AnswerAboutBooking()
        {
            hotelRoom = new Luxe();
            resultOfBookibg = false;
            discount = false;
        }
        public bool ResultOfBookibg
        {
            get { return resultOfBookibg; }
            set { resultOfBookibg = value; }
        }
        public bool Discount
        {
            get { return discount; }
            set { discount = value; }
        }
    }
}
