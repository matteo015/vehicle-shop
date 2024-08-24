using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;
using VEHICLE_SHOP.Vehicles.src.Controller;
using static VEHICLE_SHOP.Vehicles.src.Utils.ConsoleUtils;

namespace VEHICLE_SHOP.Vehicles.src.Model.Base
{
    public abstract class Menu
    {
        static public string ConsoleTitle { get; private set; } = "PERKSHOP - ";
        protected string ConsoleMenuType;
        protected string? MenuLogo;
        protected List<String> MenuOptions;
        protected int SelectedOption;

        protected virtual void DisplayTitle()
        {
            WriteLine(MenuLogo);
        }
        protected virtual void DisplayOptions(string prefix)
        {
            WriteLine();
            for (int i = 0; i < MenuOptions.Count(); i++)
            {
                string currentOption = MenuOptions[i];

                if (i == this.SelectedOption)
                {
                    WriteLine($"{BYELLOW}{FBLACK}{prefix}{FYELLOW}{RESET}{FYELLOW}|" +
                              $"{FBLACK}{BYELLOW}{currentOption.PadLeft(currentOption.Length + 3).PadRight(currentOption.Length + 5)}");
                }
                else
                {
                    WriteLine($"{FWHITE}{BBLACK}{prefix}{currentOption.PadLeft(currentOption.Length + 3).PadRight(25)}");
                }
            }
            ResetColor();
        }
        protected abstract void UpdateScreenBuffer();
        public virtual int GetUserOption()
        {
            this.SelectedOption = 0;
            UpdateScreenBuffer();
            bool running = true;
            while (running)
            {
                switch (ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        Beep();
                        Clear();
                        running = false;
                        break;
                    case ConsoleKey.UpArrow:
                        SelectedOption--;
                        if (SelectedOption < 0)
                            SelectedOption = MenuOptions.Count() - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        SelectedOption++;
                        if (SelectedOption >= MenuOptions.Count())
                            SelectedOption = 0;
                        break;
                }
                UpdateScreenBuffer();
            }
            return SelectedOption;
        }
        public abstract void RunMenu();
    }
}