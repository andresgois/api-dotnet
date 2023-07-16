using Microsoft.AspNetCore.Mvc;
using MyApplication.Model;

namespace MyApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<UsuarioModel> Get()
        {
            List<UsuarioModel> usuarioModels = new List<UsuarioModel>();
            usuarioModels.Add(new UsuarioModel() { Id = 1, Name = "Andre", Email = "andre@email.com" });
            return usuarioModels;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public UsuarioModel Get(int id)
        {
            UsuarioModel usuarioModel = new UsuarioModel() { Id = 1, Name = "Andre", Email = "andre@email.com" };
            return usuarioModel;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] UsuarioModel usuarioModel)
        {

        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UsuarioModel usuarioModel)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
