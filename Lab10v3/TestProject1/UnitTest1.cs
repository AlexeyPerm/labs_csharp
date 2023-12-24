using LibraryLab10;

namespace TestProject1 {
    [TestClass]
    public class TestOrganization {
        [TestMethod]
        public void TestZeroOrganisation() {
            var org = new Organisation("EmptyName", 0);
            var testOrg = new Organisation();
            Assert.AreEqual(org, testOrg);
        }

        [TestMethod]
        public void TestPropertySet() {
            var org = new Organisation("OrgTest", 500);
            Assert.AreEqual(org, new Organisation("OrgTest", 500));
        }

        [TestMethod]
        public void TestPropertyGet() {
            var org = new Organisation("OrgTest", 500);
            var orgName = org.OrgName;
            var budget = org.Budget;
            Assert.AreEqual(orgName, "OrgTest");
            Assert.AreEqual(budget, 500);
        }

        [TestMethod]
        public void TestRandomInit() {
            var org = new Organisation();
            org.RandomInit();
            org.Show();
        }
    }

    [TestClass]
    public class TestFactory {
        [TestMethod]
        public void TestZeroFactory() {
            var fact = new Factory("EmptyName", 0, 0);
            var testFact = new Factory();
            Assert.AreEqual(fact, testFact);
        }

        [TestMethod]
        public void TestRandomInit() {
            var testFact = new Factory();
            testFact.RandomInit();
            testFact.Show();
        }
    }

    [TestClass]
    public class TestInsurance {
        [TestMethod]
        public void TestZeroInsurance() {
            var insurance = new InsuranceCompany("EmptyName", 0, 0);
            var testinsurance = new InsuranceCompany();
            Assert.AreEqual(insurance, testinsurance);
        }

        [TestMethod]
        public void TestRandomInit() {
            var testinsurance = new InsuranceCompany();
            testinsurance.RandomInit();
            testinsurance.Show();
        }
    }

    [TestClass]
    public class TestLibrary {
        [TestMethod]
        public void TestZeroLibrary() {
            var library = new Library("EmptyName", 0, 0);
            var testLibrary = new Library();
            Assert.AreEqual(library, testLibrary);
        }

        [TestMethod]
        public void TestRandomInit() {
            var testLibrary = new Library();
            testLibrary.RandomInit();
            testLibrary.Show();
        }
    }

    [TestClass]
    public class TestShip {
        [TestMethod]
        public void TestZeroShip() {
            var ship = new Shipyard("EmptyName", 0, 0, 0);
            var testShip = new Shipyard();
            Assert.AreEqual(ship, testShip);
        }

        [TestMethod]
        public void TestRandomInit() {
            var testShip = new Shipyard();
            testShip.RandomInit();
            testShip.Show();
        }
    }
}