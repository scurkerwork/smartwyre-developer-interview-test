using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Entities;
using Smartwyre.DeveloperTest.Enums;
using Smartwyre.DeveloperTest.Requests;
using Smartwyre.DeveloperTest.Responses;
using Smartwyre.DeveloperTest.Services.Attributes;

namespace Smartwyre.DeveloperTest.Services.Strategies;

[IncentiveType(IncentiveType.FixedRateRebate)]
public class FixedRateRebateCalculationStrategy : IFixedRateCalculationStrategy
{
    private readonly Data.IRebateDataStore _rebateDataStore;
    private readonly IProductDataStore _productDataStore;


    public FixedRateRebateCalculationStrategy(Data.IRebateDataStore rebateDataStore, IProductDataStore productDataStore)
    {
        _rebateDataStore = rebateDataStore;
        _productDataStore = productDataStore;
    }


    public bool Validate(Rebate? rebate, Product? product)
    {
        if (rebate is null || product is null)
            return false;

        if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate))
            return false;

        if (rebate.Percentage == 0 || product.Price == 0)
            return false;

        return true;
    }

    public CalculateRebateResponse Calculate(CalculateRebateRequest request)
    {
        Rebate? rebate = _rebateDataStore.GetRebate(request.RebateIdentifier ?? "");
        Product? product = _productDataStore.GetProduct(request.ProductIdentifier ?? "");

        var result = new CalculateRebateResponse() { Success = false };

        if (!Validate(rebate, product) || request.Volume == 0)
            return result;

        var rebateAmount = (product?.Price ?? 0) * (rebate?.Percentage ?? 0) * request.Volume;

        result.Success = true;
        result.RebateAmount = rebateAmount;

        _rebateDataStore?.StoreCalculationResult(rebate, product, rebateAmount);

        return result;
    }
}
