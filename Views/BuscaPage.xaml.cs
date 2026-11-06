// Dupla: [NOME 1] e [NOME 2]
using RastreioPacotesApp.ViewModels;

namespace RastreioPacotesApp.Views;

public partial class BuscaPage : ContentPage
{
    public BuscaPage(BuscaViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
