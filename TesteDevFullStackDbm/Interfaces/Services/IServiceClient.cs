using TesteDevFullStackDbm.Data.Dtos;
using TesteDevFullStackDbm.Data.Entities;

namespace TesteDevFullStackDbm.Interfaces.Services
{
    public interface IServiceClient
    {
        Task AddUser(ClientDto user);
        Task UpdateUser(ClientDto user);
        Task<ClientDto> GetUser(int id);
        Task<IEnumerable<ClientDto>> GetAllUser();
        Task DeleteUser(int id);
        Task<IEnumerable<Client>> GetClientWithDetails();
    }
}
