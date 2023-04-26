using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace lab
{
    [ExcludeFromCodeCoverage]
    public static class Output
    {
        public delegate void PrinterLine(string message);
        private static PrinterLine printerLine;
        public delegate void Printer(string message);
        private static Printer printer;
        public static void AddPrinterLine(PrinterLine prnt)
        {
            printerLine += prnt;
        }
        public static void ReducePrinterLine (PrinterLine prnt)
        {
            printerLine -= prnt;
        }
        public static void AddPrinter(Printer prnt)
        {
            printer += prnt;
        }
        public static void ReducePrinter(Printer prnt)
        {
            printer -= prnt;
        }
        /// <summary>
        /// print line with line break
        /// </summary>
        /// <param name="str"></param>
        public static void PrintLine(string str)
        {
            printerLine.Invoke(str);
        }
        /// <summary>
        /// Print Line without line break
        /// </summary>
        /// <param name="str"></param>
        public static void Print(string str)
        {
            printer.Invoke(str);
        }

        /// <summary>
        /// Write the menu of array choosing in the consol 
        /// </summary>
        public static void Menu()
        {
            PrintLine("Choose data type using arrows. Press enter to confirm your choice");
            PrintLine("1 - Doubly linked list");
            PrintLine("2 - Binary Tree");
            PrintLine("3 - ...");
            PrintLine("4 - ...");
            PrintLine("0 - Shut down");
        }

        /// <summary>
        /// Write the menu of choosing filling type
        /// </summary>
        /// <param name="tp">type of menu</param>
        public static void FillTypes(int type = 1)
        {
            if (type == 1)
            {
                PrintLine("Choose how to fill the Collection using arrows. Press enter to confirm your choice");
                PrintLine("1 - Fill with random vehicles");
                PrintLine("2 - Enter vehicles from the keyboard");
            }
            else if (type == 2)
            {
                PrintLine("Choose how to add in the Collection using arrows. Press enter to confirm your choice");
                PrintLine("1 - Add random vehicles");
                PrintLine("2 - Add vehicle from the keyboard");
            }
            
        }
        /// <summary>
        /// Write the menu of command choosing in the consol 
        /// </summary>
        /// <param name="arrType">type of datas</param>
        public static void DataMenu(int type = 1, bool isSorted = false)
        {
            if (type == 1)
            {
                PrintLine("Choose command using arrows. Press enter to confirm your choice");
                PrintLine("1 - Form new collection");
                PrintLine("2 - Print collection");
                PrintLine("3 - Add collection element");
                PrintLine("4 - Сopy collection (demonstration)");
                PrintLine("5 - Delete collection");
                PrintLine("0 - Back");
            }
            else if (type == 2)
            {
                PrintLine("Choose command using arrows. Press enter to confirm your choice");
                PrintLine("1 - Form new collections");
                PrintLine("2 - Print collections");
                if (isSorted)
                {
                    PrintLine("3 - Add search tree value");
                }
                else
                {
                    PrintLine("3 - Add value");
                }
                if (isSorted)
                {
                    PrintLine("4 - Binary search for min element");
                }
                else
                {
                    PrintLine("4 - Search for min element");
                }
                if (isSorted)
                {
                    PrintLine("5 - Perfectly balanced NON-search tree");
                }
                else
                {
                    PrintLine("5 - Perfectly balanced search tree");
                }
                PrintLine("6 - Сopy collection (demonstration)");
                PrintLine("7 - Delete collection");
                PrintLine("0 - Back");
            }
            // ...
        }

        public static void PrintClasses(int i)
        {
            if (i > 0)
            {
                PrintLine($"Choose type of vehicle {i}:");
                PrintLine("1 - Car");
                PrintLine("2 - Train");
                PrintLine("3 - Express");
            }
            else if (i == -1)
            {
                PrintLine($"Choose type of vehicle that need to be found:");
                PrintLine("1 - Car");
                PrintLine("2 - Train");
                PrintLine("3 - Express");
            }
            else
            {
                PrintLine($"Choose type of vehicle:");
                PrintLine("1 - Car");
                PrintLine("2 - Train");
                PrintLine("3 - Express");
            }

        }

        public static void PrintRequests(int type = 1)
        {   
            if (type == 1) // Hashtable
            {
                PrintLine("Choose request");
                PrintLine("1 - Count the number of expresses");
                PrintLine("2 - Count the number of passengers in all trains");
                PrintLine("3 - Print all cars");
            }
            
        }

        public static void PrintSortType()
        {
            PrintLine("Choose sorting type");
            PrintLine("1 - Ascending sort");
            PrintLine("2 - Descending sort");
        }
        public static void PrintSearchType()
        {
            PrintLine("Choose searching type");
            PrintLine("1 - find by hashcode");
            PrintLine("2 - find by value");
        }

        public static void PrintCollectionsType()
        {
            PrintLine("Choose collection type");
            PrintLine("1 - List<Car>");
            PrintLine("2 - List<string>");
            PrintLine("3 - Dictionary<Vehicle,Car>");
            PrintLine("4 - Dictionary<string,Car>");
        }

        public static void PrintElementType()
        {
            PrintLine("Choose elemnt type");
            PrintLine("1 - first");
            PrintLine("2 - middle");
            PrintLine("3 - last");
            PrintLine("4 - non-existent");
        }

        /// <summary>
        /// Print that the data is not initialized
        /// </summary>
        /// <param name="type">type of data</param>
        public static void NotInit(int type=0)
        {
            switch (type)
            {
                case 0:
                    PrintLine("Necessary to form new array before working with him");
                    break;
                case 1:
                    PrintLine("Necessary to enter text before working with him");
                    break;
            }
            
            Input.Cont();
        }
    }
}
