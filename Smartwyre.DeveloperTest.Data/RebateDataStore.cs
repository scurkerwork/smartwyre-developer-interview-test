using Smartwyre.DeveloperTest.Data.DbContext;
using Smartwyre.DeveloperTest.Entities;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore : IRebateDataStore
{
	private readonly SmartwyreDbContext _context;

	public RebateDataStore(SmartwyreDbContext context)
	{
		_context = context;
	}

	public Rebate? GetRebate(string rebateIdentifier)
    {
        var rebate = _context.Rebates.FirstOrDefault(p => p.Identifier == rebateIdentifier);
        return rebate;
    }

    public void StoreCalculationResult(Rebate account, Product product, decimal rebateAmount)
    {
        var calculation = new RebateCalculation
        {
            IncentiveType = account.Incentive,
            ProductIdentifier = product.Identifier,
            RebateIdentifier = account.Identifier,
            Amount = rebateAmount
        };

        _context.RebateCalculations.Add(calculation);
		_context.SaveChanges();

	}
}
