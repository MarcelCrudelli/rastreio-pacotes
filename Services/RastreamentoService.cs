// Dupla: [NOME 1] e [NOME 2]
using RastreioPacotesApp.Models;

namespace RastreioPacotesApp.Services;

/// <summary>Serviço que SIMULA a busca com dados fictícios.</summary>
public class RastreamentoService : IRastreamentoService
{
    private readonly List<Pacote> _base;

    public RastreamentoService()
    {
        var hoje = DateTime.Today;
        _base = new List<Pacote>
        {
            new()
            {
                Id = "BR123456789",
                Status = "Em trânsito",
                DataEnvio = hoje.AddDays(-3),
                DataPrevistaEntrega = hoje.AddDays(2),
                LocalizacaoAtual = "Centro de Distribuição - Campinas/SP",
                Historico = new()
                {
                    new() { DataHora = hoje.AddDays(-3).AddHours(9),  Descricao = "Objeto postado",                  Local = "Santos/SP" },
                    new() { DataHora = hoje.AddDays(-2).AddHours(14), Descricao = "Objeto encaminhado",              Local = "Santos/SP → São Paulo/SP" },
                    new() { DataHora = hoje.AddDays(-1).AddHours(8),  Descricao = "Chegou ao centro de distribuição", Local = "Campinas/SP" },
                }
            },
            new()
            {
                Id = "BR987654321",
                Status = "Entregue",
                DataEnvio = hoje.AddDays(-7),
                DataPrevistaEntrega = hoje.AddDays(-2),
                LocalizacaoAtual = "Cubatão/SP",
                Historico = new()
                {
                    new() { DataHora = hoje.AddDays(-7).AddHours(10), Descricao = "Objeto postado",          Local = "Rio de Janeiro/RJ" },
                    new() { DataHora = hoje.AddDays(-4).AddHours(16), Descricao = "Saiu para entrega",       Local = "Cubatão/SP" },
                    new() { DataHora = hoje.AddDays(-3).AddHours(11), Descricao = "Objeto entregue ao destinatário", Local = "Cubatão/SP" },
                }
            },
            new()
            {
                Id = "BR555555555",
                Status = "Aguardando retirada",
                DataEnvio = hoje.AddDays(-5),
                DataPrevistaEntrega = hoje.AddDays(-1),
                LocalizacaoAtual = "Agência Praia Grande/SP",
                Historico = new()
                {
                    new() { DataHora = hoje.AddDays(-5).AddHours(13), Descricao = "Objeto postado",               Local = "Curitiba/PR" },
                    new() { DataHora = hoje.AddDays(-2).AddHours(9),  Descricao = "Tentativa de entrega sem êxito", Local = "Praia Grande/SP" },
                    new() { DataHora = hoje.AddDays(-1).AddHours(15), Descricao = "Disponível para retirada",      Local = "Agência Praia Grande/SP" },
                }
            }
        };
    }

    public async Task<Pacote?> BuscarPacoteAsync(string codigo)
    {
        await Task.Delay(1200); // simula latência de rede
        return _base.FirstOrDefault(p =>
            p.Id.Equals(codigo?.Trim(), StringComparison.OrdinalIgnoreCase));
    }
}
