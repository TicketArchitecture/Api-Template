using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Usuarios.Migrations;

namespace Ticket.Usuarios.API.Web
{
    public class DebugMigrationDBConfig
    {
        public static void MigrateDatabase(string connectionString)
        {
#if DEBUG
            var migrator = new DebugMigrator(connectionString);

            migrator.Migrate(runner => runner.MigrateDown(0));
            migrator.Migrate(runner => runner.MigrateUp(2));

#endif
        }
    }
}
