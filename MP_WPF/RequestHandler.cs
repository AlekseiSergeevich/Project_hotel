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
        BookingConfirmation confirmation = new BookingConfirmation();
        RequestWriter requestWriter = new RequestWriter();
        AnswerAboutBooking answer= new AnswerAboutBooking();
        public AnswerAboutBooking RabotaNeWolkRabotaWork(BookingRequest request, List<Booking> list, List<BookingRequest> BookingRequestslist)
        {
            int number = FindFreeRoom(list, request);
            requestWriter.Write(request);
            if (number != -1) //заполняет лист данными из заявки, если есть номер соответствующий запросу покупателя
            {
                EntersData(request, list, number, BookingRequestslist);
                MakeAnswer(request.room, false, true);
                return (answer);
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
                        secondTryToFind = EntersDataAfterSecondTry(request, new JuniorSuite(), secondTryToFind);
                        number = FindFreeRoom(list, secondTryToFind);
                        if (number != -1)
                        {
                            EntersData(secondTryToFind, list, number, BookingRequestslist);
                            MakeAnswer(secondTryToFind.room, false, true);
                            return (answer);

                        }
                    }
                    if (request.room is JuniorSuite)//70%
                    {
                        secondTryToFind = EntersDataAfterSecondTry(request, new Luxe(), secondTryToFind);
                        number = FindFreeRoom(list, secondTryToFind);
                        if (number != -1)
                        {
                            EntersData(secondTryToFind, list, number, BookingRequestslist);
                            MakeAnswer(secondTryToFind.room, true, true);
                            return (answer);
                        }
                    }
                    if (request.room is SingleRoom)//70%
                    {
                        secondTryToFind = EntersDataAfterSecondTry(request, new JuniorSuite(), secondTryToFind);
                        number = FindFreeRoom(list, secondTryToFind);
                        if (number != -1)
                        {
                            EntersData(secondTryToFind, list, number, BookingRequestslist);
                            MakeAnswer(secondTryToFind.room, true, true);
                            return (answer);
                        }
                    }
                    if (request.room is DoubleRoom)//70%
                    {
                        secondTryToFind = EntersDataAfterSecondTry(request, new DoubleRoomWithSofa(), secondTryToFind);
                        number = FindFreeRoom(list, secondTryToFind);
                        if (number != -1)
                        {
                            EntersData(secondTryToFind, list, number, BookingRequestslist);
                            MakeAnswer(secondTryToFind.room, true, true);
                            return (answer);
                        }
                    }
                    if (request.room is DoubleRoomWithSofa)//70%
                    {
                        secondTryToFind = EntersDataAfterSecondTry(request, new DoubleRoom(), secondTryToFind);
                        number = FindFreeRoom(list, secondTryToFind);
                        if (number != -1)
                        {
                            EntersData(secondTryToFind, list, number, BookingRequestslist);
                            MakeAnswer(secondTryToFind.room, true, true);
                            return (answer);
                        }
                    }
                }
            }
            return (answer);
        }
        private BookingRequest EntersDataAfterSecondTry(BookingRequest request, HotelRoom newRoom, BookingRequest secondTryToFind)
        {
            secondTryToFind = request;
            secondTryToFind.room = newRoom;
            return secondTryToFind;
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
                        flag = FindDate(list, request, flag, i);
                    }
                }
            }
            if (request.room is JuniorSuite)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].room is JuniorSuite)
                    {
                        flag = FindDate(list, request, flag, i);
                    }
                }
            }
            if (request.room is SingleRoom)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].room is SingleRoom)
                    {
                        flag = FindDate(list, request, flag, i);
                    }
                }
            }
            if (request.room is DoubleRoom)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].room is DoubleRoom)
                    {
                        flag = FindDate(list, request, flag, i);
                    }
                }
            }
            if (request.room is DoubleRoomWithSofa)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].room is DoubleRoomWithSofa)
                    {
                        flag = FindDate(list, request, flag, i);
                    }
                }
            }
            return flag;
        }
        private int FindDate(List<Booking> list, BookingRequest request, int flag, int i)
        {
            bool check = DateManager(list[i], request);
            if (check == true)
            {
                flag = i;
                return flag;
            }
            else
            {
                return flag;
            }
            
        }
        private bool DateManager(Booking booking, BookingRequest request) // определяет можнт ли гость заехать в ДАННЫЙ номер в даты, когда он хочет(будет ли номер свободен)
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
                    if (booking.bookings[i].StartOfBooking > request.StartOfBooking && booking.bookings[i].StartOfBooking > request.EndOfBooking || booking.bookings[i].EndOfBooking < request.StartOfBooking && booking.bookings[i].EndOfBooking < request.EndOfBooking)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                return flag;
            }
        }
        private void EntersData(BookingRequest request, List<Booking> list, int number, List<BookingRequest> BookingRequestsList)// вводит данные о занятости номера в лист
        {
            list[number].bookings.Add(request.bookingDates);
            confirmation.Write(request);
            BookingRequestsList.Add(request);
            if (DateTime.Compare(request.StartOfBooking, request.TimeOfReceiptOfApplication) == 0)
            {
                list[number].FlagOfBusyness = true;
                list[number].bookings[list[number].bookings.Count - 1].TypeOfBusyness = true;
            }
            else
            {
                list[number].FlagOfBooking = true;
            }
        }
        private void MakeAnswer(HotelRoom room, bool dis, bool res)
        {
            answer.hotelRoom = room;
            answer.Discount = dis;
            answer.ResultOfBookibg = res;
        }
    }
}