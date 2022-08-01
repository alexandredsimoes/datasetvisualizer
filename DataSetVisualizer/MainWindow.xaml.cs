using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace DataSetVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataSet _dataSet = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DataSets(*.xml)|*.xml";
            openFileDialog.Title = "Carregar DataSet";
            openFileDialog.CheckFileExists = true;
            if (openFileDialog.ShowDialog() ?? false)
            {
                _dataSet = new DataSet();
                _dataSet.ReadXml(openFileDialog.FileName);
                cbTables.Items.Clear();
                foreach (DataTable item in _dataSet.Tables)
                {
                    cbTables.Items.Add(item.TableName);
                }
            }            
        }

        private void cbTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataTable = e.AddedItems[0].ToString();
            dgItems.ItemsSource = _dataSet.Tables[dataTable].DefaultView;
        }
    }
}
