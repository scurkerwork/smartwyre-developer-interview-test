using Smartwyre.DeveloperTest.Requests;
using Smartwyre.DeveloperTest.Services;
using System;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        Startup.Start();

        Console.WriteLine("1 - Type the Rebate identifier: ");
        var rebateIdentifier = Console.ReadLine();

        Console.WriteLine("2 - Type the product identifier: ");
        var productIdentifier = Console.ReadLine();

        Console.WriteLine("3 - Type the volume: ");
        var volumeStr = Console.ReadLine();

        decimal volume = 0M;
        var success = decimal.TryParse(volumeStr, out volume);

        if (!success)
        {
            Console.WriteLine("Invalid volume");
            return;
        }

        var request = new CalculateRebateRequest
        {
            RebateIdentifier = rebateIdentifier,
            ProductIdentifier = productIdentifier,
            Volume = volume
        };

        var service = Startup.GetService<IRebateService>();
        var response = service.Calculate(request);

        if (!response.Success)
        {
            Console.WriteLine("Invalid data");
            return;
        }

        Console.WriteLine("The final amount is: {0:C}", response.RebateAmount);
    }
}
