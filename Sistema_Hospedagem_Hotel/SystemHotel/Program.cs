using SystemHotel;
using SystemHotel.Common.Models;

HotelManager hotelManager = new();
ReserveList hotel = new();

// Função principal para exibir o menu e gerenciar as opções
void Menu()
{
    while (true)
    {
        // Exibe o menu inicial
        string option = Display.InitialMenu();

        switch (option)
        {
            case "1": // Check-in
                var suite = hotelManager.RegisterSuite(); // Registra uma suíte
                if (suite != null)
                {
                    Reserve newReserve = new();
                    newReserve.RegisterSuite(suite); // Associa a suíte à reserva

                    // Solicita o número de dias da reserva
                    Console.Write("\nDigite o número de dias para a reserva: ");
                    int days;
                    while (!int.TryParse(Console.ReadLine(), out days) || days <= 0)
                    {
                        Console.WriteLine("Número de dias inválido. Por favor, insira um número positivo.");
                    }
                    newReserve.DaysReserved = days; // Define os dias reservados na nova reserva

                    var guests = hotelManager.RegisterGuests(suite); // Registra hóspedes
                    newReserve.RegisterGuests(guests); // Associa hóspedes à reserva

                    hotel.AddReserves(newReserve); // Adiciona a reserva ao hotel
                    Console.WriteLine(">> Check-in realizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Erro: Falha ao registrar a suíte.");
                }
                break;


            case "2": // Check-out
                hotelManager.RemoveGuests(hotel); // Remove hóspedes por número de reserva
                break;

            case "3": // Reservas
                hotelManager.GetReservesList(hotel); // Exibe a lista de reservas
                break;

            case "4": // Sair
                Console.Clear();
                Console.WriteLine("\n>> Saindo do Sistema...");
                Thread.Sleep(500);
                return; // Sai do programa

            default:
                Console.WriteLine(">> Opção inválida. Tente novamente.");
                break;
        }
    }
}

// Chama o método Menu para iniciar o programa
Menu();
