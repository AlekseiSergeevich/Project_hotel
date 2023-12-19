using ProjectMP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MP_WPF
{
    public class StatisticCounter //разбить на 2 класса
    {
        public double globalprofit;
        public List<HotelRoom> roomStatistic = new List<HotelRoom>();
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
    }
}