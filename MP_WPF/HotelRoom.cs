using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMP
{
    public abstract class HotelRoom
    {
        private protected int price;
        private protected int numberOfPerson;
        private protected string type;
        public string TypeOfRoom
        {
            get { return type; }
        }
        public int Price
        {
            get { return price; }
        }
        public override string ToString()
        {
            return (System.String.Format("Тип номера: {0}\r\nСтоимость: {1}", type, price));
        }
    }
}