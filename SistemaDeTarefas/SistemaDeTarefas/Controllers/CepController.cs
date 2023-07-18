using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Integracao.Interfaces;
using SistemaDeTarefas.Integracao.Response;

namespace SistemaDeTarefas.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegracao _integracao;

        public CepController(IViaCepIntegracao integracao)
        {
            _integracao = integracao;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListaDeDadosDeEndereco(string cep) 
        { 
            var responseDate = await _integracao.ObterDadosViaCep(cep);

            if(responseDate == null)
            {
                return BadRequest("Cep não encontrado");
            }
            return Ok(responseDate);
        }
    }
}
