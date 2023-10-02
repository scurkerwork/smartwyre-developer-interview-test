using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Entities;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Tests.Fakes
{
	public interface IFakeRebateDataStore : IRebateDataStore
	{
		ICollection<RebateCalculation> GetCalculationStore();
	}
}
