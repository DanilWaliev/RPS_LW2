#pragma once

using namespace std;

#include <iostream>
#include <vector>
#include <iomanip>
#include <fstream>
#include "StringUtils.h"

// ������������ ������� ����
enum class MenuOptions
{
	Exit,
	ManualInput,
	RandomInput,
	TreeSort,
	SaveToFile
};

// ������������ ����
class Menu
{
	// ������ ����� ����, ������� ������ ������������
	MenuOptions userChoice;

public:
	// ������� �� ����� ������ ����
	static void Show(void);

	// ����������� � ������������ ����� ���� � ������������� �������� userChoice
	void InputUserChoice(void);

	// ���������� �������� userChoice
	MenuOptions GetUserChoice(void);
};

// ������ ������� ��� ������ � ������ � ����������
class InputHandler
{
public:
	// �������� ������������� �������� � �������
	// ���������� ������ ������������ �������� �� ��� ���, ���� ������� �� �������� ����������
	// promptMessage - ����������� � ����� 
	// errorMessage - ��������� �� ������ ���������� ����� 
	static int GetInt(
		string promptMessage = "������� ������������� ��������: ",
		string errorMessage = "������������ ����");

	// �������� ���� ����� � �������
	// ���������� ������ ������������ �������� �� ��� ���, ���� ������� �� �������� ����������
	// promptMessage - ����������� � �����
	// errorMessage - ��������� �� ������ ���������� ����� 
	static string GetWord(
		string promptMessage = "������� ������: ",
		string errorMessage = "������������ ����");

	// ���������� � ������������ ��/��� �� ��� ��� ���� �� ������� ���������� �����
	// ��� ������ �� ���������� true, ��� - false
	static bool Prompt(std::string message);
};

// ������ ������� ��� ������ � ���������
class VectorHandler
{
public:
	// ����������� � ������������ ������ �������, �� ��� ��� ���� ���� �� �������� ����������
	static int InputVectorSize(void);

	// ��������� ���������� ������� � ����������
	static void ManualFillVector(vector<int>& nums);

	// ��������� ���������� ������� ���������� �������
	static void RandomFillVector(vector<int>& nums);
	// ��������� ������ � ��������� ����
	static void SaveVectorToFile(const vector<int>& nums, const string& filename);
};

// ��� ������ � ������� �������
class Printer
{
	// ������ ����� ��� ������
	ostream& output;
public:
	// ����������� �� ��������� ������ output = cout;
	Printer();

	// ������ output = out;
	Printer(ostream& out);

	// ��������� ����� ������� � ��������� �����
	void PrintVector(vector<int> nums);
};
