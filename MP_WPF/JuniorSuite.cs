﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMP
{
    public class JuniorSuite : HotelRoom //полулюкс если что 
    {
        JuniorSuite(int p, int count, int n)
        {
            price = p;
            numberOfPerson = count;
            roomNumber = n;
        }
    }
}