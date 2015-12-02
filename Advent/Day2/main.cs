using System;
using Namespace;

public class Day2 {
	public static void Main(string[] args) {
		
		// read each line of the file into a string array
		string[] lines = System.IO.File.ReadAllLines(@"input.txt");

		// create a box object for each line
		foreach (string line in lines) {
			string[] measurements = line.Split('x');
			int w = Int32.Parse(measurements[0]);
			int h = Int32.Parse(measurements[1]);
			int l = Int32.Parse(measurements[2]);
			Box box = new Box(w, h, l);
		}

		System.Console.WriteLine($"Wrapping paper needed: {Box.totalWrappingPaper} square feet");
		System.Console.WriteLine($"Ribbon needed: {Box.totalRibbon} feet");
	}
}