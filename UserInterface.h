#pragma once

using namespace std;

#include <iostream>
#include <vector>
#include <iomanip>
#include <fstream>
#include "StringUtils.h"

// Перечисление пунктов меню
enum class MenuOptions
{
	Exit,
	RandomInput,
	ManualInput
};

// Представляет меню
class Menu
{
	// Хранит пункт меню, который выбрал пользователь
	MenuOptions userChoice;

public:
	// Выводит на экран пункты меню
	static void Show(void);

	// Запрашивает у пользователя пункт меню и устанавливает значение userChoice
	void SetUserChoice(void);

	// Возвращает значение userChoice
	MenuOptions GetUserChoice(void);
};

// Хранит функции для работы с вводом с клавиатуры
class InputHandler
{
public:
	// получает целочисленное значение с консоли
	// предлагает ввести пользователю значение до тех пор, пока значени не окажется корректным
	// promptMessage - приглашение к вводу 
	// errorMessage - сообщение об ошибке считывания числа 
	static int GetInt(
		string promptMessage = "Введите целочисленное значение: ",
		string errorMessage = "Некорректный ввод");

	// получает одно слово с консоли
	// предлагает ввести пользователю значение до тех пор, пока значени не окажется корректным
	// promptMessage - приглашение к вводу
	// errorMessage - сообщение об ошибке считывания числа 
	static string GetWord(
		string promptMessage = "Введите строку: ",
		string errorMessage = "Некорректный ввод");

	// спрашивает у пользователя да/нет до тех пор пока не получит корректный ответ
	// при ответе да возвращает true, нет - false
	static bool Prompt(std::string message);
};

// Хранит функции для работы с векторами
class VectorHandler
{
public:
	// Запрашивает у пользователя размер вектора, до тех пор пока ввод не окажется корректным
	static int GetVectorSize(void);

	// Реализует заполнение вектора с клавиатуры
	static void ManualFillVector(vector<int>& nums);

	// Реализует заполнение вектора случайными числами
	static void RandomFillVector(vector<int>& nums);
};

// Для работы с выводом вектора
class Printer
{
	// Хранит поток для вывода
	ostream& output;
public:
	// Конструктор по умолчанию задает output = cout;
	Printer();

	// Задает output = out;
	Printer(ostream& out);

	// Реализует вывод вектора в указанный поток
	void PrintVector(vector<int> nums);
};