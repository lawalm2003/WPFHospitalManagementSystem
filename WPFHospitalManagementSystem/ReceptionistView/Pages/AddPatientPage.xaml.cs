using HMS.App.IServices;
using HMS.Domain.Model;
using HMS.Infrastructure.Services;
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
using WPFHospitalManagementSystem.AdminView.Views;
using WPFHospitalManagementSystem.ReceptionistView.Views;

namespace WPFHospitalManagementSystem.ReceptionistView.Pages
{
    /// <summary>
    /// Interaction logic for AddPatientPage.xaml
    /// </summary>
    public partial class AddPatientPage : Page
    {

        public IEnumerable<Patient>? Patients { get; private set; }
        private readonly IPatientService _patientService;
        public AddPatientPage(IPatientService patientService)
        {
            InitializeComponent();
            _patientService = patientService;
            LoadListView();
            DataContext = this;
        }

        private async void LoadListView()
        {

            Patients = await _patientService.GetAllPatientsAsync();


            if (Patients != null)
            {
                PatientListView.ItemsSource = Patients;
            }
        }

        private async void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedPart = (Patient)PatientListView.SelectedItem;
            if (selectedPart != null)
            {
                string message = $"Do you want to delete {selectedPart.FirstName} {selectedPart.LastName}'s data?";
                string title = "Delete Item";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                var result = MessageBox.Show(message, title, buttons, MessageBoxImage.Warning);
                if (result is MessageBoxResult.Yes)
                {
                    await _patientService.DeletePatientAsync(selectedPart.ID);
                }
            }
            else
            {
                MessageBox.Show("Select a record.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            LoadListView();
        }

        private void AddDoctor_Click(object sender, RoutedEventArgs e)
        {
            AddPatientModal PatientModal = new AddPatientModal(_patientService);
            PatientModal.ShowDialog();

            LoadListView();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedPart = (Patient)PatientListView.SelectedItem;
            if (selectedPart != null)
            {
                var updatePatientWindow = new UpdatePatientModal(_patientService, selectedPart);
                updatePatientWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a record.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            LoadListView();
        }






        private string searchText = string.Empty;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                FilterPatient();
            }
        }

        private List<Patient> filteredPatient = new List<Patient>();

        private void FilterPatient()
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                filteredPatient = Patients.ToList(); // Reset the filter if search text is empty
            }
            else
            {
                string searchLower = searchText.ToLower();
                filteredPatient = Patients.Where(d =>
                    d.FirstName.ToLower().Contains(searchLower) ||
                    d.LastName.ToLower().Contains(searchLower) ||
                    d.Gender.ToLower().Contains(searchLower) ||
                    d.Address.ToLower().Contains(searchLower) ||
                    d.MobileNo.ToLower().Contains(searchLower) ||
                    d.EmailID.ToLower().Contains(searchLower)
                ).ToList();
            }
            PatientListView.ItemsSource = filteredPatient;
        }
    }
}
