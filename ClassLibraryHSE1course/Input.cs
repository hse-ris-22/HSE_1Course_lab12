using System.Diagnostics.CodeAnalysis;

namespace lab
{
    [ExcludeFromCodeCoverage]
    public static class Input
    {
        /// <summary>
        /// Request to continue the program
        /// </summary>
        public static void Cont()
        {
            Output.PrintLine("press Enter to continue...");
            Console.TreatControlCAsInput = true;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            }
            while (key.Key != ConsoleKey.Enter);
            Console.TreatControlCAsInput = false;
            Console.Clear();
        }

        /// <summary>
        /// Enter an information by keyboard
        /// </summary>
        /// <param name="min">how much rows before firstcommand</param>
        /// <param name="max"> Number of the last row</param>
        /// <returns> Number choosen by a user</returns>
        public static int ReadSwitch(int min, int max)
        {
            Console.TreatControlCAsInput = true;
            ConsoleKeyInfo key;
            int com = min;
            int type = -1;
            do
            {
                Console.SetCursorPosition(0, com);
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (com != min) com--;
                        break;
                    case ConsoleKey.W:
                        if (com != min) com--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (com != max) com++;
                        break;
                    case ConsoleKey.S:
                        if (com != max) com++;
                        break;
                    case ConsoleKey.Enter:
                        type = com;
                        break;
                }
            } while (type == -1);
            Console.TreatControlCAsInput = false;
            Console.Clear();
            return type;
        }

        /// <summary>
        /// Number enter by the user
        /// incorrect enter causes an error message and repeated enter
        /// </summary>
        /// <param name="tx">input message</param>
        /// <param name="type">filtr type
        /// 0 - any numbers
        /// 1 - (>0)
        /// 2 - (>=0)</param>
        /// <returns>Number entered by the user</returns>
        public static int ReadInt(string tx, int type = 0)
        {
            Output.Print($"{tx}(");
            if (type == 1) Output.Print("positive ");
            if (type == 2) Output.Print("non-negative ");
            Output.Print("integer number): ");
            bool fl;
            int num;
            do
            {
                fl = int.TryParse(Console.ReadLine(), out num);
                if (type == 1 && num <= 0 || type == 2 && num < 0) fl = false;
                if (!fl) Output.Print($"Input error! {tx} again: ");
            } while (!fl);
            return num;
        }

        /// <summary>
        /// Number enter by the user
        /// incorrect enter causes an error message and repeated enter
        /// </summary>
        /// <param name="tx">input message</param>
        /// <param name="type">filtr type
        /// 0 - any numbers
        /// 1 - (>0)
        /// 2 - (>=0)</param>
        /// <returns>Number entered by the user</returns>
        public static double ReadDouble(string tx, int type = 0)
        {
            Output.Print($"{tx}: ");
            bool fl;
            double num;
            do
            {
                fl = double.TryParse(Console.ReadLine(), out num);
                if (type == 1 && num <= 0 || type == 2 && num < 0) fl = false;
                if (!fl) Output.Print($"Input error! {tx} again: ");
            } while (!fl);
            return num;
        }

        /// <summary>
        /// Random Number's range enter by the user
        /// incorrect enter causes an error message and repeated enter
        /// </summary>
        /// <param name="min">minimal random number</param>
        /// <param name="max">maximal random number</param>
        public static void RndNumbRange(out int min, out int max, int typeMes = 1)
        {
            bool fl;
            max = 0;
            do
            {
                fl = true;
                if (typeMes == 2)
                {
                    min = ReadInt("Enter the minimum length of array(>=0)");
                    if (min < 0)
                    {
                        Output.PrintLine("Error! the length cannot be negative number. Repeat enter");
                        fl = false;
                    }
                    else
                    {
                        max = ReadInt("Enter the maximum length of array");
                    }
                }
                else
                {
                    min = ReadInt("Enter the minimum value of array class elements");
                    max = ReadInt("Enter the maximum value of array class elements");
                }
                if (max<min)
                {
                    if (typeMes == 2)
                    {
                        Output.PrintLine("Error! the maximum length cannot be less than the minimum. Repeat enter");
                    }
                    else
                    {
                        Output.PrintLine("Error! the maximum value cannot be less than the minimum. Repeat enter");
                    }
                    fl = false;
                }
            } while (!fl);
            Console.Clear();
        }

        /// <summary>
        /// read number and filter it from minimum to maximum value
        /// </summary>
        /// <param name="min">minimal filtr value</param>
        /// <param name="max">maximum filtr value</param>
        /// <param name="message">output message before input</param>
        /// <returns>filtered number entered by user</returns>
        public static int ReadFromTo(int min, int max, string message = "number")
        {
            bool fl;
            int k;
            Output.Print($"Enter a {message}(integer number from {min} to {max}): ");
            do
            {
                fl = int.TryParse(Console.ReadLine(), out k);
                if (k<min || k>max) fl = false;
                if (!fl) Output.Print($"Input error! Enter a {message} again: ");
            } while (!fl);
            return k;
        }

        /// <summary>
        /// warning message if len > lenMax
        /// user need to confirm the action
        /// </summary>
        /// <param name="len">length of object</param>
        /// <param name="lenMax">maximal length</param>
        /// <returns>true if user don't confirm the action
        /// false if user confirmed the action
        /// </returns>
        public static bool Warning(int len, int lenMax)
        {
            if (len > lenMax)
            {
                Console.Clear();
                Output.PrintLine("This action may cause the program to slow down, terminate prematurely or it can be just unpleasant for you.");
                Output.PrintLine("Are you sure you want to interact with large collection?");
                Output.PrintLine("1 - Yes");
                Output.PrintLine("2 - No");
                int temp = ReadSwitch(2, 3);
                if (temp == 2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
