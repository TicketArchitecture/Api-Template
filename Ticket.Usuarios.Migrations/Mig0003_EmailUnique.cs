using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Ticket.Usuarios.Migrations
{
    [Migration(3)]
    public class Mig0003_EmailUnique : Migration
    {
        public override void Down()
        {
            Alter.Column("email").
                OnTable("Usuarios").
                AsString().NotNullable();
        }

        public override void Up()
        {
            Alter.Column("email").
                OnTable("Usuarios").
                AsString().Unique().NotNullable(); 
        }
    }
}
