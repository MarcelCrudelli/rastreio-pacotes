// Dupla: [NOME 1] e [NOME 2]
namespace RastreioPacotesApp.Models;

/// <summary>Um evento do histórico de um pacote.</summary>
public class EventoRastreamento
{
    public DateTime DataHora { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public string Local { get; set; } = string.Empty;
}
