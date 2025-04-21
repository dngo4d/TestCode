using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EF_DTO_API_V2.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        [Required]
        public int RoleId { get; set; }

    }
}
