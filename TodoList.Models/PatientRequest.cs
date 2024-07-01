using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models.Enums;

namespace TodoList.Models
{
    public class PatientRequest
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Job { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Address { get; set; }
    }
}
