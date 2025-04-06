using namespace std;

#include "FileUtils.h"
#include "UserInterface.h"
#include <random>
#include <filesystem>
#include <algorithm> // для transform
#include <string> // для string

void Menu::Show(void)
{
	cout << " Меню:" << endl
		<< " 1 - Заполнить массив вручную" << endl
		<< " 2 - Заполнить массив случайными числами" << endl
		<< " 3 - Отсортировать массив деревом" << endl
		<< " 4 - Сохранить массив в файл" << endl  
		<< " 0 - Выйти из программы" << endl
		<< endl;
}

void Menu::InputUserChoice(void)
{
	int input{};
	while (true)
	{
		input = InputHandler::GetInt("Введите пункт меню: ");
		if (input >= 0 && input <= 4)
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
	string promptMessage,
	string errorMessage)
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
	string promptMessage,
	string errorMessage)
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

int VectorHandler::InputVectorSize(void)
{
	int input{};
	int maxSize = 15;

	while (true)
	{
		input = InputHandler::GetInt("Введите длину массива: ");
		if (input > 0 && input <= maxSize) return input;
		cout << "Некорректная длина массива!" << endl;
	}
}

void VectorHandler::ManualFillVector(vector<int>& nums)
{
	string promptMessage;
	for (int i = 0; i < nums.size(); i++)
	{
		promptMessage = "Введите " + to_string(i + 1) + " элемент массива: ";
		nums[i] = InputHandler::GetInt(promptMessage);
	}
}

void VectorHandler::RandomFillVector(vector<int>& nums)
{
	std::random_device rd;
	std::mt19937 gen(rd());
	std::uniform_int_distribution<> distrib(0, 100); 

	for (int& val : nums)
	{
		val = distrib(gen);
	}

	std::cout << "Массив заполнен случайными числами от 0 до 100." << std::endl;
	// Выводим сгенерированный массив
	Printer().PrintVector(nums);
}

void VectorHandler::SaveVectorToFile(const std::vector<int>& nums, const std::string& filename)
{
	std::string fileToSave = filename;

	// Проверяем существует ли файл
	if (std::filesystem::exists(fileToSave)) {
		// Запрашиваем у пользователя, что делать, если файл существует
		std::string userChoice;
		std::cout << "Файл \"" << filename << "\" уже существует. Хотите перезаписать? (да/нет): ";
		std::cin >> userChoice;

		// Приводим ввод к нижнему регистру для независимости от регистра
		std::transform(userChoice.begin(), userChoice.end(), userChoice.begin(), ::tolower);

		if (userChoice == "нет") {
			// Если пользователь не хочет перезаписывать, просим ввести новое имя файла
			std::cout << "Введите новое имя файла: ";
			std::cin >> fileToSave;
		}
	}
	if (IsReadOnly(fileToSave)) {
		std::cout << "Ошибка: файл доступен только для чтения!" << std::endl;
		return; // Прерываем сохранение
	}
	std::filesystem::path absolutePath = std::filesystem::absolute(fileToSave);
	// Сохраняем массив в файл
	std::ofstream file(fileToSave);

	if (file.is_open()) {
		for (int num : nums) {
			file << num << " ";  // Сохраняем числа через пробел
		}
		file.close();
		// Выводим информативное сообщение с путём
		std::cout << "Файл успешно сохранён по пути:\n";
		std::cout << absolutePath.string() << "\n";
	}
}
Printer::Printer() : output(cout) {}

Printer::Printer(ostream& out) : output(out) {}

void Printer::PrintVector(vector<int> nums)
{
	for (int i = 0; i < nums.size(); i++)
	{
		output << nums[i];
		if (i != nums.size() - 1) output << ", ";
	}

	output << "\n";
}
