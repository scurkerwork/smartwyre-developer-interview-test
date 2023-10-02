using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Entities;

namespace Smartwyre.DeveloperTest.Tests.Fakes
{
	internal class FakeProductDataStore : IProductDataStore
	{
		public Product GetProduct(string productIdentifier)
		{
			return new Product
			{
				Id = 1,
				Identifier = "4f37732c-b44a-4a23-ba28-07b26704525a",
				Uom = "84fad465-4240-43b9-9887-5bd081655010",
				Price = 10,
				SupportedIncentives = Enums.SupportedIncentiveType.FixedRateRebate | Enums.SupportedIncentiveType.FixedCashAmount | Enums.SupportedIncentiveType.AmountPerUom
			};
		}
	}
}
