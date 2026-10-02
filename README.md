# ecommerce-checkout-xunit

Solução **.NET 10** criada via terminal (.NET CLI) para gerenciar o cálculo de cupons, itens e frete de uma loja online, com todos os métodos cobertos por **testes unitários no xUnit**.

| | |
|---|---|
| **Aluno** | Rafael Luiz Ferreira de Souza |
| **RA** | 32511503 |
| **Disciplina** | Garantia da Qualidade de Software — Gestão e Qualidade de Software |
| **Professor** | Daniel Henrique Matos de Paiva |
| **Atividade** | Lista de Exercícios — EcommerceCheckout (.NET 10 + xUnit) |

---

## 📁 Estrutura da Solução

```
EcommerceCheckout.sln
├── EcommerceCheckout.App/          # Código de produção (console, net10.0)
│   ├── Program.cs                  # Demonstração dos métodos
│   └── PedidoService.cs            # Regras de negócio do checkout
├── EcommerceCheckout.Tests/        # Testes unitários (xUnit, net10.0)
│   └── PedidoServiceTests.cs       # Suíte de testes do PedidoService
├── .gitignore                      # .gitignore oficial para C#/.NET
├── LICENSE                         # Licença MIT
└── README.md
```

## 🔧 Criação da Solução via .NET CLI

```bash
# 1. Cria a Solução
dotnet new sln -n EcommerceCheckout

# 2. Cria o projeto da aplicação (Código de Produção)
dotnet new console -n EcommerceCheckout.App -f net10.0

# 3. Cria o projeto de Testes Unitários com xUnit
dotnet new xunit -n EcommerceCheckout.Tests -f net10.0

# 4. Adiciona ambos os projetos à Solução
dotnet sln add EcommerceCheckout.App/EcommerceCheckout.App.csproj
dotnet sln add EcommerceCheckout.Tests/EcommerceCheckout.Tests.csproj

# 5. Adiciona a referência do projeto de Produção no projeto de Testes
dotnet add EcommerceCheckout.Tests/EcommerceCheckout.Tests.csproj reference EcommerceCheckout.App/EcommerceCheckout.App.csproj
```

## 🧩 Métodos Implementados (`PedidoService.cs`)

### 1. `string GerarCodigoRastreio(string regiao, int numeroPedido)`
Retorna uma string formatada unindo a região em **maiúsculas** com o número do pedido preenchido com **zeros à esquerda (4 dígitos)**.

| Entrada | Saída |
|---|---|
| `"sudeste"`, `42` | `"SUDESTE-0042"` |

### 2. `int CalcularPontosFidelidade(int valorTotal)`
Para cada **R$ 10** em compras, o cliente ganha **2 pontos** de fidelidade.

| Entrada | Cálculo | Saída |
|---|---|---|
| `150` | (150 / 10) × 2 = 15 × 2 | `30` |

### 3. `bool TemDireitoAFreteGratis(int valorTotal, bool eClienteVIP)`
O frete é grátis se o valor total for **maior ou igual a R$ 200** **OU** se o comprador for **cliente VIP**.

| Entrada | Saída |
|---|---|
| `150`, `true` (VIP abaixo de R$ 200) | `true` |
| `150`, `false` (não-VIP abaixo de R$ 200) | `false` |
| `200`, `false` (atingiu o valor mínimo) | `true` |

## ✅ Cobertura dos Testes (`PedidoServiceTests.cs` — xUnit)

Todos os métodos públicos do `PedidoService` estão cobertos por testes com o atributo `[Fact]`:

| # | Teste | Método coberto | Assert utilizado | Cenário |
|---|---|---|---|---|
| 1 | `GerarCodigoRastreio_DeveRetornarRegiaoMaiusculaComNumeroDe4Digitos` | `GerarCodigoRastreio` (string) | `Assert.Equal("SUDESTE-0042", resultado)` | Máscara exata região + zeros à esquerda |
| 2 | `CalcularPontosFidelidade_DeveRetornar30PontosParaCompraDe150` | `CalcularPontosFidelidade` (int) | `Assert.Equal(30, resultado)` | 2 pontos a cada R$ 10 |
| 3 | `TemDireitoAFreteGratis_ClienteVipAbaixoDe200_DeveRetornarTrue` | `TemDireitoAFreteGratis` (bool) | `Assert.True(...)` | Compra VIP abaixo de R$ 200 |
| 4 | `TemDireitoAFreteGratis_ClienteNaoVipAbaixoDe200_DeveRetornarFalse` | `TemDireitoAFreteGratis` (bool) | `Assert.False(...)` | Compra não-VIP abaixo de R$ 200 |

## ▶️ Como Executar

Pré-requisito: [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) instalado.

```bash
# Executar a suíte de testes unitários (na raiz do repositório)
dotnet test

# Executar a aplicação de demonstração
dotnet run --project EcommerceCheckout.App
```

Resultado esperado do `dotnet test`:

```
Passed!  - Failed: 0, Passed: 4, Skipped: 0, Total: 4
```

## 📄 Licença

Este projeto está sob a licença **MIT** — consulte o arquivo [LICENSE](LICENSE).
