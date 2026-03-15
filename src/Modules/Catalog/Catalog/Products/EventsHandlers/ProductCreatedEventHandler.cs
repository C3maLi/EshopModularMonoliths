using Microsoft.Extensions.Logging;

namespace Catalog.Products.EventsHandlers;

public class ProductCreatedEventHandler(ILogger<ProductCreatedEventHandler> logger)
    : INotificationHandler<ProductCreatedEvent>
{
    public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event hanled: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}