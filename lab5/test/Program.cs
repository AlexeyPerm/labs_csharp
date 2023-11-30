 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test {
	internal class Program {
		static void Main() {
			int [][] array = new int [3][];
			array[0] = new int[5];
			array[1] = new int[2];
			array[2] = new int[10];

			int a  = array[0].Rank;

			Random random = new Random();

			for (int i = 0; i < array.Length; i++) {
				for (int k = 0; k < array[i].Length; k++) {
					array[i][k] = random.Next(100);
				}
			}

			for (int i = 0; i < array.Length; i++) {
				for (int k = 0; k < array[i].Length; k++) {
					Console.Write(array[i][k] + "\t");
				}
				Console.WriteLine();
			}

		}
	}
}
