using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemHotel.Common.Models
{
    public class Suite
    {
        public string? SuiteType { get; set; }
        public int Capacity { get; set; }
        public decimal DailyValue { get; set; }

        public Suite(string suiteType, int capacity, decimal dailyValue)
        {
            SuiteType = suiteType;
            Capacity = capacity;
            DailyValue = dailyValue;
        }
    }
}