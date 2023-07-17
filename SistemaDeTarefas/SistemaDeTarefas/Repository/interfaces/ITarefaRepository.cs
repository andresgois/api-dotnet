using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repository.interfaces
{
    public interface ITarefaRepository
    {
        Task<List<TarefaModel>> BuscarTodosTarefas();

        Task<TarefaModel> BuscarPorId(int id);

        Task<TarefaModel> Adicionar(TarefaModel tarefa);

        Task<TarefaModel> Atualizar(TarefaModel tarefa, int id);

        Task<bool> Apagar(int id);

    }
}
