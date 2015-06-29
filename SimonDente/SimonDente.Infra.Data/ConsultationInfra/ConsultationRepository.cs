using SimonDente.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonDente.Infra.Data
{
    public class ConsultationRepository : IConsultationRepository
    {
         private ConsultationContext context;

        public ConsultationRepository()
        {
            context = new ConsultationContext();
        }

        public Consultation Save(Consultation xonsultation)
        {
            var newConsultation = context.Consultations.Add(xonsultation);
            context.SaveChanges();
            return newConsultation;
        }


        public Consultation Get(int id)
        {
            var Consultation = context.Consultations.Find(id);
            return Consultation;
        }


        public Consultation Update(Consultation Consultation)
        {
            DbEntityEntry entry = context.Entry(Consultation);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            return Consultation; 
        }


        public Consultation Delete(int id)
        {
            var Consultation = context.Consultations.Find(id);
            DbEntityEntry entry = context.Entry(Consultation);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
            return Consultation;
        }


        public List<Consultation> GetAll()
        {
            return context.Consultations.ToList();
        }
    }
}
