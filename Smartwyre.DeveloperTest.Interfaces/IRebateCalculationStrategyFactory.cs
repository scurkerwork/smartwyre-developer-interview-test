using Smartwyre.DeveloperTest.Enums;
using Smartwyre.DeveloperTest.Interfaces.Strategies;

namespace Smartwyre.DeveloperTest.Interfaces
{
	public interface IRebateCalculationStrategyFactory
	{
		IRebateCalculationStrategy CreateStrategy(IncentiveType incentiveType);
		IRebateCalculationStrategy CreateStrategy(string rebateIdentifier);
	}
}
