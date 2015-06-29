using SimonDente.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonDente.Domain
{
    public class Consultation : IObjectValidation
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new Exception("Nome Inválido");
            if (Age < 0)
                throw new Exception("Idade Inválida");
            if (string.IsNullOrEmpty(Cpf))
                throw new Exception("Cpf Inválido");
            if (string.IsNullOrEmpty(Rg))
                throw new Exception("Rg Inválido");
            if (string.IsNullOrEmpty(Type))
                throw new Exception("Tipo de Consulta Inválido");
            if (Date < DateTime.Today)
                throw new Exception("Data Inválida");
        }

        
    }
}
