using TesteDevFullStackDbm.Data.Entities;

namespace TesteDevFullStackDbm.Interfaces.Repositories
{
    public interface IRepositoryProtocol:IBaseRepository<Protocol>
    {
        Task AddWithTransaction(Protocol protocol, ProtocolFollow follow);
    }
}
