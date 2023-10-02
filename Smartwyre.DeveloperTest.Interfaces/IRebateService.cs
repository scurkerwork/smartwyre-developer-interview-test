using Smartwyre.DeveloperTest.Enums;
using Smartwyre.DeveloperTest.Requests;
using Smartwyre.DeveloperTest.Responses;

namespace Smartwyre.DeveloperTest.Services;

public interface IRebateService
{
    CalculateRebateResponse Calculate(CalculateRebateRequest request);
}
