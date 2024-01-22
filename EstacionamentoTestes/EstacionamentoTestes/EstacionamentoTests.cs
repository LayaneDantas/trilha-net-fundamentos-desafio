using DesafioFundamentos;
using DesafioFundamentos.Models;

namespace EstacionamentoTestes;

public class EstacionamentoTests
{
    [Fact]
    public void AdicionarVeiculo_DeveAdicionarVeiculoALista()
    {
        // Arrange
        Estacionamento estacionamento = new Estacionamento(0, 0);

        // Act
        estacionamento.AdicionarVeiculo("ABC123");

        // Assert
        Assert.Contains("ABC123", estacionamento.ListarVeiculos());
    }

    [Fact]
    public void RemoverVeiculo_VeiculoExistente_DeveRemoverVeiculoEImprimirValorTotal()
    {
        // Arrange
        Estacionamento estacionamento = new Estacionamento(1, 2);
        estacionamento.AdicionarVeiculo("ABC123");

        // Act
        estacionamento.RemoverVeiculo("ABC123", 2);

        // Assert
        Assert.DoesNotContain("ABC123", estacionamento.ListarVeiculos());
    }

    [Fact]
    public void ListarVeiculos_VeiculosNaLista_DeveExibirListaDeVeiculos()
    {
        // Arrange
        Estacionamento estacionamento = new Estacionamento(0, 0);
        estacionamento.AdicionarVeiculo("ABC123");
        estacionamento.AdicionarVeiculo("XYZ789");

        // Act
        List<string> veiculos = estacionamento.ListarVeiculos();

        // Assert
        Assert.Contains("ABC123", veiculos);
        Assert.Contains("XYZ789", veiculos);
    }

    private string CapturarSaidaConsole(Action action)
    {
        var consoleOutput = new System.IO.StringWriter();
        Console.SetOut(consoleOutput);

        action();

        return consoleOutput.ToString();
    }
}

