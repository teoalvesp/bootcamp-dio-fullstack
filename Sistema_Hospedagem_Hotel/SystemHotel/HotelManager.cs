using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemHotel.Common.Models;

namespace SystemHotel
{
    public class HotelManager
    {
        public List<Person> RegisterGuests(Suite suite)
        {
            var guestsTuples = Display.RegisterGuestsDisplay(suite);
            List<Person> guests = new List<Person>();

            // Converte as tuplas para objetos Person
            foreach (var (name, lastname) in guestsTuples)
            {
                guests.Add(new Person(name, lastname));
            }

            return guests;
        }

        public Suite RegisterSuite()
        {
            (string suiteType, int capacity, decimal dailyValue) = Display.RegisterSuiteDisplay();
            Suite suite = new Suite(suiteType, capacity, dailyValue);
            return suite;
        }

        public void RemoveGuests()
        {
            // Lógica para remover hóspedes
        }
    }
}
