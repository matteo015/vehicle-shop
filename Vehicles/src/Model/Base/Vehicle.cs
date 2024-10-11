using VEHICLE_SHOP.Vehicles.src.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Controller;

namespace VEHICLE_SHOP.Vehicles.src.Model.Base
{
    public abstract class Vehicle
    {
        static private int _Id = 0;
        public int VehicleId { get; protected set; }
        public string Name { get; protected set; } = "Default";
        public string Make { get; protected set; } = "Default";
        public string Model { get; protected set; } = "Default";
        public decimal Price { get; protected set; }
        public UInt16 Year { get; protected set; }
        public Engine? Engine;

        protected Vehicle(string name,
                          string make,
                          string model,
                          decimal price,
                          UInt16 year,
                          Engine? vehicleEngine)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Make = make ?? throw new ArgumentNullException(nameof(make));
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Price = price;
            Year = year;
            Engine = vehicleEngine;
            VehicleId = _Id++;
        }

        public virtual bool Valid()
        {
            return !string.IsNullOrEmpty(Name)  && 
                   !string.IsNullOrEmpty(Make)  &&
                   !string.IsNullOrEmpty(Model) &&
                   Year      > 0 &&
                   VehicleId > 0;
        }
    }
}
