namespace EF_DTO_API_V2.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }

    }
}
