using namespace std;

#include "StringUtils.h"

// ��������� �������� �� ������ ������ �����
bool IsWord(string str)
{
    locale loc("Russian"); // ��� �������� ���� ���������
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

// ��������� �������� �� ������ ���������� ������
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

// ���������� ������� ������� ������ str � ������� ��������
std::string ToLowerCase(std::string str)
{
    std::locale loc("Russian"); // ��� ������ std::tolower() � ������� ���������
    for (int i = 0; i < str.size(); i++) str[i] = std::tolower(str[i], loc);
    return str;
}

// ���������� ������� ������� ������ str � �������� ��������
std::string ToUpperCase(std::string str)
{
    std::locale loc("Russian"); // ��� ������ std::toupper() � ������� ���������
    for (int i = 0; i < str.size(); i++) str[i] = std::toupper(str[i], loc);
    return str;
}