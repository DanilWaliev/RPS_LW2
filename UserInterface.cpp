using namespace std;

#include "UserInterface.h"

void Menu::Show(void)
{
	cout << " ����:" << endl
		<< " 1 - ��������� ������ �������" << endl
		<< " 2 - ��������� ������ ���������� �������" << endl
		<< " 0 - ����� �� ���������" << endl
		<< endl;
}

void Menu::SetUserChoice(void)
{
	int input{};
	while (true)
	{
		input = InputHandler::GetInt("������� ����� ����: ");
		if (input >= 0 && input <= 2)
		{
			userChoice = static_cast<MenuOptions>(input);
			return;
		}
		cout << "������ ������ � ���� ���" << endl;
	}
}

MenuOptions Menu::GetUserChoice(void)
{
	return userChoice;
}

int InputHandler::GetInt(
	string promptMessage = "������� ������������� ��������: ",
	string errorMessage = "������������ ����")
{
	string input;

	while (true)
	{
		cout << promptMessage;
		cin >> input;

		if (IsNumber(input))
		{
			while (getchar() != '\n');
			cout << endl;
			return stoi(input);
		}

		while (getchar() != '\n');
		cout << errorMessage << endl;
		cout << endl;
	}
}

string InputHandler::GetWord(
	string promptMessage = "������� ������: ",
	string errorMessage = "������������ ����")
{
	string input;

	while (true)
	{
		cout << promptMessage;
		cin >> input;

		if (IsWord(input))
		{
			cout << endl;
			return input;
		}

		cout << errorMessage << endl;
		cout << endl;
	}
}

bool InputHandler::Prompt(std::string message)
{
	std::string input;

	while (true)
	{
		std::cout << message;
		std::cin >> input;
		while (getchar() != '\n');
		std::cout << std::endl;

		input = ToLowerCase(input);

		if (input == "��" || input == "�") return true;
		if (input == "���" || input == "�") return false;

		std::cout << "������������ ����" << std::endl;
	}
}

int InputHandler::GetVectorSize(void)
{
	int input{};
	int maxSize = 15;

	while (true)
	{
		input = GetInt("������� ����� �������: ");
		if (input > 0 && input <= maxSize) return input;
		cout << "������������ ����� �������!" << endl;
	}
}

void InputHandler::ManualFillVector(vector<int>& nums)
{
	string promptMessage;
	for (int i = 0; i < nums.size(); i++)
	{
		promptMessage = "������� " + to_string(i + 1) + " ������� �������: ";
		nums[i] = GetInt(promptMessage);
	}
}

void Printer::PrintVector(vector<int> nums)
{
	for (int i = 0; i < nums.size(); i++)
	{
		cout << nums[i];
		if (i != nums.size() - 1) cout << ", ";	
	}

	cout << "\n";
}