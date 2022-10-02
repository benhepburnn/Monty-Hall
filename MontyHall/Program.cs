using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall {
	class Program {

		static Random rand = new Random();

		static void Main(string[] args) {
			int doors = 100;
			int repetitions = 10;
			string input = "y";

			while (input.ToLower() == "y") {
				int noChangeWins = RunTests(doors, repetitions, false);
				int changeWins = RunTests(doors, repetitions, true);

				Console.WriteLine("\nDoors: {0}, Repetitions: {1}\n", doors, repetitions);
				Console.WriteLine("WITHOUT SWAPPING:");
				Console.WriteLine("=================");
				Console.WriteLine("Wins: {0}; Ratio: {1}%\n\n", noChangeWins, (noChangeWins * 1.0f / repetitions) * 100f);
				Console.WriteLine("WITH SWAPPING:");
				Console.WriteLine("=================");
				Console.WriteLine("Wins: {0}; Ratio: {1}%", changeWins, (changeWins * 1.0f / repetitions) * 100f);
				Console.WriteLine("\nRepeat? (Y/N)");
				input = Console.ReadLine();
				Console.WriteLine("----------------------------------------------------");
			}
		}

		static int RunTests (int d, int r, bool swap) {
			int wins = 0;
			List<int> choices = new List<int>();

			for (int i = 0; i < r; i++) {
				for (int c = 1; c <= d; c++) {
					choices.Add(c);
				}
				int correct = rand.Next(1, d);
				int choice = rand.Next(1, d);

				if (swap) {
					if (choice != correct) {
						choice = correct;
					} else {
						choice++;
					}
				}

				if (choice == correct) {
					wins++;
				}
			}

			return wins;
		}
	}
}
