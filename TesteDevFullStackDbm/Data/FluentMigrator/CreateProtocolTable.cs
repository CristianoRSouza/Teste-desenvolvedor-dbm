using FluentMigrator;

namespace TesteDevFullStackDbm.Data.FluentMigrator
{
    [Migration(03)]
    public class CreateProtocolTable : Migration
    {
        public override void Up()
        {
            Create.Table("Protocols")
                .WithColumn("IdProtocolo").AsInt32().PrimaryKey().Identity()
                .WithColumn("Titulo").AsString(255).NotNullable()
                .WithColumn("Descricao").AsString(1000).NotNullable()
                .WithColumn("DataAbertura").AsDateTime().NotNullable()
                .WithColumn("DataFechamento").AsDateTime().Nullable()
                .WithColumn("IdCliente").AsInt32().NotNullable().ForeignKey("Clients", "IdCliente")
                .WithColumn("IdStatus").AsInt32().NotNullable().ForeignKey("StatusProtocols", "IdStatus").OnDeleteOrUpdate(System.Data.Rule.Cascade);

        }

        public override void Down()
        {
            Delete.Table("Protocols");
        }
    }

}
