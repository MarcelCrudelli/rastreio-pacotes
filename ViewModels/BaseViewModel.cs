// Dupla: [NOME 1] e [NOME 2]
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RastreioPacotesApp.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChangedPublic(string nome) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));

    protected bool SetProperty<T>(ref T campo, T valor, [CallerMemberName] string? nome = null)
    {
        if (EqualityComparer<T>.Default.Equals(campo, valor)) return false;
        campo = valor;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
        return true;
    }
}
