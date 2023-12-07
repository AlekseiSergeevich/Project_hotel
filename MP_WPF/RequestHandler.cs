using ProjectMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MP_WPF
{
    public class RequestHandler //обработчик заявок
    {
        public void RabotaNeWolkRabotaWork(BookingRequest request, List<Booking> list)
        {
            int number = FindFreeRoom(list, request);
            if(number != -1) //заполняет лист данными из заявки, если есть номер соответствующий запросу покупателя
            {
                list[number].room=request.room;     
                if(DateTime.Compare(request.startOfBooking, request.timeOfReceiptOfApplication) == 0)
                {
                    list[number].flagOfBusyness = true;
                } 
                else list[number].flagOfBooking = true;
                list[number].bookings.Add(request.bookingDates);
            }
            else
            {
                //тут должна быть реализация предложения номера за 70% от его стоимости
            }
        }
        private int FindFreeRoom(List<Booking> list, BookingRequest request) // ищет свободный номер для гостя согласно его требованиям
        {
            int flag = -1;
            if (request.room is Luxe)
            {
                for (int i=0; i < list.Count; i++)
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
            if(booking.bookings.Count == 0)
            {
                return true;
            }
            else
            {
                for(int i=0;i < booking.bookings.Count;i++)
                {
                    if (booking.bookings[i].startOfBooking>request.startOfBooking && booking.bookings[i].startOfBooking>request.endOfBooking || booking.bookings[i].endOfBooking<request.startOfBooking && booking.bookings[i].endOfBooking < request.endOfBooking)
                    {
                        flag = true;
                    }
                }
                return flag;
            }
        }
    }
}