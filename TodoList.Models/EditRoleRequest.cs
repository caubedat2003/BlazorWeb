using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models.Enums;

namespace TodoList.Models
{
    public class EditRoleRequest
    {
        public Guid Id { get; set; }
        public UserRole UserRole { get; set; }
    }
}
