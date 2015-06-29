using SimonDente.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonDente.Infra.Data
{
    public class ConsultationContext :DbContext
    {
        public ConsultationContext()
            : base("ConsultationContext")
        {
            
        }
        public DbSet<Consultation> Consultations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultation>().ToTable("TBConsultation");
                    

        }
        
    }
}
