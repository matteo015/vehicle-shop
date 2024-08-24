using VEHICLE_SHOP.Vehicles.src.Model.Base;

namespace VEHICLE_SHOP.Vehicles.src.Model.Derived
{
    sealed public class Car : Vehicle
    {
        public int NumberOfDoors { get; private set; }
        public Car(string Make, string Name, string Model, UInt16 Year, decimal Price, Engine VehicleEngine, int NumberOfDoors) 
            : base(Name,Make,Model,Price,Year,VehicleEngine)
        {
            this.NumberOfDoors = NumberOfDoors;
        }
    }
}