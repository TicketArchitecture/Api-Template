﻿using System;
using System.Reflection;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;

namespace Ticket.Usuarios.Migrations
{
    public class DebugMigrator
    {
        string connectionString;

        public DebugMigrator(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }

            public string ProviderSwitches
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public int Timeout { get; set; }
        }

        public void Migrate(Action<IMigrationRunner> runnerAction)
        {
            var options = new MigrationOptions { PreviewOnly = false, Timeout = 0 };
            var factory = new FluentMigrator.Runner.Processors.SQLite.SQLiteProcessorFactory();
            var assembly = Assembly.GetExecutingAssembly();

            //using (var announcer = new NullAnnouncer())
            var announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));
            var migrationContext = new RunnerContext(announcer)
            {
#if DEBUG
                // will create testdata
                Profile = "development"
#endif
            };

            using (var processor = factory.Create(connectionString, announcer, options))
            {
                var runner = new MigrationRunner(assembly, migrationContext, processor);
                runner.MigrateDown(0);
                runner.MigrateUp(true);
            }
        }
    }
}
