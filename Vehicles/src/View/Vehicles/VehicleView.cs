using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using VEHICLE_SHOP.Vehicles.src.Model.Derived;
using static VEHICLE_SHOP.Vehicles.src.Utils.ConsoleUtils;

namespace VEHICLE_SHOP.Vehicles.src.View.Vehicles
{
    public abstract class VehicleView : IVehicleView<Vehicle>
    {
        public virtual string GetDetails(Vehicle vehicle)
        {

            return $"{FYELLOW}==============================================================\n{RESET}" +
                   $"{FYELLOW}{{#{vehicle.VehicleId}}}{RESET}" + $"\n* {FYELLOW}{vehicle.Make.ToUpper()}{FWHITE} " +
                   $" - {vehicle.Year} - {FCYAN}{vehicle.Model} " + $"{FYELLOW}{vehicle.Name} {RESET} {FWHITE}";
        }

        public virtual string GetEngineDetails(Vehicle vehicle)
        {
            if (vehicle.Engine == null)
            {
                return $"\n{FRED}This vehicle doens't have an engine.{RESET}";
            }
            return $"   > {FYELLOW}" +
                   $"{vehicle.Engine.EngineName}  "                 +
                   $"{vehicle.Engine.EngineType}, {FCYAN}"          +
                   $"{vehicle.Engine.HorsePower} {FWHITE}Cavalos"   +
                   $"{RESET}";
        }
    }
}
