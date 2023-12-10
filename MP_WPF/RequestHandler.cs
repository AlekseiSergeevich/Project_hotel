﻿using ProjectMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MP_WPF //статистика заселения номеров, выполненых заявок и сколько щекелей пополнило казну после завершения симуляции 
{
    public class RequestHandler //обработчик заявок
    {
        public void RabotaNeWolkRabotaWork(BookingRequest request, List<Booking> list)
        {
            int number = FindFreeRoom(list, request);
            if (number != -1) //заполняет лист данными из заявки, если есть номер соответствующий запросу покупателя
            {
                EntersData(request, list, number);
            }
            else //(альфа тест)создание второй заявки, но с другим номером, если не смогли найти подходящий номер
            {
                Random rnd = new Random();
                int accept = rnd.Next(1, 3);
                if (accept == 1)
                {
                    if (request.room is Luxe)
                    {
                        BookingRequest secondTryToFind = new BookingRequest();
                        secondTryToFind = request;
                        secondTryToFind.room = new JuniorSuite();
                        number = FindFreeRoom(list, secondTryToFind);
                        if (number != -1) 
                        {
                            EntersData(secondTryToFind, list, number);
                        }
                    }
                    if (request.room is JuniorSuite)
                    {
                        BookingRequest secondTryToFind = new BookingRequest();
                        secondTryToFind = request;
                        secondTryToFind.room = new Luxe();
                        number = FindFreeRoom(list, secondTryToFind);
                        if (number != -1)
                        {
                            EntersData(secondTryToFind, list, number);//сделать скидку 70%
                        }
                    }
                    if (request.room is SingleRoom)
                    {
                        BookingRequest secondTryToFind = new BookingRequest();
                        secondTryToFind = request;
                        secondTryToFind.room = new JuniorSuite();
                        number = FindFreeRoom(list, secondTryToFind);
                        if (number != -1)
                        {
                            EntersData(secondTryToFind, list, number);
                        }
                    }
                }
            }
        }
        private int FindFreeRoom(List<Booking> list, BookingRequest request) // ищет свободный номер для гостя согласно его требованиям
        {
            int flag = -1;
            if (request.room is Luxe)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].room is Luxe)
                    {
                        bool check = DataManager(list[i], request);
                        if (check == true)
                        {
                            flag = i;
                            return flag;
                        }
                    }
                }
            }
            if (request.room is JuniorSuite)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].room is JuniorSuite)
                    {
                        bool check = DataManager(list[i], request);
                        if (check == true)
                        {
                            flag = i;
                            return flag;
                        }
                    }
                }
            }
            if (request.room is SingleRoom)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].room is SingleRoom)
                    {
                        bool check = DataManager(list[i], request);
                        if (check == true)
                        {
                            flag = i;
                            return flag;
                        }
                    }
                }
            }
            if (request.room is DoubleRoom)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].room is DoubleRoom)
                    {
                        bool check = DataManager(list[i], request);
                        if (check == true)
                        {
                            flag = i;
                            return flag;
                        }
                    }
                }
            }
            if (request.room is DoubleRoomWithSofa)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].room is DoubleRoomWithSofa)
                    {
                        bool check = DataManager(list[i], request);
                        if (check == true)
                        {
                            flag = i;
                            return flag;
                        }
                    }
                }
            }
            return flag;
        }
        private bool DataManager(Booking booking, BookingRequest request) // определяет можнт ли гость заехать в ДАННЫЙ номер в даты, когда он хочет(будет ли номер свободен)
        {
            bool flag = false;
            if (booking.bookings.Count == 0)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < booking.bookings.Count; i++)
                {
                    if (booking.bookings[i].startOfBooking > request.startOfBooking && booking.bookings[i].startOfBooking > request.endOfBooking || booking.bookings[i].endOfBooking < request.startOfBooking && booking.bookings[i].endOfBooking < request.endOfBooking)
                    {
                        flag = true;
                    }
                }
                return flag;
            }
        }
        private void EntersData(BookingRequest request, List<Booking> list, int number)
        {
            if (DateTime.Compare(request.startOfBooking, request.timeOfReceiptOfApplication) == 0)
            {
                list[number].flagOfBusyness = true;
            }
            else list[number].flagOfBooking = true;
            list[number].bookings.Add(request.bookingDates);
        }
    }
}