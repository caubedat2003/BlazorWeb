using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class VisitRequest
    {
        public DateTime NgayHen {  get; set; }
        public DateTime NgayBNDen { get; set; }
        public DateTime NgayHenTiepTheo { get; set; }
        public int SoTuan {  get; set; }
        public string NoiDung {  get; set; }
        public string GhiChu { get; set; }
    }
}
