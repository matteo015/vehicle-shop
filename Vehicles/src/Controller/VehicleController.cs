﻿using System;
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
    public class VehicleController<T> where T : Vehicle
    {
        private VehicleRepository<T> repository;
        private readonly IVehicleView<T> view;
        private readonly IVehicleService<T> service;

        public VehicleController(VehicleRepository<T> repo) 
        {
            this.repository = repo;
            service = new(repo);
        }

        public void LoadFromStock(IRepo<T> repositoryToLoad)
        {
            VehicleShop.CurrentRepository = repositoryToLoad as VehicleRepository<Vehicle>;
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