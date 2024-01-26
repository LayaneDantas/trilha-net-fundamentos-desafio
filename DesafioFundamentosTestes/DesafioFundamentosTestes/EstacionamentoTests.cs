using DesafioFundamentos;
using DesafioFundamentos.Models;
using System.Numerics;

namespace DesafioFundamentosTestes;

public class EstacionamentoTests
{

    [Fact]
    public void ValidacaoPlaca_DeveVerificarSeAPlacaEhValidaOuInvalida()
    {
        // Arrange
        Estacionamento estacionamento = new Estacionamento(0, 0);

        // Act
        var resultadoValido = estacionamento.ValidarPlaca("ADF4567");
        var resultadoInvalido = estacionamento.ValidarPlaca("456ADF");

        // Assert
        Assert.True(resultadoValido);
        Assert.False(resultadoInvalido);

    }

    [Fact]
    public void AdicionarVeiculo_DeveAdicionarVeiculoALista()
    {
        // Arrange
        Estacionamento estacionamento = new Estacionamento(0, 0);

        // Act
        estacionamento.AdicionarVeiculo("ABC1234");

        // Assert
        Assert.Contains("ABC1234", estacionamento.ListarVeiculos());
    }

    [Fact]
    public void Capacidade_DeveTestarACapacidadeMaxima()
    {
        // Arrange
        Estacionamento estacionamento = new Estacionamento(0, 0);
        estacionamento.AdicionarVeiculo("ABC1234");
        estacionamento.AdicionarVeiculo("DEF5678");
        estacionamento.AdicionarVeiculo("IJH7658");
        estacionamento.AdicionarVeiculo("YUI5678");
        estacionamento.AdicionarVeiculo("KHG1234");
        estacionamento.AdicionarVeiculo("DEF5978");

        // Act
        List<string> veiculos = estacionamento.ListarVeiculos();

        // Assert
        Assert.Equal(5, veiculos.Count);

    }

    [Fact]
    public void RemoverVeiculo_VeiculoExistente_DeveRemoverVeiculo()
    {
        // Arrange
        Estacionamento estacionamento = new Estacionamento(0, 0);
        estacionamento.AdicionarVeiculo("ABC1234");

        // Act
        estacionamento.RemoverVeiculo("ABC1234");

        // Assert
        Assert.DoesNotContain("ABC1234", estacionamento.ListarVeiculos());
    }

    [Fact]
    public void ListarVeiculos_DeveExibirListaDeVeiculos()
    {
        // Arrange
        Estacionamento estacionamento = new Estacionamento(0, 0);
        estacionamento.AdicionarVeiculo("ABC1234");
        estacionamento.AdicionarVeiculo("XYZ7891");

        // Act
        List<string> veiculos = estacionamento.ListarVeiculos();

        // Assert
        Assert.Contains("ABC1234", veiculos);
        Assert.Contains("XYZ7891", veiculos);
    }

}

