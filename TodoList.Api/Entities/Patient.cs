using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.Entities
{
    public class Patient
    {
        [Key]
        public Guid PatientId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Job { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Address { get; set; }
    }
}
