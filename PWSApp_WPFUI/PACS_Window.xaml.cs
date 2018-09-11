using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for PACS_Window.xaml
    /// </summary>
    public partial class PACS_Window : Window
    {
        public PACS_Window()
        {
            InitializeComponent();
            this.DataContext = new PACS_ViewModel();
        }

        public void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dataGridView1.SelectedItem;
                string ID = (dataGridView1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                MessageBox.Show("Report and Images with MRN No." + ID + " are generated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Row has been selected");
            }

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            


            try
            {
                SqlDataAdapter adapter = PACS_ViewModel.Button_Clicked();
                //SqlDataAdapter adapter = obj1.GetDataFromMRN_BU(FirstName);

                DataTable dt = new DataTable("PACS_Table");
                dataGridView1.ColumnWidth = 210;
                adapter.Fill(dt);

               

                dataGridView1.ItemsSource = dt.DefaultView;

                

                adapter.Update(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
