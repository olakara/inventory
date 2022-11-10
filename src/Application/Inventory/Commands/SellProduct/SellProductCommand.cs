using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.Commands.SellProduct
{
    public class SellProductCommand : IRequest
    {
        public Guid Id { get; set; }        
    }

    public class SellProductCommandHandler : IRequestHandler<SellProductCommand>
    {
        private readonly IApplicationDbContext _context;

        public SellProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SellProductCommand request, CancellationToken cancellationToken)
        {
            var productStockItem = _context.ProductStocks.Include(p=>p.Product).SingleOrDefault(x => x.Id == request.Id);

            if (productStockItem == null)
                throw new NotFoundException(nameof(ProductStock), request.Id);            

            productStockItem.Status = Domain.Enums.ProductStatus.Sold;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;            
        }

    }
}
