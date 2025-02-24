using ContextLibrary;
using ContextLibrary.Entities;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace TechnicRepairVar2Lab3
{
    public partial class MainWindow : Window
    {
        private readonly ApplicationContext _context;

        public ObservableCollection<Request> Requests { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _context = new ApplicationContext();
            Requests = new ObservableCollection<Request>(_context.Requests);
            DataContext = this;
            if (SearchFilter != null)
                SearchFilter.SelectedIndex = 0;

            
        }

        private void AddRequest_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddEditRequestWindow(canEdit: true);
            if (addWindow.ShowDialog() == true)
            {
                Requests.Add(addWindow.Request);
                _context.Requests.Add(addWindow.Request);
            }
            UpdateCompletedRequestsCount();
        }
        private void SearchFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Вызываем ту же логику фильтрации при изменении выбора в комбо-боксе
            UpdateSearchResults();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Вызываем логику фильтрации при изменении текста
            UpdateSearchResults();
        }

        private void UpdateSearchResults()
        {
            if (SearchFilter == null || SearchFilter.SelectedItem == null) return;

            string query = SearchBox.Text.ToLower();
            string filter = (SearchFilter.SelectedItem as ComboBoxItem)?.Content.ToString();

            var filteredRequests = _context.Requests.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                switch (filter)
                {
                    case "Номер":
                        filteredRequests = filteredRequests.Where(r => r.Number.ToString().Contains(query));
                        break;
                    case "Модель":
                        filteredRequests = filteredRequests.Where(r => r.TechnicModel.ToLower().Contains(query));
                        break;
                    case "Клиент":
                        filteredRequests = filteredRequests.Where(r => r.ClientLFP.ToLower().Contains(query));
                        break;
                    case "Статус":
                        filteredRequests = filteredRequests.Where(r => r.Status.ToString().ToLower().Contains(query));
                        break;
                }
            }

            Requests.Clear();
            foreach (var request in filteredRequests)
                Requests.Add(request);
        }
        // Подсчет выполненных заявок
        private void UpdateCompletedRequestsCount()
        {
            int completedCount = _context.Requests.Count(r => r.Status == RequestStatus.Completed);
            CompletedCountLabel.Content = $"Выполненные заявки: {completedCount}";
        }
        private void EditRequest_Click(object sender, RoutedEventArgs e)
        {
            if (RequestList.SelectedItem is Request selectedRequest)
            {
                var requestCopy = new Request
                {
                    Number = selectedRequest.Number,
                    AddedDate = selectedRequest.AddedDate,
                    CarType = selectedRequest.CarType,
                    TechnicModel = selectedRequest.TechnicModel,
                    Description = selectedRequest.Description,
                    ClientLFP = selectedRequest.ClientLFP,
                    PhoneNumber = selectedRequest.PhoneNumber,
                    Status = selectedRequest.Status,
                    ExStage = selectedRequest.ExStage
                };

                var editWindow = new AddEditRequestWindow(requestCopy, canEdit: false);
                if (editWindow.ShowDialog() == true)
                {
                    int index = Requests.IndexOf(selectedRequest);
                    Requests[index] = editWindow.Request;
                    int contextIndex = _context.Requests.IndexOf(selectedRequest);
                    if (contextIndex >= 0)
                    {
                        _context.Requests[contextIndex] = editWindow.Request;
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку для редактирования!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
