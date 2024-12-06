using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Model.Base;

namespace VEHICLE_SHOP.Vehicles.src.Repository
{
    public interface IRepositoryClient<T> where T : Vehicle
    {
        public void AddItem(T item);
        public void DeleteItem(T item);
        public void DeleteItem(int id);
        public void ReadItem(T item);
        public void UpdateItem(T item, T updatedItem);
        public void UpdateItem(int id, T updatedItem);
        public T GetItem(T item);
        public T GetItem(int id);
        public List<T> GetRepo();
    }
}
