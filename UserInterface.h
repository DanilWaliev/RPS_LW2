using namespace std;

#include <iostream>
#include <vector>
#include <iomanip>
#include <fstream>
#include "Utils.h"

enum class MenuOptions
{
	Exit,
	RandomInput,
	ManualInput
};

class Menu
{
	MenuOptions userChoice;

public:
	static void Show(void);

	void SetUserChoice(void);

	MenuOptions GetUserChoice(void);
};

class InputHandler
{
public:
	static int GetInt(
		string promptMessage = "������� ������������� ��������: ",
		string errorMessage = "������������ ����");

	static string GetWord(
		string promptMessage = "������� ������: ",
		string errorMessage = "������������ ����");

	static bool Prompt(std::string message);

	static int GetVectorSize(void);

	static void ManualFillVector(vector<int>& nums);
};

class Printer
{
public:
	static void PrintVector(vector<int> nums);
};