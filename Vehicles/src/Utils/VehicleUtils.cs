using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using VEHICLE_SHOP.Vehicles.src.Model.Derived;
using static VEHICLE_SHOP.Vehicles.src.Utils.ConsoleUtils;

namespace VEHICLE_SHOP.Vehicles.src.Utils
{
    internal class VehicleUtils
    {
        static public Vehicle? NewVehicle(string type)
        {
            Vehicle vehicle;
            switch (type.ToUpper())
            {
                case "CAR":
                    vehicle = CreateCar();
                    return vehicle;
            }
            Error("INVALID CAR TYPE.TRY AGAIN.");
            Thread.Sleep(1000);
            return null;
        }

        static private Engine? NewEngine(string type) 
        {
            switch (type.ToUpper())
            {
                case "DIESEL":
                    return new Engine();
                case "PETROL":
                    return new Engine();
                case "ELETRIC":
                    return new Engine();
                case "HYBRID":
                    return new Engine();
                case "GAS":
                    return new Engine();
            }
            Console.WriteLine($"> {FRED}INVALID ENGINE TYPE. TRY AGAIN.");
            return null;
        }


        static private Car CreateCar()
        {
            string? uInput;
            string[] carInfo;
            Console.Write($" \nINFORM:{FYELLOW} MAKE,NAME, MODEL, YEAR and {FGREEN}PRICE. " +
                          $"\n{FWHITE}Separated by {FCYAN}',' " +
                          $"\n- >{FWHITE}");
            uInput = Console.ReadLine();
            if (uInput == null) 
                throw new ArgumentNullException(nameof(uInput));            
            carInfo = uInput.Split(',');
            if(carInfo.Length >= 6)
            {
                Console.Clear();
                Console.WriteLine($">{FRED} Fatal error: {FYELLOW}Too many arguments for vehicle constructor\n");
                throw new ArgumentOutOfRangeException($"{FRED}{nameof(carInfo)}{RESET}");
            }
            if(carInfo.Length < 5)
            {
                Console.Clear();
                Console.WriteLine($">{FRED} Fatal error: Too little arguments to create vehicle\n");
                throw new ArgumentOutOfRangeException($"{FRED}{nameof(carInfo)}{RESET}");
            }
            return new Car(carInfo[0],
                           carInfo[1],
                           carInfo[2],
                           Convert.ToUInt16(carInfo[3]),
                           Convert.ToDecimal(carInfo[4]),
                           null, 2);
        }

    }
}
