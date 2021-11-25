using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using oficina_do_marcio.Models;
using System.Configuration;

namespace oficina_do_marcio.Context
{
    public class Connection
    {
        public static string gplecas = ConfigurationManager.ConnectionStrings["OficinaDoMarcioContext"].ConnectionString;
        

    }
    public class EFContext : DbContext
    {

        public EFContext() : base(Connection.gplecas) { }
        public DbSet<Mecanico> mecanico { get; set; }
        public DbSet<Veiculo> veiculo { get; set; }
    }
}