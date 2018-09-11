using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWSApp_DataAccessLayer.Utilities;
using PWSApp_ModalityModel;
using PWSApp_PatientModel;

namespace PWSApp_DataAccessLayer
{
    public class RIS_DataAccessObject
    {

        public int AddPatientData(PatientModel patientModel)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            int status = 0;
            try
            {
                connection = RIS_DaoUtility.CreateConnection();

                string query = "InsertPatientData";
                command = RIS_DaoUtility.CreateCommand(connection, query, CommandType.StoredProcedure);

                SqlParameter paramMRN =
                    RIS_DaoUtility.CreateParameter("@pmrn", patientModel.MRN, SqlDbType.VarChar);

                SqlParameter paramInitials =
                    RIS_DaoUtility.CreateParameter("@pinitials", patientModel.PatientInitials, SqlDbType.VarChar);

                SqlParameter paramFirstName =
                    RIS_DaoUtility.CreateParameter("@pfirstname", patientModel.PatientFirstName, SqlDbType.VarChar);

                SqlParameter paramMiddleName =
                    RIS_DaoUtility.CreateParameter("@pmiddlename", patientModel.PatientMiddleName, SqlDbType.VarChar);

                SqlParameter paramLastName =
                    RIS_DaoUtility.CreateParameter("@plastname", patientModel.PatientLastName, SqlDbType.VarChar);

                SqlParameter paramCheckInDate =
                    RIS_DaoUtility.CreateParameter("@pcheckindate", patientModel.CheckInDate, SqlDbType.DateTime);

                SqlParameter paramCheckInTime =
                    RIS_DaoUtility.CreateParameter("@pcheckintime", patientModel.CheckInTime, SqlDbType.DateTime);

                SqlParameter paramBloodGroup =
                    RIS_DaoUtility.CreateParameter("@pbloodgroup", patientModel.PatientBloodGroup, SqlDbType.VarChar);

                SqlParameter paramGender =
                    RIS_DaoUtility.CreateParameter("@pgender", patientModel.PatientGender, SqlDbType.VarChar);

                SqlParameter paramDOB =
                    RIS_DaoUtility.CreateParameter("@pdob", patientModel.PatientDOB, SqlDbType.DateTime);

                command.Parameters.Add(paramMRN);
                command.Parameters.Add(paramInitials);
                command.Parameters.Add(paramFirstName);
                command.Parameters.Add(paramMiddleName);
                command.Parameters.Add(paramLastName);
                command.Parameters.Add(paramCheckInDate);
                command.Parameters.Add(paramCheckInTime);
                command.Parameters.Add(paramBloodGroup);
                command.Parameters.Add(paramGender);
                command.Parameters.Add(paramDOB);

                RIS_DaoUtility.OpenConnection(connection);
                status = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                RIS_DaoUtility.CloseConnection(connection);
            }
            return status;
        }

        public int AddModalityData(ModalityModel modalityModel)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            int status = 0;
            try
            {
                connection = RIS_DaoUtility.CreateConnection();

                string query = "InsertModalityData";
                command = RIS_DaoUtility.CreateCommand(connection, query, CommandType.StoredProcedure);

                SqlParameter paramModalityName =
                    RIS_DaoUtility.CreateParameter("@pmodalityname", modalityModel.ModalityName, SqlDbType.VarChar);

                SqlParameter paramExamType =
                    RIS_DaoUtility.CreateParameter("@pexamtype", modalityModel.ExamType, SqlDbType.VarChar);

                SqlParameter paramReferringPhysicianName =
                    RIS_DaoUtility.CreateParameter("@preferringphysicianname", modalityModel.ReferringPhysicianName, SqlDbType.VarChar);

                SqlParameter paramPerformingPhysicianName =
                    RIS_DaoUtility.CreateParameter("@pperformingphysicianname", modalityModel.PerformingPhysicianName, SqlDbType.VarChar);

                command.Parameters.Add(paramModalityName);
                command.Parameters.Add(paramExamType);
                command.Parameters.Add(paramReferringPhysicianName);
                command.Parameters.Add(paramPerformingPhysicianName);

                RIS_DaoUtility.OpenConnection(connection);
                status = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                RIS_DaoUtility.CloseConnection(connection);
            }
            return status;
        }

        public List<PatientModel> GetPatientData()
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            List<PatientModel> patientList = null;
            try
            {
                connection = RIS_DaoUtility.CreateConnection();
                command = RIS_DaoUtility.CreateCommand(connection, "GetPatientData", CommandType.StoredProcedure);
                RIS_DaoUtility.OpenConnection(connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    patientList = new List<PatientModel>();
                    while (reader.Read())
                    {
                        PatientModel patientModel = new PatientModel
                        {
                            MRN = reader["MRN"].ToString(),
                            PatientInitials = reader["PatientInitials"].ToString(),
                            PatientFirstName = reader["PatientFirstName"].ToString(),
                            PatientMiddleName = reader["PatientMiddleName"].ToString(),
                            PatientLastName = reader["PatientLastName"].ToString(),
                            CheckInDate = DateTime.Parse(reader["CheckInDate"].ToString()),
                            CheckInTime = DateTime.Parse(reader["CheckInTime"].ToString()),
                            PatientBloodGroup = reader["PatientBloodGroup"].ToString(),
                            PatientGender = reader["PatientGender"].ToString(),
                            PatientDOB = DateTime.Parse(reader["PatientDOB"].ToString())
                        };
                        patientList.Add(patientModel);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                RIS_DaoUtility.CloseConnection(connection);
            }
            return patientList;
        }

        public List<ModalityModel> GetModalityData()
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            List<ModalityModel> modalityList = null;
            try
            {
                connection = RIS_DaoUtility.CreateConnection();
                command = RIS_DaoUtility.CreateCommand(connection, "GetModalityData", CommandType.StoredProcedure);
                RIS_DaoUtility.OpenConnection(connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    modalityList = new List<ModalityModel>();
                    while (reader.Read())
                    {
                        ModalityModel modalityModel = new ModalityModel
                        {
                            ModalityName = reader["ModalityName"].ToString(),
                            ExamType = reader["ExamType"].ToString(),
                            ReferringPhysicianName = reader["ReferringPhysicianName"].ToString(),
                            PerformingPhysicianName = reader["PerformingPhysicianName"].ToString()
                        };
                        modalityList.Add(modalityModel);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                RIS_DaoUtility.CloseConnection(connection);
            }
            return modalityList;
        }
    }
}
