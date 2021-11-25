using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using oficina_do_marcio.Models;

namespace oficina_do_marcio.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("oficinadomarciodb") { }
        public DbSet<Mecanico> Mecanicos { get; set; }
    }
}