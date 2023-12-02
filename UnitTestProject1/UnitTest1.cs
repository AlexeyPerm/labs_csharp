using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab9;
using System.Collections.Generic;

namespace UnitTestProject1 {
	[TestClass]
	public class UnitTest1 {
		[TestMethod]
		public void ZeroMoney() {

			//Проверка на создание обнулённого экземпляра
			var zeroMoney = new Money(0, 0);

			Money[] arrZeroMoney = { new Money(),
							new Money(-1, 0),
							new Money(0, -1) };
			foreach (var item in arrZeroMoney) {
				Assert.AreEqual(item, zeroMoney);
			}

		}

		[TestMethod]
		public void TestKopeks() {
			//Копеек болшье 99
			var testKopeks = new Money(1, 123);
			Assert.AreEqual(testKopeks, new Money(2, 23));
		}

		[TestMethod]
		public void TestMinus() {
			//Проверка метода Minus
			var minus1 = new Money(4, 50);
			var minus2 = new Money(0, 60);
			var minus3 = new Money(4, 60);
			var result = minus1.Minus(minus2);
			var result1 = minus1.Minus(minus3);
			var result2 = Money.Minus(minus3, minus1);
			var result3 = Money.Minus(minus1, minus3);

			Assert.AreEqual(result,  new Money(3, 90));
			Assert.AreEqual(result1, new Money(0, 0 ));
			Assert.AreEqual(result2, new Money(0, 10));
			Assert.AreEqual(result3, new Money(0, 0 ));

		}

	}
}
