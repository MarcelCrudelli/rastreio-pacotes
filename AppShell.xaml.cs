// Dupla: [NOME 1] e [NOME 2]
using RastreioPacotesApp.Views;

namespace RastreioPacotesApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("resultado", typeof(ResultadoPage));
    }
}
