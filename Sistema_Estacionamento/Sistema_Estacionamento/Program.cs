using Sistema_Estacionamento;
using System.Globalization;

InterfaceDoUsuario interfaceDoUsuario = new InterfaceDoUsuario();
var (faturamento, capacidade) = interfaceDoUsuario.InteracaoInicial();
Estacionamento estacionamento = new Estacionamento(capacidade);
CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

while (true)
{
    var (carro, resultadoMenu) = interfaceDoUsuario.Menu(faturamento, estacionamento);

    if (carro != null || resultadoMenu == 3 || resultadoMenu == 4 || resultadoMenu == 5)
    {
        switch (resultadoMenu)
        {
            case 1:
                if (carro != null)
                {
                    estacionamento.EstacionarVeiculo(carro);
                    Thread.Sleep(500);
                    Console.WriteLine("\n>> Veículo estacionado!");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                break;

            case 2:
                if (carro != null)
                {

                }
                if (carro != null)
                {
                    bool carroIsValid = estacionamento.DesocuparVeiculo(carro);
                    if (!carroIsValid)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("\nErro: A Placa informada não foi encontrada. Confira a lista de veículos estacionados...");
                        Console.WriteLine(">>\nPress Enter");
                        Console.ReadKey();
                        Console.Clear();
                        estacionamento.ListaDeCarrosEstacionados();
                    }
                    else
                    {
                        faturamento.RegistrarSaida(carro.TempoDeEstacionamentoEmMin);
                        Thread.Sleep(500);
                        Console.WriteLine("\n>> Vaga Liberada!");

                        float valorCobrança = faturamento.ValorIndividualVeículo(carro);
                        Console.WriteLine($"\nValor da cobrança:{valorCobrança:C2}  | Press Enter");
                        Console.ReadKey();
                        Thread.Sleep(500);
                        Console.Clear();
                    }
                }
                break;

            case 3:
                Thread.Sleep(500);
                Console.Clear();
                estacionamento.ListaDeCarrosEstacionados();
                break;

            case 4:
                Thread.Sleep(500);
                Console.WriteLine("\n>> Novos dados adicionados!");
                Thread.Sleep(1000);
                Console.Clear();
                break;

            case 5:
                Console.WriteLine("\n>> Saindo do Sistema...\n");
                Thread.Sleep(500);
                return;

            default:
                Console.WriteLine("Erro: Nenhuma opção válida foi escolhida");
                Thread.Sleep(500);
                break;
        }
    }
    else
    {
        Console.WriteLine("Erro: Nenhum carro retornado.");
        Thread.Sleep(500);
    }
}
