using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Tests.Fakes;
using System;

namespace Smartwyre.DeveloperTest.Tests
{
	public static class Startup
	{
		private static IServiceProvider _serviceProvider;

		public static void Start()
		{
			var services = new ServiceCollection();

			services.AddScoped<IRebateDataStore, FakeRebateDataStore>();
			services.AddScoped<IProductDataStore, FakeProductDataStore>();

			services.AddScoped<IRebateCalculationStrategyFactory, RebateCalculationStrategyFactory>();
			services.AddScoped<IRebateService, RebateService>();

			_serviceProvider = services.BuildServiceProvider();
		}

		public static TService GetService<TService>() => _serviceProvider.GetService<TService>();
	}
}
