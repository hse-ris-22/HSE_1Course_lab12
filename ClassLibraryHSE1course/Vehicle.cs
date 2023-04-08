using lab;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace ClassLibraryHSE1course
{
    public class Vehicle :  IComparable,IInit
    {
        // Fields
        protected double mass = 0; // Kg
        protected double maxSpeed = 0; // Km per hour
        protected int power = 0; // In horsepowers
        protected int passengerCapacity = 0; // People
        static protected Random random = new Random();
        // Properties

        public double Mass
        {
            get
            {
                return this.mass;
            }
            set
            {
                if (value >= 0)
                {
                    this.mass = value;
                }
                else
                {
                    this.mass = 0;
                }
            }
        }

        public double MaxSpeed
        {
            get
            {
                return this.maxSpeed;
            }
            set
            {
                if (value >= 0)
                {
                    this.maxSpeed = value;
                }
                else
                {
                    this.maxSpeed = 0;
                }
            }
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            set
            {
                if (value >= 0)
                {
                    this.power = value;
                }
                else
                {
                    this.power = 0;
                }
            }
        }

        public int PassengerCapacity
        {
            get
            {
                return this.passengerCapacity;
            }
            set
            {
                if (value >= 0)
                {
                    this.passengerCapacity = value;
                }
                else
                {
                    this.passengerCapacity = 0;
                }
            }
        }

        // Constructors
        [ExcludeFromCodeCoverage]
        public Vehicle(double mass = 0, double speed = 0, int power = 0, int passengerCapacity= 0)
        {
            Mass = mass;
            MaxSpeed = speed;
            Power= power;
            PassengerCapacity = passengerCapacity;
        }

        // Methods
        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                if (obj is Vehicle temp)
                {
                    return this.Mass == temp.Mass && this.MaxSpeed == temp.MaxSpeed && this.Power == temp.Power && this.PassengerCapacity == temp.PassengerCapacity;
                }
            }
            return false;
        }

        // Method (virtual)
        [ExcludeFromCodeCoverage]
        public virtual void Show()
        {
            Output.Print($"Mass = {Mass}, maximum speed = {MaxSpeed}, power = {Power}, passenger capacity = {PassengerCapacity}");
        }

        [ExcludeFromCodeCoverage]
        public virtual void Init()
        {
            Mass = Input.ReadDouble("Enter vehicle mass", 2);
            MaxSpeed = Input.ReadDouble("Enter vehicle maximum speed", 2);
            Power = Input.ReadInt("Enter vehicle power", 2);
            PassengerCapacity = Input.ReadInt("Enter vehicle passenger capacity", 2);
        }
        public virtual void RandomInit(int leftBound, int rightBound)
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
            Mass = random.Next(leftBound, rightBound+1);
            MaxSpeed = random.Next(leftBound, rightBound+1);
            Power = random.Next(leftBound, rightBound+1);
            PassengerCapacity = random.Next(leftBound, rightBound+1);
        }

        public int CompareTo(object? obj)
        {
            if (obj is double dbl) return (int)(this.Mass - dbl);
            else if (obj is int ibl) return (int)(this.Mass - ibl);
            else if (obj is Vehicle vehicle)
            {
                if (this.Mass != vehicle.Mass) return (int)(this.Mass - vehicle.Mass);
                if (this.MaxSpeed != vehicle.MaxSpeed) return (int)(this.MaxSpeed - vehicle.MaxSpeed);
                if (this.Power != vehicle.Power) return this.Power - vehicle.Power;
                return this.PassengerCapacity - vehicle.PassengerCapacity;
            }
            else throw new ArgumentException("Incorrect parameter value");
        }
        public virtual Vehicle ShallowCopy()
        {
            return (Vehicle)this.MemberwiseClone();
        }
        public virtual object Clone()
        {
            return new Vehicle(mass, MaxSpeed, Power, PassengerCapacity);
        }

        public override int GetHashCode()
        {
            return Mass.GetHashCode()+MaxSpeed.GetHashCode()+Power.GetHashCode()+PassengerCapacity.GetHashCode();
        }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"Vehicle: Mass = {Mass}, maximum speed = {MaxSpeed}, power = {Power}, passenger capacity = {PassengerCapacity}";
        }
    }
}