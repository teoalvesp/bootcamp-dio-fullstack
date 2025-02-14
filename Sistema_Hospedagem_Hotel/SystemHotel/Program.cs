using System.Diagnostics;
using SystemHotel;
using SystemHotel.Common.Models;

HotelManager hotelManager = new();
Reserve reserve = new();

// Aciona a interação inicial com o usuário
string option = Display.InitialMenu();

// Define o método Menu fora do escopo principal
void Menu(string option)
{
    switch (option)
    {
        case "1":
            if (reserve.Suite == null)
            {
                var suite = hotelManager.RegisterSuite();
                reserve.RegisterSuite(suite);
            }

            // Garantir que a Suite não é nula antes de registrar os hóspedes
            if (reserve.Suite != null)
            {
                var guests = hotelManager.RegisterGuests(reserve.Suite);
                reserve.RegisterGuests(guests);
            }
            else
            {
                Console.WriteLine("Erro: Suite não está registrada.");
            }

            break;

        case "2":
            // Lógica para o caso 2
            break;

        case "3":
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("\n>> Saindo do Sistema..");
            Thread.Sleep(500);
            return;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

    // Solicita uma nova opção após executar o caso atual
    option = Display.InitialMenu();
    Menu(option);
}

// Chama o método Menu
Menu(option);
