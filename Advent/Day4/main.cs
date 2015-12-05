using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

public class Day4 {
	public static void Main(string[] args) {
		string text = "iwrupvqb"; // iwrupvqb
		
		int hashNum = 1;
		while(true) {
			string hashVal = CreateMD5(text + hashNum.ToString());
			if(hashVal.Substring(0, 5) == "00000") {
				System.Console.WriteLine($"The answer for {text} is {hashNum}");
				System.Console.WriteLine($"The MD5 hash for {text}{hashNum} is {hashVal}");
				return;
			}
			hashNum++;
		}		
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