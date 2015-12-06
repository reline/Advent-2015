using System;

public class Day1 {
	public static void Main(string[] args) {
		
		int currentFloor = 0;
		int charPosition = 0;

		// read the file as a single string
		string text = System.IO.File.ReadAllText(@"input.txt");

		// display contents to the console
		//Console.WriteLine("Contents: {0}", text);

		bool enteredBasement = false;

		foreach (char character in text)
		{
			charPosition++;
			if(character == '(')
				currentFloor++;
			else if(character == ')')
				currentFloor--;
			if(currentFloor == -1 && enteredBasement == false)
			{
				System.Console.WriteLine($"Santa enters the basement at character {charPosition}");
				enteredBasement = true;
			}
		}

		System.Console.WriteLine($"Santa ends on floor {currentFloor}");
	}
}