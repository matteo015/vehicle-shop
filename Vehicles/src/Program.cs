using VEHICLE_SHOP.Vehicles.src.View.Menus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using VEHICLE_SHOP.Vehicles.src.Model.Base;
using VEHICLE_SHOP.Vehicles.src.Repository;
using VEHICLE_SHOP.Vehicles.src.Model.Derived;
using VEHICLE_SHOP.Vehicles.src.Controller;
using VEHICLE_SHOP.Vehicles.src.View.Vehicles;
using VEHICLE_SHOP.Vehicles.src.Services;
using System.ComponentModel.Design;
using VEHICLE_SHOP.Vehicles.src.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace VEHICLE_SHOP.Vehicles.src
{
    public class VehicleShop
    {
        static internal List<RepositoryClient<Vehicle>>  Stock = new();
        static internal RepositoryClient<Vehicle>? CurrentRepository = null;

        static internal VehicleView View;
        static internal RepositoryController<Vehicle> Controller;

        static internal HomeMenu Home = new HomeMenu();
        static internal ShopMenu UserMenu = new ShopMenu();
        static internal SearchMenu SearchMenu = new SearchMenu();
        static internal RepoOperationsMenu RepoOperations = new RepoOperationsMenu();
        static internal LoadRepoMenu LoadRepo = new LoadRepoMenu();
        static internal EditRepoMenu EditRepoMenu = new EditRepoMenu();
        static internal DeleteRepoMenu DeleteRepoMenu = new DeleteRepoMenu();

        static internal string readme =
@"This project is a 4fun side piece that will be updated and 
improved over time.It has some bugs and the code isn't 
very good yet. But keep in mind, it's all for learning 
purposes.

Version naming - MAJOR.MILESTONE.MINOR.PATCH
                 YEAR.MONTH.DAY
                            
Current version: 0.0.1.0-2024.08.23";



		public VehicleShop(IRepositoryService<Vehicle> repositoryService)
		{
			Controller = new RepositoryController<Vehicle>(CurrentRepository, repositoryService);
		}
		public void Start()
        {
            Stock.Add(new RepositoryClient<Vehicle>());
			Stock.Add(new RepositoryClient<Vehicle>());
			Stock.Add(new RepositoryClient<Vehicle>());
            Console.WindowWidth = 59;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Home.RunMenu();
        }
	}
    static class Program
    {
        public static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var provider = services.BuildServiceProvider();

            RepositoryService<Vehicle> repositoryService = provider.GetRequiredService<RepositoryService<Vehicle>>();
            VehicleShop Shop = new VehicleShop(repositoryService);

			Shop.Start();

        }

		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<IRepositoryClient<Vehicle>, RepositoryClient<Vehicle>>();
			services.AddScoped<RepositoryService<Vehicle>>();
		}
	}
}