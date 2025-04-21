using System;
using System.Collections.Generic;
using EF_DTO_API_V2.DTO;
using EF_DTO_API_V2.Model;
using EF_DTO_API_V2.Repo;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace EF_DTO_API_V2.Service
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDTO>> GetAllAsync()
        {
            var ordersFromDb = await _context.Orders
                                   .FromSqlRaw("EXEC GetAllOrders")
                                   .AsNoTracking() // Optional: Improves performance if tracking is not needed
            .ToListAsync();

            var orders = ordersFromDb
                .Select(o => new OrderDTO
                {
                    Id = o.Id,
                    OrderName = o.OrderName,
                    OrderStatus = o.OrderStatus,
                    UserId = o.UserId,
                    CompanyId = o.CompanyId,
                    OrderDate = o.OrderDate,
                    TotalCost = o.TotalCost
                })
                .ToList();
           
            return orders;
        }

        public async Task<OrderDTO> GetByIdAsync(int Id)
        {
            var idParam = new SqlParameter("@Id", Id);

            // Execute the SP and asynchronously load ALL results into a list in memory
            var orderList = await _context.Orders
                                         .FromSqlRaw("EXEC GetOrderById @Id", idParam)
                                         .AsNoTracking()
                                         .ToListAsync(); // <-- Executes DB query and fetches results here
            // Now perform FirstOrDefault on the in-memory list (synchronous operation)
            var orderFromDb = orderList.FirstOrDefault();

            var order = orderFromDb == null ? null : new OrderDTO
            {
                Id = orderFromDb.Id,
                OrderName = orderFromDb.OrderName,
                OrderStatus = orderFromDb.OrderStatus,
                UserId = orderFromDb.UserId,
                CompanyId = orderFromDb.CompanyId,
                OrderDate = orderFromDb.OrderDate,
                TotalCost = orderFromDb.TotalCost
                
            };
           
            return order ?? throw new KeyNotFoundException("Order not found");
        }

    }
}
