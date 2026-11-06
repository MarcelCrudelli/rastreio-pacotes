// Dupla: [NOME 1] e [NOME 2]
using RastreioPacotesApp.ViewModels;

namespace RastreioPacotesApp.Views;

public partial class ResultadoPage : ContentPage
{
    public ResultadoPage(ResultadoViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
