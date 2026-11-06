// Dupla: [NOME 1] e [NOME 2]
using RastreioPacotesApp.Models;

namespace RastreioPacotesApp.Services;

public interface IRastreamentoService
{
    Task<Pacote?> BuscarPacoteAsync(string codigo);
}
