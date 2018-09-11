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
    /// Interaction logic for Modality_SecondWindow.xaml
    /// </summary>
    public partial class Modality_SecondWindow : Window
    {
        Modality_ViewModel ViewModelObject;

        public Modality_SecondWindow(Modality_ViewModel ViewModelObject)
        {
            InitializeComponent();
            this.ViewModelObject = ViewModelObject;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("This is dummy report.");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Exam ended successfully !");
            ExportToPACSButton.IsEnabled = true;
            GenerateReportButton.IsEnabled = true;
        }

        private void ExportToPACSButton_Click(object sender, RoutedEventArgs e)
        {
            Boolean check = ViewModelObject.ExportToPACSButtonProcessing();
            if (check == true)
                MessageBox.Show("Exported to PACS successfully !!");

            PACS_Window pacs_window = new PACS_Window();
            pacs_window.Show();
            this.Close();
        }
    }
}
