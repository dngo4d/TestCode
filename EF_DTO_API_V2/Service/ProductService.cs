using System;
using System.Collections.Generic;
using EF_DTO_API_V2.DTO;
using EF_DTO_API_V2.Repo;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
namespace EF_DTO_API_V2.Service
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string _cacheKey = "ProductList";

        public ProductService(AppDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<List<ProductDTO>> GetAllAsync()
        {
            if (!_cache.TryGetValue(_cacheKey, out List<ProductDTO> products))
            {
                var productsFromDb = await _context.Products
                                    .FromSqlRaw("EXEC GetAllProducts")
                                    .AsNoTracking() // Optional: Improves performance if tracking is not needed
                                    .ToListAsync();

                products = productsFromDb
                    .Select(p => new ProductDTO
                    {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        ProductType = p.ProductType,
                        Price = p.Price,
                        CompanyId = p.CompanyId
                    })
                    .ToList();

               
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30));
                _cache.Set(_cacheKey, products, cacheOptions);
            }
            
            return products;
        }

        public async Task<ProductDTO> GetByIdAsync(int Id)
        {
            var idParam = new SqlParameter("@Id", Id);

            // Execute the SP and asynchronously load ALL results into a list in memory
            var productList = await _context.Products
                                         .FromSqlRaw("EXEC GetProductById @Id", idParam)
                                         .AsNoTracking()
                                         .ToListAsync(); // <-- Executes DB query and fetches results here

            // Now perform FirstOrDefault on the in-memory list (synchronous operation)
            var productFromDb = productList.FirstOrDefault();

            var product = productFromDb == null ? null : new ProductDTO
            {
                Id = productFromDb.Id,
                ProductName = productFromDb.ProductName,
                ProductType = productFromDb.ProductType,
                Price = productFromDb.Price,
                CompanyId = productFromDb.CompanyId
            };
           
            return product ?? throw new KeyNotFoundException("Product not found");
        }
        public async Task<ProductDTO> CreateAsync(ProductDTO product)
        {
            var parameters = new[]
            {
            new SqlParameter("@ProductName", product.ProductName),
            new SqlParameter("@ProductType", product.ProductType),
            new SqlParameter("@Price", product.Price),
            new SqlParameter("@CompanyId", product.CompanyId)
        };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_CreateProduct @ProductName, @productType, @Price, @CompanyId", parameters);
            _cache.Remove(_cacheKey);
            return product;
        }


    }


}

