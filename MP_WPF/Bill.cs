using ProjectMP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_WPF
{
    public class Bill //счет
    {
        private string fileName = "Bill.txt";
        public void SendBill(BookingRequest booking)
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine($"Здравствуйте, {booking.name}!");
            writer.WriteLine($"Вы прибывали в отеле с {booking.startOfBooking} по {booking.endOfBooking}. Мы надеемся, что вам все понравилось!");
            writer.WriteLine($"Сумма вашего счета составляет {(booking.endOfBooking - booking.startOfBooking).Days}");
            writer.WriteLine("Всего хорошего,");
            writer.WriteLine("Администрация отеля.");
            writer.WriteLine();
        }
    }
}