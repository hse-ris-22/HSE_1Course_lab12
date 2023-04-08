using ClassLibraryHSE1course;
using System.Diagnostics.CodeAnalysis;

namespace lab.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UnitTests
    {
        // Vehicle
        [TestMethod]
        public void TestVehicleEquals1()
        {
            Vehicle vehicle1 = new Vehicle();
            Vehicle vehicle2 = new Vehicle();
            Assert.IsTrue(vehicle1.Equals(vehicle2));
        }
        [TestMethod]
        public void TestVehicleEquals2()
        {
            Vehicle vehicle1 = new Vehicle();
            Assert.IsFalse(vehicle1.Equals(null));
        }
        [TestMethod]
        public void TestVehicleEquals3()
        {
            Vehicle vehicle1 = new Vehicle(1,2,3,4);
            Vehicle vehicle2 = new Vehicle(1,2,3,4);
            Assert.IsTrue(vehicle1.Equals(vehicle2));
        }
        [TestMethod]
        public void TestVehicleEquals4()
        {
            Vehicle vehicle1 = new Vehicle(1, 2, 3);
            Vehicle vehicle2 = new Vehicle(1, 2, 3);
            Assert.IsTrue(vehicle1.Equals(vehicle2));
        }
        [TestMethod]
        public void TestVehicleEquals5()
        {
            Vehicle vehicle1 = new Vehicle(1, 2);
            Vehicle vehicle2 = new Vehicle(1, 2);
            Assert.IsTrue(vehicle1.Equals(vehicle2));
        }
        [TestMethod]
        public void TestVehicleEquals6()
        {
            Vehicle vehicle1 = new Vehicle(1);
            Vehicle vehicle2 = new Vehicle(1);
            Assert.IsTrue(vehicle1.Equals(vehicle2));
        }
        [TestMethod]
        public void TestVehicleEquals7()
        {
            Vehicle vehicle1 = new Vehicle(1, 2, 3, 4);
            Vehicle vehicle2 = new Vehicle(4, 3, 2, 1);
            Assert.IsFalse(vehicle1.Equals(vehicle2));
        }
        [TestMethod]
        public void TestVehicleEquals8()
        {
            Vehicle vehicle1 = new Vehicle();
            Assert.IsFalse(vehicle1.Equals(4));
        }

        [TestMethod]
        public void TestVehiclePropertyMass1()
        {
            int expected = 5;
            Car car = new Car();
            car.Mass = 5;
            Assert.AreEqual(expected, car.Mass);
        }
        [TestMethod]
        public void TestVehiclePropertyMass2()
        {
            int expected = 0;
            Car car = new Car();
            car.Mass = -5;
            Assert.AreEqual(expected, car.Mass);
        }
        [TestMethod]
        public void TestVehiclePropertyMaxSpeed1()
        {
            int expected = 5;
            Car car = new Car();
            car.MaxSpeed = 5;
            Assert.AreEqual(expected, car.MaxSpeed);
        }
        [TestMethod]
        public void TestVehiclePropertyMaxSpeed2()
        {
            int expected = 0;
            Car car = new Car();
            car.MaxSpeed = -5;
            Assert.AreEqual(expected, car.MaxSpeed);
        }
        [TestMethod]
        public void TestVehiclePropertyPower1()
        {
            int expected = 5;
            Car car = new Car();
            car.Power = 5;
            Assert.AreEqual(expected, car.Power);
        }
        [TestMethod]
        public void TestVehiclePropertyPower2()
        {
            int expected = 0;
            Car car = new Car();
            car.Power = -5;
            Assert.AreEqual(expected, car.Power);
        }
        [TestMethod]
        public void TestVehiclePropertyPassengerCapacity1()
        {
            int expected = 5;
            Car car = new Car();
            car.PassengerCapacity = 5;
            Assert.AreEqual(expected, car.PassengerCapacity);
        }
        [TestMethod]
        public void TestVehiclePropertyPassengerCapacity2()
        {
            int expected = 0;
            Car car = new Car();
            car.PassengerCapacity = -5;
            Assert.AreEqual(expected, car.PassengerCapacity);
        }
        [TestMethod]
        public void TestCompareTo1()
        {
            int expected = 2;
            Car car = new Car(10);
            Assert.AreEqual(expected, car.CompareTo(8));
        }
        [TestMethod]
        public void TestCompareTo2()
        {
            double expected = 2;
            Car car = new Car(10);
            Assert.AreEqual(expected, car.CompareTo(8));
        }
        [TestMethod]
        public void TestCompareTo3()
        {
            int expected = -2;
            Car car = new Car(6);
            Assert.AreEqual(expected, car.CompareTo(8));
        }
        [TestMethod]
        public void TestCompareTo4()
        {
            double expected = -2;
            Car car = new Car(6);
            Assert.AreEqual(expected, car.CompareTo(8));
        }
        [TestMethod]
        public void TestCompareTo5()
        {
            int expected = 0;
            Car car = new Car(8);
            Assert.AreEqual(expected, car.CompareTo(8));
        }
        [TestMethod]
        public void TestCompareTo6()
        {
            double expected = 0;
            Car car = new Car(8);
            Assert.AreEqual(expected, car.CompareTo(8));
        }
        [TestMethod]
        public void TestCompareTo7()
        {
            double expected = 2;
            Car car1 = new Car(8);
            Car car2 = new Car(6);
            Assert.AreEqual(expected, car1.CompareTo(car2));
        }

        [TestMethod]
        public void TestCompareTo8()
        {
            double expected = -2;
            Car car1 = new Car(6);
            Car car2 = new Car(8);
            Assert.AreEqual(expected, car1.CompareTo(car2));
        }
        [TestMethod]
        public void TestCompareTo9()
        {
            double expected = 2;
            Car car1 = new Car(8, 8);
            Car car2 = new Car(8, 6);
            Assert.AreEqual(expected, car1.CompareTo(car2));
        }
        [TestMethod]
        public void TestCompareTo10()
        {
            double expected = -2;
            Car car1 = new Car(8, 6);
            Car car2 = new Car(8, 8);
            Assert.AreEqual(expected, car1.CompareTo(car2));
        }
        [TestMethod]
        public void TestCompareTo11()
        {
            double expected = 2;
            Car car1 = new Car(8, 8, 8);
            Car car2 = new Car(8, 8, 6);
            Assert.AreEqual(expected, car1.CompareTo(car2));
        }
        [TestMethod]
        public void TestCompareTo12()
        {
            double expected = -2;
            Car car1 = new Car(8, 8, 6);
            Car car2 = new Car(8, 8, 8);
            Assert.AreEqual(expected, car1.CompareTo(car2));
        }
        [TestMethod]
        public void TestCompareTo13()
        {
            double expected = 2;
            Car car1 = new Car(8, 8, 8, 8);
            Car car2 = new Car(8, 8, 8, 6);
            Assert.AreEqual(expected, car1.CompareTo(car2));
        }
        [TestMethod]
        public void TestCompareTo14()
        {
            double expected = -2;
            Car car1 = new Car(8, 8, 8, 6);
            Car car2 = new Car(8, 8, 8, 8);
            Assert.AreEqual(expected, car1.CompareTo(car2));
        }
        [TestMethod]
        public void TestCompareTo15()
        {
            double expected = 0;
            Car car1 = new Car(8, 8, 8, 8);
            Car car2 = new Car(8, 8, 8, 8);
            Assert.AreEqual(expected, car1.CompareTo(car2));
        }
        [TestMethod]
        public void TestCompareTo16()
        {
            bool expected = true;
            Car car = new Car(8, 8, 8, 8);
            string str = "8, 8, 8, 8";
            bool isException = false;
            try
            {
                car.CompareTo(str);
            }
            catch (Exception)
            {
                isException = true;
            }
            Assert.AreEqual(expected, isException);
        }
        [TestMethod]
        public void TestCompareTo17()
        {
            double expected = 18;
            Car car = new Car(10);
            Assert.AreEqual(expected, car.CompareTo(-8));
        }
        [TestMethod]
        public void TestCompareTo18()
        {
            int expected = 18;
            Car car = new Car(10);
            Assert.AreEqual(expected, car.CompareTo(-8));
        }
        [TestMethod]
        public void TestCompareTo19()
        {
            double expected = 8;
            Car car = new Car(-8);
            Assert.AreEqual(expected, car.CompareTo(-8));
        }
        [TestMethod]
        public void TestCompareTo20()
        {
            int expected = 8;
            Car car = new Car(-8);
            Assert.AreEqual(expected, car.CompareTo(-8));
        }
        [TestMethod]
        public void TestCompareTo21()
        {
            int expected = 16;
            Car car = new Car(8.5);
            Assert.AreEqual(expected, car.CompareTo(-7.5));
        }
        [TestMethod]
        public void TestVehicleShallowCopy()
        {
            Vehicle vehicle1 = new Vehicle(1, 2, 3, 4);
            Vehicle vehicle2 = vehicle1.ShallowCopy();
            Assert.IsTrue(vehicle1.Equals(vehicle2));
            vehicle2.Mass = 2;
            Assert.AreNotEqual(vehicle1.Mass, vehicle2.Mass);
        }

        [TestMethod]
        public void TestVehicleClone()
        {
            Vehicle vehicle1 = new Vehicle(1, 2, 3, 4);
            Vehicle vehicle2 = (Vehicle)vehicle1.Clone();
            Assert.IsTrue(vehicle1.Equals(vehicle2));
            vehicle2.Mass = 2;
            Assert.AreNotEqual(vehicle1.Mass, vehicle2.Mass);
        }

        [TestMethod]
        public void TestVehicleGetHashCode()
        {
            Vehicle vehicle = new Vehicle(1, 2, 3, 4);
            int expected = (vehicle.Mass.GetHashCode() + vehicle.MaxSpeed.GetHashCode() + vehicle.Power.GetHashCode() + vehicle.PassengerCapacity.GetHashCode());
            Assert.AreEqual(expected, vehicle.GetHashCode());
        }
        // Car

        [TestMethod]
        public void TestCarPropertyFuelCapacity1()
        {
            int expected = 5;
            Car car = new Car();
            car.FuelCapacity = 5;
            Assert.AreEqual(expected, car.FuelCapacity);
        }
        [TestMethod]
        public void TestCarPropertyFuelCapacity2()
        {
            int expected = 0;
            Car car = new Car();
            car.FuelCapacity = -5;
            Assert.AreEqual(expected, car.FuelCapacity);
        }
        [TestMethod]
        public void TestCarPropertyFuelConsumption1()
        {
            int expected = 5;
            Car car = new Car();
            car.FuelConsumption = 5;
            Assert.AreEqual(expected, car.FuelConsumption);
        }
        [TestMethod]
        public void TestCarPropertyFuelConsumption2()
        {
            int expected = 0;
            Car car = new Car();
            car.FuelConsumption = -5;
            Assert.AreEqual(expected, car.FuelConsumption);
        }
        [TestMethod]
        public void TestCarPropertyManeuverability1()
        {
            int expected = 5;
            Car car = new Car();
            car.Maneuverability = 5;
            Assert.AreEqual(expected, car.Maneuverability);
        }
        [TestMethod]
        public void TestCarPropertyManeuverability2()
        {
            int expected = 0;
            Car car = new Car();
            car.Maneuverability = -5;
            Assert.AreEqual(expected, car.Maneuverability);
        }
        [TestMethod]
        public void TestCarPropertyMileage1()
        {
            int expected = 5;
            Car car = new Car();
            car.Mileage = 5;
            Assert.AreEqual(expected, car.Mileage);
        }
        [TestMethod]
        public void TestCarPropertyMileage2()
        {
            int expected = 0;
            Car car = new Car();
            car.Mileage = -5;
            Assert.AreEqual(expected, car.Mileage);
        }
        [TestMethod]
        public void TestCarRandomInit1()
        {
            int expected = 1;
            Car car = new Car();
            car.RandomInit(1, 1);
            Assert.AreEqual(expected, car.Mass);
        }
        [TestMethod]
        public void TestCarRandomInit2()
        {
            int expected = 0;
            Car car = new Car();
            car.RandomInit(-1, 0);
            Assert.AreEqual(expected, car.Mass);
        }
        [TestMethod]
        public void TestCarRandomInit3()
        {
            int expected = 0;
            Car car = new Car();
            car.RandomInit(-1, -2);
            Assert.AreEqual(expected, car.Mass);
        }
        [TestMethod]
        public void TestCarRandomInit4()
        {
            int expected = 2;
            Car car = new Car();
            car.RandomInit(2, 0);
            Assert.AreEqual(expected, car.Mass);
        }
        [TestMethod]
        public void TestCarEquals1()
        {
            Car car1 = new Car();
            Car car2 = new Car();
            Assert.IsTrue(car1.Equals(car2));
        }
        [TestMethod]
        public void TestCarEquals2()
        {
            Car car1 = new Car(1, 2, 3, 4, 5, 6, 7, 8);
            Car car2 = new Car(1, 2, 3, 4, 5, 6, 7, 8);
            Assert.IsTrue(car2.Equals(car1));
        }
        [TestMethod]
        public void TestCarEquals3()
        {
            Car car1 = new Car(1, 2, 3, 4, 5, 6, 7, 8);
            Car car2 = new Car(8, 7, 6, 5, 4, 3, 2, 1);
            Assert.IsFalse(car1.Equals(car2));
        }
        [TestMethod]
        public void TestCarEquals4()
        {
            Train car1 = new Train(1, 2, 3, 4);
            Car car2 = new Car(1, 2, 3, 4);
            Assert.IsFalse(car2.Equals(car1));
        }
        [TestMethod]
        public void TestCarEquals5()
        {
            Car car1 = new Car(1, 2, 3, 4);
            Assert.IsFalse(car1.Equals(null));
        }
        [TestMethod]
        public void TestCarEquals6()
        {
            Car car1 = new Car(1, 2, 3, 4);
            Assert.IsFalse(car1.Equals(5));
        }
        [TestMethod]
        public void TestCarEquals7()
        {
            Car car1 = new Car(1, 2, 3, 4, 5, 6, 7, 8);
            Car car2 = new Car(0, 2, 3, 4, 5, 6, 7, 8);
            Assert.IsFalse(car1.Equals(car2));
        }
        [TestMethod]
        public void TestCarEquals8()
        {
            Car car1 = new Car(1, 2, 3, 4, 5, 6, 7, 8);
            Car car2 = new Car(1, 0, 3, 4, 5, 6, 7, 8);
            Assert.IsFalse(car1.Equals(car2));
        }
        [TestMethod]
        public void TestCarEquals9()
        {
            Car car1 = new Car(1, 2, 3, 4, 5, 6, 7, 8);
            Car car2 = new Car(1, 2, 0, 4, 5, 6, 7, 8);
            Assert.IsFalse(car1.Equals(car2));
        }
        [TestMethod]
        public void TestCarEquals10()
        {
            Car car1 = new Car(1, 2, 3, 4, 5, 6, 7, 8);
            Car car2 = new Car(1, 2, 3, 0, 5, 6, 7, 8);
            Assert.IsFalse(car1.Equals(car2));
        }
        [TestMethod]
        public void TestCarEquals11()
        {
            Car car1 = new Car(1, 2, 3, 4, 5, 6, 7, 8);
            Car car2 = new Car(1, 2, 3, 4, 0, 6, 7, 8);
            Assert.IsFalse(car1.Equals(car2));
        }
        [TestMethod]
        public void TestCarEquals12()
        {
            Car car1 = new Car(1, 2, 3, 4, 5, 6, 7, 8);
            Car car2 = new Car(1, 2, 3, 4, 5, 0, 7, 8);
            Assert.IsFalse(car1.Equals(car2));
        }
        [TestMethod]
        public void TestCarEquals13()
        {
            Car car1 = new Car(1, 2, 3, 4, 5, 6, 7, 8);
            Car car2 = new Car(1, 2, 3, 4, 5, 6, 0, 8);
            Assert.IsFalse(car1.Equals(car2));
        }
        [TestMethod]
        public void TestCarEquals14()
        {
            Car car1 = new Car(1, 2, 3, 4, 5, 6, 7, 8);
            Car car2 = new Car(1, 2, 3, 4, 5, 6, 7, 0);
            Assert.IsFalse(car1.Equals(car2));
        }
        [TestMethod]
        public void TestCarShallowCopy()
        {
            Car car1 = new Car(1, 2, 3, 4, 5, 6, 7, 8);
            Car car2 = car1.ShallowCopy();
            Assert.IsTrue(car1.Equals(car2));
            car2.Mass = 2;
            Assert.AreNotEqual(car1.Mass, car2.Mass);
        }

        [TestMethod]
        public void TestCarClone()
        {
            Car car1 = new Car(1, 2, 3, 4, 5, 6, 7, 8);
            Car car2 = (Car)car1.Clone();
            Assert.IsTrue(car1.Equals(car2));
            car2.Mass = 2;
            Assert.AreNotEqual(car1.Mass, car2.Mass);
        }

        [TestMethod]
        public void TestCarGetHashCode()
        {
            Car car = new Car(1, 2, 3, 4,5,6,7,8);
            int expected = (car.Mass.GetHashCode() + car.MaxSpeed.GetHashCode() + car.Power.GetHashCode() + car.PassengerCapacity.GetHashCode() + car.Maneuverability.GetHashCode() + car.FuelConsumption.GetHashCode() + car.FuelCapacity.GetHashCode() + car.Mileage.GetHashCode()); ;
            Assert.AreEqual(expected, car.GetHashCode());
        }
        // Train
        [TestMethod]
        public void TestTrainEquals1()
        {
            Train train1 = new Train();
            Train train2 = new Train();
            Assert.IsTrue(train1.Equals(train2));
        }
        [TestMethod]
        public void TestTrainEquals2()
        {
            Train train1 = new Train(1, 2, 3, 4, new int[1] { 5 });
            Train train2 = new Train(1, 2, 3, 4, new int[1] { 5 });
            Assert.IsTrue(train1.Equals(train2));
        }
        [TestMethod]
        public void TestTrainEquals3()
        {
            Train train1 = new Train(1, 2, 3, 4, new int[1] { 5 });
            Train train2 = new Train(4, 3, 2, 1, new int[1] { 5 });
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestTrainEquals4()
        {
            Train train1 = new Train(1, 2, 3, 4);
            Car train2 = new Car(1, 2, 3, 4);
            Assert.IsFalse(train2.Equals(train1));
        }
        [TestMethod]
        public void TestTrainEquals5()
        {
            Train train1 = new Train(1, 2, 3, 4, new int[1] { 5 });
            Assert.IsFalse(train1.Equals(null));
        }
        [TestMethod]
        public void TestTrainEquals6()
        {
            Train train1 = new Train(1, 2, 3, 4, new int[1] { 5 });
            Assert.IsFalse(train1.Equals(5));
        }
        [TestMethod]
        public void TestTrainEquals7()
        {
            Train train1 = new Train(1, 2, 3, 4, new int[1] { 5 });
            Train train2 = new Train(0, 2, 3, 4, new int[1] { 5 });
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestTrainEquals8()
        {
            Train train1 = new Train(1, 2, 3, 4, new int[1] { 5 });
            Train train2 = new Train(1, 0, 3, 4, new int[1] { 5 });
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestTrainEquals9()
        {
            Train train1 = new Train(1, 2, 3, 4, new int[1] { 5 });
            Train train2 = new Train(1, 2, 0, 4, new int[1] { 5 });
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestTrainEquals10()
        {
            Train train1 = new Train(1, 2, 3, 4, new int[1] { 5 });
            Train train2 = new Train(1, 2, 3, 0, new int[1] { 5 });
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestTrainEquals11()
        {
            Train train1 = new Train(1, 2, 3, 4, new int[1] { 5 });
            Train train2 = new Train(1, 2, 3, 4, new int[1] { 0 });
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestTrainEquals12()
        {
            Train train1 = new Train(1, 2, 3, 4, new int[1] { 5 });
            Train train2 = new Train(1, 2, 3, 4, new int[0] { });
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestTrainShallowCopy()
        {
            Train train1 = new Train(1, 2, 3, 4, new int[1] { 5 });
            Train train2 = train1.ShallowCopy();
            Assert.IsTrue(train1.Equals(train2));
            train2.Mass = 2;
            Assert.AreNotEqual(train1.Mass, train2.Mass);
            train2.Wagons = new int[2];
            Assert.AreNotEqual(train1.Wagons, train2.Wagons);
        }
        [TestMethod]
        public void TestTrainClone()
        {
            Train train1 = new Train(1, 2, 3, 4, new int[1] { 5 });
            Train train2 = (Train)train1.Clone();
            Assert.IsTrue(train1.Equals(train2));
            train2.Mass = 2;
            Assert.AreNotEqual(train1.Mass, train2.Mass);
            train2.Wagons = new int[2];
            Assert.AreNotEqual(train1.Wagons, train2.Wagons);
        }

        [TestMethod]
        public void TestTrainGetHashCode()
        {
            Train train = new Train(1, 2, 3, 4, new int[1]);
            int expected = (train.Mass.GetHashCode() + train.MaxSpeed.GetHashCode() + train.Power.GetHashCode() + train.PassengerCapacity.GetHashCode() + train.Wagons.Length.GetHashCode());
            Assert.AreEqual(expected, train.GetHashCode());
        }

        // Express
        [TestMethod]
        public void TestExpressEquals1()
        {
            Express train1 = new Express();
            Express train2 = new Express();
            Assert.IsTrue(train1.Equals(train2));
        }
        [TestMethod]
        public void TestExpressEquals2()
        {
            Express train1 = new Express(1, 2, 3, 4, new int[1] { 5 }, "name");
            Express train2 = new Express(1, 2, 3, 4, new int[1] { 5 }, "name");
            Assert.IsTrue(train1.Equals(train2));
        }
        [TestMethod]
        public void TestExpressEquals3()
        {
            Express train1 = new Express(1, 2, 3, 4, new int[1] { 5 }, "name");
            Express train2 = new Express(4, 3, 2, 1, new int[1] { 5 }, "name");
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestExpressEquals4()
        {
            Express train1 = new Express(1, 2, 3, 4);
            Car train2 = new Car(1, 2, 3, 4);
            Assert.IsFalse(train2.Equals(train1));
        }
        [TestMethod]
        public void TestExpressEquals5()
        {
            Express train1 = new Express(1, 2, 3, 4, new int[1] { 5 }, "name");
            Assert.IsFalse(train1.Equals(null));
        }
        [TestMethod]
        public void TestExpressEquals6()
        {
            Express train1 = new Express(1, 2, 3, 4, new int[1] { 5 }, "name");
            Assert.IsFalse(train1.Equals(5));
        }
        [TestMethod]
        public void TestExpressEquals7()
        {
            Express train1 = new Express(1, 2, 3, 4, new int[1] { 5 }, "name");
            Express train2 = new Express(0, 2, 3, 4, new int[1] { 5 }, "name");
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestExpressEquals8()
        {
            Express train1 = new Express(1, 2, 3, 4, new int[1] { 5 }, "name");
            Express train2 = new Express(1, 0, 3, 4, new int[1] { 5 }, "name");
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestExpressEquals9()
        {
            Express train1 = new Express(1, 2, 3, 4, new int[1] { 5 }, "name");
            Express train2 = new Express(1, 2, 0, 4, new int[1] { 5 }, "name");
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestExpressEquals10()
        {
            Express train1 = new Express(1, 2, 3, 4, new int[1] { 5 }, "name");
            Express train2 = new Express(1, 2, 3, 0, new int[1] { 5 }, "name");
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestExpressEquals11()
        {
            Express train1 = new Express(1, 2, 3, 4, new int[1] { 5 }, "name");
            Express train2 = new Express(1, 2, 3, 4, new int[1] { 0 }, "name");
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestExpressEquals12()
        {
            Express train1 = new Express(1, 2, 3, 4, new int[1] { 5 }, "name");
            Express train2 = new Express(1, 2, 3, 4, new int[0] { }, "name");
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestExpressEquals13()
        {
            Express train1 = new Express(1, 2, 3, 4, new int[1] { 5 }, "name");
            Express train2 = new Express(1, 2, 3, 4, new int[1] { 5 }, "eman");
            Assert.IsFalse(train1.Equals(train2));
        }
        [TestMethod]
        public void TestExpressRandomInit1()
        {
            int expected = 1;
            Express express = new Express();
            express.RandomInit(1, 1);
            Assert.AreEqual(expected, express.Mass);
        }
        [TestMethod]
        public void TestExpressRandomInit2()
        {
            int expected = 0;
            Express express = new Express();
            express.RandomInit(-1, 0);
            Assert.AreEqual(expected, express.Mass);
        }
        [TestMethod]
        public void TestExpressRandomInit3()
        {
            int expected = 0;
            Express express = new Express();
            express.RandomInit(-1, -2);
            Assert.AreEqual(expected, express.Mass);
        }
        [TestMethod]
        public void TestExpressRandomInit4()
        {
            int expected = 2;
            Express express = new Express();
            express.RandomInit(2, 0);
            Assert.AreEqual(expected, express.Mass);
        }

        [TestMethod]
        public void TestExpressShallowCopy()
        {
            Train train1 = new Express(1, 2, 3, 4, new int[1] { 5 }, "name");
            Train train2 = train1.ShallowCopy();
            Assert.IsTrue(train1.Equals(train2));
            train2.Mass = 2;
            Assert.AreNotEqual(train1.Mass, train2.Mass);
            train2.Wagons = new int[2];
            Assert.AreNotEqual(train1.Wagons, train2.Wagons);
        }
        [TestMethod]
        public void TestExpressClone()
        {
            Train train1 = new Express(1, 2, 3, 4, new int[1] { 5 }, "name");
            Train train2 = (Express)train1.Clone();
            Assert.IsTrue(train1.Equals(train2));
            train2.Mass = 2;
            Assert.AreNotEqual(train1.Mass, train2.Mass);
            train2.Wagons = new int[2];
            Assert.AreNotEqual(train1.Wagons, train2.Wagons);
        }

        [TestMethod]
        public void TestExpressGetHashCode()
        {
            Express express = new Express(1, 2, 3, 4, new int[1],"123");
            int expected = (express.Mass.GetHashCode() + express.MaxSpeed.GetHashCode() + express.Power.GetHashCode() + express.PassengerCapacity.GetHashCode() + express.Wagons.Length.GetHashCode() + express.Name.GetHashCode());
            Assert.AreEqual(expected, express.GetHashCode());
        }

        // Comparer

        [TestMethod]
        public void TestComparer1()
        {
            double expected = 2;
            Car car1 = new Car(0, 0, 0, 8);
            Car car2 = new Car(0, 0, 0, 6);
            VehiclesComparer Comparer = new VehiclesComparer();
            Assert.AreEqual(expected, Comparer.Compare(car1, car2));
        }

        [TestMethod]
        public void TestComparer2()
        {
            double expected = -2;
            Car car2 = new Car(0, 0, 0, 8);
            Car car1 = new Car(0, 0, 0, 6);
            VehiclesComparer Comparer = new VehiclesComparer();
            Assert.AreEqual(expected, Comparer.Compare(car1, car2));
        }
        [TestMethod]
        public void TestComparer3()
        {
            double expected = 2;
            Car car1 = new Car(0, 0, 8, 8);
            Car car2 = new Car(0, 0, 6, 8);
            VehiclesComparer Comparer = new VehiclesComparer();
            Assert.AreEqual(expected, Comparer.Compare(car1, car2));
        }
        [TestMethod]
        public void TestComparer4()
        {
            double expected = -2;
            Car car2 = new Car(0, 0, 8, 8);
            Car car1 = new Car(0, 0, 6, 8);
            VehiclesComparer Comparer = new VehiclesComparer();
            Assert.AreEqual(expected, Comparer.Compare(car1, car2));
        }
        [TestMethod]
        public void TestComparer5()
        {
            double expected = 2;
            Car car1 = new Car(0, 8, 8, 8);
            Car car2 = new Car(0, 6, 8, 8);
            VehiclesComparer Comparer = new VehiclesComparer();
            Assert.AreEqual(expected, Comparer.Compare(car1, car2));
        }
        [TestMethod]
        public void TestComparer6()
        {
            double expected = -2;
            Car car2 = new Car(0, 8, 8, 8);
            Car car1 = new Car(0, 6, 8, 8);
            VehiclesComparer Comparer = new VehiclesComparer();
            Assert.AreEqual(expected, Comparer.Compare(car1, car2));
        }
        [TestMethod]
        public void TestComparer7()
        {
            double expected = 2;
            Car car1 = new Car(8, 8, 8, 8);
            Car car2 = new Car(6, 8, 8, 8);
            VehiclesComparer Comparer = new VehiclesComparer();
            Assert.AreEqual(expected, Comparer.Compare(car1, car2));
        }
        [TestMethod]
        public void TestComparer8()
        {
            double expected = -2;
            Car car2 = new Car(8, 8, 8, 8);
            Car car1 = new Car(6, 8, 8, 8);
            VehiclesComparer Comparer = new VehiclesComparer();
            Assert.AreEqual(expected, Comparer.Compare(car1, car2));
        }
        [TestMethod]
        public void TestComparer9()
        {
            double expected = 0;
            Car car1 = new Car(8, 8, 8, 8);
            Car car2 = new Car(8, 8, 8, 8);
            VehiclesComparer Comparer = new VehiclesComparer();
            Assert.AreEqual(expected, Comparer.Compare(car1, car2));
        }
        [TestMethod]
        public void TestComparer10()
        {
            bool expected = true;
            Car car1 = new Car(8, 8, 8, 8);
            Car car2 = null;
            bool isException = false;
            try
            {
                VehiclesComparer Comparer = new VehiclesComparer();
                Assert.AreEqual(expected, Comparer.Compare(car1, car2));
            }
            catch (Exception)
            {
                isException = true;
            }
            Assert.AreEqual(expected, isException);
        }
        [TestMethod]
        public void TestComparer11()
        {
            bool expected = true;
            Car car2 = new Car(8, 8, 8, 8);
            Car car1 = null;
            bool isException = false;
            try
            {
                VehiclesComparer Comparer = new VehiclesComparer();
                Assert.AreEqual(expected, Comparer.Compare(car1, car2));
            }
            catch (Exception)
            {
                isException = true;
            }
            Assert.AreEqual(expected, isException);
        }

        // Human
        [TestMethod]
        public void TestHumanRandomInit1()
        {
            int expected = 1;
            Human human = new Human();
            human.RandomInit(1, 1);
            Assert.AreEqual(expected, human.Weight);
        }
        [TestMethod]
        public void TestHumanRandomInit2()
        {
            int expected = 0;
            Human human = new Human();
            human.RandomInit(-1, 0);
            Assert.AreEqual(expected, human.Weight);
        }
        [TestMethod]
        public void TestHumanRandomInit3()
        {
            int expected = 0;
            Human human = new Human();
            human.RandomInit(-1, -2);
            Assert.AreEqual(expected, human.Weight);
        }
        [TestMethod]
        public void TestHumanRandomInit4()
        {
            int expected = 2;
            Human human = new Human();
            human.RandomInit(2, 0);
            Assert.AreEqual(expected, human.Weight);
        }
        [TestMethod]
        public void TestHumanShallowCopy()
        {
            Human human1 = new Human(1, 2, new Car(1, 2, 3, 4, 5, 6, 7, 8));
            Human human2 = human1.ShallowCopy();
            Assert.AreEqual(human1.Weight, human2.Weight);
            Assert.AreEqual(human1.Height, human2.Height);
            Assert.IsTrue(human1.PersonalCar.Equals(human2.PersonalCar));
            human2.Weight = 10;
            Assert.AreNotEqual(human1.Weight, human2.Weight);
            human2.PersonalCar.Mass = 10;
            Assert.AreEqual(human1.PersonalCar.Mass, human2.PersonalCar.Mass);
        }

        [TestMethod]
        public void TestHumanClone()
        {
            Human human1 = new Human(1, 2, new Car(1, 2, 3, 4, 5, 6, 7, 8));
            Human human2 = (Human)human1.Clone();
            Assert.AreEqual(human1.Weight, human2.Weight);
            Assert.AreEqual(human1.Height, human2.Height);
            Assert.IsTrue(human1.PersonalCar.Equals(human2.PersonalCar));
            human2.Weight = 10;
            Assert.AreNotEqual(human1.Weight, human2.Weight);
            human2.PersonalCar.Mass = 10;
            Assert.AreNotEqual(human1.PersonalCar.Mass, human2.PersonalCar.Mass);
        }
    }
}