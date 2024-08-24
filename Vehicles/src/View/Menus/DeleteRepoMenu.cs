using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using static VEHICLE_SHOP.Vehicles.src.Utils.ConsoleUtils;
using static System.Console;

namespace VEHICLE_SHOP.Vehicles.src.View.Menus
{
    internal class DeleteRepoMenu : Menu
    {
        private List<String> Ids = new List<String>();

        public DeleteRepoMenu()
        {
            ConsoleMenuType = ConsoleTitle + "REPOSITORY { delete mode }";
            MenuLogo = $"{BYELLOW}{FBLACK}{BOLD}KNOWN REPOSITORIES.";
            SelectedOption = 0;
        }
        protected override void UpdateScreenBuffer()
        {
            Clear();
            DisplayTitle();
            DisplayOptions(" ID# ");
        }
        public override void RunMenu()
        {
            if (!VehicleShop.Stock.Any())
            {
                Write($"\n{BYELLOW}{FBLACK}{BOLD} THERE ARE NO REPOSITORIES AVAILABLE ON STOCK. {RESET}");
                Thread.Sleep(1500);
                return;
            }

            VehicleShop.Stock.ForEach(x => Ids.Add(x._repoId.ToString()));
            MenuOptions = Ids;
            int SelectedId = Convert.ToInt32(Ids[GetUserOption()]);
            Ids.Clear();

            if (!DeleteMessageValidation(SelectedId.ToString()))
                return;

            if (VehicleShop.CurrentRepo == VehicleShop.Stock.Find(x => x._repoId == SelectedId))
                VehicleShop.CurrentRepo = null;
            VehicleShop.Stock.Remove(
                VehicleShop.Stock.Find(x => x._repoId == SelectedId));
        }
    }
}