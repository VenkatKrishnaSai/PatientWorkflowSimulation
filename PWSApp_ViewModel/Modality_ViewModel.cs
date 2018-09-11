using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWSApp_AllergyModel;
using PWS_BusinessLayer;
using PWSApp_OrderModell;
using System.Windows.Forms;

namespace PWSApp_ViewModel
{

    public class Modality_ViewModel
    {
        OrderModel RISObject_1;
        OrderModel RISObject_2;
        OrderModel RISObject_3;

        AllergyModel AllergyObject = new AllergyModel();
        UltrasoundModality ultrasoundObject = new UltrasoundModality();

        public int CurrentObjectNumber { get; set; }

        public string Window2MRN { get; set; }

        public string Window2PatientName { get; set; }

        public void Window2DataBinding()
        {
            if (CurrentObjectNumber == 1)
                Window2MRN = MRN[0];
            if (CurrentObjectNumber == 2)
                Window2MRN = MRN[1];
            if (CurrentObjectNumber == 3)
                Window2MRN = MRN[2];
        }

        public string[] MRN
        {
            get
            {
                string[] MRN = new string[3];
                MRN[0] = RISObject_1.MRN;
                MRN[1] = RISObject_2.MRN;
                MRN[2] = RISObject_3.MRN;
                return MRN;
            }
            set
            {
                MRN[0] = RISObject_1.MRN;
                MRN[1] = RISObject_2.MRN;
                MRN[2] = RISObject_3.MRN;
            }
        }

        public string[] PatientInitials
        {
            get
            {
                string[] PatientInitials = new string[3];
                PatientInitials[0] = RISObject_1.PatientInitials;
                PatientInitials[1] = RISObject_2.PatientInitials;
                PatientInitials[2] = RISObject_3.PatientInitials;
                return PatientInitials;
            }
            set
            {
                PatientInitials[0] = RISObject_1.PatientInitials;
                PatientInitials[1] = RISObject_2.PatientInitials;
                PatientInitials[2] = RISObject_3.PatientInitials;
            }
        }

        public string[] PatientFirstName
        {
            get
            {
                string[] PatientFirstName = new string[3];
                PatientFirstName[0] = RISObject_1.PatientFirstName;
                PatientFirstName[1] = RISObject_2.PatientFirstName;
                PatientFirstName[2] = RISObject_3.PatientFirstName;
                return PatientFirstName;
            }
            set
            {
                PatientFirstName[0] = RISObject_1.PatientFirstName;
                PatientFirstName[1] = RISObject_2.PatientFirstName;
                PatientFirstName[2] = RISObject_3.PatientFirstName;
            }
        }

        public string[] PatientMiddleName
        {
            get
            {
                string[] PatientMiddleName = new string[3];
                PatientMiddleName[0] = RISObject_1.PatientMiddleName;
                PatientMiddleName[1] = RISObject_2.PatientMiddleName;
                PatientMiddleName[2] = RISObject_3.PatientMiddleName;
                return PatientMiddleName;
            }
            set
            {
                PatientMiddleName[0] = RISObject_1.PatientMiddleName;
                PatientMiddleName[1] = RISObject_2.PatientMiddleName;
                PatientMiddleName[2] = RISObject_3.PatientMiddleName;
            }
        }

        public string[] PatientLastName
        {
            get
            {
                string[] PatientLastName = new string[3];
                PatientLastName[0] = RISObject_1.PatientLastName;
                PatientLastName[1] = RISObject_2.PatientLastName;
                PatientLastName[2] = RISObject_3.PatientLastName;
                return PatientLastName;
            }
            set
            {
                PatientLastName[0] = RISObject_1.PatientLastName;
                PatientLastName[1] = RISObject_2.PatientLastName;
                PatientLastName[2] = RISObject_3.PatientLastName;
            }
        }

        public string[] PatientBloodGroup
        {
            get
            {
                string[] PatientBloodGroup = new string[3];
                PatientBloodGroup[0] = RISObject_1.PatientBloodGroup;
                PatientBloodGroup[1] = RISObject_2.PatientBloodGroup;
                PatientBloodGroup[2] = RISObject_3.PatientBloodGroup;
                return PatientBloodGroup;
            }
            set
            {
                PatientBloodGroup[0] = RISObject_1.PatientBloodGroup;
                PatientBloodGroup[1] = RISObject_2.PatientBloodGroup;
                PatientBloodGroup[2] = RISObject_3.PatientBloodGroup;
            }
        }

        public string[] PatientGender
        {
            get
            {
                string[] PatientGender = new string[3];
                PatientGender[0] = RISObject_1.PatientGender;
                PatientGender[1] = RISObject_2.PatientGender;
                PatientGender[2] = RISObject_3.PatientGender;
                return PatientGender;
            }
            set
            {
                PatientGender[0] = RISObject_1.PatientGender;
                PatientGender[1] = RISObject_2.PatientGender;
                PatientGender[2] = RISObject_3.PatientGender;
            }
        }

        public string[] ReferringPhysicianName
        {
            get
            {
                string[] ReferringPhysicianName = new string[3];
                ReferringPhysicianName[0] = RISObject_1.ReferringPhysicianName;
                ReferringPhysicianName[1] = RISObject_2.ReferringPhysicianName;
                ReferringPhysicianName[2] = RISObject_3.ReferringPhysicianName;
                return ReferringPhysicianName;
            }
            set
            {
                ReferringPhysicianName[0] = RISObject_1.ReferringPhysicianName;
                ReferringPhysicianName[1] = RISObject_2.ReferringPhysicianName;
                ReferringPhysicianName[2] = RISObject_3.ReferringPhysicianName;
            }
        }

        public int[] PatientAge
        {
            get
            {
                int[] PatientAge = new int[3];
                PatientAge[0] = DateTime.Now.Year - RISObject_1.PatientDOB.Year;
                PatientAge[1] = DateTime.Now.Year - RISObject_2.PatientDOB.Year;
                PatientAge[2] = DateTime.Now.Year - RISObject_3.PatientDOB.Year;
                return PatientAge;
            }
            set
            {
                PatientAge[0] = DateTime.Now.Year - RISObject_1.PatientDOB.Year;
                PatientAge[1] = DateTime.Now.Year - RISObject_2.PatientDOB.Year;
                PatientAge[2] = DateTime.Now.Year - RISObject_3.PatientDOB.Year;
            }
        }

        public string[] ModalityName
        {
            get
            {
                string[] ModalityName = new string[3];
                ModalityName[0] = RISObject_1.ModalityName;
                ModalityName[1] = RISObject_2.ModalityName;
                ModalityName[2] = RISObject_3.ModalityName;
                return ModalityName;
            }
            set
            {
                ModalityName[0] = RISObject_1.ModalityName;
                ModalityName[1] = RISObject_2.ModalityName;
                ModalityName[2] = RISObject_3.ModalityName;
            }
        }

        public string[] ExamType
        {
            get
            {
                string[] ExamType = new string[3];
                ExamType[0] = RISObject_1.ExamType;
                ExamType[1] = RISObject_2.ExamType;
                ExamType[2] = RISObject_3.ExamType;
                return ExamType;
            }
            set
            {
                ExamType[0] = RISObject_1.ExamType;
                ExamType[1] = RISObject_2.ExamType;
                ExamType[2] = RISObject_3.ExamType;
            }
        }

        public string[] PerformingPhysicianName
        {
            get
            {
                string[] PerformingPhysicianName = new string[3];
                PerformingPhysicianName[0] = RISObject_1.PerformingPhysicianName;
                PerformingPhysicianName[1] = RISObject_2.PerformingPhysicianName;
                PerformingPhysicianName[2] = RISObject_3.PerformingPhysicianName;
                return PerformingPhysicianName;
            }
            set
            {
                PerformingPhysicianName[0] = RISObject_1.PerformingPhysicianName;
                PerformingPhysicianName[1] = RISObject_2.PerformingPhysicianName;
                PerformingPhysicianName[2] = RISObject_3.PerformingPhysicianName;
            }
        }

        public DateTime[] CheckInDate
        {
            get
            {
                DateTime[] CheckInDate = new DateTime[3];
                CheckInDate[0] = RISObject_1.CheckInDate;
                CheckInDate[1] = RISObject_2.CheckInDate;
                CheckInDate[2] = RISObject_3.CheckInDate;
                return CheckInDate;
            }
            set
            {
                CheckInDate[0] = RISObject_1.CheckInDate;
                CheckInDate[1] = RISObject_2.CheckInDate;
                CheckInDate[2] = RISObject_3.CheckInDate;
            }
        }

        public static string Allergies { get; set; }

        public static string DiabetesType { set; get; }

        public static string Description { set; get; }

        public String SystemID { set; get; }

        public void SaveAllergyObject()
        {
            AllergyObject.Allergies = Allergies;
            AllergyObject.DiabetesType = DiabetesType;
            AllergyObject.Description = Description;
        }

        public void Btn_FetchClicked()
        {

            List<OrderModel> orderList = ultrasoundObject.FetchOrders();
            RISObject_1 = orderList.ElementAt(0);
            RISObject_2 = orderList.ElementAt(1);
            RISObject_3 = orderList.ElementAt(2);

        }

        public Boolean ExportToPACSButtonProcessing()
        {
            Boolean ExportToPACSSuccess;

            ExportToPACSSuccess = UltrasoundModality.ExportToPACS(ultrasoundObject);
            return ExportToPACSSuccess;
        }

        public void StartExam()
        {

            ultrasoundObject.Allergies = Allergies;
            ultrasoundObject.DiabetesType = DiabetesType;
            ultrasoundObject.Description = Description;

            ultrasoundObject.SystemID = "US101";
            if (CurrentObjectNumber == 1)
                SendObject_1();
            else if (CurrentObjectNumber == 2)
                SendObject_2();
            else if (CurrentObjectNumber == 3)
                SendObject_3();
        }

        private void SendObject_3()
        {

            ultrasoundObject.MRN = MRN[2];
            ultrasoundObject.PatientInitials = PatientInitials[2];
            ultrasoundObject.PatientAge = PatientAge[2];
            ultrasoundObject.PatientFirstName = PatientFirstName[2];
            ultrasoundObject.PatientMiddleName = PatientMiddleName[2];
            ultrasoundObject.PatientLastName = PatientLastName[2];
            ultrasoundObject.CheckInTime = RISObject_3.CheckInTime;
            ultrasoundObject.PatientDOB = RISObject_3.PatientDOB;
            ultrasoundObject.PatientGender = PatientGender[2];
            ultrasoundObject.CheckInDate = CheckInDate[2];
            ultrasoundObject.PatientBloodGroup = PatientBloodGroup[2];
            ultrasoundObject.ReferringPhysicianName = ReferringPhysicianName[2];
            ultrasoundObject.ModalityName = ModalityName[2];
            ultrasoundObject.ExamType = ExamType[2];
            ultrasoundObject.PerformingPhysicianName = RISObject_3.PerformingPhysicianName;
        }

        private void SendObject_2()
        {
            ultrasoundObject.MRN = MRN[1];
            ultrasoundObject.PatientInitials = PatientInitials[1];
            ultrasoundObject.PatientAge = PatientAge[1];
            ultrasoundObject.PatientFirstName = PatientFirstName[1];
            ultrasoundObject.PatientMiddleName = PatientMiddleName[1];
            ultrasoundObject.PatientLastName = PatientLastName[1];
            ultrasoundObject.PatientGender = PatientGender[1];
            ultrasoundObject.CheckInTime = RISObject_2.CheckInTime;
            ultrasoundObject.PatientDOB = RISObject_2.PatientDOB;
            ultrasoundObject.CheckInDate = CheckInDate[1];
            ultrasoundObject.PatientBloodGroup = PatientBloodGroup[1];
            ultrasoundObject.ReferringPhysicianName = ReferringPhysicianName[1];
            ultrasoundObject.ModalityName = ModalityName[1];
            ultrasoundObject.ExamType = ExamType[1];
            ultrasoundObject.PerformingPhysicianName = RISObject_2.PerformingPhysicianName;
        }

        private void SendObject_1()
        {
            ultrasoundObject.MRN = MRN[0];
            ultrasoundObject.PatientInitials = PatientInitials[0];
            ultrasoundObject.PatientAge = PatientAge[0];
            ultrasoundObject.PatientFirstName = PatientFirstName[0];
            ultrasoundObject.PatientMiddleName = PatientMiddleName[0];
            ultrasoundObject.PatientLastName = PatientLastName[0];
            ultrasoundObject.CheckInTime = RISObject_1.CheckInTime;
            ultrasoundObject.PatientDOB = RISObject_1.PatientDOB;
            ultrasoundObject.PatientGender = PatientGender[0];
            ultrasoundObject.CheckInDate = CheckInDate[0];
            ultrasoundObject.PatientBloodGroup = PatientBloodGroup[0];
            ultrasoundObject.ReferringPhysicianName = ReferringPhysicianName[0];
            ultrasoundObject.ModalityName = ModalityName[0];
            ultrasoundObject.ExamType = ExamType[0];
            ultrasoundObject.PerformingPhysicianName = RISObject_1.PerformingPhysicianName;
        }



    }



}

