using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace test {
	internal class Program {
		static void Main(string[] args) {

			string stroke = "As the Internet is developed and network applications grow, IPv4 addresses are running out. Hello";


			string output = new string(stroke.ToCharArray().Reverse().ToArray());
			string[] words = output.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			Array.Sort(words);
			output = string.Join(" ", words);

			Console.WriteLine(output);

		}



	}

}
