using Smartwyre.DeveloperTest.Enums;

namespace Smartwyre.DeveloperTest.Entities;

public class Rebate
{
    public int Id { get; set; }
    public string Identifier { get; set; } = string.Empty;
    public IncentiveType Incentive { get; set; }
    public decimal Amount { get; set; }
    public decimal Percentage { get; set; }
}
