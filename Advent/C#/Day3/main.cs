using System;
using System.Collections.Generic;
using System.Linq;

public class Day3 {
	public static void Main(string[] args) {
		string text = System.IO.File.ReadAllText(@"input.txt");

		// v^>v

		List<Point> houses = new List<Point>();

		int x = 0; // current x position
		int y = 0; // current y position

		houses.Add(new Point(x, y));

		foreach(char character in text) {
			
			if(character == 'v') {
				y--;
			} else if (character == '^') {
				y++;
			} else if (character == '>') {
				x++;
			} else if (character == '<') {
				x--;
			}

			Point point = new Point(x, y);
            if(!houses.Contains(point)) {
            	houses.Add(point);
            }
		}

		System.Console.WriteLine($"Santa visits {houses.Count} houses by himself");


		houses = new List<Point>();

		int santaX = 0; // santa x position
		int santaY = 0; // santa y position

		int roboX = 0; // roboSanta x position
		int roboY = 0; // roboSanta y position

		houses.Add(new Point(santaX, santaY));

		bool santaTurn = true;

		foreach(char character in text) {
			
			Point point = new Point();

			if(santaTurn) {
				if(character == 'v') {
					santaY--;
				} else if (character == '^') {
					santaY++;
				} else if (character == '>') {
					santaX++;
				} else if (character == '<') {
					santaX--;
				}
				point = new Point(santaX, santaY);
			} else {
				if(character == 'v') {
					roboY--;
				} else if (character == '^') {
					roboY++;
				} else if (character == '>') {
					roboX++;
				} else if (character == '<') {
					roboX--;
				}
				point = new Point(roboX, roboY);
			}
			
            if(!houses.Contains(point)) {
            	houses.Add(point);
            }

            santaTurn = !santaTurn;
		}

		System.Console.WriteLine($"Santa visits {houses.Count} houses with help from RoboSanta");
	}
}

public struct Point
{
	public int X, Y;

	public Point(int x, int y) {
		X = x;
		Y = y;
	}
}