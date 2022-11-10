using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Inventory.Commands.SellProduct;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.UpdateProduct
{
    public class ChangeProductStatusCommand : IRequest
    {
        public Guid Id { get; set; }
        public ProductStatus Status { get; set; }
    }

    public class ChangeProductStatusCommandHandler : IRequestHandler<ChangeProductStatusCommand>
    {
        private readonly IApplicationDbContext _context;

        public ChangeProductStatusCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ChangeProductStatusCommand request, CancellationToken cancellationToken)
        {
            var productStockItem = _context.ProductStocks.SingleOrDefault(x => x.Id == request.Id);

            if (productStockItem == null)
                throw new NotFoundException(nameof(ProductStock), request.Id);

            productStockItem.Status = request.Status;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
