using ProjectMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MP_WPF
{
    public class StatisticCounter
    {
        private double globalprofit;
        List<HotelRoom> roomStatistic = new List<HotelRoom>();
        private string fileName = "Statistic.txt";
        public StatisticCounter()
        {
            globalprofit = 0;
        }
        public void AddToGlobalProfit(HotelRoom room)
        {
            globalprofit += room.price;
            roomStatistic.Add(room);
        }
        public void AddToGlobalProfitWithDiscount(HotelRoom room)
        {
            globalprofit += room.price * 0.7;
            roomStatistic.Add(room);
        }
        public void GetResults()//Использовать этот метод после окончания симуляции, чтобы записать статистику в файл
        {
            StreamWriter writer = new StreamWriter(fileName, true);
            int hotelRoomLuxeCounter = 0;
            int hotelRoomJuniourSuiteCounter = 0;
            int hotelRoomSingleRCounter = 0;
            int hotelRoomDoubleCounter = 0;
            int hotelRoomDoubleWithSofaCounter = 0;
            for (int i = 0; i < roomStatistic.Count; i++)
            {
                if(roomStatistic[i] is Luxe)
                {
                    hotelRoomLuxeCounter++;
                }
                if (roomStatistic[i] is JuniorSuite)
                {
                    hotelRoomJuniourSuiteCounter++;
                }
                if (roomStatistic[i] is SingleRoom)
                {
                    hotelRoomSingleRCounter++;
                }
                if (roomStatistic[i] is DoubleRoom)
                {
                    hotelRoomDoubleCounter++;
                }
                if (roomStatistic[i] is DoubleRoomWithSofa)
                {
                    hotelRoomDoubleWithSofaCounter++;
                }
            }
            Double halfOfThisRoom =Math.Round((Convert.ToDouble(hotelRoomLuxeCounter) / Convert.ToDouble(roomStatistic.Count))*100,2);
            writer.WriteLine($"Номер Luxe выбирали в {halfOfThisRoom} процентах случаев, а точнее {hotelRoomLuxeCounter} раз.");
            halfOfThisRoom = Math.Round((Convert.ToDouble(hotelRoomJuniourSuiteCounter) / Convert.ToDouble(roomStatistic.Count)) * 100, 2);
            writer.WriteLine($"Номер Junior Suite выбирали в {halfOfThisRoom} процентах случаев, а точнее {hotelRoomJuniourSuiteCounter} раз.");
            halfOfThisRoom = Math.Round((Convert.ToDouble(hotelRoomSingleRCounter) / Convert.ToDouble(roomStatistic.Count)) * 100, 2);
            writer.WriteLine($"Номер Single Room выбирали в {halfOfThisRoom} процентах случаев, а точнее {hotelRoomSingleRCounter} раз.");
            halfOfThisRoom = Math.Round((Convert.ToDouble(hotelRoomDoubleCounter) / Convert.ToDouble(roomStatistic.Count)) * 100, 2);
            writer.WriteLine($"Номер Double Room выбирали в {halfOfThisRoom} процентах случаев, а точнее {hotelRoomDoubleCounter} раз.");
            halfOfThisRoom = Math.Round((Convert.ToDouble(hotelRoomDoubleWithSofaCounter) / Convert.ToDouble(roomStatistic.Count)) * 100, 2);
            writer.WriteLine($"Номер Double Room With Sofa выбирали в {halfOfThisRoom} процентах случаев, а точнее {hotelRoomDoubleWithSofaCounter} раз.");
            writer.WriteLine($"Всего было обработано {roomStatistic.Count} заявок.");
            writer.WriteLine($"Всего отель заработал {Math.Round(globalprofit,2)} рублей за указанный период.");
            writer.WriteLine();
        }
      
    }
}
