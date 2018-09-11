using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWSApp_ModalityModel;
using PWSApp_PatientModel;
using System.Windows.Forms;
using PWS_BusinessLayer;
using System.ComponentModel;

using System.Windows.Controls;
using System.Data.SqlTypes;
using RIS_InputValidation;

namespace PWSApp_ViewModel
{
    public class RIS_ViewModel
    {
        public static string PatientFirstName { get; set; } = "";


        public static string PatientInitials { get; set; } = "";

        public static string PatientMiddleName { get; set; } = "";

        public static string PatientLastName { get; set; }

        public static DateTime CheckInDate
        {
            get
            {
                return DateTime.Now.Date;
            }

        }

        public static DateTime CheckInTime
        {

            get
            {
                return DateTime.Now;
            }
        }

        public static string PatientBloodGroup { get; set; } = "";

        public static string PatientGender { get; set; } = "";

        public static DateTime? patientDOB;
        public static DateTime? PatientDOB
        {

            //Need to change the type of the private variable as well
            get { return patientDOB; }
            set
            {
               
                 if ((PatientDOB != null) || !PatientDOB.Equals(value))
                {
                    patientDOB = value;
                    //MessageBox.Show(patientDOB.ToString());
                }

                else if (PatientDOB == null)
               {
                   // patientDOB =(DateTime?) SqlDateTime.MinValue;
                  
                   patientDOB = (DateTime?)DateTime.Now;
                    //MessageBox.Show(patientDOB.ToString());
               }
               

            }

        }

        public static string ModalityName { get; set; } = "";

        public static string ExamType { get; set; } = "";

        public static string ReferringPhysicianName { get; set; } = "";

        public static string PerformingPhysicianName { get; set; } = "";



        public RIS_ViewModel()
        {

        }


       


        //validation implementation

        public static bool button_Clicked(int MRN)
        { 
            if (PatientDOB == null) {

                  PatientDOB =(DateTime?)DateTime.Now;
                  //MessageBox.Show("hhhh" + PatientDOB.ToString());

              }

            if (ReferringPhysicianName == null) {

                ReferringPhysicianName = "";
            }

            if (PerformingPhysicianName == null)
            {

                PerformingPhysicianName = "";
            }

            if (PatientMiddleName == null)
            {

                PatientMiddleName = "";
            }

            if (PatientFirstName == null)
            {

                PatientFirstName = "";
            }


            //validation check
            RIS_InputFieldValidation obj = new RIS_InputFieldValidation();
          bool result=  obj.validation_check(PatientFirstName, PatientMiddleName, PatientLastName, ReferringPhysicianName, PerformingPhysicianName);
            if (result == false)
            {

               // MessageBox.Show("Enter character should not be between [//, /,:,?,*,<,>,|] ");
                return false;

            }
            

            else if (result == true)
            {
                RISDataManager risDataManager = new RISDataManager("PIC" + MRN, PatientInitials, PatientFirstName, PatientMiddleName, PatientLastName, CheckInDate, CheckInTime, PatientBloodGroup, PatientGender, (DateTime)PatientDOB, ModalityName, ExamType, ReferringPhysicianName, PerformingPhysicianName);
                return true;
           }
            else return false;



        }

    }
}
