using ListaDeTarefasApi.Models;

namespace ListaDeTarefasApi.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<IEnumerable<Tarefa>> ObterTarefas(string titulo, bool? finalizada);
        Task<Tarefa> ObterTarefa(int id);
        Task<Tarefa> AdicionarTarefa(Tarefa tarefa);
        Task<Tarefa> AtualizarTarefa(Tarefa tarefa);
        Task<bool> ExcluirTarefa(int id);
    }
}
