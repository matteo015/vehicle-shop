using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using VEHICLE_SHOP.Vehicles.src.Repository;
using VEHICLE_SHOP.Vehicles.src.Utils;
using VEHICLE_SHOP.Vehicles.src.View.Menus;
using static VEHICLE_SHOP.Vehicles.src.Utils.ConsoleUtils;

namespace VEHICLE_SHOP.Vehicles.src.Controller
{
    static internal class RepoController
    {
        static public void ShowRepo(RepositoryClient<Vehicle>? Repo)
        {
            if (Repo is null)
            {
                Console.WriteLine($"\n  {BYELLOW}{FBLACK}> Sorry... There is no vehicles available for now.     {RESET}");
                return;
            }
            if(!Repo._vehicles.Any()) 
            {
                Console.WriteLine($"\n  {BYELLOW}{FBLACK}> Sorry... There is no vehicles available for now.     {RESET}");
                return;
            }
            foreach (var item in Repo._vehicles)
                Repo.ReadItem(item);
        }

        static public void InsertVehicle(RepositoryClient<Vehicle> destRepo)
        {
            string type;
            Console.Write($"{BOLD}{BBLUE}{FWHITE}VEHICLE TYPE:{RESET} {BYELLOW}{FBLACK}");
            type = Console.ReadLine()
                ?? throw new ArgumentNullException(nameof(type));
            Console.WriteLine(RESET);

            Vehicle vehicle = VehicleUtils.NewVehicle(type) 
                ?? throw new ArgumentNullException(nameof(vehicle));

            destRepo.AddItem(vehicle);

            Console.Clear();
            Console.Write($"\n{BOLD}{FGREEN}ADDED:  " +
                          $"{FWHITE}{vehicle.Name} "  +
                          $"{FGREEN} SUCESSFULLY!{RESET}");
            Thread.Sleep(1000);
        }

        static public void InsertVehicle(RepositoryClient<Vehicle> destRepo, Vehicle? srcVehicle)
        {
            if(srcVehicle == null)
            {
                Console.WriteLine($">{FRED} Fatal error: Unable to insert vehicle into REPOSITORY [ID]:" +
                                  $"{FYELLOW} {destRepo._repoId}{RESET}\n");
                throw new ArgumentNullException($"{FRED}{nameof(srcVehicle)}{RESET}");
            }
            destRepo.AddItem(srcVehicle);
        }

        static public void RemoveVehicle(RepositoryClient<Vehicle> srcRepo)
        {
            Vehicle? vehicle = SearchController.SearchId(srcRepo);
            if(vehicle == null)
                throw new ArgumentNullException($"{FRED}FAILED TO DELETE: {nameof(vehicle)}, DOESN'T EXISTS{RESET}");

            if (!DeleteMessageValidation($"{vehicle.Name}"))
                return;

            srcRepo.DeleteItem(vehicle);
            Console.WriteLine($"\n >{FRED}{BOLD}DELETED: "          +
                              $"{FYELLOW}{vehicle.Name.ToUpper()} " +
                              $"{FRED} SUCESSFULLY!{RESET}");
            Thread.Sleep(1250);
        }

        static public void ShowVehicle(RepositoryClient<Vehicle> repo, Vehicle item)
        {
            repo.ReadItem(item);
        }
    }
}