using static System.Console;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VEHICLE_SHOP.Vehicles.src.Utils.ConsoleUtils;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using VEHICLE_SHOP.Vehicles.src.Model.Derived;
using VEHICLE_SHOP.Vehicles.src.View.Vehicles;

namespace VEHICLE_SHOP.Vehicles.src.Repository
{
    internal class VehicleRepo : IRepo<Vehicle>
    {
        private static CarView _carView = new CarView();

        public int _repoId { get; protected set; }
        public readonly List<Vehicle> _vehicles;

        //CONSTRUCTORS
        public VehicleRepo(int id)
        {
            _repoId = id;
            _vehicles = new List<Vehicle>();
        }

        public VehicleRepo(int id,List<Vehicle> vehicles)
        {
            _repoId = id;
            _vehicles = vehicles ?? throw new ArgumentNullException(nameof(vehicles));
        }

        //METHODS
        public void AddItem(Vehicle item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (_vehicles.Contains(item))
            {
                WriteLine($"{FRED}>{nameof(item.Name)} Already exist, unable to add...{RESET}");
                return;
            }
            _vehicles.Add(item);
        }

        public void ReadItem(Vehicle item)
        {
            if (item == null)
            {
                throw new ArgumentNullException
                          ($"{FRED}Unable to read [ {nameof(item)} ] (NULL){RESET}");
            }
            if (item is Car car)
            {
                WriteLine(_carView.GetDetails(item));
                WriteLine(_carView.GetEngineDetails(item));
            }
        }

        public void DeleteItem(Vehicle item)
        {
            if (item == null) 
            { 
                throw new ArgumentNullException
                          ($"{FRED}Unable to delete [ {nameof(item)} ] (NULL){RESET}");
            }
            if (!_vehicles.Contains(item))
            {
                WriteLine($"{nameof(item)} Doesn't exist");
                throw new ArgumentException($"{FRED}{nameof(item)} Doesn't exists {RESET}.");
            }
            _vehicles?.Remove(item);
        }

        public Vehicle GetItem(Vehicle item)
        {
            if (item == null)
            {
                throw new ArgumentNullException
                           ($"{FRED}Unable to get [ {nameof(item)} ] (NULL){RESET}");
            }

            Vehicle src = _vehicles.Find(x => x.Equals(item)) ?? throw new ArgumentNullException(nameof(src));
            return src;
        }

        public void UpdateItem(Vehicle item)
        {
            if(_vehicles.Contains(item))
            {
                _vehicles.Remove(item);
            }
        }

        public List<Vehicle> GetRepo()
        {
            return _vehicles;
        }
    }
}