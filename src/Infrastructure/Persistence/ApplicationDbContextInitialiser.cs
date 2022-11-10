using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            if (!_context.ProductCategories.Any())
            {
                _context.ProductCategories.Add(new Domain.Entities.ProductCategory
                {
                    Name = "Stationary"                   
                });
            }
            await _context.SaveChangesAsync();

            if (!_context.Products.Any())
            {
                var stationaryCategory = _context.ProductCategories.Single(x => x.Name == "Stationary");

                _context.Products.Add(new Domain.Entities.Product
                {
                    Name = "Pencil",
                    Barcode = "8908000034198",
                    ProductCategoryId = stationaryCategory.Id,
                    Type = Domain.Enums.ProductType.NonWeighted,
                    UnitPrice = 2
                });

                _context.Products.Add(new Domain.Entities.Product
                {
                    Name = "Note Book",
                    Barcode = "3770005251",
                    ProductCategoryId = stationaryCategory.Id,
                    Type = Domain.Enums.ProductType.NonWeighted,
                    UnitPrice = 5
                });

                _context.Products.Add(new Domain.Entities.Product
                {
                    Name = "Blue Pen",
                    Barcode = "034285468156",
                    ProductCategoryId = stationaryCategory.Id,
                    Type = Domain.Enums.ProductType.NonWeighted,
                    UnitPrice = 3
                });

                _context.Products.Add(new Domain.Entities.Product
                {
                    Name = "Eraser",
                    Barcode = "46815600052",
                    ProductCategoryId = stationaryCategory.Id,
                    Type = Domain.Enums.ProductType.NonWeighted,
                    UnitPrice = 1.50M
                });

                await _context.SaveChangesAsync();


                var pencil = _context.Products.Single(x => x.Name == "Pencil");
                var eraser = _context.Products.Single(x => x.Name == "Eraser");
                var notebook = _context.Products.Single(x => x.Name == "Note Book");
                var pen = _context.Products.Single(x => x.Name == "Blue Pen");


                _context.ProductStocks.Add(new Domain.Entities.ProductStock
                {
                    ProductId = pencil.Id,                    
                    Status = Domain.Enums.ProductStatus.InStock
                });

                _context.ProductStocks.Add(new Domain.Entities.ProductStock
                {
                    ProductId = pen.Id,                    
                    Status = Domain.Enums.ProductStatus.InStock
                });

                _context.ProductStocks.Add(new Domain.Entities.ProductStock
                {
                    ProductId = pen.Id,                   
                    Status = Domain.Enums.ProductStatus.InStock
                });

                _context.ProductStocks.Add(new Domain.Entities.ProductStock
                {
                    ProductId = notebook.Id,                   
                    Status = Domain.Enums.ProductStatus.InStock
                });

                _context.ProductStocks.Add(new Domain.Entities.ProductStock
                {
                    ProductId = notebook.Id,                   
                    Status = Domain.Enums.ProductStatus.Damaged
                });

                _context.ProductStocks.Add(new Domain.Entities.ProductStock
                {
                    ProductId = notebook.Id,                   
                    Status = Domain.Enums.ProductStatus.Sold
                });

                _context.ProductStocks.Add(new Domain.Entities.ProductStock
                {
                    ProductId = eraser.Id,                   
                    Status = Domain.Enums.ProductStatus.Sold
                });

                await _context.SaveChangesAsync();
            }
        }

    }
}
