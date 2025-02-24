using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using ContextLibrary;
using ContextLibrary.Entities;

namespace TechnicRepairVar2Lab3
{
    public partial class AddEditRequestWindow : Window, INotifyPropertyChanged
    {
        public Request Request { get; set; }
        public List<CarType> CarTypes { get; } = Enum.GetValues(typeof(CarType)).Cast<CarType>().ToList();
        public List<RequestStatus> RequestStatuses { get; } = Enum.GetValues(typeof(RequestStatus)).Cast<RequestStatus>().ToList();
        public List<ExecutionStage> ExecutionStages { get; } = Enum.GetValues(typeof(ExecutionStage)).Cast<ExecutionStage>().ToList();
        public List<Mechanic> Mechanics { get; } 
        public Mechanic SelectedMechanic { get; set; } 

        private readonly ApplicationContext _context;

        public event PropertyChangedEventHandler PropertyChanged;
        private static int lastRequestNumber = 0;


        public AddEditRequestWindow(Request request = null, bool canEdit = true)
        {
            InitializeComponent();
            _context = new ApplicationContext();
            Mechanics = _context.Mechanics; 

            Request = request ?? new Request
            {
                Number = ++lastRequestNumber, // Увеличиваем счётчик
                TechnicModel = "Не указано",
                Description = "Не указано",
                ClientLFP = "Не указано",
                PhoneNumber = "Не указано",
                AddedDate = DateTime.Now,
                Status = RequestStatus.New,
                CarType = CarType.SmallCar,
                ExStage = ExecutionStages.FirstOrDefault()
            };

            SelectedMechanic = _context.MechanicRequests
                .FirstOrDefault(mr => mr.Request == Request)?.Mechanic;

            DataContext = this;
            SetFieldsEditable(canEdit);
        }
        private void SetFieldsEditable(bool canEdit)
        {

            TechnicModelTextBox.IsEnabled = canEdit;
            ClientLFPTextBox.IsEnabled = canEdit;
            PhoneNumberTextBox.IsEnabled = canEdit;
            CarTypeComboBox.IsEnabled = canEdit;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                Request.Mechanic = SelectedMechanic; // Назначаем механика прямо в заявку
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Некорректные данные!");
            }
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Request.TechnicModel) &&
                   !string.IsNullOrWhiteSpace(Request.Description) &&
                   !string.IsNullOrWhiteSpace(Request.ClientLFP) &&
                   !string.IsNullOrWhiteSpace(Request.PhoneNumber);
        }
    }
}
