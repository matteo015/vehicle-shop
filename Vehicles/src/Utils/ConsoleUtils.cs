using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace VEHICLE_SHOP.Vehicles.src.Utils
{
    internal static class ConsoleUtils
    {
        public static string NL = Environment.NewLine; // shortcut
        public static string DEFAULT = IsOutputRedirected ? "" : "\x1b[39m";
        public static string RESET = IsOutputRedirected ? "" : "\x1b[0m";
        public static string BOLD = IsOutputRedirected ? "" : "\x1b[22m";  //nobold"\x1b[1m";
        public static string NOBOLD = IsOutputRedirected ? "" : "\x1b[1m";
        public static string UNDERLINE = IsOutputRedirected ? "" : "\x1b[4m";
        public static string NOUNDERLINE = IsOutputRedirected ? "" : "\x1b[24m";
        public static string REVERSE = IsOutputRedirected ? "" : "\x1b[7m";
        public static string NOREVERSE = IsOutputRedirected ? "" : "\x1b[27m";
        public static string FRED = IsOutputRedirected ? "" : "\x1b[91m";
        public static string FGREEN = IsOutputRedirected ? "" : "\x1b[92m";
        public static string FYELLOW = IsOutputRedirected ? "" : "\x1b[93m";
        public static string FBLUE = IsOutputRedirected ? "" : "\x1b[94m";
        public static string FMAGENTA = IsOutputRedirected ? "" : "\x1b[95m";
        public static string FCYAN = IsOutputRedirected ? "" : "\x1b[96m";
        public static string FGREY = IsOutputRedirected ? "" : "\x1b[97m";
        public static string FWHITE = IsOutputRedirected ? "" : "\x1b[97m";
        public static string FBLACK = IsOutputRedirected ? "" : "\x1b[30m";
        public static string BRED = IsOutputRedirected ? "" : "\x1b[101m";
        public static string BGREEN = IsOutputRedirected ? "" : "\x1b[102m";
        public static string BYELLOW = IsOutputRedirected ? "" : "\x1b[103m";
        public static string BBLUE = IsOutputRedirected ? "" : "\x1b[104m";
        public static string BMAGENTA = IsOutputRedirected ? "" : "\x1b[105m";
        public static string BCYAN = IsOutputRedirected ? "" : "\x1b[106m";
        public static string BGREY = IsOutputRedirected ? "" : "\x1b[107m";
        public static string BWHITE = IsOutputRedirected ? "" : "\x1b[107m";
        public static string BBLACK = IsOutputRedirected ? "" : "\x1b[40m";
        public static void QuitConsole()
        {
            Clear();
            Beep();
            Environment.Exit(0);
        }
        public static void ConsoleMemUsage()
        {
            WriteLine("\nMem usage:{0}mb", (float)Process.GetCurrentProcess().PrivateMemorySize64 / 1_000_000);
        }

        public static void Error(string message) 
        {
            WriteLine($"\n{BRED}>{BOLD}{FWHITE} {message} {RESET}");
        }

        public static bool DeleteMessageValidation(string item)
        {
            WriteLine($"\n {BRED} >{BOLD}{FWHITE} ARE YOU SURE YOU WANT TO DELETE: {item} ? [Y/N] {RESET}");
            switch(ReadKey().Key)
            {
                case ConsoleKey.Y:
                    return true;
                case ConsoleKey.N:
                    return false;
            }
            return false;
        }
    }
}
