﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectMP
{
    public class RequestGenerator//теперь в генератор передается интервал через который придет заявка и весь счет времени будет идти тут <=======3
    {
        BookingRequest bookingRequest;
        private DateTime date = DateTime.Now;
        public BookingRequest Generator(int itervalBetweenAplications) //Дописать создание файла с заявками
        {
            Random rnd = new Random();
            bookingRequest = new BookingRequest();
            int count = File.ReadAllLines("Visiters.txt").Length;
            int finish = rnd.Next(0, count);
            bookingRequest.name = File.ReadLines("Visiters.txt").Skip(finish).First();
            DateTime startData = date.AddHours(Convert.ToDouble(itervalBetweenAplications));
            startData = startData.AddDays(Convert.ToDouble(rnd.Next(0, 4)));
            DateTime endData = startData;
            endData = endData.AddDays(Convert.ToDouble(rnd.Next(1, 4)));
            bookingRequest.bookingDates.startOfBooking = startData;
            bookingRequest.bookingDates.endOfBooking = endData;
            date = date.AddHours(Convert.ToDouble(itervalBetweenAplications));
            bookingRequest.timeOfReceiptOfApplication = date;
            bookingRequest.startOfBooking = startData;
            bookingRequest.endOfBooking = endData;
            int num = rnd.Next(000, 999);
            int num2 = rnd.Next(00, 99);
            int num3 = rnd.Next(00, 99);
            string phone = "+7 (987)" + " " + num.ToString() + " " + num2.ToString() + " " + num3.ToString();
            bookingRequest.telephoneNumber = phone;
            int room = rnd.Next(0, 5);
            if (room == 0)
            {
                HotelRoom hotelRoom = new Luxe();
                bookingRequest.room = hotelRoom;
            }
            if (room == 1)
            {
                HotelRoom hotelRoom = new JuniorSuite();
                bookingRequest.room = hotelRoom;
            }
            if (room == 2)
            {
                HotelRoom hotelRoom = new SingleRoom();
                bookingRequest.room = hotelRoom;
            }
            if (room == 3)
            {
                HotelRoom hotelRoom = new DoubleRoom();
                bookingRequest.room = hotelRoom;
            }
            if (room == 4)
            {
                HotelRoom hotelRoom = new DoubleRoomWithSofa();
                bookingRequest.room = hotelRoom;
            }
            return (bookingRequest);
        }
    }
}