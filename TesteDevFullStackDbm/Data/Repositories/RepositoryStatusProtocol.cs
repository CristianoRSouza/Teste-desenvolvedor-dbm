using TesteDevFullStackDbm.Data.Context;
using TesteDevFullStackDbm.Data.Entities;
using TesteDevFullStackDbm.Interfaces.Repositories;

namespace TesteDevFullStackDbm.Data.Repositories
{
    public class RepositoryStatusProtocol : BaseRepository<StatusProtocol>, IRepositoryStatusProtocol
    {
        public RepositoryStatusProtocol(MyContext myContext) : base(myContext)
        {
        }
    }
}
