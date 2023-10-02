using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Entities;
using Smartwyre.DeveloperTest.Requests;
using Smartwyre.DeveloperTest.Responses;
using System;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Tests.Fakes
{
	public class FakeRebateDataStore : IFakeRebateDataStore
	{
		private readonly ICollection<RebateCalculation> _store;


		public FakeRebateDataStore()
		{
			_store = new List<RebateCalculation>();
		}


		public ICollection<RebateCalculation> GetCalculationStore() => _store;

		public Rebate GetRebate(string rebateIdentifier)
		{
			return new Rebate
			{
				Id = 1,
				Identifier = rebateIdentifier,
				Incentive = Enums.IncentiveType.FixedRateRebate,
				Amount = 10,
				Percentage = 50
			};
		}

		public void StoreCalculationResult(Rebate account, Product product, decimal rebateAmount)
		{
			_store.Add(new RebateCalculation
			{
				Id = account.Id,
				Amount = rebateAmount,
				IncentiveType = Enums.IncentiveType.FixedRateRebate,
				ProductIdentifier = product.Identifier,
				RebateIdentifier = account.Identifier
			});
		}
	}
}
