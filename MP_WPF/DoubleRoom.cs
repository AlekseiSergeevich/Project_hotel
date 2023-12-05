using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMP
{
    public class DoubleRoom : HotelRoom
    {
        public DoubleRoom()
        {
            price = 2700;
            numberOfPerson = 2;
            type = "Двухместный";
        }
        
    }
}