
namespace AdvancedCsharp.DesignPatterns
{
    using System;
    using Factory;
    using Observer;
    using Singleton;

    class Program
    {
        static void Main(string[] args)
        {
            SetupConsoleWindow();

            new ObserverAssignement().Run();
        }


        static public void SetupConsoleWindow()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WindowWidth = 60;
            Console.WindowHeight = 30;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }

    }
}
