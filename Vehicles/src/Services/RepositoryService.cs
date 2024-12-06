using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using VEHICLE_SHOP.Vehicles.src.Repository;

namespace VEHICLE_SHOP.Vehicles.src.Services
{
    public class RepositoryService<T>(IRepositoryClient<T> repository) : IRepositoryService<T> where T : Vehicle
    {
        private IRepositoryClient<T> _repository = repository;

        public void LoadRepository(IRepositoryClient<T> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void AddVehicle(T vehicle)
        { 
            if(vehicle is null)
                throw new ArgumentNullException($"{nameof(vehicle)} is null");
            if (!vehicle.Valid())
                throw new InvalidDataException($"Invalid data");

            try
            {
                repository.AddItem(vehicle);
            }
            catch 
            {
                throw new Exception($"Error: Couldn't add {nameof(vehicle)}");
            }
        }
        public T GetVehicle(int id)
        { 
            if(id < 0)
                throw new ArgumentOutOfRangeException("Error: Invalid ID");
            try
            {
                return repository.GetItem(id);
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        } 
        public List<T> GetVehicles() => repository.GetRepo();

        public void RemoveVehicle(T vehicle) 
        {
            if (vehicle is null)
                throw new ArgumentNullException($"{nameof(vehicle)} is null");
            if (!vehicle.Valid())
                throw new InvalidDataException($"Error: Invalid data");
            try
            {
                repository.DeleteItem(vehicle);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new ApplicationException("Error: An unknow error has occured");
            }
        }
        public void RemoveVehicle(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException("Error: Invalid ID");
            try
            {
                repository.DeleteItem(id);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new ApplicationException("Error: An unknow error has occured");
            }
        }

        public void UpdateVehicle(T vehicle)
        {
            throw new NotImplementedException();
        }

        public void UpdateVehicles(int id)
        {
            throw new NotImplementedException();
        }
    }
}
