using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using VEHICLE_SHOP.Vehicles.src.Repository;

namespace VEHICLE_SHOP.Vehicles.src.Services
{
    public interface IRepositoryService<T> where T : Vehicle
    {
        public void LoadRepository(IRepositoryClient<T> repository);

		void AddVehicle(T vehicle);
        void RemoveVehicle(T vehicle);
        void RemoveVehicle(int id);
        void UpdateVehicle(T vehicle);
        void UpdateVehicles(int id);
        T GetVehicle(int id);
        List<T> GetVehicles();
    }
}
