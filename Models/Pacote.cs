// Dupla: [NOME 1] e [NOME 2]
namespace RastreioPacotesApp.Models;

/// <summary>Modelo (M do MVVM): representa um pacote.</summary>
public class Pacote
{
    public string Id { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime DataEnvio { get; set; }
    public DateTime DataPrevistaEntrega { get; set; }
    public string LocalizacaoAtual { get; set; } = string.Empty;
    public List<EventoRastreamento> Historico { get; set; } = new();
}
