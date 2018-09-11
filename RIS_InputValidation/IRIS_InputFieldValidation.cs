using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIS_InputValidation
{
    public interface IRIS_InputFieldValidation
    {

        bool validation_check(string PatientFirstName, string PatientMiddleName, string PatientLastName, string ReferringPhysicianName, string PerformingPhysicianName);
       


        }
}
