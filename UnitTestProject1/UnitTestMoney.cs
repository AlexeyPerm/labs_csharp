using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab9;
using System;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestMoney
    {
        [TestMethod]
        public void ZeroMoney()
        {
            //Проверка на создание обнулённого экземпляра
            var zeroMoney = new Money(0, 0);
            Money[] arrZeroMoney =
            {
                new Money(),
                new Money(-1, 0),
                new Money(0, -1)
            };
            foreach (var item in arrZeroMoney)
            {
                Assert.AreEqual(item, zeroMoney);
            }
        }

        [TestMethod]
        public void TestKopeks()
        {
            //Копеек болшье 99
            var testKopeks = new Money(1, 123);
            Assert.AreEqual(testKopeks, new Money(2, 23));
        }

        [TestMethod]
        public void TestMinus()
        {
            //Проверка метода Minus
            var money1 = new Money(4, 50);
            var money2 = new Money(0, 60);
            var money3 = new Money(45, 60);

            var result = money1.Minus(money2);
            var result1 = money1.Minus(money3);
            var result2 = Money.Minus(money3, money1);
            var result3 = Money.Minus(money1, money3);

            Assert.AreEqual(result, new Money(3, 90));
            Assert.AreEqual(result1, new Money(0, 0));
            Assert.AreEqual(result2, new Money(41, 10));
            Assert.AreEqual(result3, new Money(0, 0));
        }


        [TestMethod]
        public void UnaryOperators()
        {
            var m1 = new Money(423, 99);
            m1++;
            var m2 = new Money(213, 0);
            m2--;

            Assert.AreEqual(m1, new Money(424, 0));
            m1++;
            Assert.AreEqual(m1, new Money(424, 1));

            Assert.AreEqual(m2, new Money(212, 99));
            m2--;
            Assert.AreEqual(m2, new Money(212, 98));
        }

        [TestMethod]
        public void TestConversions()
        {
            var m1 = new Money(423, 99);
            int x = m1;
            double y = (double)m1;
            Assert.AreEqual(x, 423);
            Assert.AreEqual(y, 0, 99);
        }

        [TestMethod]
        public void TestBinaryOperations()
        {
            var m1 = new Money(123, 23);
            m1 -= 24;
            Assert.AreEqual(m1, new Money(122, 99));
            m1 -= 1000000;
            Assert.AreEqual(m1, new Money(0, 0));

            var m2 = new Money(1, 20);
            m2 = 122 - m2;
            Assert.AreEqual(m2, new Money(0, 2));
            m2 = 10 - m2;
            Assert.AreEqual(m2, new Money(0, 8));
            var m3 = new Money(100, 2);
            m2 = 10 - m3;
            Assert.AreEqual(m2, new Money(0, 0));


            var m10 = new Money(29, 54);
            var m11 = new Money(3, 56);
            var m12 = m10 - m11;
            Assert.AreEqual(m12, new Money(25, 98));
            m12 -= m10;
            Assert.AreEqual(m12, new Money(0, 0));
        }


        [TestMethod]
        public void TestEq()
        {
            var m1 = new Money(423, 99);
            var m2 = new Money(425, 99);

            Assert.IsTrue(m1 < m2);
            Assert.IsFalse(m1 > m2);

            Assert.IsTrue(m2 > m1);
            Assert.IsFalse(m2 < m1);

            var m3 = new Money(2, 3);
            var m4 = new Money(2, 3);
            Assert.IsFalse(m3 > m4);
            Assert.IsFalse(m3 < m4);
        }


        [TestMethod]
        public void TestCreatedObjCount()
        {
            int count = Money.CreatedObjectCount();

            Assert.AreEqual(Money.CreatedObjectCount(), count);
        }
    }

    [TestClass]
    public class UnitTestMoneyArray
    {
        [TestMethod]
        public void TestInitArray()
        {
            int count = 10;
            MoneyArray arr1 = new MoneyArray();
            MoneyArray arr = new MoneyArray(count);
            Assert.AreEqual(arr.Length, count);
        }

        [TestMethod]
        public void TestThis()
        {
            var minus1 = new Money(4, 50);
            var minus2 = new Money(0, 60);
            var minus3 = new Money(4, 60);
            MoneyArray arr1 = new MoneyArray(minus1, minus2, minus3);
            Assert.AreEqual(arr1[1], minus2);
            try
            {
                Assert.AreEqual(arr1[4], minus2);
            }
            catch (System.ArgumentException)
            {
                Console.WriteLine("Выход за границы массива");
            }

            try
            {
                Assert.AreEqual(arr1[-4], minus2);
            }
            catch (System.ArgumentException)
            {
                Console.WriteLine("Выход за границы массива");
            }

            arr1[1] = minus3;

            Assert.AreEqual(arr1[1], minus3);

            try
            {
                arr1[4] = minus3;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Выход за границы массива");
            }

            try
            {
                arr1[-2] = minus3;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Выход за границы массива");
            }
        }

        [TestMethod]
        public void TestMax()
        {
            var minus1 = new Money(4, 50);
            var minus2 = new Money(0, 60);
            var minus3 = new Money(45, 60);
            var minus4 = new Money(123, 40);
            var minus5 = new Money(2, 1);
            var arr1 = new MoneyArray(minus1, minus2, minus3, minus4, minus5);
            var maxElen = arr1.Max();
            Assert.AreEqual(maxElen, minus4);
        }
    }
}