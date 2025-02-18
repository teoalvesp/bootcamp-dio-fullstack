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

        public void RemoveGuests(ReserveList hotel)
        {
            if (hotel.Reserves.Count > 0)
            {
                Display.CheckOutDisplay(hotel);
            }
            else
            {
                Thread.Sleep(500);
                Console.Write("\n>> O Hotel ainda não possui Hóspedes!");
                Thread.Sleep(1200);
            }

        }

        public void GetReservesList(ReserveList hotel)
        {
            Display.DisplayReservations(hotel);
        }

    }
}
