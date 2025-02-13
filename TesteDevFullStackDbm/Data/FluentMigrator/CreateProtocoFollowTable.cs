using FluentMigrator;

namespace TesteDevFullStackDbm.Data.FluentMigrator
{
    [Migration(04)]
    public class CreateProtocolFollowTable : Migration
    {
        public override void Up()
        {
            Create.Table("ProtocolFollows")
                .WithColumn("IdFollow").AsInt32().PrimaryKey().Identity()
                .WithColumn("IdProtocolo").AsInt32().NotNullable().ForeignKey("Protocols", "IdProtocolo") // Nome da FK corrigido
                .WithColumn("DataAcao").AsDateTime().NotNullable()
                .WithColumn("DescricaoAcao").AsString(1000).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("ProtocolFollows");
        }
    }

}
