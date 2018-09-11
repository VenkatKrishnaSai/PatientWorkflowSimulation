using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PWSApp_ViewModel;
namespace PWSApp_WPFUI
{
    /// <summary>
    /// Interaction logic for Modality_FirstWindow.xaml
    /// </summary>
    public partial class Modality_FirstWindow : Window
    {
        Modality_ViewModel ViewModelObject = new Modality_ViewModel();

        public Modality_FirstWindow()
        {
            InitializeComponent();
            DataContext = new Modality_ViewModel();

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            //ViewModelObject = new ViewModel();
            ViewModelObject.Btn_FetchClicked();
            FetchRadioButton1.IsEnabled = true;
            FetchRadioButton2.IsEnabled = true;
            FetchRadioButton3.IsEnabled = true;

            MRN_1.Text = ViewModelObject.MRN[0];
            MRN_2.Text = ViewModelObject.MRN[1];
            MRN_3.Text = ViewModelObject.MRN[2];

            PatientFirstName_1.Text = ViewModelObject.PatientFirstName[0];
            PatientFirstName_2.Text = ViewModelObject.PatientFirstName[1];
            PatientFirstName_3.Text = ViewModelObject.PatientFirstName[2];

            PatientMiddleName_1.Text = ViewModelObject.PatientMiddleName[0];
            PatientMiddleName_2.Text = ViewModelObject.PatientMiddleName[1];
            PatientMiddleName_3.Text = ViewModelObject.PatientMiddleName[2];

            PatientLastName_1.Text = ViewModelObject.PatientLastName[0];
            PatientLastName_2.Text = ViewModelObject.PatientLastName[1];
            PatientLastName_3.Text = ViewModelObject.PatientLastName[2];

            PatientAge_1.Text = ViewModelObject.PatientAge[0].ToString();
            PatientAge_2.Text = ViewModelObject.PatientAge[1].ToString();
            PatientAge_3.Text = ViewModelObject.PatientAge[2].ToString();

            PatientGender_1.Text = ViewModelObject.PatientGender[0];
            PatientGender_2.Text = ViewModelObject.PatientGender[1];
            PatientGender_3.Text = ViewModelObject.PatientGender[2];

            ExamType_1.Text = ViewModelObject.ExamType[0];
            ExamType_2.Text = ViewModelObject.ExamType[1];
            ExamType_3.Text = ViewModelObject.ExamType[2];

            ReferringPhysicianName_1.Text = ViewModelObject.ReferringPhysicianName[0];
            ReferringPhysicianName_2.Text = ViewModelObject.ReferringPhysicianName[1];
            ReferringPhysicianName_3.Text = ViewModelObject.ReferringPhysicianName[2];

            DateOfExam_1.Text = ViewModelObject.CheckInDate[0].ToString();
            DateOfExam_2.Text = ViewModelObject.CheckInDate[1].ToString();
            DateOfExam_3.Text = ViewModelObject.CheckInDate[2].ToString();
        }

        public void select_Checked(object sender, RoutedEventArgs e)
        {
            //ViewModelObject = new ViewModel();

            MRNTextBox.Text = ViewModelObject.MRN[0];
            PatientNameTextBox.Text = ViewModelObject.PatientInitials[0] + " " + ViewModelObject.PatientFirstName[0] + " " + ViewModelObject.PatientMiddleName[0] + " " + ViewModelObject.PatientLastName[0];
            PatientAgeTextBox.Text = (ViewModelObject.PatientAge[0]).ToString();
            ReferringPhysicianNameTextBox.Text = ViewModelObject.ReferringPhysicianName[0];
            ExamTypeTextBox.Text = ViewModelObject.ExamType[0];
            GenderTextBox.Text = ViewModelObject.PatientGender[0];

            ViewModelObject.CurrentObjectNumber = 1;
        }

        private void No_Checked(object sender, RoutedEventArgs e)
        {
            DiabetesType.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            ViewModelObject.SaveAllergyObject();
            ViewModelObject.StartExam();

            Modality_SecondWindow modality2Window = new Modality_SecondWindow(ViewModelObject);
            modality2Window.Show();
            ViewModelObject.Window2DataBinding();

            if (ViewModelObject.CurrentObjectNumber == 1)
            {
                modality2Window.Modality2PatientNameTextBox.Text = ViewModelObject.PatientFirstName[0];
                modality2Window.Modality2MRNTextbox.Text = ViewModelObject.MRN[0];
            }
            else if (ViewModelObject.CurrentObjectNumber == 2)
            {
                modality2Window.Modality2PatientNameTextBox.Text = ViewModelObject.PatientFirstName[1];
                modality2Window.Modality2MRNTextbox.Text = ViewModelObject.MRN[1];
            }
            else if (ViewModelObject.CurrentObjectNumber == 3)
            {
                modality2Window.Modality2PatientNameTextBox.Text = ViewModelObject.PatientFirstName[2];
                modality2Window.Modality2MRNTextbox.Text = ViewModelObject.MRN[2];
            }

            this.Close();
        }

        private void FetchRadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            // ViewModelObject = new ViewModel();

            MRNTextBox.Text = ViewModelObject.MRN[1];
            PatientNameTextBox.Text = ViewModelObject.PatientInitials[1] + " " + ViewModelObject.PatientFirstName[1] + " " + ViewModelObject.PatientMiddleName[1] + " " + ViewModelObject.PatientLastName[1];
            PatientAgeTextBox.Text = (ViewModelObject.PatientAge[1]).ToString();
            ReferringPhysicianNameTextBox.Text = ViewModelObject.ReferringPhysicianName[1];
            ExamTypeTextBox.Text = ViewModelObject.ExamType[1];
            GenderTextBox.Text = ViewModelObject.PatientGender[1];

            ViewModelObject.CurrentObjectNumber = 2;
        }

        private void FetchRadioButton3_Checked(object sender, RoutedEventArgs e)
        {
            //ViewModelObject = new ViewModel();

            MRNTextBox.Text = ViewModelObject.MRN[2];
            PatientNameTextBox.Text = ViewModelObject.PatientInitials[2] + " " + ViewModelObject.PatientFirstName[2] + " " + ViewModelObject.PatientMiddleName[2] + " " + ViewModelObject.PatientLastName[2];
            PatientAgeTextBox.Text = (ViewModelObject.PatientAge[2]).ToString();
            ReferringPhysicianNameTextBox.Text = ViewModelObject.ReferringPhysicianName[2];
            ExamTypeTextBox.Text = ViewModelObject.ExamType[2];
            GenderTextBox.Text = ViewModelObject.PatientGender[2];

            ViewModelObject.CurrentObjectNumber = 3;
        }
    }
}
