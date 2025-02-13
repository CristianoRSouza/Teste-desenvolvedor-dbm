using FluentMigrator;

namespace TesteDevFullStackDbm.Data.FluentMigrator
{
    [Migration(02)]
    public class CreateStatusProtocolTable : Migration
    {
        public override void Up()
        {
            Create.Table("StatusProtocols")
                .WithColumn("IdStatus").AsInt32().PrimaryKey().Identity()
                .WithColumn("NomeStatus").AsString(255).NotNullable();

            Insert.IntoTable("StatusProtocols")
                .Row(new { NomeStatus = "Ativo" })
                .Row(new { NomeStatus = "Desativado" });
        }

        public override void Down()
        {
            Delete.Table("StatusProtocols");
        }
    }
}
