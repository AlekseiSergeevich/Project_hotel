using ProjectMP;
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
        public void RabotaNeWolkRabotaWork(BookingRequest request, List<Booking> list, StatisticCounter statistic)
        {
            int number = FindFreeRoom(list, request);
            if (number != -1) //заполняет лист данными из заявки, если есть номер соответствующий запросу покупателя
            {
                EntersData(request, list, number);
                statistic.AddToGlobalProfit(request.room);
            }
            else //создание второй заявки, но с другим номером, если не смогли найти подходящий номер
            {
                Random rnd = new Random();
                int accept = rnd.Next(1, 3);
                if (accept == 1)
                {
                    BookingRequest secondTryToFind = new BookingRequest();
                    if (request.room is Luxe)//100%
                    {
                        secondTryToFind = request;
                        secondTryToFind.room = new JuniorSuite();
                        number = FindFreeRoom(list, secondTryToFind);
                        if (number != -1) 
                        {
                            EntersData(secondTryToFind, list, number);
                            statistic.AddToGlobalProfit(secondTryToFind.room);
                        }
                    }
                    if (request.room is JuniorSuite)//70%
                    {
                        secondTryToFind = request;
                        secondTryToFind.room = new Luxe();
                        number = FindFreeRoom(list, secondTryToFind);
                        if (number != -1)
                        {
                            EntersData(secondTryToFind, list, number);//сделать скидку 70%
                            statistic.AddToGlobalProfitWithDiscount(secondTryToFind.room);
                        }
                    }
                    if (request.room is SingleRoom)//70%
                    {
                        secondTryToFind = request;
                        secondTryToFind.room = new JuniorSuite();
                        number = FindFreeRoom(list, secondTryToFind);
                        if (number != -1)
                        {
                            EntersData(secondTryToFind, list, number);
                            statistic.AddToGlobalProfitWithDiscount(secondTryToFind.room);
                        }
                    }
                    if (request.room is DoubleRoom)//70%
                    {
                        secondTryToFind = request;
                        secondTryToFind.room = new DoubleRoomWithSofa();
                        number = FindFreeRoom(list, secondTryToFind);
                        if (number != -1)
                        {
                            EntersData(secondTryToFind, list, number);
                            statistic.AddToGlobalProfitWithDiscount(secondTryToFind.room);
                        }
                    }
                    if (request.room is DoubleRoomWithSofa)//70%
                    {
                        secondTryToFind = request;
                        secondTryToFind.room = new DoubleRoom();
                        number = FindFreeRoom(list, secondTryToFind);
                        if (number != -1)
                        {
                            EntersData(secondTryToFind, list, number);
                            statistic.AddToGlobalProfitWithDiscount(secondTryToFind.room);
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
        private void EntersData(BookingRequest request, List<Booking> list, int number)// вводит данные о занятости номера в лист
        {
            list[number].bookings.Add(request.bookingDates);
            if (DateTime.Compare(request.startOfBooking, request.timeOfReceiptOfApplication) == 0)
            {
                list[number].flagOfBusyness = true;
                list[number].bookings[list[number].bookings.Count - 1].typeOfBusyness = true;
            }
            else
            {
                list[number].flagOfBooking = true;
            }
        }
    }
}