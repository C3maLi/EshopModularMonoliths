using Shared.Pagination;

namespace Catalog.Products.Features.GetProducts;

public record GetProductsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetProducstResult>;

public record GetProducstResult(PaginateResult<ProductDto> Products);

public class GetProductsHandler(CatalogDbContext dbContext)
    : IQueryHandler<GetProductsQuery, GetProducstResult>
{
    public async Task<GetProducstResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Products.LongCountAsync(cancellationToken);

        var products = await dbContext.Products
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var productsDtos = products.Adapt<List<ProductDto>>();

        return new GetProducstResult(
            new PaginateResult<ProductDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    productsDtos
                )
            );
    }

}
