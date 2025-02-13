using Microsoft.EntityFrameworkCore;
using TesteDevFullStackDbm.Data.Context;
using TesteDevFullStackDbm.Data.Entities;
using TesteDevFullStackDbm.Interfaces.Repositories;

namespace TesteDevFullStackDbm.Data.Repositories
{
    public class RepositoryProtocol : BaseRepository<Protocol>, IRepositoryProtocol
    {
        public RepositoryProtocol(MyContext context) : base(context)
        {
        }
        public async Task AddWithTransaction(Protocol protocol, ProtocolFollow follow)
        {
            await using var transaction = await _myContexto.Database.BeginTransactionAsync();

            try
            {
                await _myContexto.Protocols.AddAsync(protocol);
                await _myContexto.SaveChangesAsync();

                follow.ProtocolId = protocol.IdProtocol;
                await _myContexto.ProtocolFollows.AddAsync(follow);
                await _myContexto.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}