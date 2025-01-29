public class Faturamento
{
    public float ValorInicial { get; set; }
    public float ValorPorHora { get; set; }
    private float TotalDinheiro { get; set; }

    public Faturamento(int valorInicial, int valorPorHora)
    {
        ValorInicial = valorInicial;
        ValorPorHora = valorPorHora;
        TotalDinheiro = 0.0f;
    }

    public void RegistrarEntrada()
    {
        TotalDinheiro += ValorInicial;
    }

    public void RegistrarSaida(int minEstacionado)
    {
        float horaEstacionado = minEstacionado / 60f;
        TotalDinheiro += ValorPorHora * horaEstacionado;
    }

    public float ValorIndividualVeículo(Carro carro)
    {
        float horaEstacionado = carro.TempoDeEstacionamentoEmMin / 60f;
        float combrarVeiculo = ValorInicial + (ValorPorHora * horaEstacionado);
        return combrarVeiculo;
    }

    public void ExibirCaixa()
    {
        Console.WriteLine($"\nRendimento total do dia: {TotalDinheiro:C2}");
    }

    public void EditarValores()
    {
        Console.WriteLine("");
    }
}
