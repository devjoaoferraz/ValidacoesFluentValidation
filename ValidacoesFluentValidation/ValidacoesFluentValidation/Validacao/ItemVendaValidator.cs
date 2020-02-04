using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacoesFluentValidation.Entidades;

namespace ValidacoesFluentValidation.Validacao
{
    public class ItemVendaValidator : AbstractValidator<ItemVenda>
    {
        public ItemVendaValidator()
        {
            RuleFor(i => i.Descricao)
                .Length(3, 50).WithMessage("A descrição do item deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(i => i.Preco)
                .GreaterThan(0).WithMessage("O preço do item deve ser maior que {ComparisonValue}.");

            RuleFor(i => i.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade do item deve ser maior que {ComparisonValue}.");
        }
    }
}
