using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonDente.Domain
{
    public interface IConsultationRepository
    {
        Consultation Save(Consultation consultation);

        Consultation Get(int id);

        Consultation Update(Consultation consultation);

        Consultation Delete(int id);

        List<Consultation> GetAll();
    }
}
