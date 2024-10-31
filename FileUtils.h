#pragma once

using namespace std;

#include <string>
#include <filesystem>
#include <ios>
#include <vector>

bool IsFileNameReserved(string filename);

bool IsReadOnly(string fileName);
