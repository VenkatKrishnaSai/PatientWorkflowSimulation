using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWSApp_PatientModel;
using PWSApp_ModalityModel;
using PWSApp_OrderModell;
using PWSApp_DataAccessLayer;
namespace PWS_BusinessLayer
{
    public class RISDataManager
    {
        public PatientModel patientData;
        public ModalityModel modalityData;
        private RIS_DataAccessObject dao;
        public OrderModel orderData;

        public RISDataManager(string MRN, string PatientInitials, string PatientFirstName, string PatientMiddleName, string PatientLastName, DateTime CheckInDate, DateTime CheckInTime, string PatientBloodGroup, string PatientGender, DateTime PatientDOB, string ModalityName, string ExamType, string ReferringPhysicianName, string PerformingPhysicianName)
        {
            patientData = new PatientModel()
            {
                MRN = MRN,
                PatientInitials = PatientInitials,
                PatientFirstName = PatientFirstName,
                PatientMiddleName = PatientMiddleName,
                PatientLastName = PatientLastName,
                CheckInDate = CheckInDate,
                CheckInTime = CheckInTime,
                PatientBloodGroup = PatientBloodGroup,
                PatientGender = PatientGender,
                PatientDOB = PatientDOB
            };

            modalityData = new ModalityModel()
            {
                ModalityName = ModalityName,
                ExamType = ExamType,
                ReferringPhysicianName = ReferringPhysicianName,
                PerformingPhysicianName = PerformingPhysicianName
            };

            dao = new RIS_DataAccessObject();

            int status_PatientData = savePatientData();

            int status_ModalityData = saveModalityData();




        }

        public RISDataManager()
        {
            dao = new RIS_DataAccessObject();
        }

        public int savePatientData()
        {
            int status = 0;
            try
            {
                if (patientData != null)
                {
                    status = dao.AddPatientData(patientData);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        public int saveModalityData()
        {
            int status = 0;
            try
            {
                if (modalityData != null)
                {
                    status = dao.AddModalityData(modalityData);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }


        public List<OrderModel> GetOrders()
        {
            List<PatientModel> patientDataList = null;
            List<ModalityModel> modalityDataList = null;
            List<OrderModel> ordersList = null;

            patientDataList = dao.GetPatientData();

            modalityDataList = dao.GetModalityData();

            try
            {
                ordersList = new List<OrderModel>();
                foreach (var patientData in patientDataList)
                {
                    orderData = new OrderModel();
                    orderData.MRN = patientData.MRN;
                    orderData.PatientInitials = patientData.PatientInitials;
                    orderData.PatientFirstName = patientData.PatientFirstName;
                    orderData.PatientMiddleName = patientData.PatientMiddleName;
                    orderData.PatientLastName = patientData.PatientLastName;
                    orderData.CheckInDate = patientData.CheckInDate;
                    orderData.CheckInTime = patientData.CheckInTime;
                    orderData.PatientBloodGroup = patientData.PatientBloodGroup;
                    orderData.PatientGender = patientData.PatientGender;
                    orderData.PatientDOB = patientData.PatientDOB;
                    orderData.ModalityName = "";
                    orderData.ExamType = "";
                    orderData.ReferringPhysicianName = "";
                    orderData.PerformingPhysicianName = "";
                    ordersList.Add(orderData);
                }
                int i = 0;
                foreach (var modalityData in modalityDataList)
                {
                    ordersList.ElementAt(i).ModalityName = modalityData.ModalityName;
                    ordersList.ElementAt(i).ExamType = modalityData.ExamType;
                    ordersList.ElementAt(i).ReferringPhysicianName = modalityData.ReferringPhysicianName;
                    ordersList.ElementAt(i).PerformingPhysicianName = modalityData.PerformingPhysicianName;
                    i++;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ordersList;
        }

    }
}

