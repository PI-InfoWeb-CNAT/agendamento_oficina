using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using oficina_do_marcio.Models;
using System.Configuration;

namespace oficina_do_marcio.Context
{
    // enable-migrations
    // add-migration MigrationName
    // update-database
    // update-database -TargetMigration $InitialDatabase
    // update-database -TargetMigration MigrationName
    public class Connection
    {
        public static string connectString = ConfigurationManager.ConnectionStrings["OficinaDoMarcioContext"].ConnectionString;
    }
    public class EFContext : DbContext
    {

        public EFContext() : base(Connection.connectString) { }
        public DbSet<Mecanico> mecanico { get; set; }
        public DbSet<Veiculo> veiculo { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Orcamento> orcamento { get; set; }
        public DbSet<Agendamento> agendamento { get; set; }
        public DbSet<Produto> produto { get; set; }
        public DbSet<Servico> servico { get; set; }
    }
}