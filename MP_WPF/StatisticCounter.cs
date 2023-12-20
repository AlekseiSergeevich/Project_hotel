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
        private double globalprofit;
        public List<HotelRoom> roomStatistic = new List<HotelRoom>();
        public double Globalprofit
        {
            get { return globalprofit; }
        }
        public StatisticCounter()
        {
            globalprofit = 0;
        }
        public void AddToGlobalProfit(HotelRoom room)
        {
            globalprofit += room.Price;
            roomStatistic.Add(room);
        }
        public void AddToGlobalProfitWithDiscount(HotelRoom room)
        {
            globalprofit += room.Price * 0.7;
            roomStatistic.Add(room);
        }
    }
}