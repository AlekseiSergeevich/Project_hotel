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
        public void SendBill(BookingRequest request)
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine($"Здравствуйте, {request.name}!");
            writer.WriteLine($"Вы прибывали в отеле с {request.startOfBooking} по {request.endOfBooking}. Мы надеемся, что вам все понравилось!");
            writer.WriteLine($"Сумма вашего счета составляет {request.room.price}");
            writer.WriteLine("Всего хорошего,");
            writer.WriteLine("Администрация отеля.");
            writer.WriteLine();
            writer.Close();
        }
    }
}