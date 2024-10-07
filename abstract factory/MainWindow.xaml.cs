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
using abstract_factory;

namespace abstract_factory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IShapeFactory _factory;
        public List<IShape> _shapes = new List<IShape>();
        public MainWindow()
        {
            InitializeComponent();
            _factory = new RedFactory();
            FactoryComboBox.SelectedIndex = 0; 

            // это чтобы в комбобоксе выбиралась красная фабрика и не было ошибок из за непоследовательной инициализации
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CreateShapes(); 
        }
        private void CreateShapes()
        {
            // удаляем существующие фигури
            ShapesCanvas.Children.Clear();

            _shapes.Clear();

            var circle = _factory.CreateCircle();
            var square = _factory.CreateSquare();
            var triangle = _factory.CreateTriangle();

            _shapes.Add(circle);
            _shapes.Add(square);
            _shapes.Add(triangle);

            
            foreach (var shape in _shapes)
            {
                if (shape is IShapeDrawable drawableShape)
                {
                    drawableShape.Draw(ShapesCanvas);
                }
            }
        }
        private void FactoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var selectedFactoryItem = FactoryComboBox.SelectedItem as ComboBoxItem;
            var selectedFactory = selectedFactoryItem.Content.ToString();

            switch (selectedFactory)
            {
                case "Red":
                    _factory = new RedFactory();
                    break;
                case "Blue":
                    _factory = new BlueFactory();
                    break;
                case "Green":
                    _factory = new GreenFactory();
                    break;
                default:
                    MessageBox.Show("не то");
                    break;
            }
            CreateShapes();
        }  
    }
}