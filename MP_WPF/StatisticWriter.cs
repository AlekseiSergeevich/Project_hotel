using ProjectMP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_WPF
{
    public class StatisticWriter
    {
        private string fileName = "Statistic.txt";
        public void GetResult(StatisticCounter counter)//Использовать этот метод после окончания симуляции, чтобы записать статистику в файл
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            int hotelRoomLuxeCounter = 0;
            int hotelRoomJuniourSuiteCounter = 0;
            int hotelRoomSingleRCounter = 0;
            int hotelRoomDoubleCounter = 0;
            int hotelRoomDoubleWithSofaCounter = 0;
            for (int i = 0; i < counter.roomStatistic.Count; i++)
            {
                if (counter.roomStatistic[i] is Luxe)
                {
                    hotelRoomLuxeCounter++;
                }
                if (counter.roomStatistic[i] is JuniorSuite)
                {
                    hotelRoomJuniourSuiteCounter++;
                }
                if (counter.roomStatistic[i] is SingleRoom)
                {
                    hotelRoomSingleRCounter++;
                }
                if (counter.roomStatistic[i] is DoubleRoom)
                {
                    hotelRoomDoubleCounter++;
                }
                if (counter.roomStatistic[i] is DoubleRoomWithSofa)
                {
                    hotelRoomDoubleWithSofaCounter++;
                }
            }
            Double halfOfThisRoom = Math.Round((Convert.ToDouble(hotelRoomLuxeCounter) / Convert.ToDouble(counter.roomStatistic.Count)) * 100, 2);
            writer.WriteLine($"Номер Luxe выбирали в {halfOfThisRoom} процентах случаев, а точнее {hotelRoomLuxeCounter} раз.");
            halfOfThisRoom = Math.Round((Convert.ToDouble(hotelRoomJuniourSuiteCounter) / Convert.ToDouble(counter.roomStatistic.Count)) * 100, 2);
            writer.WriteLine($"Номер Junior Suite выбирали в {halfOfThisRoom} процентах случаев, а точнее {hotelRoomJuniourSuiteCounter} раз.");
            halfOfThisRoom = Math.Round((Convert.ToDouble(hotelRoomSingleRCounter) / Convert.ToDouble(counter.roomStatistic.Count)) * 100, 2);
            writer.WriteLine($"Номер Single Room выбирали в {halfOfThisRoom} процентах случаев, а точнее {hotelRoomSingleRCounter} раз.");
            halfOfThisRoom = Math.Round((Convert.ToDouble(hotelRoomDoubleCounter) / Convert.ToDouble(counter.roomStatistic.Count)) * 100, 2);
            writer.WriteLine($"Номер Double Room выбирали в {halfOfThisRoom} процентах случаев, а точнее {hotelRoomDoubleCounter} раз.");
            halfOfThisRoom = Math.Round((Convert.ToDouble(hotelRoomDoubleWithSofaCounter) / Convert.ToDouble(counter.roomStatistic.Count)) * 100, 2);
            writer.WriteLine($"Номер Double Room With Sofa выбирали в {halfOfThisRoom} процентах случаев, а точнее {hotelRoomDoubleWithSofaCounter} раз.");
            writer.WriteLine($"Всего было обработано {counter.roomStatistic.Count} заявок.");
            writer.WriteLine($"Всего отель заработал {Math.Round(counter.globalprofit, 2)} рублей за указанный период.");
            writer.WriteLine();
        }
    }
}
