#pragma once

#include <string>
#include <vector>
#include <utility>
#include <map>
#include <iostream>

class Location
{
private:
	std::string name;
	// collection neighboring Locations (Location name, distance from Location)
	std::map<std::string, int> neighborLocations;
	bool visited;

public:
	Location(std::string);
	~Location();

	void AddNeighbor(std::string LocationName, int distance);
	std::string GetName();
};