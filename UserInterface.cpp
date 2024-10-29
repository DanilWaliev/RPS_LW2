using namespace std;

#include "UserInterface.h"

void Menu::Show(void)
{
	cout << " Меню:" << endl
		<< " 1 - Заполнить массив вручную" << endl
		<< " 2 - Заполнить массив случайными числами" << endl
		<< " 0 - Выйти из программы" << endl
		<< endl;
}

void Menu::SetUserChoice(void)
{
	int input{};
	while (true)
	{
		input = InputHandler::GetInt("Введите пункт меню: ");
		if (input >= 0 && input <= 2)
		{
			userChoice = static_cast<MenuOptions>(input);
			return;
		}
		cout << "Такого пункта в меню нет" << endl;
	}
}

MenuOptions Menu::GetUserChoice(void)
{
	return userChoice;
}

int InputHandler::GetInt(
	string promptMessage = "Введите целочисленное значение: ",
	string errorMessage = "Некорректный ввод")
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
	string promptMessage = "Введите строку: ",
	string errorMessage = "Некорректный ввод")
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

		if (input == "да" || input == "д") return true;
		if (input == "нет" || input == "н") return false;

		std::cout << "Некорректный ввод" << std::endl;
	}
}

int InputHandler::GetVectorSize(void)
{
	int input{};
	int maxSize = 15;

	while (true)
	{
		input = GetInt("Введите длину массива: ");
		if (input > 0 && input <= maxSize) return input;
		cout << "Некорректная длина массива!" << endl;
	}
}

void InputHandler::ManualFillVector(vector<int>& nums)
{
	string promptMessage;
	for (int i = 0; i < nums.size(); i++)
	{
		promptMessage = "Введите " + to_string(i + 1) + " элемент массива: ";
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