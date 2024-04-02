using Marten.Schema;

namespace Catalog.Api.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        var session = store.LightweightSession();
        if(await session.Query<Product>().AnyAsync())
        {
            return;
        }

        // Marten UPSERT will carter for existing records
        session.Store<Product>(GetProconfiguredProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetProconfiguredProducts() => new List<Product>()
    {
        new Product()
        {
            Id = new Guid(),
            Name = "Iphone X",
            Description = "Desciption of Iphone X",
            ImageFile = "Iphone-X.png",
            Price = 100000,
            Category = new List<string> { "Smart phone" }
        },
        new Product()
        {
            Id = new Guid(),
            Name = "Iphone 11",
            Description = "Desciption of Iphone 11",
            ImageFile = "Iphone-11.png",
            Price = 110000,
            Category = new List<string> { "Smart phone" }
        },
        new Product()
        {
            Id = new Guid(),
            Name = "Iphone 12",
            Description = "Desciption of Iphone 12",
            ImageFile = "Iphone-12.png",
            Price = 120000,
            Category = new List<string> { "Smart phone" }
        },
        new Product()
        {
            Id = new Guid(),
            Name = "Iphone 13",
            Description = "Desciption of Iphone 13",
            ImageFile = "Iphone-13.png",
            Price = 130000,
            Category = new List<string> { "Smart phone" }
        }
    };

}
