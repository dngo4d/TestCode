namespace EF_DTO_API_V2.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string OrderName { get; set; }

        public string OrderStatus { get; set; }

        public int UserId { get; set; }

        public int CompanyId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalCost { get; set; }
    }
}
