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
using ContextLibrary.Entities;
namespace prilog
{
    /// <summary>
    /// Логика взаимодействия для AddEditApplication.xaml
    /// </summary>
    public partial class AddEditRequest : Window
    {
       
            public AddEditRequest()
            {
                InitializeComponent();
            }

            private void SaveButton_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    if (int.TryParse(ApplicationIdTextBox.Text, out int requestNumber) &&
                        !string.IsNullOrWhiteSpace(CustomerNameTextBox.Text) &&
                        !string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) &&
                        EquipmentTypeComboBox.SelectedItem is ComboBoxItem selectedEquipmentType &&
                        StatusComboBox.SelectedItem is ComboBoxItem selectedStatus)
                    {
                        DateTime dateAdded = DateAddedPicker.SelectedDate ?? DateTime.Now;
                        string equipmentType = selectedEquipmentType.Content.ToString();
                        string model = ModelTextBox.Text;
                        string problemDescription = ProblemDescriptionTextBox.Text;
                        string customerName = CustomerNameTextBox.Text;
                        string phoneNumber = PhoneNumberTextBox.Text;
                        string status = selectedStatus.Content.ToString();

                        Request newRequest = new Request
                        {
                            Number = requestNumber,
                            AddedDate = dateAdded,
                            ApplianceType = equipmentType,
                            ApplianceModel = model,
                            Description = problemDescription,
                            ClientLFP = customerName,
                            PhoneNumber = phoneNumber,
                            
                        };

                        MainWindow.Requests.Add(newRequest);
                        MessageBox.Show("Заявка успешно сохранена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Некорректные данные. Проверьте введенные значения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении заявки: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
       
    }
}
