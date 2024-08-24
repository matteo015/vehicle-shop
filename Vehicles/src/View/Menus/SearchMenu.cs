using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static VEHICLE_SHOP.Vehicles.src.Utils.ConsoleUtils;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using VEHICLE_SHOP.Vehicles.src.Controller;
using VEHICLE_SHOP.Vehicles.src.Repository;
namespace VEHICLE_SHOP.Vehicles.src.View.Menus
{
    internal class SearchMenu : Menu
    {
        private string[] _LocalOptions = { "SEARCH BY : ID", "SEARCH BY : MAKE",
                                 "SEARCH BY : MODEL", "SEARCH BY : YEAR","Back" };
        public SearchMenu()
        {
            ConsoleMenuType = ConsoleTitle + "USER - SEARCH";
            MenuLogo =
                "░░░░░░░░█░░░█▀█░█▀█░█░█░▀█▀░█▀█░█▀▀░░░█▀▀░█▀█░█▀▄░░░░░░░░░░\n" +
                "░░░░░░░░█░░░█░█░█░█░█▀▄░░█░░█░█░█░█░░░█▀▀░█░█░█▀▄░░░░░░░░░░\n" +
                "░░░░░░░░▀▀▀░▀▀▀░▀▀▀░▀░▀░▀▀▀░▀░▀░▀▀▀░░░▀░░░▀▀▀░▀░▀░▀░░▀░░▀░░\n";
            MenuOptions = _LocalOptions.ToList();
        }

        protected override void DisplayTitle()
        {
            ForegroundColor = ConsoleColor.Yellow;
            base.DisplayTitle();
            ResetColor();
        }

        protected override void UpdateScreenBuffer()
        {
            Clear();
            DisplayTitle();
            DisplayOptions("");
        }

        public override void RunMenu()
        {
            while (true)
            {
                Vehicle? src = null;
                VehicleRepo? srcList = null;
                switch (base.GetUserOption())
                {
                    case 0:
                        Clear();
                        DisplayTitle();
                        src = SearchController.SearchId(VehicleShop.CurrentRepo);
                        if (src is null)
                        {
                            Error("VEHICLE NOT FOUND");
                            Thread.Sleep(500);
                            break;
                        }
                        else
                            VehicleShop.CurrentRepo.ReadItem(src);
                        ReadKey(true);
                        break;
                    case 1:
                        Clear();
                        DisplayTitle();
                        srcList = SearchController.SearchMake(VehicleShop.CurrentRepo);
                        if (srcList is null)
                        {
                            Error("VEHICLE NOT FOUND");
                            Thread.Sleep(500);
                            break;
                        }
                        RepoController.ShowRepo(srcList);
                        ReadKey(true);
                        break;
                    case 2:
                        Clear();
                        DisplayTitle();
                        srcList = SearchController.SearchModel(VehicleShop.CurrentRepo);
                        if (srcList is null)
                        {
                            Error("VEHICLE NOT FOUND");
                            Thread.Sleep(500);
                            break;
                        }
                        RepoController.ShowRepo(srcList);
                        ReadKey(true);
                        break;
                    case 3:
                        Clear();
                        DisplayTitle();
                        srcList = SearchController.SearchYear(VehicleShop.CurrentRepo);
                        if (srcList is null)
                        {
                            Error("VEHICLE NOT FOUND");
                            Thread.Sleep(500);
                            break;
                        }
                        RepoController.ShowRepo(srcList);
                        ReadKey(true);
                        break;
                    case 4:
                        return;
                }
            }
        }
    }
}