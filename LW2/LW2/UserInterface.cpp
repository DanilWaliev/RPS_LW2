using namespace std;

#include "FileUtils.h"
#include "UserInterface.h"
#include <random>
#include <filesystem>
#include <algorithm> // ��� transform
#include <string> // ��� string

void Menu::Show(void)
{
	cout << " ����:" << endl
		<< " 1 - ��������� ������ �������" << endl
		<< " 2 - ��������� ������ ���������� �������" << endl
		<< " 3 - ������������� ������ �������" << endl
		<< " 4 - ��������� ������ � ����" << endl  
		<< " 0 - ����� �� ���������" << endl
		<< endl;
}

void Menu::InputUserChoice(void)
{
	int input{};
	while (true)
	{
		input = InputHandler::GetInt("������� ����� ����: ");
		if (input >= 0 && input <= 4)
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

		if (input == "��" || input == "�") return true;
		if (input == "���" || input == "�") return false;

		std::cout << "������������ ����" << std::endl;
	}
}

int VectorHandler::InputVectorSize(void)
{
	int input{};
	int maxSize = 15;

	while (true)
	{
		input = InputHandler::GetInt("������� ����� �������: ");
		if (input > 0 && input <= maxSize) return input;
		cout << "������������ ����� �������!" << endl;
	}
}

void VectorHandler::ManualFillVector(vector<int>& nums)
{
	string promptMessage;
	for (int i = 0; i < nums.size(); i++)
	{
		promptMessage = "������� " + to_string(i + 1) + " ������� �������: ";
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

	std::cout << "������ �������� ���������� ������� �� 0 �� 100." << std::endl;
	// ������� ��������������� ������
	Printer().PrintVector(nums);
}

void VectorHandler::SaveVectorToFile(const std::vector<int>& nums, const std::string& filename)
{
	std::string fileToSave = filename;

	// ��������� ���������� �� ����
	if (std::filesystem::exists(fileToSave)) {
		// ����������� � ������������, ��� ������, ���� ���� ����������
		std::string userChoice;
		std::cout << "���� \"" << filename << "\" ��� ����������. ������ ������������? (��/���): ";
		std::cin >> userChoice;

		// �������� ���� � ������� �������� ��� ������������� �� ��������
		std::transform(userChoice.begin(), userChoice.end(), userChoice.begin(), ::tolower);

		if (userChoice == "���") {
			// ���� ������������ �� ����� ��������������, ������ ������ ����� ��� �����
			std::cout << "������� ����� ��� �����: ";
			std::cin >> fileToSave;
		}
	}
	if (IsReadOnly(fileToSave)) {
		std::cout << "������: ���� �������� ������ ��� ������!" << std::endl;
		return; // ��������� ����������
	}
	std::filesystem::path absolutePath = std::filesystem::absolute(fileToSave);
	// ��������� ������ � ����
	std::ofstream file(fileToSave);

	if (file.is_open()) {
		for (int num : nums) {
			file << num << " ";  // ��������� ����� ����� ������
		}
		file.close();
		// ������� ������������� ��������� � ����
		std::cout << "���� ������� ������� �� ����:\n";
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
