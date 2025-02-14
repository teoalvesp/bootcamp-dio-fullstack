using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using SystemHotel.Common.Models;

namespace SystemHotel
{
    public static class Display
    {
        public static string InitialMenu()
        {
            string? option;

            while (true)
            {
                // Menu de interação inicial com o usuário
                Console.Clear();
                Console.WriteLine("** Bem vindo(a) ao Alves Hotel **");
                Console.WriteLine("---------------------------------");
                Console.Write("1 - Check-in\n2 - Check-out\n3 - Sair\nR: ");
                option = Console.ReadLine();

                // Verifica se a output é nulo ou apenas com espaços
                if (string.IsNullOrWhiteSpace(option))
                {
                    Console.WriteLine("\n>> Erro, opção inválida!");
                    Thread.Sleep(1000);
                    continue;
                }

                // Trata as opções do Menu
                option = (option == "1" || option == "2" || option == "3" || option == "4") ? option : null;
                if (option != null)
                {
                    return option;
                }
                else
                {
                    Console.WriteLine("\n>> Erro, opção inválida!");
                    Thread.Sleep(1000);
                }

            }

        }

        public static List<(string Name, string LastName)> RegisterGuestsDisplay(Suite suite)
        {
            int numberOfGuests;
            List<(string Name, string LastName)> guests = new List<(string Name, string LastName)>();

            while (true)
            {
                Console.Clear();
                Thread.Sleep(200);

                Console.WriteLine(" **   Alves Hotel   **");
                Console.WriteLine("------------------------");
                Console.WriteLine("  Registro de Hóspede ");

                // Pergunta quantos hóspedes farão o check-in
                Console.Write($"\nQuantas pessoas farão o check-in (Capacidade máxima: {suite.Capacity}): ");
                while (!int.TryParse(Console.ReadLine(), out numberOfGuests) || numberOfGuests <= 0 || numberOfGuests > suite.Capacity)
                {
                    Console.WriteLine($"Número inválido. Por favor, insira um número entre 1 e {suite.Capacity}:\nR: ");
                }

                if (numberOfGuests > suite.Capacity)
                {
                    Console.WriteLine("\n>> Não há espaço suficiente para todos os hóspedes.");
                    Thread.Sleep(1000);
                    continue;
                }

                while (true)
                {
                    // Solicita os dados de cada hóspede
                    guests.Clear();

                    for (int i = 1; i <= numberOfGuests; i++)
                    {
                        Console.Write($"\nHóspede {i} | Nome: ");
                        string nameNewGuest = Console.ReadLine()?.ToUpper() ?? "";
                        Console.Write("Sobrenome: ");
                        string lastnameNewGuest = Console.ReadLine()?.ToUpper() ?? "";

                        guests.Add((nameNewGuest, lastnameNewGuest));
                    }

                    Console.WriteLine("\n------------------");
                    foreach (var guest in guests)
                    {
                        Console.WriteLine($"Nome do Hóspede: {guest.Name} {guest.LastName}");
                    }

                    Console.Write("Os dados estão corretos? [S/N]: ");
                    string? option = Console.ReadLine();

                    if (option != null) option = option.ToUpper();

                    bool confirmed = option == "S";
                    if (confirmed)
                    {
                        Thread.Sleep(700);
                        Console.WriteLine("\n>> Dados confirmados");
                        Thread.Sleep(700);
                        Console.Clear();
                        break;
                    }
                    else if (option == "N")
                    {
                        guests.Clear();
                        Thread.Sleep(700);
                        Console.WriteLine("\n>> Digite os dados novamente ...");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("\n>> Erro, opção inválida!");
                        Thread.Sleep(1000);
                    }
                }

                break;
            }

            return guests;
        }

        public static (string SuiteType, int Capacity, decimal DailyValue) RegisterSuiteDisplay()
        {
            string suiteType;
            int capacity;
            decimal dailyValue;

            while (true)
            {
                Console.Clear();
                Thread.Sleep(200);

                Console.WriteLine(" **   Alves Hotel   **");
                Console.WriteLine("------------------------");
                Console.WriteLine("  Registro de Suíte ");

                Console.Write("\nTipo de Suíte: ");
                suiteType = Console.ReadLine()?.ToUpper() ?? "";

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

                Console.WriteLine("------------------");
                Console.WriteLine($"Suíte: {suiteType}\nCapacidade: {capacity} pessoas\nValor Diário: R$ {dailyValue:F2}");

                Console.Write("Os dados estão corretos? [S/N]: ");
                string? option = Console.ReadLine();

                if (option != null) option = option.ToUpper();

                bool confirmed = option == "S";
                if (confirmed)
                {
                    Thread.Sleep(700);
                    Console.WriteLine("\n>> Dados confirmados");
                    Thread.Sleep(700);
                    Console.Clear();
                    break;
                }
                else if (option == "N")
                {
                    Thread.Sleep(700);
                    Console.WriteLine("\n>> Digite os dados novamente ...");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("\n>> Erro, opção inválida!");
                    Thread.Sleep(1000);
                }
            }

            return (suiteType, capacity, dailyValue);
        }

    }
}