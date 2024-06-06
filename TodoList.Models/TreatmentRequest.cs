using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class TreatmentRequest
    {
        public string ClinicalDiagnosis { get; set;}
        public int Pulse { get; set;}
        public int BloodPressure { get; set;}
        public int Temperature { get; set;}
        public int Breath {  get; set;}
        public int Weight { get; set;}
        public int Height { get; set;}
        public string AdditionalDisease { get; set;}
        public string Allergy { get; set;}
        public string ICD10 { get; set;}
        public string Diagnostic { get; set;}
        public string Conclusion { get; set;}
    }
}
