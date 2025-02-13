using FluentMigrator;

namespace TesteDevFullStackDbm.Data.FluentMigrator
{
    [Migration(01)]
    public class CreateClientTable : Migration
    {
        public override void Up()
        {
            Create.Table("Clients")
                .WithColumn("IdCliente").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("Telefone").AsString(50).Nullable()
                .WithColumn("Endereco").AsString(500).Nullable();

            Insert.IntoTable("Clients")
                .Row(new { Nome = "Me contrata >.>", Email = "Crisvideoaulas@gmail.com", Telefone = "41989008598", Endereco = "Marechal Deodoro" });
        }

        public override void Down()
        {
            Delete.Table("Clients");
        }
    }

}
