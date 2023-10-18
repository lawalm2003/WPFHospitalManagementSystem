using HMS.App.IServices;
using HMS.Domain.Const;
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
using System.Windows.Shapes;

namespace WPFHospitalManagementSystem.AdminView.Views
{
    /// <summary>
    /// Interaction logic for AddDoctorModal.xaml
    /// </summary>
    public partial class AddDoctorModal : Window
    {
        private readonly IDoctorService _doctorService;
        public AddDoctorModal(IDoctorService doctorService)
        {
            InitializeComponent();
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
        }
               
        private async void Addbtn_Click(object sender, RoutedEventArgs e)
        {



            // Create a new Doctor object with the user's input
            var doctor = new Doctor
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                DateOfBirth = DateOfBirthDatePicker.SelectedDate,
                // Handle gender selection based on the radio buttons
                Gender = MaleRadioBtn.IsChecked == true ? "Male" : "Female",
                Specialization = GetSelectedSpecialization(),
                MobileNo = MobileNoTextBox.Text,
                Email = EmailTextBox.Text,
                UserRole = Role.Doctor
            };

            // Call the DoctorService to create the doctor
            bool success = await _doctorService.CreateDoctorAsync(doctor);

            if (success)
            {
                // Handle successful creation (e.g., show a success message)
                MessageBox.Show("Doctor added successfully.");
            }
            else
            {
                // Handle the case where creation failed (e.g., show an error message)
                MessageBox.Show("Failed to add the doctor.");
            }
            Close();
        }

        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to close this Window", "Close window", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
            else
            {
                return;
            }
        }

        private string GetSelectedSpecialization()
        {
            var selectedComboBoxItem = SpecializationComboBox.SelectedItem as ComboBoxItem;

            if (selectedComboBoxItem != null)
            {
                return selectedComboBoxItem.Content?.ToString() ?? string.Empty;
            }

            return "No Specialization"; // Return null or handle the case when no specialization is selected
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }



}

