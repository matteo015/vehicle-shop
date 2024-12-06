using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Model.Derived;

namespace VEHICLE_SHOP.Vehicles.src.View.Vehicles
{
    internal class CarView : VehicleView, IVehicleView<Car>
    {
        public string GetDetails(Car vehicle)
        {
           return base.GetDetails(vehicle) + $"{vehicle.NumberOfDoors} Doors";
        }

        public string GetEngineDetails(Car vehicle)
        {
            return base.GetDetails(vehicle);
        }
    }
}
