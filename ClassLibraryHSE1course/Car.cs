using lab;
using System.Diagnostics.CodeAnalysis;

namespace ClassLibraryHSE1course
{
    public class Car : Vehicle, ICloneable
    {
        // Fields
        protected double fuelCapacity = 0; // Litres
        protected double fuelConsumption = 0; // Per km
        protected double мaneuverability = 0; // Turning speed
        protected double mileage = 0; // Km
        // Properties
        public double FuelCapacity
        {
            get
            {
                return this.fuelCapacity;
            }
            set
            {
                if (value >= 0)
                {
                    this.fuelCapacity = value;
                }
                else
                {
                    this.fuelCapacity = 0;
                }
            }
        }
        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set
            {
                if (value >= 0)
                {
                    this.fuelConsumption = value;
                }
                else
                {
                    this.fuelConsumption = 0;
                }
            }
        }
        public double Maneuverability
        {
            get
            {
                return this.мaneuverability;
            }
            set
            {
                if (value >= 0)
                {
                    this.мaneuverability = value;
                }
                else
                {
                    this.мaneuverability = 0;
                }
            }
        }
        public double Mileage
        {
            get
            {
                return this.mileage;
            }
            set
            {
                if (value >= 0)
                {
                    this.mileage = value;
                }
                else
                {
                    this.mileage = 0;
                }
            }
        }
        [ExcludeFromCodeCoverage]
        public Vehicle BaseVehicle
        {
            get
            {
                return new Vehicle(Mass, MaxSpeed, Power, PassengerCapacity);
            }
        }

        // Constructors
        [ExcludeFromCodeCoverage]
        public Car(double mass = 0, double maxSpeed = 0, int power = 0, int passengerCapacity = 0, double fuelCapacity= 0, double fuelConsumption = 0, double мaneuverability = 0, double mileage = 0) : base(mass, maxSpeed, power, passengerCapacity)
        {
            FuelCapacity = fuelCapacity;
            FuelConsumption = fuelConsumption;
            Maneuverability = мaneuverability;
            Mileage = mileage;
        }

        // Methods
        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                if (obj is Car temp)
                {
                    return this.Mass == temp.Mass && this.MaxSpeed == temp.MaxSpeed && this.Power == temp.Power && this.PassengerCapacity == temp.PassengerCapacity && this.FuelCapacity == temp.FuelCapacity && this.FuelConsumption == temp.FuelConsumption && this.Maneuverability == temp.Maneuverability && this.Mileage == temp.Mileage;
                }
            }
            return false;
        }

        // Methods (virtual)
        [ExcludeFromCodeCoverage]
        public override void Show(int ln = 0)
        {
            base.Show(ln);
            Output.PrintLine($", fuel capacity = {FuelCapacity}, fuel consumption = {FuelConsumption}, maneuverability = {Maneuverability}, mileage = {Mileage}");
        }

        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            base.Init();
            FuelCapacity = Input.ReadDouble("Enter vehicle fuel capacity", 2);
            FuelConsumption = Input.ReadDouble("Enter vehicle maximum fuel consumption", 2);
            Maneuverability = Input.ReadDouble("Enter vehicle maneuverability", 2);
            Mileage = Input.ReadDouble("Enter vehicle passenger mileage", 2);
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
            FuelCapacity = random.Next(leftBound, rightBound+1);
            FuelConsumption = random.Next(leftBound, rightBound+1);
            Maneuverability = random.Next(leftBound, rightBound+1);
            Mileage = random.Next(leftBound, rightBound+1);
        }
        public override Car ShallowCopy()
        {
            return (Car) this.MemberwiseClone();
        }
        public override object Clone()
        {
            return new Car(this.Mass, this.MaxSpeed, this.Power, this.PassengerCapacity, this.fuelCapacity, this.FuelConsumption, this.Maneuverability, this.mileage);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()+fuelCapacity.GetHashCode()+FuelConsumption.GetHashCode()+Maneuverability.GetHashCode()+mileage.GetHashCode();
        }
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"Car: Mass = {Mass}, maximum speed = {MaxSpeed}, power = {Power}, passenger capacity = {PassengerCapacity}, fuel capacity = {FuelCapacity}, fuel consumption = {FuelConsumption}, maneuverability = {Maneuverability}, mileage = {Mileage}";
        }
    }
}
