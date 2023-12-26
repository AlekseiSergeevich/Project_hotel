using ProjectMP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_WPF
{
    public class Bill : IWriter //счет
    {
        private string fileName = "Bill.txt";
        public void Write(BookingRequest request)
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine($"Здравствуйте, {request.Name}!");
            writer.WriteLine($"Вы прибывали в отеле с {request.StartOfBooking} по {request.EndOfBooking}. Мы надеемся, что вам все понравилось!");
            writer.WriteLine($"Сумма вашего счета составляет {request.room.Price}");
            writer.WriteLine("Всего хорошего,");
            writer.WriteLine("Администрация отеля.");
            writer.WriteLine();
            writer.Close();
        }
    }
}