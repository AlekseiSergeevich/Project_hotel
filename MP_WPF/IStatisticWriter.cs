using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_WPF
{
    internal interface IStatisticWriter
    {
        void Write(StatisticCounter counter);
    }
}
