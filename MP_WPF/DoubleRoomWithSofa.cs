using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMP
{
    public class DoubleRoomWithSofa : HotelRoom
    {
        public DoubleRoomWithSofa()
        {
            price = 2700;
            numberOfPerson = 2;
            type = "Двухместный с диваном";
        }

    }
}