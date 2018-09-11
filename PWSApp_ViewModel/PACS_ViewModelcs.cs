using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PWS_BusinessLayer;
using PWSApp_RecordModel;
namespace PWSApp_ViewModel
{

    public class PACS_ViewModel
    {
        private static string _MRN;
        public static string MRN
        {
            get
            {
                if (_MRN == null)
                {
                    return "";
                }
                return _MRN;
            }

            set
            {
                _MRN = value;
            }
        }
        private static string _firstName;
        private static string _lastName;
        private static string _referringPhysicianName;
        private static DateTime? _dateOfExam;
        private static string _modalityType;
        private static string _allergies;
        private static string _description;


        public static string Allergies
        {
            get
            {
                if (_allergies == null)
                {
                    //MessageBox.Show("kk");
                    return "";
                }
                return _allergies;
            }

            set
            {
                
                _allergies = value;
            }
        }



       
     public static string Description
        {
            get
            {
                if (_description == null)
                {
                    _description = "";
                }
                return _description;
            }

            set
            {
               
                _description = value;
            }
        }
        





        public static string FirstName
        {
            get
            {
                if (_firstName == null)
                {
                    return "";
                }
                return _firstName;
            }

            set
            {
                _firstName = value;
            }
        }

        public static string LastName
        {
            get
            {
                if (_lastName == null)
                {
                    return "";
                }
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

        public static string ReferringPhysician
        {
            get
            {
                if (_referringPhysicianName == null)
                {
                    return "";
                }
                return _referringPhysicianName;
            }

            set
            {
                _referringPhysicianName = value;
            }
        }

        public static DateTime? DateOfExam
        {

            get
            {
                if (_dateOfExam == null)
                {
                    return DateTime.Now;
                    //_dateOfExam = (DateTime?)SqlDateTime.MinValue;//myself
                }
               
                return _dateOfExam;
            }

            set
            {
                if ((DateOfExam != null) || !DateOfExam.Equals(value))
                    _dateOfExam = value;
            }

        }

        public static string ModalityType
        {
            get
            {
                if (_modalityType == null)
                {
                    return "";
                }
                return _modalityType;
            }

            set
            {
                _modalityType = value;
            }
        }
        


        public static SqlDataAdapter Button_Clicked()
        {

           // MessageBox.Show(MRN + FirstName + LastName + ReferringPhysician + DateOfExam + ModalityType);

            PACSManager pacsManager = new PACSManager();
            //List<RecordModel> records = new List<RecordModel>();
           // MessageBox.Show(DateOfExam.ToString());
            SqlDataAdapter adapter = pacsManager.GetDataFromBL(MRN, FirstName, LastName, ReferringPhysician, (DateTime)DateOfExam, ModalityType);
            return adapter;
        }
    }


}
