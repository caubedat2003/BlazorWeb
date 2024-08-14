using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class PageRoleAssignment
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsReceptionist { get; set; }
        public bool IsDoctor { get; set; }
        public bool IsCashier { get; set; }
        public bool IsPharmacist { get; set; }
    }
}
