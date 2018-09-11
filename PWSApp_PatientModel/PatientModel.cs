using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWSApp_PatientModel
{
    public class PatientModel
    {
        public string MRN {
            get; set;
        }

        public string PatientInitials { get; set; }

        public string PatientFirstName { get; set; }

        public string PatientMiddleName { get; set; }

        public string PatientLastName { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckInTime { get; set; }

        public string PatientBloodGroup { get; set; }

        public string PatientGender { get; set; }

        public DateTime PatientDOB { get; set; }


    }

}