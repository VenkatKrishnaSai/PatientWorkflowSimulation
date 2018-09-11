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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PWSApp_ViewModel;

namespace PWSApp_WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RIS_Window : Window
    {


        public RIS_Window()
        {
            InitializeComponent();
            DataContext = new RIS_ViewModel();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            bool res=RIS_ViewModel.button_Clicked(Properties.Settings.Default.MRN);
           
             if (res == true)
            {
            Modality_FirstWindow modality_FirstWindow = new Modality_FirstWindow();
                modality_FirstWindow.Show();
                
                this.Close();
            }

            if (res == false) {

               MessageBox.Show("Enter character should not be between [//, /,:,?,*,<,>,|] ","Error",MessageBoxButton.OK,MessageBoxImage.Error);
               /// txtFirstName.Focus();
            }

          
            //this.Close();
        }

        private void comboModalityName_DropDownClosed(object sender, EventArgs e)
        {

            comboExamSearch.Items.Clear();

            if (comboModalityName.Text == "UltraSound")
            {
                comboExamSearch.Items.Add("Abdominal UltraSound");
                comboExamSearch.Items.Add("Pelvic UltraSound");
                comboExamSearch.Items.Add("TransAbdominal UltraSound");
                comboExamSearch.Items.Add("Obstetric UltraSound");
            }


            else if (comboModalityName.Text == "XRay")
            {

                comboExamSearch.Items.Add("Chest XRay");
                comboExamSearch.Items.Add("Lungs XRay");
                comboExamSearch.Items.Add("Abdomen XRay");
                comboExamSearch.Items.Add("Teeth XRay");
                comboExamSearch.Items.Add("Kidney XRay");

            }

            else if (comboModalityName.Text == "MRI")
            {

                comboExamSearch.Items.Add("Functional MRI");
                comboExamSearch.Items.Add("Breast scans");
                comboExamSearch.Items.Add("MRI");
                comboExamSearch.Items.Add("MRV");
                comboExamSearch.Items.Add("Cardiac MRI");

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                int MRN = Properties.Settings.Default.MRN;
                txtMRN.Text = MRN.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.MRN = Properties.Settings.Default.MRN + 1;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Proceedbtn.IsEnabled = true;
        }


       
    }
}
