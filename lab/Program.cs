using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using ClassLibraryHSE1course;

namespace lab
{
    
    internal class Program
    {
        [ExcludeFromCodeCoverage]
        public static void PrintLine(string str = "")
        {
            //Random rnd = new Random();
            //ConsoleColor[] consoleColors = (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor));
            //Console.ForegroundColor = consoleColors[rnd.Next(0,consoleColors.Length)];
            Console.WriteLine(str);

            //Console.ResetColor();
        }
        [ExcludeFromCodeCoverage]
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

        private static Vehicle KeyboardVehicle(int i)
        {
            Vehicle vehicle = new Vehicle();
            Console.Clear();
            Output.PrintClasses(i);
            int vehicleType = Input.ReadSwitch(1, 3);
            switch (vehicleType)
            {
                case 1: // car
                    Car car = new Car();
                    car.Init();
                    vehicle = car;
                    break;
                case 2: // train
                    Train train = new Train();
                    train.Init();
                    vehicle = train;
                    break;
                case 3: // express
                    Express express = new Express();
                    express.Init();
                    vehicle = express;
                    break;
            }
            return vehicle;
        }

        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            Output.AddPrinterLine(PrintLine);
            Output.AddPrinter(Print);
            DoublyLinkedList<Vehicle> list = new DoublyLinkedList<Vehicle>();
            DoublyLinkedList<Vehicle>.randomT = RandomVehicle;
            DoublyLinkedList<Vehicle>.keyboardT = KeyboardVehicle;
            BinaryTree<Vehicle> tree = new BinaryTree<Vehicle>();
            BinaryTree<Vehicle>.randomT = RandomVehicle;
            BinaryTree<Vehicle>.keyboardT = KeyboardVehicle;

            int collectionNumber;
            int menuNumber;
            int fillType;
            int min;
            int max;
            bool isCreated1 = false;
            bool isCreated2 = false;
            bool isSorted2 = false;
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
                                    int len;
                                    do
                                    {
                                        len = Input.ReadInt("Enter list length", 2);
                                    } while (Input.Warning(len, 1000));
                                    if (len != 0)
                                    {
                                        Console.Clear();
                                        Output.FillTypes();
                                        fillType = Input.ReadSwitch(1, 2);
                                        switch (fillType)
                                        {
                                            case 1: // Random
                                                Input.RndNumbRange(out min, out max);
                                                list = new DoublyLinkedList<Vehicle>(len, min, max);
                                                break;
                                            case 2: // Keyboard
                                                list = new DoublyLinkedList<Vehicle>(len);
                                                break;
                                        }
                                        
                                    }
                                    else
                                    {
                                        list = new DoublyLinkedList<Vehicle>();
                                    }
                                    Console.Clear();
                                    PrintLine("Doubly linked list successfully created");
                                    Input.Cont();
                                    isCreated1 = true;
                                    break;
                                case 2: // Print
                                    if (isCreated1)
                                    {
                                        list.Show();
                                    }
                                    else
                                    {
                                        PrintLine("Necessary to form new collection before printing");
                                    }
                                    Input.Cont();
                                    break;
                                case 3: // Add element
                                    if (isCreated1)
                                    {
                                        int pos = Input.ReadInt("Enter the position where the random vehicle will be added", 1);
                                        Console.Clear();
                                        Output.FillTypes(2);
                                        fillType = Input.ReadSwitch(1, 2);
                                        switch (fillType)
                                        {
                                            case 1: // Random
                                                Input.RndNumbRange(out min, out max);
                                                Console.Clear();
                                                list.AddByNumber(pos-1, RandomVehicle(min, max));
                                                break;
                                            case 2: // Keyboard
                                                list.AddByNumber(pos-1, KeyboardVehicle(0));
                                                break;
                                        }
                                        
                                        Console.Clear();
                                        PrintLine("Successfully added in Doubly linked list");
                                    }
                                    else
                                    {
                                        PrintLine("Necessary to form new collection before adding");
                                    }
                                    Input.Cont();
                                    break;
                                case 4: // Сopy collection (demonstration)
                                    // Create original list
                                    DoublyLinkedList<IInit> testList = new DoublyLinkedList<IInit>();
                                    PrintLine("Empty original list:");
                                    testList.Show();
                                    PrintLine();

                                    DoublyLinkedList<IInit> listEmptyCopy = (DoublyLinkedList<IInit>)testList.Clone();
                                    PrintLine("Empty copy list:");
                                    listEmptyCopy.Show();
                                    PrintLine();

                                    listEmptyCopy.AddByNumber(1, RandomVehicle(3, 3));
                                    PrintLine("Modified Empty copy:");
                                    listEmptyCopy.Show();
                                    PrintLine();

                                    PrintLine("Empty original list:");
                                    testList.Show();
                                    PrintLine();
                                    PrintLine();
                                    PrintLine();

                                    // Initialization
                                    Human testHuman = new Human();
                                    testHuman.RandomInit(100, 100);
                                    Car TestCar = new Car();
                                    TestCar.RandomInit(100, 100);

                                    testList.AddByNumber(1, testHuman);
                                    testList.AddByNumber(2, TestCar);

                                    PrintLine("Original List"); // Print original hashtable
                                    testList.Show();

                                    DoublyLinkedList<IInit> shallowCopy = (DoublyLinkedList<IInit>)testList.ShallowCopy(); // Shallow copy
                                    DoublyLinkedList<IInit> deepCopy = (DoublyLinkedList<IInit>)testList.Clone(); // Shallow copy

                                    testHuman.RandomInit(1, 1);
                                    TestCar.RandomInit(1, 1);

                                    PrintLine("New original List:");
                                    testList.Show();
                                    PrintLine();

                                    PrintLine("Shallow copy:");
                                    shallowCopy.Show();
                                    PrintLine();

                                    shallowCopy.AddByNumber(3, RandomVehicle(3, 3));
                                    PrintLine("Modified shallow copy:");
                                    shallowCopy.Show();
                                    PrintLine();

                                    PrintLine("Deep copy:");
                                    deepCopy.Show();
                                    PrintLine();

                                    deepCopy.AddByNumber(3, RandomVehicle(3, 3));
                                    PrintLine("Modified deep copy:");
                                    deepCopy.Show();
                                    PrintLine();

                                    PrintLine("New original List:");
                                    testList.Show();
                                    PrintLine();
                                    Input.Cont();
                                    break;
                                case 5: // delete
                                    if (isCreated1)
                                    {
                                        list = new DoublyLinkedList<Vehicle>();
                                        PrintLine("Doubly linked list successfully deleted");
                                        isCreated1 = false;
                                    }
                                    else
                                    {
                                        PrintLine("Necessary to form new collection before deleting");
                                    }
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
                                    int len;
                                    do
                                    {
                                        len = Input.ReadInt("Enter tree length", 2);
                                    } while (Input.Warning(len, 100));
                                    if (len != 0)
                                    {
                                        Console.Clear();
                                        Output.FillTypes();
                                        fillType = Input.ReadSwitch(1, 2);
                                        switch (fillType)
                                        {
                                            case 1: // Random
                                                Input.RndNumbRange(out min, out max);
                                                tree = new BinaryTree<Vehicle>(len, min, max);
                                                break;
                                            case 2: // Keyboard
                                                tree = new BinaryTree<Vehicle>(len);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        tree = new BinaryTree<Vehicle>();
                                    }
                                    Console.Clear();
                                    PrintLine("Binary tree successfully created");
                                    Input.Cont();
                                    isCreated2 = true;
                                    isSorted2 = false;
                                    break;
                                case 2: // Print
                                    if (isCreated2)
                                    {
                                        tree.Show();
                                    }
                                    else
                                    {
                                        PrintLine("Necessary to form new collection before printing");
                                    }
                                    Input.Cont();
                                    break;
                                case 3: // min
                                    if (isCreated2)
                                    {
                                        if (tree.Length != 0)
                                        {
                                            PrintLine("Minimum tree value: ");

                                            Vehicle mn = tree.MinElement(isSorted2);
                                            if (mn != null)
                                            {
                                                mn.Show();
                                            }
                                            else
                                            {
                                                PrintLine("Empty element");
                                            }
                                        }
                                        else
                                        {
                                            PrintLine("Empty tree");
                                        }
                                    }
                                    else
                                    {
                                        PrintLine("Necessary to form new collection before searching");
                                    }
                                    Input.Cont();
                                    break;
                                case 4: // transform
                                    if (isCreated2)
                                    {
                                        if (tree.Length != 0)
                                        {
                                            tree.FormSearch();
                                            isSorted2 = true;
                                            PrintLine("Perfectly balanced search tree successfully created");
                                        }
                                        else
                                        {
                                            PrintLine("Impossible to transform empty tree");
                                        }
                                            
                                    }
                                    else
                                    {
                                        PrintLine("Necessary to form new collection before transforming");
                                    }

                                    Input.Cont();
                                    break;
                                case 5: // Сopy collection (demonstration)
                                    Input.Cont();
                                    break;
                                case 6: // delete
                                    if (isCreated2)
                                    {
                                        tree = new BinaryTree<Vehicle>();
                                        PrintLine("Binary tree successfully deleted");
                                        isCreated2 = false;
                                        isSorted2 = false;
                                    }
                                    else
                                    {
                                        PrintLine("Necessary to form new collection before deleting");
                                    }
                                    Input.Cont();
                                    break;
                            }
                        } while (menuNumber != 7);
                        break;
                    case 3:
                        break;
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
                        break;
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