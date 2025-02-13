using TesteDevFullStackDbm.Data.Context;
using TesteDevFullStackDbm.Data.Entities;
using TesteDevFullStackDbm.Interfaces.Repositories;

namespace TesteDevFullStackDbm.Data.Repositories
{
    public class RepositoryFollow : BaseRepository<ProtocolFollow>, IRepositoryFollow
    {
        public RepositoryFollow(MyContext myContext) : base(myContext)
        {
        }
    }
}
