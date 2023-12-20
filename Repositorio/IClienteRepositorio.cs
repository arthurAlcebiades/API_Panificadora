using API_Panificadora.Models;

namespace API_Panificadora.Repositorio
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteModelView>> BuscarClientes();
    }
}
