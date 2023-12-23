using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab10;

namespace TestLab10 {
    [TestClass]
    public class TestOrganization {
        [TestMethod]
        public void TestZeroOrganisation() {
            var org = new Organisation(null, null, 0);
            var testOrg = new Organisation();
            Assert.AreEqual(org, testOrg);
        }
    }
}