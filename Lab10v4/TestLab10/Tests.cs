using ClassLibraryLab10;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLab10
{
    [TestClass]
    public class TestOrganization
    {
        [TestMethod]
        public void TestZeroOrganisation()
        {
            var org = new Organisation("EmptyName", 0);
            var testOrg = new Organisation();
            Assert.AreEqual(org, testOrg);
        }

        [TestMethod]
        public void TestPropertySet()
        {
            var org = new Organisation("OrgTest", 500);
            Assert.AreEqual(org, new Organisation("OrgTest", 500));
        }

        [TestMethod]
        public void TestPropertyGet()
        {
            var org = new Organisation("OrgTest", 500);
            var orgName = org.OrgName;
            var budget = org.Budget;
            Assert.AreEqual(orgName, "OrgTest");
            Assert.AreEqual(budget, 500);
        }

        [TestMethod]
        public void TestRandomInit()
        {
            var org = new Organisation();
            org.RandomInit();
            org.Show();
        }

        [TestMethod]
        public void TestShallowCopy()
        {
            var obj = new Organisation();
            var newObj = (Organisation)obj.ShallowCopy();

            Assert.IsInstanceOfType(obj, typeof(Organisation));
            Assert.AreNotSame(newObj, obj); //Проверяет, ссылаются ли указанные объекты на разные объекты
        }

        [TestMethod]
        public void TestClone()
        {
            var obj = new Organisation();
            var newObj = (Organisation)obj.Clone();

            Assert.IsInstanceOfType(obj, typeof(Organisation));
            Assert.AreNotSame(newObj, obj);
        }
    }


    [TestClass]
    public class TestFactory
    {
        [TestMethod]
        public void TestZeroFactory()
        {
            var fact = new Factory("EmptyName", 0, 0);
            var testFact = new Factory();
            Assert.AreEqual(fact, testFact);
        }

        [TestMethod]
        public void TestRandomInit()
        {
            var testFact = new Factory();
            testFact.RandomInit();
            testFact.Show();
        }

        [TestMethod]
        public void TestShallowCopy()
        {
            Factory obj = new Factory();
            Factory newObj = (Factory)obj.ShallowCopy();

            Assert.IsInstanceOfType(obj, typeof(Factory));
            Assert.AreNotSame(newObj, obj); //Проверяет, ссылаются ли указанные объекты на разные объекты
        }

        [TestMethod]
        public void TestClone()
        {
            Factory obj = new Factory();
            Factory newObj = (Factory)obj.Clone();

            Assert.IsInstanceOfType(obj, typeof(Factory));
            Assert.AreNotSame(newObj, obj);
        }
    }

    [TestClass]
    public class TestInsurance
    {
        [TestMethod]
        public void TestZeroInsurance()
        {
            var insurance = new InsuranceCompany("EmptyName", 0, 0);
            var testinsurance = new InsuranceCompany();
            Assert.AreEqual(insurance, testinsurance);
        }

        [TestMethod]
        public void TestRandomInit()
        {
            var testinsurance = new InsuranceCompany();
            testinsurance.RandomInit();
            testinsurance.Show();
        }

        [TestMethod]
        public void TestShallowCopy()
        {
            var obj = new InsuranceCompany();
            var newObj = (InsuranceCompany)obj.ShallowCopy();

            Assert.IsInstanceOfType(obj, typeof(InsuranceCompany));
            Assert.AreNotSame(newObj, obj); //Проверяет, ссылаются ли указанные объекты на разные объекты
        }

        [TestMethod]
        public void TestClone()
        {
            var obj = new InsuranceCompany();
            var newObj = (InsuranceCompany)obj.Clone();

            Assert.IsInstanceOfType(obj, typeof(InsuranceCompany));
            Assert.AreNotSame(newObj, obj);
        }
    }

    [TestClass]
    public class TestLibrary
    {
        [TestMethod]
        public void TestZeroLibrary()
        {
            var library = new Library("EmptyName", 0, 0);
            var testLibrary = new Library();
            Assert.AreEqual(library, testLibrary);
        }

        [TestMethod]
        public void TestRandomInit()
        {
            var testLibrary = new Library();
            testLibrary.RandomInit();
            testLibrary.Show();
        }

        [TestMethod]
        public void TestShallowCopy()
        {
            var obj = new Library();
            var newObj = (Library)obj.ShallowCopy();

            Assert.IsInstanceOfType(obj, typeof(Library));
            Assert.AreNotSame(newObj, obj); //Проверяет, ссылаются ли указанные объекты на разные объекты
        }

        [TestMethod]
        public void TestClone()
        {
            var obj = new Library();
            var newObj = (Library)obj.Clone();

            Assert.IsInstanceOfType(obj, typeof(Library));
            Assert.AreNotSame(newObj, obj);
        }
    }

    [TestClass]
    public class TestShip
    {
        [TestMethod]
        public void TestZeroShip()
        {
            var ship = new Shipyard("EmptyName", 0, 0, 0);
            var testShip = new Shipyard();
            Assert.AreEqual(ship, testShip);
        }

        [TestMethod]
        public void TestRandomInit()
        {
            var testShip = new Shipyard();
            testShip.RandomInit();
            testShip.Show();
        }

        [TestMethod]
        public void TestShallowCopy()
        {
            var obj = new Shipyard();
            var newObj = (Shipyard)obj.ShallowCopy();

            Assert.IsInstanceOfType(obj, typeof(Shipyard));
            Assert.AreNotSame(newObj, obj); //Проверяет, ссылаются ли указанные объекты на разные объекты
        }

        [TestMethod]
        public void TestClone()
        {
            var obj = new Shipyard();
            var newObj = (Shipyard)obj.Clone();

            Assert.IsInstanceOfType(obj, typeof(Shipyard));
            Assert.AreNotSame(newObj, obj);
        }
    }

    [TestClass]
    public class Teststart
    {
        [TestMethod]
        public void TestZeroStar()
        {
            var testStar = new Star(null, 0, 0);
            var star = new Star();
            Assert.AreEqual(star, testStar);
        }

        [TestMethod]
        public void TestRandomInit()
        {
            var testStar = new Star();
            testStar.RandomInit();
            testStar.Show();
        }

        [TestMethod]
        public void TestShallowCopy()
        {
            var obj = new Star();
            var newObj = (Star)obj.ShallowCopy();

            Assert.IsInstanceOfType(obj, typeof(Star));
            Assert.AreNotSame(newObj, obj); //Проверяет, ссылаются ли указанные объекты на разные объекты
        }

        [TestMethod]
        public void TestClone()
        {
            var obj = new Star();
            var newObj = (Star)obj.Clone();

            Assert.IsInstanceOfType(obj, typeof(Star));
            Assert.AreNotSame(newObj, obj);
        }
    }
}