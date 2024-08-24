using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEHICLE_SHOP.Vehicles.src.Repository
{
    internal interface IRepo<T> where T : class
    {
        public void AddItem(T item);
        public void DeleteItem(T item);
        public void UpdateItem(T item);
        public void ReadItem(T item);
        public T GetItem(T item);
        public List<T> GetRepo();
    }
}
