using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using VEHICLE_SHOP.Vehicles.src.Repository;
using VEHICLE_SHOP.Vehicles.src.Services;
using VEHICLE_SHOP.Vehicles.src.View.Vehicles;

namespace VEHICLE_SHOP.Vehicles.src.Controller
{
    public class RepositoryController<T>(IRepositoryClient<T> repositoryClient,
                                         IRepositoryService<T> repositoryService) where T : Vehicle
    {
        private RepositoryClient<T> repository = (RepositoryClient<T>)repositoryClient;
        private readonly IVehicleView<T> view;
        private readonly IRepositoryService<T> service = repositoryService;

        public void LoadFromStock(IRepositoryClient<T> repositoryToLoad)
        {
            service.LoadRepository(repositoryToLoad);

            VehicleShop.CurrentRepository = repositoryToLoad as RepositoryClient<Vehicle>;
            VehicleShop.RepoOperations.currentRepoId = VehicleShop.CurrentRepository._repoId;
        }

        public void ReadVehicle(T vehicle)
        {
            view.GetDetails(vehicle);
        }

        public void ReadRepository()
        {
            repository._vehicles.ForEach(vehicle => { ReadVehicle(vehicle);});
        }

        public void AddVehicle(T vehicle)
        {
            try
            {
                service.AddVehicle(vehicle);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Unable to add " + ex.Message + " is null!");
                return;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Unable to add, vehicle already added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to add, invalid data.");
            }
            Console.WriteLine("Added!");
        }

        public void RemoveVehicle(T vehicle)
        {
            try
            {
                service.RemoveVehicle(vehicle);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Unable to remove vehicle, doesn't exists or already removed!");
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to remove, invalid vehicle");
            }
        }
        public void RemoveVehicle(int vehicleId)
        {
            try
            {
                service.RemoveVehicle(vehicleId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to remove. Invalid Id or else.");
            }
        }
    }
}