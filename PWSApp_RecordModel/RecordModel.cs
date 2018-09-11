using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWSApp_RecordModel
{
    public class RecordModel
    {

        public string MRN { get; set; }
        public string PatientInitials { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientMiddleName { get; set; }
        public string PatientLastName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckInTime { get; set; }
        public string PatientBloodGroup { get; set; }
        public string PatientGender { get; set; }
        public DateTime PatientDOB { get; set; }
        public string ModalityName { get; set; }
        public string ExamType { get; set; }
        public string ReferringPhysicianName { get; set; }
        public string PerformingPhysicianName { get; set; }
        public string Allergies { get; set; }
        public string DiabetesType { get; set; }
        public string Description { get; set; }

    }
}
