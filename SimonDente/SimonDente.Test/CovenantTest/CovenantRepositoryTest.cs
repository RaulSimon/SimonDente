using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimonDente.Domain;
using SimonDente.Infra.Data.CovenantInfra;

namespace SimonDente.Test.CovenantTest
{
    [TestClass]
    public class CovenantRepositoryTest
    {
        private CovenantContext _contextForTest;

        [TestInitialize]
        public void Setup()
        {
            //Inicializa o banco, apagando e recriando-o
            Database.SetInitializer(new DropCreateDatabaseAlways<CovenantContext>());
            //Seta um registro padrão pra ser usado nos testes
            _contextForTest = new CovenantContext();
            _contextForTest.Covenants.Add(ObjectMother.GetCovenant());
            _contextForTest.SaveChanges();
        }

        [TestMethod]
        public void CreateCovenantRepositoryTest()
        {
            //Arrange
            Covenant b = ObjectMother.GetCovenant();
            ICovenantRepository repository = new CovenantRepository();

            //Action
            Covenant newCovenant = repository.Save(b);

            //Assert
            Assert.IsTrue(newCovenant.Id > 0);

        }

        [TestMethod]
        public void RetrieveCovenantRepositoryTest()
        {
            //Arrange
            ICovenantRepository repository = new CovenantRepository();

            //Action
            Covenant Covenant = repository.Get(1);

            //Assert
            Assert.IsNotNull(Covenant);
            Assert.IsTrue(Covenant.Id > 0);
            Assert.IsFalse(string.IsNullOrEmpty(Covenant.Name));
            Assert.IsFalse(string.IsNullOrEmpty(Covenant.Business));
            Assert.IsFalse(string.IsNullOrEmpty(Covenant.Plan));
            Assert.IsFalse(Covenant.Coverage < 0);

        }

        [TestMethod]
        public void UpdateCovenantRepositoryTest()
        {
            //Arrange
            ICovenantRepository repository = new CovenantRepository();
            Covenant Covenant = _contextForTest.Covenants.Find(1);
            Covenant.Name = "Teste";
            Covenant.Business = "NDD";
            Covenant.Plan = "0000";
            Covenant.Coverage = 20;

            //Action
            var updatedCovenant = repository.Update(Covenant);

            //Assert
            var persistedCovenant = _contextForTest.Covenants.Find(1);
            Assert.IsNotNull(updatedCovenant);
            Assert.AreEqual(updatedCovenant.Id, persistedCovenant.Id);
            Assert.AreEqual(updatedCovenant.Name, persistedCovenant.Name);
            Assert.AreEqual(updatedCovenant.Business, persistedCovenant.Business);
            Assert.AreEqual(updatedCovenant.Plan, persistedCovenant.Plan);
            Assert.AreEqual(updatedCovenant.Coverage, persistedCovenant.Coverage);
        }

        [TestMethod]
        public void DeleteCovenantRepositoryTest()
        {
            //Arrange
            ICovenantRepository repository = new CovenantRepository();

            //Action
            var deletedCovenant = repository.Delete(1);

            //Assert
            var persistedCovenant = _contextForTest.Covenants.Find(1);
            Assert.IsNull(persistedCovenant);

        }
    }
}
