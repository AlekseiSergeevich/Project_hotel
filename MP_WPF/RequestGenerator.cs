using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectMP
{
    public class RequestGenerator
    {
        BookingRequest bookingRequest;
        public BookingRequest Generator()
        {
            Random rnd = new Random();
            bookingRequest = new BookingRequest();
            int count = File.ReadAllLines("Visiters.txt").Length;
            int finish =rnd.Next(0, count);
            bookingRequest.name = File.ReadLines("Visiters.txt").Skip(finish).First();
            DateTime startData = DateTime.Now;
            startData.AddDays(rnd.Next(0,4));
            DateTime endData = startData;
            endData.AddDays(rnd.Next(1,3));
            bookingRequest.startOfBooking = startData;
            bookingRequest.endOfBooking = endData;
            int num = rnd.Next(000, 999);
            int num2 = rnd.Next(00, 99);
            int num3 = rnd.Next(00, 99);
            string phone = "+7 (987)" + " " + num.ToString() + " " + num2.ToString() + " " + num3.ToString();
            bookingRequest.telephoneNumber = phone;
            return(bookingRequest);
        }
    }
}
