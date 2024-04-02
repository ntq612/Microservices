using Marten;

namespace Catalog.Api.Products.GetProduct;
public record GetProductQuery() : IQuery<GetProductResult>;
public record GetProductResult(IEnumerable<Product> Products);

public class GetProductQueryHandler
    (IDocumentSession session, ILogger<GetProductQueryHandler> logger)
    : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductQueryHandler. Handle called with {@Query}", request);
        var products = await session.Query<Product>().ToListAsync(cancellationToken);
        return new GetProductResult(products);  
    }
}