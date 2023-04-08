using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ClassLibraryHSE1course;

namespace lab
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        public static void PrintLine(string str = "")
        {
            //Random rnd = new Random();
            //ConsoleColor[] consoleColors = (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor));
            //Console.ForegroundColor = consoleColors[rnd.Next(0,consoleColors.Length)];
            Console.WriteLine(str);

            //Console.ResetColor();
        }
        public static void Print(string str = "")
        {
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

            // random linked list with from start showing
            DoublyLinkedList list = new DoublyLinkedList(10,1,5);
            list.Show(isFromStart: true);
            Input.Cont();
            Console.Clear();
            // random linked list with from end showing
            list.Show(isFromStart: false);
            Input.Cont();
            Console.Clear();

            // adding to empty linked list
            list = new DoublyLinkedList();
            list.Show(isFromStart:true);
            list.AddRandomByNumber(123,1,1);
            list.Show(isFromStart: true);
            list.AddRandomByNumber(0, 2, 2);
            list.Show(isFromStart: true);
            list.AddRandomByNumber(123, 3, 3);
            list.Show(isFromStart: true);
            list.AddRandomByNumber(2, 4, 4);
            list.Show(isFromStart: true);
            list.AddRandomByNumber(1, 5, 5);
            list.Show(isFromStart: true);
            list.AddRandomByNumber(4, 6, 10);
            list.Show(isFromStart: true);



        }
    }
}