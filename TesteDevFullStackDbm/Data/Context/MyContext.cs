using Microsoft.EntityFrameworkCore;
using TesteDevFullStackDbm.Data.Entities;

namespace TesteDevFullStackDbm.Data.Context
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients  { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<ProtocolFollow> ProtocolFollows { get; set; }
        public DbSet<StatusProtocol> StatusProtocols { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyContext).Assembly);
            base.OnModelCreating(modelBuilder);

        }

    }
}
