using System;
using System.Collections.Generic;
using EF_DTO_API_V2.DTO;
namespace EF_DTO_API_V2.Service
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetAllAsync();
        Task<OrderDTO> GetByIdAsync(int id);
        //Task<OrderDTO> CreateAsync(OrderDTO order);
        //Task UpdateAsync(int id, OrderDTO order);
        //Task DeleteAsync(int id);

    }
}
