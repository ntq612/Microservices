using Marten.Pagination;
namespace Catalog.Api.Products.GetProduct;
public record GetProductQuery(int? PageNumber, int? PageSize) : IQuery<GetProductResult>;
public record GetProductResult(IEnumerable<Product> Products);
public class GetProductQueryHandler
    (IDocumentSession session, ILogger<GetProductQueryHandler> logger)
    : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductQueryHandler. Handle called with {@Query}", query);
        var products = await session.Query<Product>()
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);
        return new GetProductResult(products);  
    }
}