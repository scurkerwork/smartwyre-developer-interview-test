using Smartwyre.DeveloperTest.Enums;

namespace Smartwyre.DeveloperTest.Entities;

public class RebateCalculation
{
    public int Id { get; set; }
    public string ProductIdentifier { get; set; } = string.Empty;
    public string RebateIdentifier { get; set; } = string.Empty;
    public IncentiveType IncentiveType { get; set; }
    public decimal Amount { get; set; }
}
