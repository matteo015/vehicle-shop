using static VEHICLE_SHOP.Vehicles.src.Utils.ConsoleUtils;
using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using VEHICLE_SHOP.Vehicles.src.Repository;

namespace VEHICLE_SHOP.Vehicles.src.View.Menus
{
    internal class RepoOperationsMenu : Menu
    {
        private string[] _LocalOptions = { "EDIT REPO", "LOAD REPO", "DELETE REPO", "Back" };
        public int currentRepoId { get; set; }
        public RepoOperationsMenu()
        {
            ConsoleMenuType = ConsoleTitle + "REPOSITORY";
            MenuLogo =
            "░█▀▄░█▀▀░█▀█░█▀█░░░█▀█░█▀█░█▀▀░█▀▄░█▀█░▀█▀░▀█▀░█▀█░█▀█░█▀▀\n" +
            "░█▀▄░█▀▀░█▀▀░█░█░░░█░█░█▀▀░█▀▀░█▀▄░█▀█░░█░░░█░░█░█░█░█░▀▀█\n" +
            "░▀░▀░▀▀▀░▀░░░▀▀▀░░░▀▀▀░▀░░░▀▀▀░▀░▀░▀░▀░░▀░░▀▀▀░▀▀▀░▀░▀░▀▀▀\n";
            MenuOptions = _LocalOptions.ToList();
            SelectedOption = 0;
        }
        protected override void DisplayTitle()
        {
            ForegroundColor = ConsoleColor.Yellow;
            base.DisplayTitle();
            ResetColor();
        }

        private void DisplayCurrentRepo()
        {
            WriteLine($"{BWHITE}>{RESET} {BYELLOW}{FBLACK} EDITING: repo~ID:" + "{0}"
                    ,(currentRepoId == 0  || !VehicleShop.Stock.Exists(x=> x._repoId == currentRepoId)) ? " NO REPO SELECTED..." : currentRepoId);
        }

        protected override void UpdateScreenBuffer()
        {
            Clear();
            DisplayTitle();
            DisplayCurrentRepo();
            DisplayOptions("");
        }

        /*public void LoadRepository(VehicleRepository repository)
        {
            VehicleShop.CurrentRepo = repository;
            currentRepoId = repository._repoId;
        }*/
        public override void RunMenu()
        {
            while (true)
            {
                switch (base.GetUserOption())
                {
                    case 0:
                        if(VehicleShop.CurrentRepository == null)
                        {
                            Clear();
                            DisplayTitle();
                            DisplayCurrentRepo();
                            WriteLine($"\n{BWHITE}>{RESET} {BRED}{FWHITE} UNABLE TO EDIT. NO REPO SELECTED! {RESET}");
                            Thread.Sleep(1500);
                            break;
                        }
                        VehicleShop.EditRepoMenu.RunMenu();
                        break;
                    case 1:
                        VehicleShop.LoadRepo.RunMenu();
                        break;
                    case 2:
                        VehicleShop.DeleteRepoMenu.RunMenu();
                        break;
                    case 3:
                        return;
                }
            }
        }
    }
}
