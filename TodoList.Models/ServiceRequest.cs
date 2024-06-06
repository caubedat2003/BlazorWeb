using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class ServiceRequest
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Price { get; set; }
        public float Percentage { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
