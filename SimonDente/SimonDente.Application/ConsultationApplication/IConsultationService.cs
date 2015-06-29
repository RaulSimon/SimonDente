using SimonDente.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonDente.Application
{
    public interface IConsultationService
    {

        Consultation Create(Consultation consultation);
        Consultation Retrieve(int id);
        Consultation Update(Consultation consultation);
        Consultation Delete(int id);

        List<Consultation> GetAll();
    }
}
