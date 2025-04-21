using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EF_DTO_API_V2.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductType { get; set; }
        [Required]
        public string ProductStatus { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

    }
}
