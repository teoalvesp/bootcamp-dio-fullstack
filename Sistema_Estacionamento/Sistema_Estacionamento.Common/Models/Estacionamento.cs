using System.ComponentModel.DataAnnotations;

public class Estacionamento
{
    public List<Vaga> Vagas { get; set; }
    public int Capacidade { get; set; }

    public Estacionamento(int capacidade)
    {
        Capacidade = capacidade;
        Vagas = new List<Vaga>(capacidade);
        for (int i = 0; i < capacidade; i++)
        {
            Vagas.Add(new Vaga { Numero = i + 1, Ocupada = false });
        }
    }

    public bool EstacionarVeiculo(Carro carro)
    {
        Vaga? vagaDisponivel = Vagas.FirstOrDefault(vaga => !vaga.Ocupada);

        if (vagaDisponivel != null)
        {
            vagaDisponivel.Ocupada = true;
            vagaDisponivel.CarroEstacionado = carro;

            return true;
        }

        return false;
    }

    public bool DesocuparVeiculo(Carro carro)
    {
        Vaga? VagaOcupada = Vagas.FirstOrDefault(vaga => vaga.Ocupada && vaga.CarroEstacionado?.Placa == carro.Placa);

        if (VagaOcupada != null)
        {
            VagaOcupada.Ocupada = false;
            VagaOcupada.CarroEstacionado = null;
            return true;
        }

        return false;

    }

    public void ListaDeCarrosEstacionados()
    {
        Console.WriteLine("===== Gerenciador de Estacionamento =====\n");
        foreach (Vaga vaga in Vagas)
        {
            if (vaga.Ocupada)
            {
                Console.WriteLine($"Vaga 0{vaga.Numero}: Status: Ocupado");
                Console.WriteLine($"Modelo: {vaga.CarroEstacionado?.Modelo}, Placa: {vaga.CarroEstacionado?.Placa}");
                Console.WriteLine("----------------------------------");
            }
            else
            {
                Console.WriteLine($"Vaga 0{vaga.Numero}: Status: Livre\n----------------------------------");
            }

        }
        Console.WriteLine("Press Enter para voltar");
        Console.ReadKey();
        Console.Clear();
    }
}

public class Vaga
{
    public int Numero { get; set; }
    public bool Ocupada { get; set; }
    public Carro? CarroEstacionado { get; set; }

}