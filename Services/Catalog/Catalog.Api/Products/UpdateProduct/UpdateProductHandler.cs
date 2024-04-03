using Marten.Linq.SoftDeletes;
namespace Catalog.Api.Products.UpdateProduct;
public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<UpdateProductResult>; 
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is required");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
            .Length(2, 150).WithMessage("Name lenght must be from 2 to 150 characters");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price is not lower than 0");
    }
}
public record UpdateProductResult(bool IsSuccess);
public class UpdateProductCommandHandler(IDocumentSession session)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        if(product is null)
        {
            throw new ProductNotFoundException();
        }
        product.Name = command.Name;
        product.Category = command.Category;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;
        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);
        return new UpdateProductResult(true);
    }
}
