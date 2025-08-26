using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseApi.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }


        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

    }
}
