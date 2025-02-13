using TesteDevFullStackDbm.Data.Dtos;
using TesteDevFullStackDbm.Data.Entities;

namespace TesteDevFullStackDbm.Interfaces.Repositories
{
    public interface IRepositoryClient:IBaseRepository<Client>
    {
        Task<IEnumerable<Client>> GetClientWithDetails();
    }
}
