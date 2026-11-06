// Dupla: [NOME 1] e [NOME 2]
using System.Windows.Input;
using RastreioPacotesApp.Services;

namespace RastreioPacotesApp.ViewModels;

/// <summary>ViewModel da página inicial: recebe o código e busca o pacote.</summary>
public class BuscaViewModel : BaseViewModel
{
    private readonly IRastreamentoService _servico;
    private string _codigo = string.Empty;
    private string _mensagemErro = string.Empty;
    private bool _ocupado;

    public BuscaViewModel(IRastreamentoService servico)
    {
        _servico = servico;
        BuscarCommand = new Command(async () => await BuscarAsync(), () => !Ocupado);
    }

    public string Codigo
    {
        get => _codigo;
        set => SetProperty(ref _codigo, value);
    }

    public string MensagemErro
    {
        get => _mensagemErro;
        set { SetProperty(ref _mensagemErro, value); OnPropertyChanged(nameof(TemErro)); }
    }

    public bool TemErro => !string.IsNullOrEmpty(MensagemErro);

    public bool Ocupado
    {
        get => _ocupado;
        set { SetProperty(ref _ocupado, value); ((Command)BuscarCommand).ChangeCanExecute(); }
    }

    public ICommand BuscarCommand { get; }

    private void OnPropertyChanged(string nome) => base.OnPropertyChangedPublic(nome);

    private async Task BuscarAsync()
    {
        MensagemErro = string.Empty;

        if (string.IsNullOrWhiteSpace(Codigo))
        {
            MensagemErro = "Digite o código de rastreamento.";
            return;
        }

        try
        {
            Ocupado = true;
            var pacote = await _servico.BuscarPacoteAsync(Codigo);

            if (pacote is null)
            {
                MensagemErro = "Pacote não encontrado. Confira o código.";
                return;
            }

            // Navega para a página de resultados passando o pacote
            await Shell.Current.GoToAsync("resultado",
                new Dictionary<string, object> { ["Pacote"] = pacote });
        }
        finally
        {
            Ocupado = false;
        }
    }
}
