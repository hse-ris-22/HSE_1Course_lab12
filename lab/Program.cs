using System.Collections;
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

            /*// random linked list with from start showing
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
            list.Show(isFromStart: true);*/


            int collectionNumber;
            int menuNumber;
            int fillType;
            DoublyLinkedList list = new DoublyLinkedList();
            do
            {
                Output.Menu();
                collectionNumber = Input.ReadSwitch(1,5); // 1 - Doubly linked list
                switch (collectionNumber)
                {
                    case 1:
                        do
                        {
                            Output.DataMenu(1);
                            menuNumber = Input.ReadSwitch(1, 6); // 1 - Form new collection, 2 - Print collection, 3 - Add collection element 4 - Сopy collection (demonstration) 5 delete
                            switch (menuNumber)
                            {
                                case 1: // Form new collection
                                    int len = Input.ReadInt("Enter hashtable length", 2);
                                    int min;
                                    int max;
                                    Input.RndNumbRange(out min, out max);
                                    list = new DoublyLinkedList(len, min, max);
                                    PrintLine("Doubly linked list successfully created");
                                    Input.Cont();
                                    break;
                                case 2: // Print
                                    list.Show();
                                    Input.Cont();
                                    break;
                                case 3: // Add element

                                    Input.Cont();
                                    break;
                                case 4: // Сopy collection (demonstration)

                                    Input.Cont();
                                    break;
                                case 5: // delete
                                    list = new DoublyLinkedList();
                                    Input.Cont();
                                    break;
                            }
                        } while (menuNumber != 6);
                        break;
                    case 2:
                        do
                        {
                            Output.DataMenu(2);
                            menuNumber = Input.ReadSwitch(1, 7); // 1 - Form new collection, 2 - Print collection, 3 - Add collection element 4 - Сopy collection (demonstration) 5 delete
                            switch (menuNumber)
                            {
                                case 1: // Form new collection

                                    PrintLine("Hashtable successfully created");
                                    Input.Cont();
                                    break;
                                case 2: // Print

                                    Input.Cont();
                                    break;
                                case 3: // min

                                    Input.Cont();
                                    break;
                                case 4: // transform

                                    Input.Cont();
                                    break;
                                case 5: // Сopy collection (demonstration)
                                    Input.Cont();
                                    break;
                                case 6: // delete
                                    Input.Cont();
                                    break;
                            }
                        } while (menuNumber != 7);
                        break;
                    case 3:
                        do
                        {
                            Output.DataMenu(2);
                            menuNumber = Input.ReadSwitch(1, 6);
                            switch (menuNumber)
                            {
                                case 1: // Form new collection

                                    PrintLine("Hashtable successfully created");
                                    Input.Cont();
                                    break;
                                case 2: // Print

                                    Input.Cont();
                                    break;
                                case 3: // Add element

                                    Input.Cont();
                                    break;
                                case 4: // Сopy collection (demonstration)

                                    Input.Cont();
                                    break;
                                case 5: // delete
                                    Input.Cont();
                                    break;
                            }
                        } while (menuNumber != 6);
                        break;
                    case 4:
                        do
                        {
                            Output.DataMenu(2);
                            menuNumber = Input.ReadSwitch(1, 6);
                            switch (menuNumber)
                            {
                                case 1: // Form new collection

                                    PrintLine("Hashtable successfully created");
                                    Input.Cont();
                                    break;
                                case 2: // Print

                                    Input.Cont();
                                    break;
                                case 3: // Add element

                                    Input.Cont();
                                    break;
                                case 4: // DСopy collection (demonstration)

                                    Input.Cont();
                                    break;
                                case 5: // delete
                                    Input.Cont();
                                    break;
                            }
                        } while (menuNumber != 6);
                        break;
                }
            } while (collectionNumber != 5);
        }
    }
}