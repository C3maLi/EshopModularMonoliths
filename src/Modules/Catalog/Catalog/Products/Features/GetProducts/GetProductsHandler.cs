namespace Catalog.Products.Features.GetProducts;

public record GetProductsQuery()
    : IQuery<GetProducstResult>;

public record GetProducstResult(IEnumerable<ProductDto> Products);

public class GetProductsHandler(CatalogDbContext dbContext)
    : IQueryHandler<GetProductsQuery, GetProducstResult>
{
    public async Task<GetProducstResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {

        var products = await dbContext.Products
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);

        var productsDtos = products.Adapt<List<ProductDto>>();


        return new GetProducstResult(productsDtos);
    }

}
