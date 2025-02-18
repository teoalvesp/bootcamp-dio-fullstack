using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SystemHotel.Common.Models;

namespace SystemHotel.Common.Models
{
    public class Reserve
    {
        private static int nextId = 1;
        public int Id { get; private set; }
        public List<Person>? Guests { get; set; }
        public Suite? Suite { get; set; }
        public int DaysReserved { get; set; }

        public Reserve()
        {
            Id = nextId++;
            Guests = new List<Person>();
        }

        public void RegisterGuests(List<Person> guests)
        {
            if (Guests == null)
            {
                Guests = new List<Person>();
            }

            Guests.AddRange(guests);

            foreach (var guest in Guests)
            {
                Console.WriteLine("Nome: " + guest.Name);
            }
        }

        public void RegisterSuite(Suite suite)
        {
            Suite = suite;
            Console.WriteLine("\n>> Suite registrada com sucesso");
        }

        public int GetNumberGuests()
        {
            return Guests?.Count ?? 0;
        }

        public decimal CalculateDailyValue()
        {
            if (Suite == null || Guests == null)
            {
                return 0.0m;
            }

            decimal total = Suite.DailyValue * DaysReserved;


            if (Guests.Count > 1)
            {
                total *= 0.90m;
            }

            return total;
        }
    }
}
