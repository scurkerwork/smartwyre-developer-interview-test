using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Enums;
using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Interfaces.Strategies;
using Smartwyre.DeveloperTest.Services.Attributes;
using System.Reflection;

namespace Smartwyre.DeveloperTest.Services
{
	public class RebateCalculationStrategyFactory : IRebateCalculationStrategyFactory
	{
		private readonly Data.IRebateDataStore _rebateDataStore;
		private readonly IProductDataStore _productDataStore;

		public RebateCalculationStrategyFactory(Data.IRebateDataStore rebateDataStore, IProductDataStore productDataStore)
		{
			_rebateDataStore = rebateDataStore;
			_productDataStore = productDataStore;
		}


		public IRebateCalculationStrategy? CreateStrategy(IncentiveType incentiveType)
		{
			var type = 
				GetType()
					.Assembly
					.GetTypes()
					.Where(t => t.GetCustomAttribute<IncentiveTypeAttribute>()?.IncentiveType == incentiveType)
					.FirstOrDefault();

			if (type is null)
				return null;

			var constructor = type.GetConstructor(new[] { typeof(Data.IRebateDataStore), typeof(IProductDataStore) });
			var instance = constructor?.Invoke(new object[] { _rebateDataStore, _productDataStore });

			return instance as IRebateCalculationStrategy;
		}

		public IRebateCalculationStrategy? CreateStrategy(string rebateIdentifier)
		{
			var rebate = _rebateDataStore.GetRebate(rebateIdentifier);

			if (rebate is null)
				return null;

			var strategy = CreateStrategy(rebate.Incentive);

			return strategy;
		}
	}
}
