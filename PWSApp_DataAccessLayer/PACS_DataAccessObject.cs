using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWSApp_DataAccessLayer.Utilities;
using PWSApp_RecordModel;


namespace PWSApp_DataAccessLayer
{
    public class PACS_DataAccessObject
    {
        public int AddRecords(RecordModel record)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            int status = 0;
            try
            {
                connection = PACS_DaoUtility.CreateConnection();

                string query = "InsertRecord";
                command = PACS_DaoUtility.CreateCommand(connection, query, CommandType.StoredProcedure);

                SqlParameter paramMRN =
                    PACS_DaoUtility.CreateParameter("@MRN", record.MRN, SqlDbType.VarChar);
                SqlParameter paramPatientInitials =
                    PACS_DaoUtility.CreateParameter("@PatientInitials", record.PatientInitials, SqlDbType.VarChar);
                SqlParameter paramPatientFirstName =
                    PACS_DaoUtility.CreateParameter("@PatientFirstName", record.PatientFirstName, SqlDbType.VarChar);
                SqlParameter paramPatientMiddleName =
                    PACS_DaoUtility.CreateParameter("@PatientMiddleName", record.PatientMiddleName, SqlDbType.VarChar);
                SqlParameter paramPatientLastName =
                   PACS_DaoUtility.CreateParameter("@PatientLastName", record.PatientLastName, SqlDbType.VarChar);
                SqlParameter paramPatientCheckInDate =
                   PACS_DaoUtility.CreateParameter("@PatientCheckInDate", record.CheckInDate, SqlDbType.DateTime);
                SqlParameter paramPatientCheckInTime =
                   PACS_DaoUtility.CreateParameter("@PatientCheckInTime", record.CheckInTime, SqlDbType.DateTime);
                SqlParameter paramPatientBloodGroup =
                   PACS_DaoUtility.CreateParameter("@PatientBloodGroup", record.PatientBloodGroup, SqlDbType.VarChar);
                SqlParameter paramPatientGender =
                    PACS_DaoUtility.CreateParameter("@PatientGender", record.PatientGender, SqlDbType.VarChar);
                SqlParameter paramPatientDOB =
                    PACS_DaoUtility.CreateParameter("@PatientDOB", record.PatientDOB, SqlDbType.DateTime);
                SqlParameter paramModalityReferCode =
                    PACS_DaoUtility.CreateParameter("@ModalityName", record.ModalityName, SqlDbType.VarChar);
                SqlParameter paramExamType =
                    PACS_DaoUtility.CreateParameter("@ExamType", record.ExamType, SqlDbType.VarChar);
                SqlParameter paramReferringPhysicianName =
                    PACS_DaoUtility.CreateParameter("@ReferringPhysicianName", record.ReferringPhysicianName, SqlDbType.VarChar);
                SqlParameter paramPerformingPhysicianName =
                    PACS_DaoUtility.CreateParameter("@PerformingPhysicianName", record.PerformingPhysicianName, SqlDbType.VarChar);


                if (record.Allergies == null) {
                    record.Allergies = "";
                }
                SqlParameter paramAllergies =
                    PACS_DaoUtility.CreateParameter("@Allergies", record.Allergies, SqlDbType.VarChar);
                if (record.DiabetesType == null)
                {
                    record.DiabetesType = "";
                }
                SqlParameter paramDiabetesType =
                    PACS_DaoUtility.CreateParameter("@DiabetesType", record.DiabetesType, SqlDbType.VarChar);
                if (record.Description == null)
                {
                    record.Description = "";
                }
                SqlParameter paramDescription =
                    PACS_DaoUtility.CreateParameter("@Description", record.Description, SqlDbType.VarChar);

                command.Parameters.Add(paramMRN);
                command.Parameters.Add(paramPatientInitials);
                command.Parameters.Add(paramPatientFirstName);
                command.Parameters.Add(paramPatientMiddleName);
                command.Parameters.Add(paramPatientLastName);

                command.Parameters.Add(paramPatientCheckInDate);
                command.Parameters.Add(paramPatientCheckInTime);
                command.Parameters.Add(paramPatientBloodGroup);
                command.Parameters.Add(paramPatientGender);
                command.Parameters.Add(paramPatientDOB);
                command.Parameters.Add(paramModalityReferCode);
                command.Parameters.Add(paramExamType);
                command.Parameters.Add(paramReferringPhysicianName);
                command.Parameters.Add(paramPerformingPhysicianName);
                command.Parameters.Add(paramAllergies);
                command.Parameters.Add(paramDiabetesType);
                command.Parameters.Add(paramDescription);

                /* Changes*/
                PACS_DaoUtility.OpenConnection(connection);
                status = command.ExecuteNonQuery();
                /*End changes*/
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PACS_DaoUtility.CloseConnection(connection);
            }
            return status;
        }

        public List<RecordModel> GetRecords()
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;
            List<RecordModel> records = null;
            try
            {
                connection = PACS_DaoUtility.CreateConnection();
                command = PACS_DaoUtility.CreateCommand(connection, "GetRecords", CommandType.StoredProcedure);
                PACS_DaoUtility.OpenConnection(connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    records = new List<RecordModel>();
                    while (reader.Read())
                    {
                        RecordModel record = new RecordModel
                        {
                            MRN = reader["MRN"].ToString(),
                            PatientFirstName = reader["PatientFirstName"].ToString(),
                            PatientLastName = reader["PatientLastName"].ToString(),
                            ReferringPhysicianName = reader["ReferringPhysicianName"].ToString(),
                            //CheckInDate = reader["CheckInDate"].ToString(),
                            CheckInDate = DateTime.Parse(reader["CheckInDate"].ToString()),
                            ModalityName = reader["ModalityType"].ToString()
                        };
                        records.Add(record);
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
                PACS_DaoUtility.CloseConnection(connection);
            }
            return records;
        }

       
        public SqlDataAdapter GetDataFromDAL(string uMRN, string uFirstName, string uLastName, string uReferrringPhysician, DateTime uCheckInDate, string uModalityName)
        
        {

            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataAdapter reader = null;
            
            try
            {
                connection = PACS_DaoUtility.CreateConnection();
                command = PACS_DaoUtility.CreateCommand(connection, "GetSearchRecords", CommandType.StoredProcedure);
                //command = DaoUtility.CreateCommand(connection, "update products set productname=@name, productdescription=@desc, price=@price where productid=@id", CommandType.Text);

                SqlParameter pmMRN = PACS_DaoUtility.CreateParameter("@MRN", uMRN, SqlDbType.VarChar);
                SqlParameter pmFirstName = PACS_DaoUtility.CreateParameter("@PatientFirstName", uFirstName, SqlDbType.VarChar);

                SqlParameter pmLastName = PACS_DaoUtility.CreateParameter("@PatientLastName", uLastName, SqlDbType.VarChar);
                SqlParameter pmReferringPhysician = PACS_DaoUtility.CreateParameter("@ReferringPhysicianName", uReferrringPhysician, SqlDbType.VarChar);
                SqlParameter pmCheckInDate = PACS_DaoUtility.CreateParameter("@CheckInDate", uCheckInDate, SqlDbType.VarChar);
                SqlParameter pmModalityName = PACS_DaoUtility.CreateParameter("@ModalityName", uModalityName, SqlDbType.VarChar);

                command.Parameters.Add(pmMRN);
                command.Parameters.Add(pmLastName);
                command.Parameters.Add(pmCheckInDate);
                command.Parameters.Add(pmModalityName);
                command.Parameters.Add(pmReferringPhysician);
                command.Parameters.Add(pmFirstName);

                PACS_DaoUtility.OpenConnection(connection);
                reader = new SqlDataAdapter(command);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;
        }

        //public SqlDataAdapter GetDataForFirstName(string uFirstName)
        //{
        //    SqlConnection connection = null;
        //    SqlCommand command = null;
        //    SqlDataAdapter reader = null;
        //    //SqlDataReader reader = null;
        //    //List<Record> records = null;
        //    try
        //    {
        //        connection = DaoUtility.CreateConnection();
        //        command = DaoUtility.CreateCommand(connection, "GetSearchRecords", CommandType.StoredProcedure);

        //        SqlParameter pmFirstName = DaoUtility.CreateParameter("@FirstName", uFirstName, SqlDbType.VarChar);
        //        command.Parameters.Add(pmFirstName);

        //        DaoUtility.OpenConnection(connection);
        //        reader = new SqlDataAdapter(command);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    return reader;
        //}

        public int UpdateRecord(RecordModel record)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            int status = 0;
            try
            {
                connection = PACS_DaoUtility.CreateConnection();
                /*
                command = DaoUtility.CreateCommand(connection, "update PACS_Table set MRN=@paramMRN, PatientInitials=@PatientInitials, PatientFirstName=@PatientFirstName,PatientMiddleName=@PatientMiddleName,CheckInDate=@CheckInDate,CheckInTime=@CheckInTime, PatientBloodGroup=@PatientBloodGroup,PatientGender=@PatientGender,PatientDOB=@PatientDOB,ModalityReferCode=@ModalityReferCode,ExamType=@ExamType,ReferringPhysicianName=@ReferringPhysicianName,Allergies=@Allergies,DiabetesType=@DiabetesType,DescriptionAttribute=@Description where productid=@id", CommandType.Text);
                */
                string query = "UpdateRecords";
                command = PACS_DaoUtility.CreateCommand(connection, query, CommandType.StoredProcedure);


                SqlParameter paramMRN =
                     PACS_DaoUtility.CreateParameter("@MRN", record.MRN, SqlDbType.VarChar);
                SqlParameter paramPatientInitials =
                    PACS_DaoUtility.CreateParameter("@PatientInitials", record.PatientInitials, SqlDbType.VarChar);
                SqlParameter paramPatientFirstName =
                    PACS_DaoUtility.CreateParameter("@PatientFirstName", record.PatientFirstName, SqlDbType.VarChar);
                SqlParameter paramPatientMiddleName =
                    PACS_DaoUtility.CreateParameter("@PatientMiddleName", record.PatientMiddleName, SqlDbType.VarChar);
                SqlParameter paramPatientLastName =
                   PACS_DaoUtility.CreateParameter("@PatientLastName", record.PatientLastName, SqlDbType.VarChar);
                SqlParameter paramPatientCheckInDate =
                   PACS_DaoUtility.CreateParameter("@PatientCheckInDate", record.CheckInDate, SqlDbType.DateTime);
                SqlParameter paramPatientCheckInTime =
                   PACS_DaoUtility.CreateParameter("@PatientCheckInTime", record.CheckInTime, SqlDbType.DateTime);
                SqlParameter paramPatientBloodGroup =
                   PACS_DaoUtility.CreateParameter("@PatientBloodGroup", record.PatientBloodGroup, SqlDbType.VarChar);
                SqlParameter paramPatientGender =
                    PACS_DaoUtility.CreateParameter("@PatientGender", record.PatientGender, SqlDbType.VarChar);
                SqlParameter paramPatientDOB =
                    PACS_DaoUtility.CreateParameter("@PatientDOB", record.PatientDOB, SqlDbType.DateTime);
                SqlParameter paramModalityReferCode =
                    PACS_DaoUtility.CreateParameter("@ModalityName", record.ModalityName, SqlDbType.VarChar);
                SqlParameter paramExamType =
                    PACS_DaoUtility.CreateParameter("@ExamType", record.ExamType, SqlDbType.VarChar);
                SqlParameter paramReferringPhysicianName =
                    PACS_DaoUtility.CreateParameter("@ReferringPhysicianName", record.ReferringPhysicianName, SqlDbType.VarChar);
                SqlParameter paramPerformingPhysicianName =
                    PACS_DaoUtility.CreateParameter("@PerformingPhysicianName", record.PerformingPhysicianName, SqlDbType.VarChar);
                SqlParameter paramAllergies =
                    PACS_DaoUtility.CreateParameter("@Allergies", record.Allergies, SqlDbType.VarChar);
                SqlParameter paramDiabetesType =
                    PACS_DaoUtility.CreateParameter("@DiabetesType", record.DiabetesType, SqlDbType.VarChar);
                SqlParameter paramDescription =
                    PACS_DaoUtility.CreateParameter("@Description", record.Description, SqlDbType.VarChar);

                command.Parameters.Add(paramMRN);
                command.Parameters.Add(paramPatientInitials);
                command.Parameters.Add(paramPatientFirstName);
                command.Parameters.Add(paramPatientMiddleName);
                command.Parameters.Add(paramPatientLastName);
                command.Parameters.Add(paramPatientCheckInDate);
                command.Parameters.Add(paramPatientCheckInTime);
                command.Parameters.Add(paramPatientBloodGroup);
                command.Parameters.Add(paramPatientGender);
                command.Parameters.Add(paramPatientDOB);
                command.Parameters.Add(paramModalityReferCode);
                command.Parameters.Add(paramExamType);
                command.Parameters.Add(paramReferringPhysicianName);
                command.Parameters.Add(paramPerformingPhysicianName);
                command.Parameters.Add(paramAllergies);
                command.Parameters.Add(paramDiabetesType);
                command.Parameters.Add(paramDescription);

                PACS_DaoUtility.OpenConnection(connection);
                status = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PACS_DaoUtility.CloseConnection(connection);
            }
            return status;
        }
    }
}
