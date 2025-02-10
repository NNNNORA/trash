using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContextLibrary.Entities;


namespace prilog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Request> Requests = new List<Request>();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            RequestsDataGrid.ItemsSource = null;
            RequestsDataGrid.ItemsSource = Requests;
        }

        private void AddRequestButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditRequest addRequestWindow = new AddEditRequest();
            addRequestWindow.ShowDialog();
            LoadData();
        }
        
    }


}