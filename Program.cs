using System;
using System.Collections;
using System.Collections.Generic;

/*
ID  NAME
1   Gustavo
2   Petao
3   Kokoska
4   Batak
5   Kofica
6   Sombrero
 */

namespace Test
{
    class Symbol
    { 
        private int ID;
        private string? Name;

        Symbol(int id, string name) 
        {
            ID = id; Name = name;
        }

        public int id() { return ID; }
        public string? name() { return Name; }
    }
    class Reel 
    {
        public const int GUSTAVO = 0, ; 
        private int len;
        private Symbol[]? symbols;

        Reel(int num) {
            if (num == 1) {
                symbols = new Symbol[22];
                foreach (string line in System.IO.File.ReadLines(@"c:\test.txt"))
                {
                    
                }
            }
            
        }
    }
    class Simulation
    {
        public static void Run() { 
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000; i++)
                Simulation.Run();

        }
    }
}