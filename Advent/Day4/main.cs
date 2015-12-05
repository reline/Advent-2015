using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

public class Day4 {
	public static void Main(string[] args) {
		string text = "iwrupvqb"; // iwrupvqb
		KeyValuePair<int, string> answer = CreateSmallestAnswer(text);
		System.Console.WriteLine($"The answer for {text} is {answer.Key}");
		System.Console.WriteLine($"The MD5 hash for {text}{answer.Key} is {answer.Value}");
	}

	public static KeyValuePair<int, string> CreateSmallestAnswer(string input) {

		string str = "";
		int hashInput = Int32.Parse(str.PadLeft(input.Length - 1, '9')); // 9999999 minimum/startpos
		int maxLength = Int32.Parse("1" + str.PadLeft(input.Length, '0')); // 100000000 maximum

		KeyValuePair<int, string> hash = new KeyValuePair<int, string>(hashInput, "");
		KeyValuePair<int, string> answer = hash;

		while (hash.Key < maxLength) {
			// create our md5 hash
			string hashVal = CreateMD5(input + (hash.Key + 1).ToString());

			// increment
		 	hash = new KeyValuePair<int, string>(hash.Key + 1, hashVal);

		 	if (answer.Value == "") {
		 		// initialize answer.Value if it hasn't been already
		 		answer = hash;
		 	} else if(isSmallerHex(hash.Value, answer.Value)) {
				// keep the smaller hash
				answer = hash;
				System.Console.WriteLine($"New solution: {input}{answer.Key} = {answer.Value}");
			}
		}
		return answer;
	}

	public static bool isSmallerHex(string arg1, string arg2) {

		if(arg1.Length < arg2.Length) {
			return true;
		}
		else if(arg2.Length < arg1.Length) {
			return false;
		}

		Dictionary<char, int> dict = new Dictionary<char, int>() {
	        { 'A', 10 },
	        { 'B', 11 },
	        { 'C', 12 },
	        { 'D', 13 },
	        { 'E', 14 },
	        { 'F', 15 }
	    };

		for (int i = 0; i < arg1.Length; i++) {
			int first = 0;
			int second = 0;
			
			if(dict.ContainsKey(arg1[i])) {
				dict.TryGetValue(arg1[i], out first);
			} else {
				first = (int)Char.GetNumericValue(arg1[i]);
			}

			if(dict.ContainsKey(arg2[i])) {
				dict.TryGetValue(arg2[i], out second);
			} else {
				second = (int)Char.GetNumericValue(arg2[i]);
			}

			if(first < second) {
				return true;
			} else if(second < first) {
				return false;
			}
		}
		return true;
	}

	public static string CreateMD5(string input) {
	    // Use input string to calculate MD5 hash
	    MD5 md5 = System.Security.Cryptography.MD5.Create();
	    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
	    byte[] hashBytes = md5.ComputeHash(inputBytes);

	    // Convert the byte array to hexadecimal string
	    StringBuilder sb = new StringBuilder();
	    for (int i = 0; i < hashBytes.Length; i++) {
	        sb.Append(hashBytes[i].ToString("X2"));
	    }
	    return sb.ToString();
	}
}