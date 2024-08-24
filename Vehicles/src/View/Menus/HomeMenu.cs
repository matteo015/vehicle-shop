using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using static VEHICLE_SHOP.Vehicles.src.Utils.ConsoleUtils;


namespace VEHICLE_SHOP.Vehicles.src.View.Menus
{
    internal class HomeMenu : Menu
    {
        private string[] _LocalOptions = { "Shop", "Repository", "About", "Exit" };
        public HomeMenu()
        {
            ConsoleMenuType = ConsoleTitle + "HOME";
            MenuLogo =
                "▒░▒▒░▒░░█░█░█▀▀░█░█░▀█▀░█▀▀░█░▒▒█▀▀░░█▀▀░█░█░█▀█░█▀█░░▒▒▒░▒\r\n" +
                "░░▒░▒░▒░▀▄▀░█▀▀░█▀█░░█░░█░░░█░░▒█▀▀▒░▀▀█░█▀█░█░█░█▀▀░▒▒░▒░░\r\n" +
                "░▒▒▒░▒▒░▒▀░░▀▀▀░▀░▀░▀▀▀░▀▀▀░▀▀▀▒▀▀▀░░▀▀▀░▀░▀░▀▀▀░▀░░░░▒▒░▒░\r";
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
            ConsoleMemUsage();
        }
        public override void RunMenu()
        {
            while (true)
            {
                switch (base.GetUserOption())
                {
                    case 0:
                        VehicleShop.UserMenu.RunMenu();
                        break;
                    case 1:
                        VehicleShop.RepoOperations.RunMenu();
                        break;
                    case 2:
                        Clear();
                        Write(FYELLOW+VehicleShop.readme);
                        ReadKey(true);
                        break;
                    case 3:
                        QuitConsole();
                        break;
                }
            }
        }
    }
}