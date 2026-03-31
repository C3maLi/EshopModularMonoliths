using Catalog.Products.EventsHandlers;
using MassTransit;
using MediatR;
using Shared.Messaging.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Products.EventHandlers
{
    public class ProductPriceChangedEventHandler(IBus bus, ILogger<ProductCreatedEventHandler> logger)
        : INotificationHandler<ProductPriceChangedEvent>
    {
        public async Task Handle(ProductPriceChangedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event hanled: {DomainEvent}", notification.GetType().Name);
            // return Task.CompletedTask;

            var integrationEvent = new ProductPriceChangeIntegrationEvent
            {
                ProductId = notification.Product.Id,
                Name = notification.Product.Name,
                Category = notification.Product.Category,
                Description = notification.Product.Description,
                ImageFile = notification.Product.ImageFile,
                Price = notification.Product.Price,
            }; 

            await bus.Publish(integrationEvent, cancellationToken);
        }
    }
}