using ProjectMP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_WPF
{
    internal class RequestWriter : IWriter
    {
        private string fileName = "Requests.txt";
        public void Write(BookingRequest request)
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.Write("Заявка.");
            writer.WriteLine($"Фамилия Имя: {request.Name}.");
            writer.WriteLine($"Дата заезда - выезда: {request.StartOfBooking} - {request.EndOfBooking}.");
            writer.WriteLine($"Тип номера: {request.room.TypeOfRoom}");
            writer.WriteLine($"Номер телефона заказчика: {request.TelephoneNumber}");
            writer.WriteLine($"Время подачи заявки: {request.TimeOfReceiptOfApplication}");
            writer.WriteLine();
            writer.Close();
        }
    }
}