using FluentMigrator;

namespace Ticket.Usuarios.Migrations
{
    [Migration(1)]
    public class CreateUsersTable : Migration
    {
        public override void Up()
        {
            Create.Table("Usuarios")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("nome_completo").AsString().NotNullable()
            .WithColumn("email").AsString().NotNullable()
            .WithColumn("cpf").AsString().WithDefaultValue("nao_informado")
            .WithColumn("aceita_mkt").AsBoolean().NotNullable()
            .WithColumn("status_validacao").AsInt32().WithDefaultValue(0)
            .WithColumn("numero_telefone").AsString().WithDefaultValue("nao_informado")
            .WithColumn("uuid_telefone").AsString().WithDefaultValue("nao_informado")
            .WithColumn("telefone_validado").AsBoolean().WithDefaultValue(false)
            .WithColumn("sistema_operacional_telefone").AsString().WithDefaultValue("nao_informado");
#if DEBUG
            this.Execute.Sql("Insert into Usuarios (nome_completo,email, aceita_mkt) Values (\"usuario teste\",\"email@teste.com\",1)");
#endif
        }

        public override void Down()
        {
            Delete.Table("Usuarios");
        }
    }
}
