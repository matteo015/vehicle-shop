using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using VEHICLE_SHOP.Vehicles.src.Repository;
using static VEHICLE_SHOP.Vehicles.src.Utils.ConsoleUtils;

namespace VEHICLE_SHOP.Vehicles.src.Controller
{
    internal class SearchController
    {
        static public Vehicle? SearchId(RepositoryClient<Vehicle>? SourceRepository)
        {
            if (SourceRepository is null)
            {
                Error("Unable to search, repository unloaded");
                Thread.Sleep(1000);
                return null;
            }

            Write($"{BYELLOW}{FBLACK} INSERT VEHICLE ID:{RESET} {BBLUE}{FWHITE}");
            string? input = ReadLine();
            int id;
            if(input is null || !int.TryParse(input, out id))
            {
                Error(" INVALID INPUT. ");
                return null;
            }
            Write(RESET);
            return SourceRepository._vehicles.Find(x => x.VehicleId == id);
        }
        static public RepositoryClient<Vehicle>? SearchMake(RepositoryClient<Vehicle>? SourceRepository)
        {
            if (SourceRepository is null)
            {
                Error("Unable to search, repository unloaded");
                Thread.Sleep(1000);
                return null;
            }

            string? make;
            Write($"{BYELLOW}{FBLACK} INSERT VEHICLE MAKE:{RESET} {BBLUE}{FWHITE}");
            make = ReadLine().ToLower();
            if (make is null)
            {
                Error(" INVALID INPUT. ");
                Thread.Sleep(2000);
                Clear();
                return null;
            }
            Write(RESET);
            return new(-1, SourceRepository._vehicles.FindAll(x => x.Make.ToLower().Equals(make)));
        }

        static public RepositoryClient<Vehicle>? SearchModel(RepositoryClient<Vehicle>? SourceRepository)
        {
            if (SourceRepository is null)
            {
                Error("Unable to search, repository unloaded");
                Thread.Sleep(1000);
                return null;
            }

            string? model;
            Write($"{BYELLOW}{FBLACK} INSERT VEHICLE MODEL:{RESET} {BBLUE}{FWHITE}");
            model = ReadLine().ToLower();
            if (model is null)
            {
                Error(" INVALID INPUT. ");
                Thread.Sleep(2000);
                Clear();
                return null;
            }
            Write(RESET);
            return new(-1, SourceRepository._vehicles.FindAll(x => x.Model.ToLower().Equals(model)));
        }
        static public RepositoryClient<Vehicle>? SearchYear(RepositoryClient<Vehicle>? SourceRepository)
        {
            if (SourceRepository is null)
            {
                Error("Unable to search, repository unloaded");
                Thread.Sleep(1000);
                return null;
            }

            Write($"{BYELLOW}{FBLACK} INSERT VEHICLE PRODUCTION YEAR:{RESET} {BBLUE}{FWHITE}");
            string? input = ReadLine();
            int year;
            if (input is null || !int.TryParse(input, out year))
            {
                Error(" INVALID INPUT. ");
                return null;
            }
            Write(RESET);
            return new(-1, SourceRepository._vehicles.FindAll(x => x.Year == year));
        }
    }
}