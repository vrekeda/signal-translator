using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Lexer lex = new Lexer("test.txt");
            lex.ReadFromFile();
            Console.ReadLine();
        }
    }
}
