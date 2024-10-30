#pragma once

using namespace std;

#include <string>
#include <filesystem>
#include <ios>
#include <vector>

class FileHandler
{
public:
	static bool IsFileNameReserved(string filename);

	static void PrintVectorToFile(vector<int> nums);
};