using SimonDente.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonDente.Domain
{
    public class Covenant : IObjectValidation
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Business { get; set; }

        public string Plan { get; set; }

        public int Coverage { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new Exception("Nome Inválido");
            if (string.IsNullOrEmpty(Business))
                throw new Exception("Empresa Inválida");
            if (string.IsNullOrEmpty(Plan))
                throw new Exception("Plano Inválido");
            if (Coverage < 0)
                throw new Exception("Cobertura Inválida");
        }
    }
}
