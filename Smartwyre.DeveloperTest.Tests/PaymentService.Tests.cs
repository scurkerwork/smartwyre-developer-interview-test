using Smartwyre.DeveloperTest.Requests;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Tests.Fakes;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{    
    public PaymentServiceTests()
    {
        Startup.Start();
    }

    [Fact]
    public void Test_Calculate_FixedRateRebate()
    {
        var service = Startup.GetService<IRebateService>();

        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "820b3f3d-8418-4d93-9323-25dac412b611",
            ProductIdentifier = "4f37732c-b44a-4a23-ba28-07b26704525a",
            Volume = 10,
            IncentiveType = Enums.IncentiveType.FixedRateRebate
        };

        var response = service.Calculate(request);

        Assert.NotNull(response);
        Assert.True(response.Success);
		Assert.True(response.RebateAmount > 0);
	}

	[Fact]
	public void Test_Calculate_FixedCashAmount()
	{
		var service = Startup.GetService<IRebateService>();

		var request = new CalculateRebateRequest
		{
			RebateIdentifier = "820b3f3d-8418-4d93-9323-25dac412b611",
			ProductIdentifier = "4f37732c-b44a-4a23-ba28-07b26704525a",
			Volume = 10,
			IncentiveType = Enums.IncentiveType.FixedCashAmount
		};

		var response = service.Calculate(request);

		Assert.NotNull(response);
		Assert.True(response.Success);
		Assert.True(response.RebateAmount > 0);
	}

	[Fact]
	public void Test_Calculate_AmountPerUom()
	{
		var service = Startup.GetService<IRebateService>();

		var request = new CalculateRebateRequest
		{
			RebateIdentifier = "820b3f3d-8418-4d93-9323-25dac412b611",
			ProductIdentifier = "4f37732c-b44a-4a23-ba28-07b26704525a",
			Volume = 10,
			IncentiveType = Enums.IncentiveType.AmountPerUom
		};

		var response = service.Calculate(request);

		Assert.NotNull(response);
		Assert.True(response.Success);
		Assert.True(response.RebateAmount > 0);
	}
}
