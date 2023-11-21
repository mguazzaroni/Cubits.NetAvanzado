using Cubits.NET.Avanzado.Application.Contracts;
using FluentValidation;

namespace Cubits.NET.Avanzado.Application.Validators
{
    public class GetProductValidator : AbstractValidator<GetProductRequest>
    {
        public GetProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("El Id no puede ser nulo o vacio");
        }
    }
}
