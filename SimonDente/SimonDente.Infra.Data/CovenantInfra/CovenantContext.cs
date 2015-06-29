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
    
        public DbSet<Covenant> Covenants  { get; set; }

        
    }
}
