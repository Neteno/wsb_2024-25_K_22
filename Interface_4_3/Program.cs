namespace _3_interface
{
    internal class Program
    {
        public interface IVehicle
        {
            void Start();
            void Stop();
        }

        public interface IElectricVehicle : IVehicle
        {
            void ChargeBattery();
        }

        public abstract class Vehicle : IVehicle
        {
            public string Brand { get; set; }
            public string Model { get; set; }

            public Vehicle(string brand, string model)
            {
                Brand = brand;
                Model = model;
            }

            public virtual void Start()
            {
                Console.WriteLine($"{Brand} {Model} uruchamia się");
            }

            public virtual void Stop()
            {
                Console.WriteLine($"{Brand} {Model} zatrzymuje się");
            }
        }

        public class Car : Vehicle
        {
            public int NumberOfDoors { get; set; }

            public Car(string brand, string model, int numberOfDoors) : base(brand, model)
            {
                NumberOfDoors = numberOfDoors;
            }

            public override void Start()
            {
                Console.WriteLine($"{Brand} {Model} z {NumberOfDoors} drzwi uruchamia się");
            }

            public override void Stop()
            {
                Console.WriteLine($"{Brand} {Model} z {NumberOfDoors} drzwi zatrzymuje się");
            }
        }

        public class ElectricCar : Car, IElectricVehicle
        {
            public int BatteryCapacity { get; set; }

            public ElectricCar(string brand, string model, int numberOfDoors, int batteryCapacity) : base(brand, model, numberOfDoors)
            {
                BatteryCapacity = batteryCapacity;
            }

            public override void Start()
            {
                Console.WriteLine($"{Brand} {Model} z baterią o pojemności {BatteryCapacity} uruchamia się");
            }

            public override void Stop()
            {
                Console.WriteLine($"{Brand} {Model} z baterią o pojemności {BatteryCapacity} zatrzymuje się");
            }

            public void ChargeBattery()
            {
                Console.WriteLine($"{Brand} {Model} z baterią o pojemności {BatteryCapacity} ładuje się\"");
            }
        }
        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new List<IVehicle>()
            {
                new Car("Toyota", "Corolla", 4),
                new Car("Toyota", "Corolla", 4),
                new ElectricCar("Toyota", "Corolla", 4, 200),
                new ElectricCar("Toyota", "Corolla", 4, 200)
            };

            foreach (var vehicle in vehicles)
            {
                vehicle.Start();
                vehicle.Stop();

                if (vehicle is IElectricVehicle electricVehicle)
                {
                    electricVehicle.ChargeBattery();
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}