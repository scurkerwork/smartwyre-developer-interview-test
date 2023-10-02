using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Data.DbContext;
using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Services;

namespace Smartwyre.DeveloperTest.IoC
{
    public static class SmartwyreIoCExtensions
	{
		public static IConfiguration AddConfiguration(this IServiceCollection services)
		{
			var builder = new ConfigurationBuilder();

			var config = 
				builder
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json")
					.Build();

			services.AddSingleton<IConfiguration>(config);

			return config;
		}

		public static void AddSmartwyreDbContext(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
		{
			services.AddDbContext<SmartwyreDbContext>(options =>
			{
				var connectioString = configuration.GetConnectionString(connectionStringName);
				options.UseSqlServer(connectioString);
			});
		}

		public static void AddSmartwyreDataStores(this IServiceCollection services)
		{
			services.AddScoped<IRebateDataStore, RebateDataStore>();
			services.AddScoped<IProductDataStore, ProductDataStore>();
		}

		public static void AddSmartwyreServices(this IServiceCollection services)
		{
			services.AddScoped<IRebateCalculationStrategyFactory, RebateCalculationStrategyFactory>();
			services.AddScoped<IRebateService, RebateService>();
		}
	}
}
