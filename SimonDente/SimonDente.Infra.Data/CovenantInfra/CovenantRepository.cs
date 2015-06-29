using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimonDente.Domain;

namespace SimonDente.Infra.Data.CovenantInfra
{
    public class CovenantRepository : ICovenantRepository
    {
        private CovenantContext context;

        public CovenantRepository()
        {
            context = new CovenantContext();
        }

        public Covenant Save(Covenant xonsultation)
        {
            var newCovenant = context.Covenants.Add(xonsultation);
            context.SaveChanges();
            return newCovenant;
        }


        public Covenant Get(int id)
        {
            var Covenant = context.Covenants.Find(id);
            return Covenant;
        }


        public Covenant Update(Covenant Covenant)
        {
            DbEntityEntry entry = context.Entry(Covenant);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            return Covenant; 
        }


        public Covenant Delete(int id)
        {
            var Covenant = context.Covenants.Find(id);
            DbEntityEntry entry = context.Entry(Covenant);
            entry.State = EntityState.Deleted;
            context.SaveChanges();
            return Covenant;
        }


        public List<Covenant> GetAll()
        {
            return context.Covenants.ToList();
        }

    }
}
