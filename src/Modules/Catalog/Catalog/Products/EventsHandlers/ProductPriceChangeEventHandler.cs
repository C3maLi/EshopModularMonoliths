using Catalog.Products.EventsHandlers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Products.EventHandlers
{
    public class ProductPriceChangedEventHandler(ILogger<ProductCreatedEventHandler> logger) : INotificationHandler<ProductPriceChangedEvent>
    {
        public Task Handle(ProductPriceChangedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event hanled: {DomainEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}