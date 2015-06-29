using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimonDente.Application.CovenantApplication;
using SimonDente.Domain;
using SimonDente.Infra;

namespace SimonDente.Test.CovenantTest
{
    [TestClass]
    public class CovenantServiceTest
    {
        [TestMethod]
        public void CreateCovenantServiceValidationAndPersistenceTest()
        {
            //Arrange
            Covenant Covenant = ObjectMother.GetCovenant();
            //Fake do repositório
            var repositoryFake = new Mock<ICovenantRepository>();
            repositoryFake.Setup(r => r.Save(Covenant)).Returns(Covenant);
            //Fake do dominio
            var CovenantFake = new Mock<Covenant>();
            CovenantFake.As<IObjectValidation>().Setup(b => b.Validate());

            ICovenantService service = new CovenantService(repositoryFake.Object);

            //Action
            service.Create(CovenantFake.Object);

            //Assert
            CovenantFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Save(CovenantFake.Object));
        }

        [TestMethod]
        public void RetrieveCovenantServiceTest()
        {
            //Arrange
            Covenant Covenant = ObjectMother.GetCovenant();
            //Fake do repositório
            var repositoryFake = new Mock<ICovenantRepository>();
            repositoryFake.Setup(r => r.Get(1)).Returns(Covenant);

            ICovenantService service = new CovenantService(repositoryFake.Object);

            //Action
            var CovenantFake = service.Retrieve(1);

            //Assert
            repositoryFake.Verify(r => r.Get(1));
            Assert.IsNotNull(CovenantFake);
        }

        [TestMethod]
        public void UpdateCovenantServiceValidationAndPersistenceTest()
        {
            //Arrange
            Covenant Covenant = ObjectMother.GetCovenant();
            //Fake do repositório
            var repositoryFake = new Mock<ICovenantRepository>();
            repositoryFake.Setup(r => r.Update(Covenant)).Returns(Covenant);
            //Fake do dominio
            var CovenantFake = new Mock<Covenant>();
            CovenantFake.As<IObjectValidation>().Setup(b => b.Validate());

            ICovenantService service = new CovenantService(repositoryFake.Object);

            //Action
            service.Update(CovenantFake.Object);

            //Assert
            CovenantFake.As<IObjectValidation>().Verify(b => b.Validate());
            repositoryFake.Verify(r => r.Update(CovenantFake.Object));
        }

        [TestMethod]
        public void DeleteCovenantServiceTest()
        {
            //Arrange
            Covenant Covenant = null;
            //Fake do repositório
            var repositoryFake = new Mock<ICovenantRepository>();
            repositoryFake.Setup(r => r.Delete(1)).Returns(Covenant);

            ICovenantService service = new CovenantService(repositoryFake.Object);

            //Action
            var CovenantFake = service.Delete(1);

            //Assert
            repositoryFake.Verify(r => r.Delete(1));
            Assert.IsNull(CovenantFake);
        }
    }
}
