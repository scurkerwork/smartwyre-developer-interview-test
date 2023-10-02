using Smartwyre.DeveloperTest.Data.DbContext;
using Smartwyre.DeveloperTest.Entities;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore : IProductDataStore
{
    private readonly SmartwyreDbContext _context;

	public ProductDataStore(SmartwyreDbContext context)
    {
        _context = context;
    }

	public Product? GetProduct(string productIdentifier)
    {
        var product = _context.Products.FirstOrDefault(p => p.Identifier == productIdentifier);
        return product;
    }
}
