
#include <iostream>
#include <string>
#include <Windows.h>

using namespace std;

static  int MaxId = 1;
int MaxSize = 3;
string* ST[3];
class Stack
{
	string StackId;
	char buffer[65];
	string* ST[3];
	int top;
public: Stack()
{
	top = 0;
	for (int i = 0; i < MaxSize; i++)
	{
		ST[i] = new string;
	}
	//		StackId = std::to_string(MaxId);
	_itoa_s(MaxId, buffer, 65, 10); //(MaxId, NULL, 10);
	MaxId++;
	StackId = buffer;
	cout << "Создан стек " << StackId + "!" << endl;
}
public: void push(string c)
{
	if (top < MaxSize)
		*ST[top++] = c;
	else printf("Стек переполнен!");
}
public: string pop()
{
	if (top > 0)
		return *ST[--top];
	else
	{
		printf("Стек пуст!");
		return "";
	}
}

};

int main()//int _tmain(int argc, _TCHAR* argv[])
{
	SetConsoleCP(1251);// установка кодовой страницы win-cp 1251 в поток ввода
	SetConsoleOutputCP(1251);
	string r;
	Stack* stack;
	cout << "Создать стек?" << endl;

	cin >> r;
	if (r == "да")
		stack = new Stack();
	else return 0;


	string s;
	do
	{
		cout << "Что сделать?" << endl;
		cin >> s;
		if (s == "заложить")
		{
			cout << "Что?" << endl;
			cin >> r;
			stack->push(r);
		};
		if (s == "достать")
		{
			cout << stack->pop() << endl;
		};
	} while (s != "Х");
}