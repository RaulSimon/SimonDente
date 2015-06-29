using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimonDente.Domain;
using SimonDente.Infra;

namespace SimonDente.Test
{
    [TestClass]
    public class ConsultationDomainTest
    {
        [TestMethod]
        public void CreateAConsultationTest()
        {
            Consultation consultation = ObjectMother.GetConsultation();

            Assert.IsNotNull(consultation);
        }

        [TestMethod]
        public void CreateAValidConsultationTest()
        {
            Consultation consultation = ObjectMother.GetConsultation();

            Validator.Validate(consultation);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidConsultationNameTest()
        {
            Consultation consultation = new Consultation();

            Validator.Validate(consultation);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidConsultationAgeTest()
        {
            Consultation Consultation = new Consultation();
            Consultation.Name = "Raul";

            Validator.Validate(Consultation);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidConsultationCpfTest()
        {
            Consultation Consultation = new Consultation();
            Consultation.Name = "SI Uniplac";
            Consultation.Age = 20;           

            Validator.Validate(Consultation);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidConsultationRgTest()
        {
            Consultation Consultation = new Consultation();
            Consultation.Name = "SI Uniplac";
            Consultation.Age = 20;
            Consultation.Cpf = "090.319-189-03";
            
            Validator.Validate(Consultation);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidConsultationTypeTest()
        {
            Consultation Consultation = new Consultation();
            Consultation.Name = "SI Uniplac";
            Consultation.Age = 20;
            Consultation.Cpf = "090.319-189-03";
            Consultation.Rg = "6.301.210";

            Validator.Validate(Consultation);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidConsultationDateTest()
        {
            Consultation Consultation = new Consultation();
            Consultation.Name = "SI Uniplac";
            Consultation.Age = 20;
            Consultation.Cpf = "090.319-189-03";
            Consultation.Rg = "6.301.210";
            Consultation.Type = "LOL";

            Validator.Validate(Consultation);
        }
    }
}
