using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimonDente.Domain;

namespace SimonDente.Infra.Data.CovenantInfra
{
    public class CovenantContext : DbContext
    {
        public CovenantContext()
            : base("CovenantContext")
        {
            
        }
        public DbSet<Covenant> Covenants  { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Covenant>().ToTable("TBCovenant");


        }
        
    }
}
