using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository.interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TarefaController : ControllerBase
    {

        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTodos()
        {
            List<TarefaModel> tarefa = await _tarefaRepository.BuscarTodosTarefas(); 
            return Ok(tarefa);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorTarefa(int id)
        {
            TarefaModel tarefa = await _tarefaRepository.BuscarPorId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepository.Adicionar(tarefaModel);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRepository.Atualizar(tarefaModel, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> Deletar(int id)
        {
            bool deletado = await _tarefaRepository.Apagar(id);
            return Ok(deletado);
        }

    }
}
