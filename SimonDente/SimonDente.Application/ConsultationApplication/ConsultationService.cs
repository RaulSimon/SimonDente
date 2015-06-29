using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimonDente.Domain;
using SimonDente.Infra;

namespace SimonDente.Application
{
    public class ConsultationService : IConsultationService
    {
        private IConsultationRepository _consultationRepository;

        public ConsultationService(IConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        public Consultation Create(Consultation consultation)
        {
            Validator.Validate(consultation);

            var savedConsultation = _consultationRepository.Save(consultation);

            return savedConsultation;
        }

        public Consultation Retrieve(int id)
        {
            return _consultationRepository.Get(id);
        }

        public Consultation Update(Consultation consultation)
        {
            Validator.Validate(consultation);

            var updatedConsultation = _consultationRepository.Update(consultation);

            return updatedConsultation;
        }

        public Consultation Delete(int id)
        {
            return _consultationRepository.Delete(id);
        }


        public List<Consultation> GetAll()
        {
            return _consultationRepository.GetAll();
        }
    }
}
