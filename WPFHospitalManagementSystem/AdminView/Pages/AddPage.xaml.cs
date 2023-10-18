using HMS.App.IServices;
using HMS.Domain.Model;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFHospitalManagementSystem.AdminView.Views;

namespace WPFHospitalManagementSystem.View
{
   
    public partial class AddPage : Page
    {
        public IEnumerable<Doctor>? Doctors { get; private set; }
        private readonly IDoctorService _doctorService; 

        public AddPage(IDoctorService doctorService) 
        {
            InitializeComponent();
            _doctorService = doctorService;
            LoadListView();
            DataContext = this;
        }

        private async void LoadListView()
        {
            
                Doctors = await _doctorService.GetAllDoctorsAsync();                
            

            if (Doctors != null)
            {
                DoctorsListView.ItemsSource = Doctors;
            }
        }
        private void AddDoctor_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of AddDoctorModal with the IDoctorService instance
            AddDoctorModal doctorModal = new AddDoctorModal(_doctorService);
            doctorModal.ShowDialog();

            LoadListView();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Doctor selectedPart = (Doctor)DoctorsListView.SelectedItem;
            if (selectedPart != null)
            {
                var updateDoctorWindow = new UpdateDoctorModal(_doctorService, selectedPart);
                updateDoctorWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a record.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            LoadListView();
        }

        private async void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            Doctor selectedPart = (Doctor)DoctorsListView.SelectedItem;
            if (selectedPart != null)
            {
                string message = $"Do you want to delete {selectedPart.FirstName} {selectedPart.LastName}'s data?";
                string title = "Delete Item";
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                var result = MessageBox.Show(message, title, buttons, MessageBoxImage.Warning);
                if (result is MessageBoxResult.Yes)
                {
                    await _doctorService.DeleteDoctorAsync(selectedPart.ID);
                }
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
                FilterDoctors();
            }
        }

        private List<Doctor> filteredDoctors = new List<Doctor>();

        private void FilterDoctors()
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                filteredDoctors = Doctors.ToList(); // Reset the filter if search text is empty
            }
            else
            {
                string searchLower = searchText.ToLower();
                filteredDoctors = Doctors.Where(d =>
                    d.FirstName.ToLower().Contains(searchLower) ||
                    d.LastName.ToLower().Contains(searchLower) ||
                    d.Gender.ToLower().Contains(searchLower) ||
                    d.Specialization.ToLower().Contains(searchLower) ||
                    d.MobileNo.ToLower().Contains(searchLower) ||
                    d.Email.ToLower().Contains(searchLower)
                ).ToList();
            }
            DoctorsListView.ItemsSource = filteredDoctors;
        }

    }

}
