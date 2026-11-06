// Dupla: [NOME 1] e [NOME 2]
using System.Collections.ObjectModel;
using System.Windows.Input;
using RastreioPacotesApp.Models;

namespace RastreioPacotesApp.ViewModels;

/// <summary>ViewModel da página de resultados.</summary>
public class ResultadoViewModel : BaseViewModel, IQueryAttributable
{
    private Pacote? _pacote;

    public Pacote? Pacote
    {
        get => _pacote;
        private set => SetProperty(ref _pacote, value);
    }

    // Histórico do mais recente para o mais antigo
    public ObservableCollection<EventoRastreamento> Historico { get; } = new();

    public ICommand NovaConsultaCommand { get; } =
        new Command(async () => await Shell.Current.GoToAsync(".."));

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Pacote", out var obj) && obj is Pacote p)
        {
            Pacote = p;
            Historico.Clear();
            foreach (var e in p.Historico.OrderByDescending(x => x.DataHora))
                Historico.Add(e);
        }
    }
}
