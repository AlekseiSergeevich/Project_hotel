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
        AnswerAboutBooking answer= new AnswerAboutBooking();
        Random rnd = new Random();
        public AnswerAboutBooking RabotaNeWolkRabotaWork(BookingRequest request, List<Booking> list, List<BookingRequest> BookingRequestslist)
        {
            int number = FindFreeRoom(list, request);
            if (number != -1) //заполняет лист данными из заявки, если есть номер соответствующий запросу покупателя
            {
                list[number] = EntersData(request, list[number], BookingRequestslist);
                MakeAnswer(request, false, true);
                return (answer);
            }
            else //создание второй заявки, но с другим номером, если не смогли найти подходящий номер
            {
                int accept = rnd.Next(1, 3);
                if (accept == 1)
                {
                    HotelRoom proposedRoom = DiscountAnalayzer(request.room);
                    BookingRequest secondTryToFind = EntersDataAfterSecondTry(request, proposedRoom);
                    number = FindFreeRoom(list, secondTryToFind);
                    if (number != -1)
                    {
                        list[number] = EntersData(request, list[number], BookingRequestslist);
                        MakeAnswer(secondTryToFind, true, true);
                        return (answer);

                    }                   
                }
            }
            return (answer);
        }
        private HotelRoom DiscountAnalayzer(HotelRoom room)
        {
            if(room is Luxe)
            {
                HotelRoom hotelRoom = new Luxe();
                return (hotelRoom);
            }
            if (room is JuniorSuite)
            {
                HotelRoom hotelRoom = new Luxe();
                return (hotelRoom);
            }
            if (room is SingleRoom)
            {
                HotelRoom hotelRoom = new JuniorSuite();
                return (hotelRoom);
            }
            if (room is DoubleRoom)
            {
                HotelRoom hotelRoom = new DoubleRoomWithSofa();
                return (hotelRoom);
            }
            if (room is DoubleRoomWithSofa)
            {
                HotelRoom hotelRoom = new DoubleRoom();
                return (hotelRoom);
            }
            return null;
        }
        private BookingRequest EntersDataAfterSecondTry(BookingRequest request, HotelRoom newRoom)
        {
            BookingRequest secondTryToFind = request;
            secondTryToFind.room = newRoom;
            return secondTryToFind;
        }
        private int FindFreeRoom(List<Booking> list, BookingRequest request) // ищет свободный номер для гостя согласно его требованиям
        {
            int flag = -1;
            var variants = list.FindAll(req => req.room.TypeOfRoom.CompareTo(request.room.TypeOfRoom) == 0);
            for (int i = 0; i < variants.Count; i++)
            {
                flag = FindDate(variants, request, i);
                if (flag != -1)
                {
                    return flag;
                }
            }
            return flag;
        }
        private int FindDate(List<Booking> variants, BookingRequest request, int position)
        {
            int flag = -1;
            bool check = DateManager(variants[position], request);
            if (check)
            {
                flag = variants[position].RoomNumber - 1;
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
        private Booking EntersData(BookingRequest request, Booking onePositionInList, List<BookingRequest> BookingRequestsList)// вводит данные о занятости номера в лист
        {
            onePositionInList.bookings.Add(request.bookingDates);
            BookingRequestsList.Add(request);
            if (DateTime.Compare(request.StartOfBooking, request.TimeOfReceiptOfApplication) == 0)
            {
                onePositionInList.FlagOfBusyness = true;
                onePositionInList.bookings[onePositionInList.bookings.Count - 1].TypeOfBusyness = true;
            }
            else
            {
                onePositionInList.FlagOfBooking = true;
            }
            return onePositionInList;
        }
        private void MakeAnswer(BookingRequest request, bool dis, bool res)
        {
            answer.Discount = dis;
            answer.ResultOfBookibg = res;
            answer.request= request;
        }
    }
}