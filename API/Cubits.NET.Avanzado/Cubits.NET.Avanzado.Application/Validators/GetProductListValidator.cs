using Cubits.NET.Avanzado.Application.Contracts;
using FluentValidation;

namespace Cubits.NET.Avanzado.Application.Validators
{
    public class GetProductListValidator : AbstractValidator<GetProductListRequest>
    {
        public GetProductListValidator()
        {
            RuleFor(x => x.Count)
                .LessThanOrEqualTo(200)
                .WithMessage("El request para la lista de productos no es valido");
        }
    }
}
