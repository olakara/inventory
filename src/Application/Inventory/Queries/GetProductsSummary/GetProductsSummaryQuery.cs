using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inventory.Queries.GetProductsSummary
{
    public class GetProductsSummaryQuery : IRequest<ProductsSummaryViewModel>
    {
    }

    public class GetProductsSummaryQueryHandler : IRequestHandler<GetProductsSummaryQuery, ProductsSummaryViewModel>
    {
        private readonly IApplicationDbContext _context;

        public GetProductsSummaryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductsSummaryViewModel> Handle(GetProductsSummaryQuery request, CancellationToken cancellationToken)
        {
            var countPerStatus = await _context.ProductStocks.GroupBy(p => p.Status).Select(product => new
            {
                Count = product.Count(),
                Key = product.Key
            }).ToListAsync();

            var result = new ProductsSummaryViewModel {
                ProductsDamaged = countPerStatus.Where(x => x.Key == Domain.Enums.ProductStatus.Damaged).Sum( x=> x.Count),
                ProductsSold = countPerStatus.Where(x => x.Key == Domain.Enums.ProductStatus.Sold).Sum(x => x.Count),
                ProductsInStock = countPerStatus.Where(x => x.Key == Domain.Enums.ProductStatus.InStock).Sum(x => x.Count)
            };

            return result;
        }
    }
}
