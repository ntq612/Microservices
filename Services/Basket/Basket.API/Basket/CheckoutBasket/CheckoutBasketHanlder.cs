using FluentValidation;

namespace Basket.API.Basket.CheckoutBasket;
public record CheckoutBasketCommand(ShoppingCart Cart) : ICommand<CheckoutBasketResult>;
public record CheckoutBasketResult(bool IsSuccess);

public class CheckoutBasketCommandValidation : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutBasketCommandValidation()
    {
        RuleFor(x => x.Cart).NotEmpty().WithMessage("Cart can not be null");
    }
}
public class CheckoutBasketCommandHanlder
{

}