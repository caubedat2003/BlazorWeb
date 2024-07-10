using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TodoList.Models.Enums;

namespace TodoList.Api.Entities
{
    public class User : IdentityUser<Guid>
    {
        [MaxLength(250)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(250)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public UserRole UserRole { get; set; }

    }
}
