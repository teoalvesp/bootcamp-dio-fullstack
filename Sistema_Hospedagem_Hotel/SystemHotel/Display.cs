using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SystemHotel.Common.Models;

namespace SystemHotel
{
    public static class Display
    {
        // Método para exibir o menu inicial
        public static string InitialMenu()
        {
            string? option;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("** Bem vindo(a) ao Alves Hotel **");
                Console.WriteLine("---------------------------------");
                Console.Write("1 - Check-in\n2 - Check-out\n3 - Reservas\n4 - Sair\nR: ");
                option = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(option) && new[] { "1", "2", "3", "4" }.Contains(option))
                {
                    return option;
                }

                Console.WriteLine("\n>> Erro, opção inválida!");
                Thread.Sleep(1000);
            }
        }

        // Método para registrar hóspedes
        public static List<(string Name, string LastName)> RegisterGuestsDisplay(Suite suite)
        {
            List<(string Name, string LastName)> guests = new();
            int numberOfGuests;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("** Alves Hotel - Registro de Hóspedes **");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Capacidade máxima da suíte: {suite.Capacity}");

                Console.Write("\nQuantas pessoas farão o check-in: ");
                if (int.TryParse(Console.ReadLine(), out numberOfGuests) && numberOfGuests > 0 && numberOfGuests <= suite.Capacity)
                {
                    guests.Clear();
                    for (int i = 1; i <= numberOfGuests; i++)
                    {
                        Console.Write($"\nHóspede {i} | Nome: ");
                        string name = Console.ReadLine()?.Trim().ToUpper() ?? "";
                        Console.Write("Sobrenome: ");
                        string lastName = Console.ReadLine()?.Trim().ToUpper() ?? "";
                        guests.Add((name, lastName));
                    }

                    Console.WriteLine("\nConfirme os dados:");
                    foreach (var guest in guests)
                    {
                        Console.WriteLine($"Hóspede: {guest.Name} {guest.LastName}");
                    }

                    Console.Write("Os dados estão corretos? [S/N]: ");
                    if (Console.ReadLine()?.Trim().ToUpper() == "S")
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine($"Número inválido. Por favor, insira um número entre 1 e {suite.Capacity}.");
                    Thread.Sleep(1000);
                }


            }

            return guests;
        }

        // Método para registrar uma suíte
        public static (string SuiteType, int Capacity, decimal DailyValue) RegisterSuiteDisplay()
        {
            string suiteType;
            int capacity;
            decimal dailyValue;

            Console.Clear();
            Console.WriteLine("** Alves Hotel - Registro de Suíte **");

            Console.Write("\nTipo de Suíte: ");
            suiteType = Console.ReadLine()?.Trim().ToUpper() ?? "";

            Console.Write("Capacidade (Número de Pessoas): ");
            while (!int.TryParse(Console.ReadLine(), out capacity) || capacity <= 0)
            {
                Console.Write("Capacidade inválida. Por favor, insira um número positivo: ");
            }

            Console.Write("Valor Diário (em reais): ");
            while (!decimal.TryParse(Console.ReadLine(), out dailyValue) || dailyValue <= 0)
            {
                Console.Write("Valor diário inválido. Por favor, insira um valor positivo: ");
            }

            return (suiteType, capacity, dailyValue);
        }

        // Método para exibir a lista de reservas
        public static void DisplayReservations(ReserveList hotel)
        {
            if (hotel.Reserves.Count == 0)
            {
                Console.WriteLine("\n>> O Hotel ainda não possui reservas.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("** Alves Hotel - Lista de Reservas **");

                foreach (var reserve in hotel.Reserves)
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine($"Reserva #{reserve.Id}");

                    if (reserve.Guests != null && reserve.Guests.Any())
                    {
                        Console.WriteLine("Hóspedes:");
                        foreach (var guest in reserve.Guests)
                        {
                            Console.WriteLine($"- {guest.Name} {guest.LastName}");
                        }
                    }

                    Console.WriteLine($"Suíte: {reserve.Suite?.SuiteType ?? "Não especificada"}");
                }
            }

            Console.Write("\nPressione ENTER para continuar...");
            Console.ReadKey();
        }

        // Método para realizar o checkout
        public static void CheckOutDisplay(ReserveList hotel)
        {
            while (true)
            {
                Thread.Sleep(700);
                Console.Clear();

                Console.WriteLine("** Alves Hotel - Checkout **");
                Console.WriteLine("---------------------------------");
                Console.Write("\nDigite o número da reserva: ");
                if (int.TryParse(Console.ReadLine(), out int reserveId))
                {
                    var reserve = hotel.Reserves.FirstOrDefault(r => r.Id == reserveId);
                    if (reserve != null)
                    {
                        decimal totalAmount = reserve.CalculateDailyValue();
                        hotel.Reserves.Remove(reserve);

                        Console.WriteLine($"\n>> Checkout concluído para a reserva {reserveId}.");
                        Console.WriteLine($"Valor total: R$ {totalAmount:F2}");
                        Console.Write("\nPressione ENTER para continuar...");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n>> Reserva não encontrada.");
                    }
                }
                else
                {
                    Console.WriteLine("\n>> Número inválido. Insira um número inteiro.");
                }

                Console.Write("\nTentar novamente? [S/N]: ");
                if (Console.ReadLine()?.Trim().ToUpper() != "S")
                {
                    break;
                }
            }
        }


    }


}
