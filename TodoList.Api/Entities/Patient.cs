using System.ComponentModel.DataAnnotations;
using TodoList.Models.Enums;

namespace TodoList.Api.Entities
{
    public class Patient
    {
        [Key]
        public Guid PatientId { get; set; }
        [Required]
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Job { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Address { get; set; }
    }
}
