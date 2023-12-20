using API_Panificadora.Models;

namespace API_Panificadora.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private AppContexto _dbContext;
        public ClienteRepositorio(AppContexto appContexto)
        {
            _dbContext = appContexto;
        }
        public async Task<List<ClienteModelView>> BuscarClientes()
        {
            return await Task.FromResult(_dbContext.cliente.ToList());
        }
    }
}
