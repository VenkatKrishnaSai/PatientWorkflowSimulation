using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWSApp_DataAccessLayer;
using PWSApp_RecordModel;
namespace PWS_BusinessLayer
{
    public class PACSManager
    {
        private PACS_DataAccessObject dao;

        public PACSManager()
        {
            dao = new PACS_DataAccessObject();
            //RecordModel record = new RecordModel();
            //sendInfoToPACS(record);
        }

        public int sendInfoToPACS(RecordModel record)
        {

            int status = 0;
            try
            {
                if (record != null)
                {
                    status = dao.AddRecords(record);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        public List<RecordModel> FetchRecords(int choice)
        {
            List<RecordModel> records = null;
            try
            {
                records = dao.GetRecords();
                SortRecords(records, choice);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return records;
        }

        private void SortRecords(List<RecordModel> records, int choice)
        {
            Comparison<RecordModel> comparison = null;
            switch (choice)
            {
                case 1:
                    comparison = (p1, p2) => p1.ModalityName.CompareTo(p2.ModalityName);
                    break;

                case 2:
                    comparison = (p1, p2) => p1.PatientLastName.CompareTo(p2.PatientLastName);
                    break;

                case 3:
                    comparison = (p1, p2) => p1.PatientFirstName.CompareTo(p2.PatientFirstName);
                    break;

                default:
                    comparison = (p1, p2) => p1.ModalityName.CompareTo(p2.ModalityName);
                    break;
            }
            records.Sort(comparison);
        }

        public int Update(RecordModel record)
        {
            int status = 0;
            try
            {
                if (record != null)
                    status = dao.UpdateRecord(record);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }


        public SqlDataAdapter GetDataFromBL(string MRN, string FirstName, string LastName, string ReferringPhysician, DateTime CheckInDate, string ModalityName)
        {
            SqlDataAdapter adapter = null;
            try
            {
                PACS_DataAccessObject obj1 = new PACS_DataAccessObject();
                adapter = obj1.GetDataFromDAL(MRN, FirstName, LastName, ReferringPhysician, CheckInDate, ModalityName);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return adapter;
        }

       
    }


}
