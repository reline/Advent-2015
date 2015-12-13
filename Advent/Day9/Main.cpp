#include <fstream>
#include <sstream>
#include <iostream>
#include <algorithm>

#include "Location.h"

int main(int argc, char const *argv[])
{
	// output our Locations into a collection with their respective distances
	std::ifstream input("input.txt");
	std::vector<Location> Locations;

	std::string line;
	while (std::getline(input, line))
	{
		// split up the line into separate words (words.at(0), words.at(2), words.at(4))
		std::string buf;
		std::stringstream ss(line);
		std::vector<std::string> words;
		while (ss >> buf)
			words.push_back(buf);

		Location firstLocation = Location(words.at(0));
		Location secondLocation = Location(words.at(2));

		bool duplicateOne = false;
		bool duplicateTwo = false;
		for (std::vector<Location>::iterator i = Locations.begin(); i != Locations.end(); ++i)
		{
			if (Location(*i).GetName() == firstLocation.GetName())
			{
				duplicateOne = true;
				Location(*i).AddNeighbor(firstLocation.GetName(), std::stoi(words.at(4), nullptr));
			}
			else if (Location(*i).GetName() == secondLocation.GetName())
			{
				duplicateTwo = true;
				Location(*i).AddNeighbor(secondLocation.GetName(), std::stoi(words.at(4), nullptr));
			}
		}

		if (!duplicateOne)
		{
			Locations.push_back(firstLocation);
		}

		if (!duplicateTwo)
		{
			Locations.push_back(secondLocation);
		}
	}

	for (std::vector<Location>::iterator i = Locations.begin(); i != Locations.end(); ++i)
	{
		std::cout << Location(*i).GetName() << std::endl;
	}

	return 0;
}