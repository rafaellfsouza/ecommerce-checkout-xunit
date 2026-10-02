using EcommerceCheckout.App;

// Demonstração rápida dos métodos do PedidoService.
var pedidoService = new PedidoService();

Console.WriteLine("===== EcommerceCheckout.App =====");
Console.WriteLine($"Código de rastreio (sudeste, 42): {pedidoService.GerarCodigoRastreio("sudeste", 42)}");
Console.WriteLine($"Pontos de fidelidade (R$ 150):    {pedidoService.CalcularPontosFidelidade(150)}");
Console.WriteLine($"Frete grátis (R$ 150, VIP):       {pedidoService.TemDireitoAFreteGratis(150, true)}");
Console.WriteLine($"Frete grátis (R$ 150, não-VIP):   {pedidoService.TemDireitoAFreteGratis(150, false)}");
