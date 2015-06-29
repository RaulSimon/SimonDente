using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonDente.Domain
{
    public interface ICovenantRepository
    {
        Covenant Save(Covenant covenant);

        Covenant Get(int id);

        Covenant Update(Covenant covenant);

        Covenant Delete(int id);

        List<Covenant> GetAll();
    }
}
