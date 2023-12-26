using MP_WPF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMP //исправить заявку(добавить тип номера для бронирования)
{
    public class BookingConfirmation : IWriter //сообщение о подтверждении бронирования и запись их в файл
    {
        private string fileName = "confirmation.txt";
        public void Write(BookingRequest booking)
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine($"Здравствуйте, {booking.Name}!");
            writer.WriteLine("Мы рады сообщить вам о успешном завершении процесса бронирования вашего пребывания в нашем отеле!");
            writer.WriteLine($"Напоминаем, что вы забронировали номер {booking.room.TypeOfRoom} стоимостью - {booking.room.Price}р.");
            writer.WriteLine($"Бронь будет распространяться на данные даты {booking.StartOfBooking} - {booking.EndOfBooking}.");
            writer.WriteLine("Спасибо, что выбрали наш отель!");
            writer.WriteLine("По всем вопросам обращаться по телефону +79108107589");
            writer.WriteLine();
            writer.Close();
        }
    }
}