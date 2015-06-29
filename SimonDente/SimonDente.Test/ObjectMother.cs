using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimonDente.Domain;

namespace SimonDente.Test
{

    public class ObjectMother
    {

        public static Consultation GetConsultation()
        {
            Consultation consultation = new Consultation();
            consultation.Name = "Raul";
            consultation.Age = 20;
            consultation.Cpf = "090.319.189-03";
            consultation.Rg = "6.301.210";
            consultation.Type = "Verificação Anual";
            consultation.Date = DateTime.Now;

            return consultation;
        }

        public static Covenant GetCovenant()
        {
            Covenant covenant = new Covenant();
            covenant.Name = "Unimed";
            covenant.Business = "NddDigital";
            covenant.Plan = "Plano ideal";
            covenant.Coverage = 80;

            return covenant;
        }
    }



 
}
