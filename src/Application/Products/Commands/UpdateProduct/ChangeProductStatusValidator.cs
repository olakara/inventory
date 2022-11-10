using Application.Inventory.Commands.SellProduct;
using Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.UpdateProduct
{
    public sealed class ChangeProductStatusValidator : AbstractValidator<ChangeProductStatusCommand>
    {
        public ChangeProductStatusValidator()
        {
            // 1: Status should be a valid status
            RuleFor(p => p.Status).IsInEnum();
        }
    }
}
