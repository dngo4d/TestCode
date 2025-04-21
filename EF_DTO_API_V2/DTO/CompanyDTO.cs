namespace EF_DTO_API_V2.DTO
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyType { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
    }
}
