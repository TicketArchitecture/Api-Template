using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Ticket.Usuarios.Migrations
{
    [Migration(2)]
    public class Mig0001_ChangeUsersTable : Migration
    {
        public override void Down()
        {
            Alter.Column("status_validacao").
                OnTable("Users").
                AsInt32().NotNullable().WithDefaultValue(0);
        }

        public override void Up()
        {
            Alter.Column("status_validacao").
                OnTable("Users").
                AsInt32().Nullable().WithDefaultValue(0);
        }
    }
}
