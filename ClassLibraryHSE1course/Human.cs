using lab;
using System.Diagnostics.CodeAnalysis;

namespace ClassLibraryHSE1course
{
    public class Human:IInit, ICloneable
    {
        static Random random = new Random();
        [ExcludeFromCodeCoverage]
        public double Weight { get; set; }
        [ExcludeFromCodeCoverage]
        public double Height { get; set; }
        [ExcludeFromCodeCoverage]
        public Car PersonalCar { get; set; }
        [ExcludeFromCodeCoverage]
        public Human()
        {
            Weight = 0;
            Height = 0;
            PersonalCar= new Car();
        }
        [ExcludeFromCodeCoverage]
        public Human(double w, double h)
        {
            Weight = w;
            Height = h;
            PersonalCar = new Car();
        }
        [ExcludeFromCodeCoverage]
        public Human(double w, double h, Car personalCar)
        {
            Weight = w;
            Height = h;
            PersonalCar = personalCar;
        }
        [ExcludeFromCodeCoverage]
        public void Show(int ln)
        {
            for (int i = 0; i < ln; i++)
            {
                Output.Print(" ");
            }
            Output.PrintLine($"Weight = {Weight}, height = {Height}, Human perosnal car:");
            PersonalCar.Show();
        }
        [ExcludeFromCodeCoverage]
        public void Init()
        {
            Output.Print("Enter human weight: ");
            bool fl;
            double num;
            do
            {
                fl = double.TryParse(Console.ReadLine(), out num);
                if (num < 0) fl = false;
                if (!fl) Output.Print($"Input error! Enter human weight: ");
            } while (!fl);
            Weight = num;

            Output.Print("Enter human height: ");
            do
            {
                fl = double.TryParse(Console.ReadLine(), out num);
                if (num < 0) fl = false;
                if (!fl) Output.Print($"Input error! Enter human weight: ");
            } while (!fl);
            Height = num;
            PersonalCar.Init();
        }

        public void RandomInit(int leftBound, int rightBound)
        {
            if (leftBound < 0)
            {
                leftBound= 0;
            }
            if (rightBound < 0)
            {
                rightBound= 0;
            }
            if (rightBound < leftBound)
            {
                rightBound= leftBound;
            }
            Weight = random.Next(leftBound, rightBound+1);
            Height = random.Next(leftBound, rightBound+1);
            PersonalCar.RandomInit(leftBound,rightBound);
        }

        public Human ShallowCopy()
        {
            return (Human)this.MemberwiseClone();
        }
        public object Clone()
        {
            return new Human(this.Weight, this.Height, (Car) this.PersonalCar.Clone());
        }
    }
}