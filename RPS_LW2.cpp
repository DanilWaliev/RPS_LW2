using namespace std;

#include <iostream>
#include <Windows.h>
#include "UserInterface.h"
#include "Sort.h"

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	// объект меню для работы с ним
	Menu menu;
	// вектор, в котором будем хранить числа
	vector<int> nums;
	
	while (true)
	{
		// Вывод меню на экран
		menu.Show();
		// Получаем пункт меню, который выбрал пользователь
		menu.InputUserChoice();

		switch (menu.GetUserChoice())
		{
		case MenuOptions::ManualInput:
			// Задаем размер вектора
			nums.resize(VectorHandler::InputVectorSize());
			// Ввод каждого элмента с клавиатуры
			VectorHandler::ManualFillVector(nums);
			break;
		case MenuOptions::RandomInput:
			// Задаем размер вектора
			nums.resize(VectorHandler::InputVectorSize());
			// Заполнение вектора случайными числами
			VectorHandler::RandomFillVector(nums);
			break;
		case MenuOptions::TreeSort:
			TreeSortUtils::Sort(nums);
			Printer().PrintVector(nums);
			break;
		case MenuOptions::SaveToFile:
			// Сохраняем массив в файл
			{
			std::string filename = InputHandler::GetWord("Введите имя файла для сохранения: ");
			VectorHandler::SaveVectorToFile(nums, filename);
			}
			break;

		case MenuOptions::Exit:
			// Завершение работы программы
			return EXIT_SUCCESS;
		default:
			cout << "Такого пункта в меню нет!" << endl;
		}
	}
}

