using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using static VEHICLE_SHOP.Vehicles.src.Utils.ConsoleUtils;
using static VEHICLE_SHOP.Vehicles.src.Controller.RepositoryControllerView;

namespace VEHICLE_SHOP.Vehicles.src.View.Menus
{
    internal class EditRepoMenu : RepoOperationsMenu
    {
        private string[] _LocalOptions = {"ADD VEHICLE", "REMOVE VEHICLE" ,"EDIT VEHICLE", "Back"};
        public EditRepoMenu() 
        {
            ConsoleMenuType = ConsoleTitle + "REPOSITORY - {edit mode}";
            MenuOptions = _LocalOptions.ToList();
            SelectedOption = 0;
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
                switch (base.GetUserOption())
                {
                    case 0:
                        Clear();
                        Write($"{BOLD}{BYELLOW}{FBLACK} ALREADY EXISTS? [Y/N]:{RESET} ");
                        switch (ReadKey().Key)
                        {
                            case ConsoleKey.Y:
                                Clear();
                                Write($"{BOLD}{BYELLOW}{FBLACK} UNIMPLEMENTED EXECEPTION.{RESET} ");
                                break;
                            case ConsoleKey.N:
                                Clear();
                                InsertVehicle(VehicleShop.CurrentRepository);
                                break;
                            default:
                                WriteLine($"{FRED} INVALID INPUT.");
                                Thread.Sleep(2000);
                                break;
                        }
                        break;
                    case 1:
                        Clear();
                        DisplayTitle();
                        RemoveVehicle(VehicleShop.CurrentRepository);
                        break;
                    case 2:

                    case 3:
                        return;
                }
            }
        }
    }
}
