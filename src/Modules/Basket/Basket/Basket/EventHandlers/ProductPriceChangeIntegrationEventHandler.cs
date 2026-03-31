using Basket.Basket.Features.UpdateItemPriceBasket;
using Microsoft.Extensions.Logging;

namespace Basket.Basket.EventHandlers;

public class ProductPriceChangeIntegrationEventHandler
    (ISender sender, ILogger<ProductPriceChangeIntegrationEventHandler> logger)
    : IConsumer<ProductPriceChangeIntegrationEvent>
{
    public async Task Consume(ConsumeContext<ProductPriceChangeIntegrationEvent> context)
    {
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = new UpdateItemPriceInBasketCommand(context.Message.ProductId, context.Message.Price);
        var result = await sender.Send(command);

        if (!result.IsSuccess)
        {
            logger.LogError("Error updateing price in basket for pdorudct id: {ProductId}", context.Message.Name);

        }

        logger.LogError("Price for product id: {ProductId} update in basket", context.Message.Price);

    }
}
