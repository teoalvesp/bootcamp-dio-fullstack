public class Carro
{
    public string? Placa { get; private set; }
    public string? Modelo { get; private set; }
    public int TempoDeEstacionamentoEmMin { get; private set; }

    public Carro(string placa, string? modelo, int TempoDeEstacionamento)
    {
        Placa = placa;
        Modelo = modelo;
        TempoDeEstacionamentoEmMin = TempoDeEstacionamento;
    }

    // Método para obter os dados do veículo
    public void ObterDadosVeiculo()
    {
        Console.WriteLine($"Placa: {Placa}, Modelo: {Modelo}, Tempo Estacionado: {TempoDeEstacionamentoEmMin} min");
    }

}