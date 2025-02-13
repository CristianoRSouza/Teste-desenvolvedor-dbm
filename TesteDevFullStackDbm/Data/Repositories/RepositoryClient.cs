using Microsoft.EntityFrameworkCore;
using TesteDevFullStackDbm.Data.Context;
using TesteDevFullStackDbm.Data.Dtos;
using TesteDevFullStackDbm.Data.Entities;
using TesteDevFullStackDbm.Interfaces.Repositories;

namespace TesteDevFullStackDbm.Data.Repositories
{
    public class RepositoryClient : BaseRepository<Client>, IRepositoryClient
    {
        public RepositoryClient(MyContext myContext) : base(myContext)
        {
        }

        public async Task<IEnumerable<Client>> GetClientWithDetails()
        {
            var clients = await _myContexto.Clients
          .Include(c => c.Protocols)
              .ThenInclude(p => p.StatusProtocol) 
          .Include(c => c.Protocols)
              .ThenInclude(p => p.Follows) 
          .ToListAsync();

            return clients;
        }


    }
}
