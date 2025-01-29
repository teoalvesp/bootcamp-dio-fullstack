namespace Sistema_Estacionamento
{
    public class InterfaceDoUsuario
    {
        private static string? Usuario;
        public static int CapacidadeEstacionamento;
        Faturamento faturamento = new Faturamento(0, 0);

        public void AddValores(bool estacionamentoExiste)
        {
            while (true)
            {
                string? inputCapacidade = null;
                int capacidade = 0;

                if (!estacionamentoExiste)
                {
                    Console.Write("Qual vai ser a capacidade máxima do estacionamento: ");
                    inputCapacidade = Console.ReadLine();
                }

                Console.Write("Qual o valor inicial: R$");
                string? inputValorInicial = Console.ReadLine();

                Console.Write("Qual o valor por hora: R$");
                string? inputValorPorHora = Console.ReadLine();

                // Validação das entradas
                bool isCapacidadeValida = estacionamentoExiste || int.TryParse(inputCapacidade, out capacidade);
                bool isValorInicialValido = float.TryParse(inputValorInicial, out float valorInicial);
                bool isValorPorHoraValido = float.TryParse(inputValorPorHora, out float valorPorHora);

                if (isCapacidadeValida && isValorInicialValido && isValorPorHoraValido)
                {
                    if (!estacionamentoExiste)
                    {
                        CapacidadeEstacionamento = capacidade;
                    }
                    faturamento.ValorInicial = valorInicial;
                    faturamento.ValorPorHora = valorPorHora;
                    break;
                }
                else
                {
                    Console.WriteLine("\nPor favor, digite números válidos.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }


        public void ExibirDados()
        {
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine($"Total de vagas no Estacionamento: {CapacidadeEstacionamento}");
            Console.WriteLine($"Valor Inicial: R${faturamento.ValorInicial}");
            Console.WriteLine($"Valor por hora: R${faturamento.ValorPorHora}");
            if (string.IsNullOrWhiteSpace(Usuario)) Usuario = "Desconhecido";
            Console.WriteLine($"Usuário: {Usuario}");

        }

        public (Faturamento, int) InteracaoInicial()
        {
            Console.Clear();
            Console.WriteLine("Bem-vindo(a) ao Gerenciador de Estacionamento");
            Thread.Sleep(1000);

            Console.Write("Seu nome de usuário: ");
            Usuario = Console.ReadLine();
            Thread.Sleep(1000);
            Console.Clear();

            AddValores(false);
            ExibirDados();

            Console.Write("\nPressione Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
            return (faturamento, CapacidadeEstacionamento);
        }

        public (Carro?, int) Menu(Faturamento faturamento, Estacionamento estacionamento)
        {

            while (true)
            {
                Console.WriteLine("===== Gerenciador de Estacionamento =====\n");
                if (string.IsNullOrWhiteSpace(Usuario)) Usuario = "Desconhecido";
                Console.Write($"usuario: {Usuario}");
                faturamento.ExibirCaixa();

                Console.WriteLine("\n1 - Adicionar veículo\n2 - Remover veículo\n3 - Lista de veículos estacionados\n4 - Editar Dados\n5 - Sair");
                Console.Write("R: ");
                string? escolha = Console.ReadLine();
                switch (escolha)
                {
                    case "1":
                        if (estacionamento.Vagas.All(vaga => vaga.Ocupada))
                        {
                            Console.WriteLine("\nEstacionamento Cheio!");
                            Console.WriteLine("Press Enter..");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine("===== Gerenciador de Estacionamento =====\n");
                        Console.WriteLine(">>>>>\nADICIONAR NOVO VEÍCULO:");

                        Console.Write("Placa: ");
                        string? placa = Console.ReadLine();
                        if (string.IsNullOrEmpty(placa))
                        {
                            Console.WriteLine("\nErro: Placa não pode ser nula ou vazia.");
                            break;
                        }

                        if (estacionamento.Vagas.Any(vaga => vaga.Ocupada && vaga.CarroEstacionado?.Placa == placa))
                        {
                            Console.WriteLine("\n>>Erro: Já existe um veículo com essa placa estacionado.");
                            Console.WriteLine("Press Enter..");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                        Console.Write("Modelo: ");
                        string? modelo = Console.ReadLine();
                        if (string.IsNullOrEmpty(modelo))
                        {
                            Console.WriteLine("\n>> Erro: Modelo não pode ser nulo ou vazio.");
                            break;
                        }

                        Carro carro = new Carro(placa, modelo, 0);
                        faturamento.RegistrarEntrada();
                        return (carro, 1);

                    case "2":
                        Console.Clear();
                        Console.WriteLine("===== Gerenciador de Estacionamento =====\n");
                        Console.WriteLine(">>>>>\nREMOVER VEÍCULO:");

                        Console.Write("Placa: ");
                        string? placa_ = Console.ReadLine();
                        if (string.IsNullOrEmpty(placa_))
                        {
                            Console.WriteLine("Erro: Placa não pode ser nula ou vazia.");
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        }

                        int tempoEstacionado;
                        while (true)
                        {
                            Console.Write("Quanto tempo em Min o veículo ficou estacionado: ");
                            string? inputTempoEstacionado = Console.ReadLine();

                            if (int.TryParse(inputTempoEstacionado, out tempoEstacionado))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nErro: Por favor, insira um número válido para o tempo estacionado.");
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                        }

                        Carro desocupar_carro = new Carro(placa_, "", tempoEstacionado);
                        return (desocupar_carro, 2);

                    case "3":
                        return (null, 3);

                    case "4":
                        Console.Clear();
                        Console.WriteLine("===== Gerenciador de Estacionamento =====\n");
                        Console.WriteLine(">>>>>\nEDITAR VALORES:\n");

                        AddValores(true);
                        return (null, 4);

                    case "5":
                        return (null, 5);

                    default:
                        Console.WriteLine("\n>> Opção inválida. Tente novamente.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
