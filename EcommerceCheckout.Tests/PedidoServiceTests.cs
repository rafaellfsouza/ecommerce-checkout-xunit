using EcommerceCheckout.App;

namespace EcommerceCheckout.Tests;

public class PedidoServiceTests
{
    private readonly PedidoService _pedidoService = new();

    // Teste 1 (string): valida a máscara exata do código de rastreio.
    [Fact]
    public void GerarCodigoRastreio_DeveRetornarRegiaoMaiusculaComNumeroDe4Digitos()
    {
        var resultado = _pedidoService.GerarCodigoRastreio("sudeste", 42);

        Assert.Equal("SUDESTE-0042", resultado);
    }

    // Teste 2 (int): valida o cálculo de pontos (2 pontos a cada R$ 10).
    [Fact]
    public void CalcularPontosFidelidade_DeveRetornar30PontosParaCompraDe150()
    {
        var resultado = _pedidoService.CalcularPontosFidelidade(150);

        Assert.Equal(30, resultado);
    }

    // Teste 3 (bool): cliente VIP com compra abaixo de R$ 200 tem frete grátis.
    [Fact]
    public void TemDireitoAFreteGratis_ClienteVipAbaixoDe200_DeveRetornarTrue()
    {
        var resultado = _pedidoService.TemDireitoAFreteGratis(150, true);

        Assert.True(resultado);
    }

    // Teste 3 (bool): cliente não-VIP com compra abaixo de R$ 200 não tem frete grátis.
    [Fact]
    public void TemDireitoAFreteGratis_ClienteNaoVipAbaixoDe200_DeveRetornarFalse()
    {
        var resultado = _pedidoService.TemDireitoAFreteGratis(150, false);

        Assert.False(resultado);
    }
}
