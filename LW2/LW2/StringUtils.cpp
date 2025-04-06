using namespace std;

#include "StringUtils.h"

// проверяет содержит ли строка только буквы
bool IsWord(string str)
{
    locale loc("Russian"); // для проверки букв кириллицы
    bool isWord = true;
    for (const char ch : str)
    {
        if (!isalpha(ch, loc) && ch != '-')
        {
            isWord = false;
            break;
        }
    }

    return isWord;
}

// проверяет является ли строка десятичным числом
bool IsNumber(string str)
{
    locale loc("Russian");
    bool isNumber = true;
    for (const char ch : str)
    {
        if (!isdigit(ch, loc) && ch != '-' && ch != '.')
        {
            isNumber = false;
            break;
        }
    }

    return isNumber;
}

// приведение каждого символа строки str к нижнему регистру
std::string ToLowerCase(std::string str)
{
    std::locale loc("Russian"); // для работы std::tolower() с буквами кириллицы
    for (int i = 0; i < str.size(); i++) str[i] = std::tolower(str[i], loc);
    return str;
}

// приведение каждого символа строки str к верхнему регистру
std::string ToUpperCase(std::string str)
{
    std::locale loc("Russian"); // для работы std::toupper() с буквами кириллицы
    for (int i = 0; i < str.size(); i++) str[i] = std::toupper(str[i], loc);
    return str;
}