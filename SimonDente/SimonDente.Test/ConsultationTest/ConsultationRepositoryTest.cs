using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using SimonDente.Domain;
using SimonDente.Infra.Data;

namespace SimonDente.Test
{
    [TestClass]
    public class ConsultationRepositoryTest
    {
        private ConsultationContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {
            //Inicializa o banco, apagando e recriando-o
            Database.SetInitializer(new CreateDatabaseIfNotExists<ConsultationContext>());
            //Seta um registro padrão pra ser usado nos testes
            _contextForTest = new ConsultationContext();
            _contextForTest.Consultations.Add(ObjectMother.GetConsultation());
            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void CreateConsultationRepositoryTest()
        {
            //Arrange
            Consultation b = ObjectMother.GetConsultation();
            IConsultationRepository repository = new ConsultationRepository();

            //Action
            Consultation newConsultation = repository.Save(b);

            //Assert
            Assert.IsTrue(newConsultation.Id > 0);

        }

        [TestMethod]
        public void RetrieveConsultationRepositoryTest()
        {
            //Arrange
            IConsultationRepository repository = new ConsultationRepository();

            //Action
            Consultation Consultation = repository.Get(1);

            //Assert
            Assert.IsNotNull(Consultation);
            Assert.IsTrue(Consultation.Id > 0);
            Assert.IsFalse(string.IsNullOrEmpty(Consultation.Name));
            Assert.IsFalse(string.IsNullOrEmpty(Consultation.Type));
            Assert.IsFalse(string.IsNullOrEmpty(Consultation.Cpf));

        }

        [TestMethod]
        public void UpdateConsultationRepositoryTest()
        {
            //Arrange
            IConsultationRepository repository = new ConsultationRepository();
            Consultation Consultation = _contextForTest.Consultations.Find(1);
            Consultation.Name = "Teste";
            Consultation.Age = 20;
            Consultation.Cpf = "0000";
            Consultation.Rg = "0000";
            Consultation.Date = DateTime.Now;
            Consultation.Type = " SAUHSAHUSUAS";

            //Action
            var updatedConsultation = repository.Update(Consultation);

            //Assert
            var persistedConsultation = _contextForTest.Consultations.Find(1);
            Assert.IsNotNull(updatedConsultation);
            Assert.AreEqual(updatedConsultation.Id, persistedConsultation.Id);
            Assert.AreEqual(updatedConsultation.Name, persistedConsultation.Name);
            Assert.AreEqual(updatedConsultation.Cpf, persistedConsultation.Cpf);
            Assert.AreEqual(updatedConsultation.Rg, persistedConsultation.Rg);
            Assert.AreEqual(updatedConsultation.Type, persistedConsultation.Type);
            Assert.AreEqual(updatedConsultation.Date, persistedConsultation.Date);

        }

        [TestMethod]
        public void DeleteConsultationRepositoryTest()
        {
            //Arrange
            IConsultationRepository repository = new ConsultationRepository();

            //Action
            var deletedConsultation = repository.Delete(1);

            //Assert
            var persistedConsultation = _contextForTest.Consultations.Find(1);
            Assert.IsNull(persistedConsultation);

        }
    }

}
