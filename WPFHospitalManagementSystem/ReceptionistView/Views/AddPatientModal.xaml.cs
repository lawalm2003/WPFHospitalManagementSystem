using HMS.App.IServices;
using HMS.Domain.Const;
using HMS.Domain.Model;
using HMS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

namespace WPFHospitalManagementSystem.ReceptionistView.Views
{
    /// <summary>
    /// Interaction logic for AddPatientModal.xaml
    /// </summary>
    public partial class AddPatientModal : Window
    {
        private readonly IPatientService _patientService;
        public AddPatientModal(IPatientService patientService)
        {
            InitializeComponent();
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        }


        private async void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            var patient = new Patient
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                DOB = DateOfBirthDatePicker.SelectedDate,
                // Handle gender selection based on the radio buttons
                Gender = MaleRadioBtn.IsChecked == true ? "Male" : "Female",
                Address = AddressTextBox.Text,
                MobileNo = MobileNoTextBox.Text,
                EmailID = EmailTextBox.Text,
                UserRole = Role.Patient
            };

            bool success = await _patientService.CreatePatientAsync(patient);

            if (success)
            {
                // Handle successful creation (e.g., show a success message)
                MessageBox.Show("Patient added successfully.");
            }
            else
            {
                // Handle the case where creation failed (e.g., show an error message)
                MessageBox.Show("Failed to add the Patient.");
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

       

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
