#pragma once

using namespace std;

#include <string>
#include <locale>

// ѕровер€ет содержит ли указанна€ строка только буквы
bool IsWord(string str);

// ѕровер€ет содержит ли указанна€ строка только числа
bool IsNumber(string str);

// ѕриводит указанную строку к нижнему регистру
string ToLowerCase(string str);

// ѕриводит указанную строку к верхнему регистру
string ToUpperCase(string str);