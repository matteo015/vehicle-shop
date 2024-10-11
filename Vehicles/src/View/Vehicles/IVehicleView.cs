using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Model.Base;

namespace VEHICLE_SHOP.Vehicles.src.View.Vehicles
{
    public interface IVehicleView<T> where T : Vehicle
    {
        public string GetDetails(T vehicle);

        public string GetEngineDetails(T vehicle);
    }
}
