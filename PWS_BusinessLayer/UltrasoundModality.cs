using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWSApp_OrderModell;
using PWSApp_RecordModel;


namespace PWS_BusinessLayer
{
    public class UltrasoundModality
    {
        public string MRN { get; set; }

        public string PatientInitials { get; set; }

        public string PatientFirstName { get; set; }

        public string PatientMiddleName { get; set; }

        public string PatientLastName { get; set; }

        public string PatientBloodGroup { get; set; }

        public string PatientGender { get; set; }

        public DateTime PatientDOB { get; set; }

        public string ReferringPhysicianName { get; set; }

        public int PatientAge { get; set; }

        public string ModalityName { get; set; }

        public string ExamType { get; set; }

        public string PerformingPhysicianName { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckInTime { get; set; }

        public String Allergies { get; set; }

        public String DiabetesType { set; get; }

        public String Description { set; get; }

        public String SystemID { set; get; }

        public static Boolean ExportToPACS(UltrasoundModality UltrasoundObject)
        {


            //PACSObject.GetModalityObject(UltrasoundObject);
            RecordModel record = new RecordModel()
            {
                MRN = UltrasoundObject.MRN,
                PatientInitials = UltrasoundObject.PatientInitials,
                PatientFirstName = UltrasoundObject.PatientFirstName,
                PatientMiddleName = UltrasoundObject.PatientMiddleName,
                PatientLastName = UltrasoundObject.PatientLastName,
                CheckInDate = UltrasoundObject.CheckInDate,
                CheckInTime = UltrasoundObject.CheckInTime,
                PatientBloodGroup = UltrasoundObject.PatientBloodGroup,
                PatientGender = UltrasoundObject.PatientGender,
                PatientDOB = UltrasoundObject.PatientDOB,
                ModalityName = UltrasoundObject.ModalityName,
                ExamType = UltrasoundObject.ExamType,
                ReferringPhysicianName = UltrasoundObject.ReferringPhysicianName,
                PerformingPhysicianName = UltrasoundObject.PerformingPhysicianName,
                Allergies = UltrasoundObject.Allergies,
                DiabetesType = UltrasoundObject.DiabetesType,
                Description = UltrasoundObject.Description
            };
            PACSManager pacsManager = new PACSManager();
            pacsManager.sendInfoToPACS(record);
            return true;
        }

        public List<OrderModel> FetchOrders()
        {
            RISDataManager risDataManager = new RISDataManager();

            List<OrderModel> orderlist = risDataManager.GetOrders();

            return orderlist;

        }

    }
}
