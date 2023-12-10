using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMP
{
    public class SingleRoom : HotelRoom
    {
        public SingleRoom()
        {
            price = 2500;
            numberOfPerson = 1;
            type = "Одноместный";
        }
    }


}