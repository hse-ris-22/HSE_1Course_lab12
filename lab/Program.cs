using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
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

        private static Vehicle RandomVehicle(int min, int max)
        {
            Vehicle vehicle = new Vehicle();
            Random rnd = new Random();
            int vehicleType = rnd.Next(1, 4);
            switch (vehicleType)
            {
                case 1: // car
                    Car car = new Car();
                    car.RandomInit(min, max);
                    vehicle = car;
                    break;
                case 2: // train
                    Train train = new Train();
                    train.RandomInit(min, max);
                    vehicle = train;
                    break;
                case 3: // express
                    Express express = new Express();
                    express.RandomInit(min, max);
                    vehicle = express;
                    break;
            }
            return vehicle;
        }

        static void Main(string[] args)
        {
            Output.AddPrinterLine(PrintLine);
            Output.AddPrinter(Print);
            DoublyLinkedList<Vehicle> list = new DoublyLinkedList<Vehicle>();
            DoublyLinkedList<Vehicle>.randomT = RandomVehicle;
            //list.AssignRandomT(RandomVehicle);

            /*// random linked list with from start showing
            list = new DoublyLinkedList<Vehicle>(10,1,5);
            list.Show(isFromStart: true);
            Input.Cont();
            Console.Clear();
            // random linked list with from end showing
            list.Show(isFromStart: false);
            Input.Cont();
            Console.Clear();

            // adding to empty linked list
            list = new DoublyLinkedList<Vehicle>();
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
                                    list = new DoublyLinkedList<Vehicle>(len, min, max);
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
                                    list = new DoublyLinkedList<Vehicle>();
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