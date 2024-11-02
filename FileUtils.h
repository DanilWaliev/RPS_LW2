#pragma once

using namespace std;

#include <string>
#include <filesystem>
#include <ios>
#include <vector>

// Проверяет является ли указанное имя файла зарезервированным
bool IsFileNameReserved(string filename);

// Проверяет является ли файл с указанным именем только для чтения
bool IsReadOnly(string fileName);
