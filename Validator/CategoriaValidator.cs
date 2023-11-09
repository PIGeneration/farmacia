using farmacia.Model;
using FluentValidation;

namespace farmacia.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator() {

            RuleFor(p => p.Nome)
                .NotEmpty();
        }
    }
}
