using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimonDente.Domain;
using SimonDente.Infra;

namespace SimonDente.Application.CovenantApplication
{
    public class CovenantService : ICovenantService
    {
        private ICovenantRepository _CovenantRepository;

        public CovenantService(ICovenantRepository CovenantRepository)
        {
            _CovenantRepository = CovenantRepository;
        }

        public Covenant Create(Covenant Covenant)
        {
            Validator.Validate(Covenant);

            var savedCovenant = _CovenantRepository.Save(Covenant);

            return savedCovenant;
        }

        public Covenant Retrieve(int id)
        {
            return _CovenantRepository.Get(id);
        }

        public Covenant Update(Covenant Covenant)
        {
            Validator.Validate(Covenant);

            var updatedCovenant = _CovenantRepository.Update(Covenant);

            return updatedCovenant;
        }

        public Covenant Delete(int id)
        {
            return _CovenantRepository.Delete(id);
        }


        public List<Covenant> GetAll()
        {
            return _CovenantRepository.GetAll();
        }
    }
}
