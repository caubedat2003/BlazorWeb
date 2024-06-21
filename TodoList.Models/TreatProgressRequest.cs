using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class TreatProgressRequest
    {
        public DateTime CreatedDate { get; set; }
        public string Doctor { get; set; }
        public DateTime DateStart { get; set; }
        public int DateEnd { get; set; }
        public string RecommendSource { get; set; }
        public string RecommendPerson { get; set; }
        public int PicturePeriod { get; set; }
        public DateTime CSKH { get; set; }
        public string Notice { get; set; }
        public string Diagnose { get; set; }
        public string TreatmentMethod { get; set; }
    }
}
