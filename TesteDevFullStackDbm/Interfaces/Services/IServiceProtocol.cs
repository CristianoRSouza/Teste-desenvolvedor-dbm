using Microsoft.AspNetCore.Mvc.Rendering;
using TesteDevFullStackDbm.Data.Dtos;

namespace TesteDevFullStackDbm.Interfaces.Services
{
    public interface IServiceProtocol
    {
        Task Add(ProtocolDto user);
        Task Update(ProtocolDto user);
        Task<ProtocolDto> Get(int id);
        Task<IEnumerable<ProtocolDto>> GetAll();
        Task Delete(int id);
        Task<IEnumerable<SelectListItem>> GetClientes();
        Task<IEnumerable<SelectListItem>> GetStatus();
    }
}
