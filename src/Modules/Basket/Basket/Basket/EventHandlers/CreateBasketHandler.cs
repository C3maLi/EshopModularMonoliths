namespace Basket.Basket.EventHandlers;

public record CreateBasketCommand(ShoppingCartDto ShoppingCart)
    : ICommand<CreateBasketResult>;

public record CreateBasketResult(Guid Id);

public class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommand>
{
    public CreateBasketCommandValidator()
    {
        RuleFor(x => x.ShoppingCart.UserName).NotEmpty().WithMessage("UserName is required!");
    }
}

public class CreateBasketHandler
    : ICommandHandler<CreateBasketCommand, CreateBasketResult>
{
    public Task<CreateBasketResult> Handle(CreateBasketCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
