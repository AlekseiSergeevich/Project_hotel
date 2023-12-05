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
            price = 3000;
            numberOfPerson = 2;
            type = "Двухместный с диваном";
        }
        
    }
}