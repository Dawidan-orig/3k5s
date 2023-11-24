#pragma once
#include <string>
#include <iostream>

using namespace std;

namespace Arbeit {
    class Example
    {
    private: string name;
    private: static bool isAlive;

    public: static void MakeAlive()
    {
        isAlive = true;
    }

    public: Example(string name);
    public:~Example();

    public: static void Print_Unhinged();
    public: void Print_Objected();
    };
}