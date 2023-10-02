using Smartwyre.DeveloperTest.Entities;
using Smartwyre.DeveloperTest.Requests;
using Smartwyre.DeveloperTest.Responses;

namespace Smartwyre.DeveloperTest.Interfaces.Strategies;

public interface IRebateCalculationStrategy
{
    bool Validate(Rebate? rebate, Product? product);
    CalculateRebateResponse Calculate(CalculateRebateRequest request);
}
