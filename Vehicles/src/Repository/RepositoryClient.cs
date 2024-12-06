using static System.Console;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VEHICLE_SHOP.Vehicles.src.Utils.ConsoleUtils;
using VEHICLE_SHOP.Vehicles.src.Model.Base;

namespace VEHICLE_SHOP.Vehicles.src.Repository
{
    public class RepositoryClient<T> : IRepositoryClient<T> where T : Vehicle
    {
        private static int ID = 0;
        public int _repoId { get; protected set; }
        public readonly List<T> _vehicles;

        public RepositoryClient()
        {
            _repoId = ID++;
            _vehicles = new List<T>();
        }

        public RepositoryClient(int existingId, List<T> existingRepository)
        {
            _repoId = existingId;
            _vehicles = existingRepository;
        }
        //METHODS
        public void AddItem(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (_vehicles.Contains(item))
                throw new ArgumentException();
            _vehicles.Add(item);
        }

        public void DeleteItem(T item)
        {
            if (item is null) 
                throw new ArgumentNullException
                          ($"{FRED}Unable to delete [ {nameof(item)} ] (NULL){RESET}");

            if (!_vehicles.Contains(item))
                throw new KeyNotFoundException();
            _vehicles.Remove(item);
        }

        public void DeleteItem(int id)
        {
            if(!_vehicles.Remove(GetItem(id)))
                throw new ApplicationException();
        }

        public T GetItem(T item)
        {
            if (item is null)
                throw new ArgumentNullException();

            T vehicle = _vehicles.Find(v => v.Equals(item)) ?? throw new KeyNotFoundException(nameof(vehicle));
            return vehicle;
        }

        public T GetItem(int id)
        {
            return _vehicles.Find(v => v.VehicleId == id) ?? throw new KeyNotFoundException();
        }
        public void UpdateItem(T item, T updatedItem)
        {
            if(_vehicles.Contains(item))
            {
                DeleteItem(item);
                AddItem(updatedItem);
            }
        }

        public void UpdateItem(int id, T updatedItem)
        {
            if (_vehicles.Contains(GetItem(id)))
            {
                DeleteItem(GetItem(id));
                AddItem(updatedItem);
            }
        }

        public void ReadItem(T item)
        {
            
        }

        public List<T> GetRepo()
        {
            return _vehicles;
        }
    }
}