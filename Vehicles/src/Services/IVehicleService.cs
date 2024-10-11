using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Model.Base;

namespace VEHICLE_SHOP.Vehicles.src.Services
{
    public interface IVehicleService<T> where T : Vehicle
    {
        void AddVehicle(T vehicle);
        void RemoveVehicle(T vehicle);
        void RemoveVehicle(int id);
        void UpdateVehicle(T vehicle);
        void UpdateVehicles(int id);
        T GetVehicle(int id);
        List<T> GetVehicles();
    }
}
