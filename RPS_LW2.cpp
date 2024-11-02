using namespace std;

#include <iostream>
#include "UserInterface.h"

int main()
{
	// объект меню для работы с ним
	Menu menu;
	// вектор, в котором будем хранить числа
	vector<int> nums;
	
	while (true)
	{
		// Вывод меню на экран
		menu.Show();
		// Получаем пункт меню, который выбрал пользователь
		menu.SetUserChoice();

		switch (menu.GetUserChoice())
		{
		case MenuOptions::ManualInput:
			// Задаем размер вектора
			nums.resize(VectorHandler::GetVectorSize());
			// Ввод каждого элмента с клавиатуры
			VectorHandler::ManualFillVector(nums);
			break;
		case MenuOptions::RandomInput:
			nums.resize(VectorHandler::GetVectorSize());
			VectorHandler::RandomFillVector(nums);

			break;
		case MenuOptions::Exit:
			return EXIT_SUCCESS;
		default:
			cout << "Такого пункта в меню нет!" << endl;
		}
	}
}

