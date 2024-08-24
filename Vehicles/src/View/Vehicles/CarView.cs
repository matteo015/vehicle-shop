using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using VEHICLE_SHOP.Vehicles.src.Model.Derived;

namespace VEHICLE_SHOP.Vehicles.src.View.Vehicles
{
    internal class CarView : VehicleView
    {
        public override string GetDetails(Vehicle vehicle)
        {
            //Checking if vehicle has a null value.
            Car car = vehicle as Car ?? throw new ArgumentNullException(nameof(vehicle));
            return base.GetDetails(car) + $"{car.NumberOfDoors} Portas";
        }
    }
}
