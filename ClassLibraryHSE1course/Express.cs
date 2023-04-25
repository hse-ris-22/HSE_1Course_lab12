using lab;
using System.Diagnostics.CodeAnalysis;

namespace ClassLibraryHSE1course
{
    public class Express:Train
    {
        // Fields
        protected string name = "Nameless";
        // Properties
        [ExcludeFromCodeCoverage]
        public string Name { get; set; }

        // Constructors
        [ExcludeFromCodeCoverage]
        public Express() : base()
        {
            Name = "Nameless";
        }
        [ExcludeFromCodeCoverage]
        public Express(double mass) : base(mass)
        {
            Name = "Nameless";
        }
        [ExcludeFromCodeCoverage]
        public Express(double mass, double maxSpeed) : base(mass, maxSpeed)
        {
            Name = "Nameless";
        }
        [ExcludeFromCodeCoverage]
        public Express(double mass, double maxSpeed, int power) : base(mass, maxSpeed, power)
        {
            Name = "Nameless";
        }
        [ExcludeFromCodeCoverage]
        public Express(double mass, double maxSpeed, int power, int passengerCapacity) : base(mass, maxSpeed, power, passengerCapacity)
        {
            Name = "Nameless";
        }
        [ExcludeFromCodeCoverage]
        public Express(double mass, double maxSpeed, int power, int passengerCapacity, int[] wagons) : base(mass, maxSpeed, power, passengerCapacity, wagons)
        {
            Name = "Nameless";
        }
        [ExcludeFromCodeCoverage]
        public Express(double mass, double maxSpeed, int power, int passengerCapacity, int[] wagons, string name) : base(mass, maxSpeed, power, passengerCapacity, wagons)
        {
            Name = name;
        }

        // Methods
        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                if (obj is Express temp)
                {
                    if (this.Mass == temp.Mass && this.MaxSpeed == temp.MaxSpeed && this.Power == temp.Power && this.PassengerCapacity == temp.PassengerCapacity && this.Wagons.Length == temp.Wagons.Length && this.Name == temp.Name)
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

        // Methods (virtual)
        [ExcludeFromCodeCoverage]
        public override void Show(int ln)
        {
            
            for (int i = 0; i < ln; i++)
            {
                Output.Print(" ");
            }
            Output.Print($"{Name}: ");
            Output.PrintLine($"Mass = {Mass}, maximum speed = {MaxSpeed}, power = {Power}, passenger capacity = {PassengerCapacity}, number of wagons = {Wagons.Length}");
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
            Output.Print("Enter vehicle name: ");
            Name = Console.ReadLine();
            if (Name == "")
            {
                Name = "Nameless";
            }
        }
        public override void RandomInit(int leftBound, int rightBound)
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
            string str = "";
            for (int i = 0; i < 10; i++)
            {
                str = str + Convert.ToChar(random.Next(70, 90));
            }
            Name = str;
        }

        public override Express ShallowCopy()
        {
            return (Express)this.MemberwiseClone();
        }
        public override object Clone()
        {
            return new Express(this.Mass, this.MaxSpeed, this.Power, this.PassengerCapacity, this.Wagons, this.Name);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode()+Name.GetHashCode();
        }
    }
}
