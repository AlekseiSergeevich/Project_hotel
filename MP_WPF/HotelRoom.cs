using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMP
{
    public abstract class HotelRoom
    {
        public int price;
        public int numberOfPerson;
        public string type;
        public override string ToString()
        {
            return (System.String.Format("Тип номера: {0}\r\nСтоимость: {1}", type, price));
        }
    }
}