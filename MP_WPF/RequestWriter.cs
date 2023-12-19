using ProjectMP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_WPF
{
    internal class RequestWriter
    {
        private string fileName = "Requests.txt";
        public void WriteRequest(BookingRequest request)
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.Write("Заявка.");
            writer.WriteLine($"Фамилия Имя: {request.name}.");
            writer.WriteLine($"Дата заезда - выезда: {request.startOfBooking} - {request.endOfBooking}.");
            writer.WriteLine($"Тип номера: {request.room.type}");
            writer.WriteLine($"Номер телефона заказчика: {request.telephoneNumber}");
            writer.WriteLine($"Время подачи заявки: {request.timeOfReceiptOfApplication}");
            writer.WriteLine();
            writer.Close();
        }
    }
}