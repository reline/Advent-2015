#include "Location.h"

Location::Location(std::string name)
{
	this->name = name;
	this->neighborLocations = std::map<std::string, int>();
	this->visited = false;
}

void Location::AddNeighbor(std::string LocationName, int distance)
{
	this->neighborLocations[LocationName] = distance;
}

std::string Location::GetName()
{
	return this->name;
}

Location::~Location()
{

}