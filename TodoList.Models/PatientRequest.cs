using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class PatientRequest
    {
        //phong kham rang
        public Guid PatientId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Job {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Doctor { get; set; }
        public DateTime DateStart { get; set; }
        public int DateEnd { get; set; }
        public string RecommendSource {  get; set; }
        public string RecommendPerson {  get; set; }
        public int PicturePeriod { get; set; }
        public DateTime CSKH { get; set; }
        public string Notice { get; set; }
        public string Diagnose { get; set; }
        public string TreatmentMethod { get; set; }
        //quan ly phong kham
        public string Target { get; set; }
        public string Nation { get; set;}
        public int Age { get; set;}
        public string Address { get; set;}
        public string TreatmentType { get; set;}
        public int FileNumber { get; set;}
        public string Condition { get; set;}
        public string ClinicRoom { get; set;}
        public int TreatmentFee { get; set;}
        public string TreatmentNote { get; set;}
    }
}
