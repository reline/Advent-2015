using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Day4 {
	public static void Main(string[] args) {
		string[] lines = System.IO.File.ReadAllLines(@"input.txt");

		int niceStrings = 0;

		foreach(string line in lines) {
			bool repeatPair = false;
			bool repeatSplit = false;

			for(int i = 0; i < line.Length; i++) {

				if(i < line.Length - 1) {
					StringBuilder sb = new StringBuilder();
					sb.Append(line[i]).Append(line[i+1]);
					var regex = new Regex(sb.ToString());
					if(regex.Matches(line).Count >= 2) {
						repeatPair = true;
					}
				}
				
				if(i < line.Length - 2) {
					if(line[i] == line[i+2]) {
						repeatSplit = true;
					}
				}
				
			}

			if(repeatPair && repeatSplit) {
				niceStrings++;
				System.Console.WriteLine($"Nice: {line}");
			} else {
				//System.Console.WriteLine($"Naughty: {line}");
			}
		}

		System.Console.WriteLine($"Nice strings: {niceStrings}");
	}
}