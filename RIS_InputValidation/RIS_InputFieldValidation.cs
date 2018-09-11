using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIS_InputValidation
{
    public class RIS_InputFieldValidation:IRIS_InputFieldValidation
    {



     /*   public bool Validation_Check(string Name) {

            if (Name.Contains("//") || Name.Contains("/") || Name.Contains(":") || Name.Contains("*") || Name.Contains("?") || Name.Contains("<") || Name.Contains(">") || Name.Contains("|"))
                return false;

            else return true;
        }
        */



        public bool validation_check(string PatientFirstName, string PatientMiddleName, string PatientLastName, string ReferringPhysicianName, string PerformingPhysicianName)
        {


            if (PatientFirstName.Contains("//") || PatientFirstName.Contains("/") || PatientFirstName.Contains(":") || PatientFirstName.Contains("*") || PatientFirstName.Contains("?") || PatientFirstName.Contains("<") || PatientFirstName.Contains(">") || PatientFirstName.Contains("|"))
                return false;

            if (PatientMiddleName.Contains("//") || PatientMiddleName.Contains("/") || PatientMiddleName.Contains(":") || PatientMiddleName.Contains("*") || PatientMiddleName.Contains("?") || PatientMiddleName.Contains("<") || PatientMiddleName.Contains(">") || PatientMiddleName.Contains("|"))
                return false;

            if (PatientLastName.Contains("//") || PatientLastName.Contains("/") || PatientLastName.Contains(":") || PatientLastName.Contains("*") || PatientLastName.Contains("?") || PatientLastName.Contains("<") || PatientLastName.Contains(">") || PatientLastName.Contains("|"))
                return false;

            if (ReferringPhysicianName.Contains("//") || ReferringPhysicianName.Contains("/") || ReferringPhysicianName.Contains(":") || ReferringPhysicianName.Contains("*") || ReferringPhysicianName.Contains("?") || ReferringPhysicianName.Contains("<") || ReferringPhysicianName.Contains(">") || ReferringPhysicianName.Contains("|"))
                return false;

            if (PerformingPhysicianName.Contains("//") || PerformingPhysicianName.Contains("/") || PerformingPhysicianName.Contains(":") || PerformingPhysicianName.Contains("*") || PerformingPhysicianName.Contains("?") || PerformingPhysicianName.Contains("<") || PerformingPhysicianName.Contains(">") || PerformingPhysicianName.Contains("|"))
                return false;


            return true;
        }


    }
}
