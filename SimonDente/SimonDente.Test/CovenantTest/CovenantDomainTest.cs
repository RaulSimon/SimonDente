using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimonDente.Domain;
using SimonDente.Infra;

namespace SimonDente.Test.CovenantTest
{
    [TestClass]
    public class CovenantDomainTest
    {
        [TestMethod]
        public void CreateACovenantTest()
        {
            Covenant covenant = ObjectMother.GetCovenant();

            Assert.IsNotNull(covenant);
        }

        [TestMethod]
        public void CreateAValidCovenantTest()
        {
            Covenant covenant = ObjectMother.GetCovenant();

            Validator.Validate(covenant);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidCovenantNameTest()
        {
            Covenant covenant = new Covenant();

            Validator.Validate(covenant);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidcovenantBusinessTest()
        {
            Covenant covenant = new Covenant();
            covenant.Name = "Raul";

            Validator.Validate(covenant);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidcovenantPlanTest()
        {
            Covenant covenant = new Covenant();
            covenant.Name = "Unimed";
            covenant.Business = "Teste";

            Validator.Validate(covenant);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateAInvalidCovenantCoverageTest()
        {
            Covenant covenant = new Covenant();
            covenant.Name = "Unimed";
            covenant.Business = "Ndd";
            covenant.Plan = "Pobre";
            covenant.Coverage = -1;
            Validator.Validate(covenant);
        }
    }
}
