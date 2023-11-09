using farmacia.Model;
using FluentValidation;

namespace farmacia.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {

        public ProdutoValidator()
        {

            RuleFor(p => p.Nome)
                .NotEmpty();

            RuleFor(p => p.Descricao)
                .NotEmpty();

            RuleFor(p => p.Laboratorio)
                .NotEmpty();

            RuleFor(p => p.Preco)
                .NotNull()
                .GreaterThan(0);

        }

    }
}
