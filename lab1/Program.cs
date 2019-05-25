using System;
using System.Windows.Forms;

namespace SignalTranslator
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Lexer lexer = new Lexer("test.txt");
        //    lexer.ReadFile();
        //    Console.ReadLine();
        //}
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
