using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Model.Base;

namespace VEHICLE_SHOP.Vehicles.src.View.Vehicles
{
    internal interface IVehicleView
    {
        public string GetDetails(Vehicle vehicle);

        public string GetEngineDetails(Vehicle vehicle);
    }
}
