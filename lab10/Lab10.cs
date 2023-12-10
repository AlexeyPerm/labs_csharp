using System;
using System.Data.SqlTypes;

namespace Lab10 {
    public class Lab10 {
        static void Main() {
            const int variantNumber = 549 % 16 - 1; //номер варианта 8
            Console.WriteLine($"Номер варианта = {variantNumber}\n");

            //var org = new Organisation();
            //var ins = new InsuranceCompany();
            //ins.Show();
            //var fact = new Factory();
            //fact.Show();

            var sh = new Shipyard();
            sh.RandomInit();
            sh.Show();
        }
    }
}