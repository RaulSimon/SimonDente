using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimonDente.Domain;

namespace SimonDente.Application.CovenantApplication
{
   public interface ICovenantService
    {
        Covenant Create(Covenant Covenant);
        Covenant Retrieve(int id);
        Covenant Update(Covenant Covenant);
        Covenant Delete(int id);

        List<Covenant> GetAll();
    }
}
