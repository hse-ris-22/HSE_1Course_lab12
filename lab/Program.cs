using System.Diagnostics.CodeAnalysis;
using ClassLibraryHSE1course;

namespace lab
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        public static void PrintLine(string str = "")
        {
            // Если убрать комментарий снизу, то изменяться вывод с переносом строки во всей программе
            //Random rnd = new Random();
            //ConsoleColor[] consoleColors = (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor));
            //Console.ForegroundColor = consoleColors[rnd.Next(0,consoleColors.Length)];
            Console.WriteLine(str);

            //Console.ResetColor();
        }
        public static void Print(string str = "")
        {
            // Если убрать комментарий снизу, то изменяться вывод без переноса строки во всей программе
            //Random rnd = new Random();
            //ConsoleColor[] consoleColors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            //Console.ForegroundColor = consoleColors[rnd.Next(0, consoleColors.Length)];
            Console.Write(str);
            //Console.ResetColor();
        }
        static void Main(string[] args)
        {
            Output.AddPrinterLine(PrintLine);
            Output.AddPrinter(Print);

            DoublyLinkedList list = new DoublyLinkedList(1,10,5);
            list.Show(isFromStart:true);
        }
    }
}