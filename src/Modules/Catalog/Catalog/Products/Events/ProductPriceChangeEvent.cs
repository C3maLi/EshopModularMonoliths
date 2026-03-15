
using Catalog.Products.Models;

namespace Catalog.Products.Events
{
    public record ProductPriceChangeEvent(Product Product) : IDomainEvent;
}
