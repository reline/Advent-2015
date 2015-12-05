using System;
using System.Linq;
using System.Text;

public class Day4 {
	public static void Main(string[] args) {
		string[] lines = System.IO.File.ReadAllLines(@"input.txt"); // less than 274

		string[] forbiddenStrings = new string[4] {"ab", "cd", "pq", "xy"};
		string vowels = "aeiou";

		int niceStrings = 0;

		foreach(string line in lines) {
			int numVowels = 0;
			bool dub = false;
			bool containsForbiddenString = false;
			char prevChar = '0';

			foreach(string forbiddenString in forbiddenStrings) {
				if(line.Contains(forbiddenString)) {
					containsForbiddenString = true;
					break;
				}
			}
			if(containsForbiddenString) continue;

			foreach(char character in line) {
				if(vowels.ToLowerInvariant().Contains(character)) {
					numVowels++;
				}

				if(character == prevChar) {
					dub = true;
				}

				prevChar = character;
			}

			if(numVowels >= 3 && dub && !containsForbiddenString) {
				niceStrings++;
				System.Console.WriteLine($"Nice: {line}");
			} else {
				//System.Console.WriteLine($"Naughty: {line}");
			}
		}

		System.Console.WriteLine($"Nice strings: {niceStrings}");
	}
}