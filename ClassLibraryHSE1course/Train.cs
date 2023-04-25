using lab;
using System.Diagnostics.CodeAnalysis;

namespace ClassLibraryHSE1course
{
    public class Train:Vehicle,ICloneable
    {
        // Fields
        protected int[] wagons = new int[0]; // Number of passengers in each wagon
        // Properties
        [ExcludeFromCodeCoverage]
        public int[] Wagons { get; set; }

        // Constructors
        [ExcludeFromCodeCoverage]
        public Train() : base()
        {
            Wagons = new int[0];
        }
        [ExcludeFromCodeCoverage]
        public Train(double mass) : base(mass)
        {
            Wagons = new int[0];
        }
        [ExcludeFromCodeCoverage]
        public Train(double mass, double maxSpeed) : base(mass, maxSpeed)
        {
            Wagons = new int[0];
        }
        [ExcludeFromCodeCoverage]
        public Train(double mass, double maxSpeed, int power) : base(mass, maxSpeed, power)
        {
            Wagons = new int[0];
        }
        [ExcludeFromCodeCoverage]
        public Train(double mass, double maxSpeed, int power, int passengerCapacity) : base(mass, maxSpeed, power, passengerCapacity)
        {
            Wagons = new int[0];
        }
        [ExcludeFromCodeCoverage]
        public Train(double mass, double maxSpeed, int power, int passengerCapacity, int[] wagons) : base(mass, maxSpeed, power, passengerCapacity)
        {
            Wagons = wagons;
        }

        // Methods
        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                if (obj is Train temp)
                {
                    if (this.Mass == temp.Mass && this.MaxSpeed == temp.MaxSpeed && this.Power == temp.Power && this.PassengerCapacity == temp.PassengerCapacity && this.Wagons.Length == temp.Wagons.Length)
                    {
                        if (this.Wagons.Length == 0)
                        {
                            return true;
                        }
                        else
                        {
                            bool flag = true;
                            for (int i = 0; i < this.Wagons.Length; i++)
                            {
                                if (this.Wagons[i] != temp.Wagons[i])
                                {
                                    flag = false;
                                }
                            }
                            return flag;
                        }
                    }
                }
            }
            return false;
        }

        //Methods (virtual)
        [ExcludeFromCodeCoverage]
        public override void Show(int ln = 0)
        {
            base.Show(ln);
            Output.PrintLine($", number of wagons = {Wagons.Length}");
            for (int i = 0; i < ln; i++)
            {
                Output.Print(" ");
            }
            if (Wagons.Length > 0)
            {
                
                Output.Print("Wagons passengers: ");
                foreach (int i in Wagons)
                {
                    Output.Print($"{i} ");
                }
                Output.PrintLine("");
            }
            else
            {
                Output.PrintLine("No Wagons");
            }
        }

        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            base.Init();
            
            int numi = Input.ReadInt("Enter vehicle number of wagons", 2);
            Wagons = new int[numi];

            bool fl;
            Output.PrintLine("Enter number of passengers in each wagon (integer number): ");
            for (int i = 0; i < Wagons.Length; i++)
            {
                int num;
                Output.Print($"{i+1}) ");
                do
                {
                    fl = int.TryParse(Console.ReadLine(), out num);
                    if (numi < 0) fl = false;
                    if (!fl)
                    {
                        Output.PrintLine("Error! repeat the wagon enter");
                        Output.Print($"{i+1}) ");
                    }
                } while (!fl);
                Wagons[i] = num;
            }
        }
        public virtual void RandomInit(int leftBound, int rightBound)
        {
            base.RandomInit(leftBound, rightBound);
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
            Wagons = new int[random.Next(0, 10)];
            for (int i = 0; i < Wagons.Length; i++)
            {
                Wagons[i] = random.Next(leftBound, rightBound+1);
            }
        }

        public override Train ShallowCopy()
        {
            return (Train)this.MemberwiseClone();
        }
        public override object Clone()
        {
            return new Train(this.Mass, this.MaxSpeed, this.Power, this.PassengerCapacity, this.Wagons);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode()+Wagons.Length.GetHashCode();
        }
    }
}
