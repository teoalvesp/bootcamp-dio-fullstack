using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemHotel.Common.Models
{

    public class ReserveList
    {
        public List<Reserve> Reserves { get; private set; }
        public ReserveList()
        {
            Reserves = new List<Reserve>();
        }
    }
}