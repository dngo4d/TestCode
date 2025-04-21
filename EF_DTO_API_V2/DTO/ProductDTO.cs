using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace EF_DTO_API_V2.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
        public int CompanyId { get; set; }

    }
}
