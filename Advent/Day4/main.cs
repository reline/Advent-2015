using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

/** prepare for horribly named variables **/
public class Day4 {
	public static void Main(string[] args) {
		string text = "iwrupvqb";
		// string test = "abcdef"; //609043
		string hex = CreateSmallestAnswer(text);
		System.Console.WriteLine($"The answer for {text} is {hex}");
		string md5hash = CreateMD5(text + hex);
		System.Console.WriteLine($"The MD5 hash for {text}{hex} is {md5hash}");
	}

	public static string CreateSmallestAnswer(string input)
	{
		// todo: change hashNum and hash to a pair value
		string smallestHash = "";
		string smallestHashSolution = "";
		string hash = "";
		int hashNum = 0;
		string stringMaxLength = "";
		int maxLength = Int32.Parse("1" + stringMaxLength.PadLeft(input.Length, '0')); // 1000000

		while(hashNum < maxLength)
		{
			// convert our int to a string with the correct amount of 0's in front
			int zeros = input.Length - hashNum.ToString().Length;

			string solution = "";
			for(int i = 0; i < zeros; i++)
			{
				solution += "0";
			}
			solution += hashNum.ToString();
			// hash = hash.PadLeft(zeros, '0');

			// progress tracking 
			//System.Console.WriteLine($"Input: {solution}");

			// create our md5 hash
			hash = CreateMD5(input + solution);
			// DEBUG
			// System.Console.WriteLine($"Hash: {hash}");

			if (smallestHash != "")
			{
				// keep the smaller hash
				if(isSmallerHex(hash, smallestHash))
				{
					smallestHash = hash;
					smallestHashSolution = solution;
					System.Console.WriteLine($"New smallestHashSolution: {smallestHashSolution}\nNew smallestHash: {smallestHash}");
				}
			} 
			else
			{
				smallestHash = hash;
				smallestHashSolution = solution;
			}
			
			// System.Console.WriteLine($"Smallest Hash: {smallestHashSolution}");

			// increment
			hashNum++;
		}

		return smallestHashSolution;
	}

	public static bool isSmallerHex(string arg1, string arg2)
	{
		// DEBUG
		// System.Console.WriteLine($"Comparing: {arg1} and {arg2}");
		if(arg1.Length < arg2.Length)
		{
			return true;
		}
		else if(arg2.Length < arg1.Length)
		{
			return false;
		}

		Dictionary<char, int> dict = new Dictionary<char, int>()
	    {
	        { 'A', 10 },
	        { 'B', 11 },
	        { 'C', 12 },
	        { 'D', 13 },
	        { 'E', 14 },
	        { 'F', 15 }
	    };

		for (int i = 0; i < arg1.Length; i++)
		{
			int first = 0;
			int second = 0;
			
			if(dict.ContainsKey(arg1[i]))
			{
				dict.TryGetValue(arg1[i], out first);
			}
			else
			{
				first = (int)Char.GetNumericValue(arg1[i]);
			}

			if(dict.ContainsKey(arg2[i]))
			{
				dict.TryGetValue(arg2[i], out second);
			}
			else
			{
				second = (int)Char.GetNumericValue(arg2[i]);
			}

			if(first < second)
			{
				return true;
			}
			else if(second < first)
			{
				return false;
			}
		}

		return true;
	}

	public static string CreateMD5(string input)
	{
	    // Use input string to calculate MD5 hash
	    MD5 md5 = System.Security.Cryptography.MD5.Create();
	    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
	    byte[] hashBytes = md5.ComputeHash(inputBytes);

	    // Convert the byte array to hexadecimal string
	    StringBuilder sb = new StringBuilder();
	    for (int i = 0; i < hashBytes.Length; i++)
	    {
	        sb.Append(hashBytes[i].ToString("X2"));
	    }
	    return sb.ToString();
	}
}