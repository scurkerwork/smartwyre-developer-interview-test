using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.IoC;
using System;

namespace Smartwyre.DeveloperTest.Runner
{
	public static class Startup
	{
		private static IServiceProvider _serviceProvider;
		public static IConfiguration Configuration { get; private set; }

		public static void Start()
		{
			var service = new ServiceCollection();

			var config = service.AddConfiguration();
			service.AddSmartwyreDataStores();
			service.AddSmartwyreServices();
			service.AddSmartwyreDbContext(config, "RebateDb");

			_serviceProvider = service.BuildServiceProvider();
			Configuration = config;

		}

		public static TService GetService<TService>() => _serviceProvider.GetService<TService>();
	}
}
