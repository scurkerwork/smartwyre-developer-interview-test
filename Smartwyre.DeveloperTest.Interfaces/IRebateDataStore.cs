using Smartwyre.DeveloperTest.Entities;

namespace Smartwyre.DeveloperTest.Data;

public interface IRebateDataStore
{
    Rebate? GetRebate(string rebateIdentifier);
    void StoreCalculationResult(Rebate account, Product product, decimal rebateAmount);
}
