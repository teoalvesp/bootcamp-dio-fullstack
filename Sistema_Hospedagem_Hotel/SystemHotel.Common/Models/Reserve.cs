using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SystemHotel.Common.Models
{
    public class Reserve
    {
        public List<Person>? Guests { get; set; }
        public Suite? Suite { get; set; }
        public int DaysReserved { get; set; }

        public Reserve()
        {
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
            Console.WriteLine("Suite registrada com sucesso");
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

            // Aplicar desconto se houver mais de uma pessoa (opcional)
            if (Guests.Count > 1)
            {
                total *= 0.90m; // Desconto de 10%
            }

            return total;
        }
    }
}
