using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using static VEHICLE_SHOP.Vehicles.src.Utils.ConsoleUtils;
using VEHICLE_SHOP.Vehicles.src.Controller;

namespace VEHICLE_SHOP.Vehicles.src.View.Menus
{

    internal class ShopMenu : Menu

    {
        private string[] _LocalOptions = { "Search", "Show Stock", "Back" };
        public ShopMenu()
        {
            ConsoleMenuType = ConsoleTitle + "USER";
            MenuLogo =
                "▒░▒░▒░▒▒░▒░░░█▀▀░█░█░█▀█░█▀█░░░█░█░█▀█░█▄█░█▀▀░░▒▒▒░▒░▒▒░▒░\n" +
                "▒▒░▒░░▒░▒░▒░░▀▀█░█▀█░█░█░█▀▀░░░█▀█░█░█░█░█░█▀▀░▒▒░▒░░░▒░▒░▒\n" +
                "░░▒░░▒▒▒░▒▒░▒▀▀▀░▀░▀░▀▀▀░▀░░░░░▀░▀░▀▀▀░▀░▀░▀▀▀░░░░▒▒░▒░░░▒░";
            MenuOptions = _LocalOptions.ToList();
            SelectedOption = 0;
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
                switch (base.GetUserOption())
                {
                    case 0:
                        VehicleShop.SearchMenu.RunMenu();
                        break;
                    case 1:
                        Clear();
                        DisplayTitle();
                    //RepoController.ShowRepo(VehicleShop.CurrentRepository);
                    VehicleShop.Controller.ReadRepository();
                        ReadKey();
                        break;
                    case 2:
                        return;
                }
            }
        }
    }
}
