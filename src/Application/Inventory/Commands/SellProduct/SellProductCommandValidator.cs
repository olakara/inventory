using Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.Commands.SellProduct
{
    public sealed class SellProductCommandValidator : AbstractValidator<SellProductCommand>
    {
        private readonly IApplicationDbContext _context;


        public SellProductCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(p => p.Id).Must(BePurchaseable).WithMessage("This item cannot be purchased!");
        }       

        private bool BePurchaseable(Guid Id)
        {
            var item = _context.ProductStocks.Find(Id);
            if(item == null)
                return true;
            if (item.Status == Domain.Enums.ProductStatus.InStock)
                return true;
            return false;
        }
    }
}
