using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryHSE1course
{
    public class VehiclesComparer: IComparer<Vehicle>
    {
        public int Compare(Vehicle? x, Vehicle? y)
        {
            if (x == null || y == null) throw new ArgumentException("Incorrect parameter value");
            if (x.PassengerCapacity != y.PassengerCapacity) return x.PassengerCapacity - y.PassengerCapacity;
            if (x.Power != y.Power) return x.Power - y.Power;
            if (x.MaxSpeed != y.MaxSpeed) return (int)(x.MaxSpeed - y.MaxSpeed);
            return (int)(x.Mass - y.Mass);
        }
    }
}
