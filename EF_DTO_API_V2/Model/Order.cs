using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EF_DTO_API_V2.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OrderName { get; set; }
        [Required]
        public string OrderStatus { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        [Required]
        public decimal TotalCost { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }

    }
}
