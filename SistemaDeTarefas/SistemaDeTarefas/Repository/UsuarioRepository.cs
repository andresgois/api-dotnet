using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository.interfaces;

namespace SistemaDeTarefas.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SistemasTarefasDBContext _dbContext;

        public UsuarioRepository(SistemasTarefasDBContext sistemasTarefasDBContext) 
        { 
            _dbContext = sistemasTarefasDBContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário com ID: {id} não econtrado!");
            }
            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if(usuarioPorId == null)
            {
                throw new Exception($"Usuário com ID: {id} não econtrado!");
            }
            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return usuarioPorId;
        }

    }
}
