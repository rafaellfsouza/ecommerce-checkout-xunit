namespace EcommerceCheckout.App;

/// <summary>
/// Serviço com as regras de negócio do checkout da loja online:
/// geração de código de rastreio, cálculo de pontos de fidelidade
/// e validação do direito a frete grátis.
/// </summary>
public class PedidoService
{
    /// <summary>
    /// Gera o código de rastreio unindo a região em MAIÚSCULAS
    /// com o número do pedido preenchido com zeros à esquerda (4 dígitos).
    /// Exemplo: "sudeste" e 42 -> "SUDESTE-0042".
    /// </summary>
    public string GerarCodigoRastreio(string regiao, int numeroPedido)
    {
        return $"{regiao.ToUpperInvariant()}-{numeroPedido:D4}";
    }

    /// <summary>
    /// Calcula os pontos de fidelidade: a cada R$ 10 em compras,
    /// o cliente ganha 2 pontos.
    /// Exemplo: 150 -> (150 / 10) * 2 = 30 pontos.
    /// </summary>
    public int CalcularPontosFidelidade(int valorTotal)
    {
        return valorTotal / 10 * 2;
    }

    /// <summary>
    /// O frete é grátis se o valor total for maior ou igual a R$ 200
    /// OU se o comprador for um cliente VIP.
    /// Exemplo: (150, true) -> true | (150, false) -> false.
    /// </summary>
    public bool TemDireitoAFreteGratis(int valorTotal, bool eClienteVIP)
    {
        return valorTotal >= 200 || eClienteVIP;
    }
}
