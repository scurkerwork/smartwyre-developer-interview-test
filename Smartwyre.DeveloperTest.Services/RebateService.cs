using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Interfaces.Strategies;
using Smartwyre.DeveloperTest.Requests;
using Smartwyre.DeveloperTest.Responses;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{

    private readonly IRebateCalculationStrategyFactory _strategyFactory;

    public RebateService(IRebateCalculationStrategyFactory calculatationFactory)
    {
        _strategyFactory = calculatationFactory;
    }


    public CalculateRebateResponse Calculate(CalculateRebateRequest request)
    {
        IRebateCalculationStrategy? strategy = null;

        if (request.IncentiveType.HasValue)
            strategy = _strategyFactory.CreateStrategy(request.IncentiveType.Value);
        else
            strategy = _strategyFactory.CreateStrategy(request.RebateIdentifier);

        var result = strategy.Calculate(request);

        return result;
    }
}
