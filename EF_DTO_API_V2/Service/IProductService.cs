using System;
using System.Collections.Generic;
using EF_DTO_API_V2.DTO;
namespace EF_DTO_API_V2.Service
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetByIdAsync(int id);
        Task<ProductDTO> CreateAsync(ProductDTO product);
        //Task UpdateAsync(int id, ProductDTO product);
        //Task DeleteAsync(int id);

    }
}
