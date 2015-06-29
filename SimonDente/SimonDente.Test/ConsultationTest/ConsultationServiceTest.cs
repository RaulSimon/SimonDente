using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimonDente.Application;
using SimonDente.Domain;
using SimonDente.Infra;

namespace SimonDente.Test
{
    [TestClass]
    public class ConsultationServiceTest
    {
        [TestMethod]
        public void CreateConsultationServiceValidationAndPersistenceTest()
        {
            //Arrange
            Consultation Consultation = ObjectMother.GetConsultation();
            //Fake do repositório
            var repositoryFake = new Mock<IConsultationRepository>();
            repositoryFake.Setup(r => r.Save(Consultation)).Returns(Consultation);
            //Fake do dominio
            var ConsultationFake = new Mock<Consultation>();
            ConsultationFake.As<IObjectValidation>().Setup(b => b.Validate());

            IConsultationService service = new ConsultationService(repositoryFake.Object);

            //Action
            service.Create(ConsultationFake.Object);

            //Assert
            ConsultationFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Save(ConsultationFake.Object));
        }

        [TestMethod]
        public void RetrieveConsultationServiceTest()
        {
            //Arrange
            Consultation Consultation = ObjectMother.GetConsultation();
            //Fake do repositório
            var repositoryFake = new Mock<IConsultationRepository>();
            repositoryFake.Setup(r => r.Get(1)).Returns(Consultation);

            IConsultationService service = new ConsultationService(repositoryFake.Object);

            //Action
            var ConsultationFake = service.Retrieve(1);

            //Assert
            repositoryFake.Verify(r => r.Get(1));
            Assert.IsNotNull(ConsultationFake);
        }

        [TestMethod]
        public void UpdateConsultationServiceValidationAndPersistenceTest()
        {
            //Arrange
            Consultation Consultation = ObjectMother.GetConsultation();
            //Fake do repositório
            var repositoryFake = new Mock<IConsultationRepository>();
            repositoryFake.Setup(r => r.Update(Consultation)).Returns(Consultation);
            //Fake do dominio
            var ConsultationFake = new Mock<Consultation>();
            ConsultationFake.As<IObjectValidation>().Setup(b => b.Validate());

            IConsultationService service = new ConsultationService(repositoryFake.Object);

            //Action
            service.Update(ConsultationFake.Object);

            //Assert
            ConsultationFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Update(ConsultationFake.Object));
        }

        [TestMethod]
        public void DeleteConsultationServiceTest()
        {
            //Arrange
            Consultation Consultation = null;
            //Fake do repositório
            var repositoryFake = new Mock<IConsultationRepository>();
            repositoryFake.Setup(r => r.Delete(1)).Returns(Consultation);

            IConsultationService service = new ConsultationService(repositoryFake.Object);

            //Action
            var ConsultationFake = service.Delete(1);

            //Assert
            repositoryFake.Verify(r => r.Delete(1));
            Assert.IsNull(ConsultationFake);
        }
    }
}
