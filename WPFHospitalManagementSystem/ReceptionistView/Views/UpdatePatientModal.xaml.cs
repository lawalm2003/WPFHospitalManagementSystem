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
using System.Windows.Shapes;

namespace WPFHospitalManagementSystem.ReceptionistView.Views
{
    /// <summary>
    /// Interaction logic for UpdatePatientModal.xaml
    /// </summary>
    public partial class UpdatePatientModal : Window
    {
        private readonly IPatientService _patientService;
        private Patient patientToUpdate;
        public UpdatePatientModal(IPatientService patientService, Patient patient)
        {
            InitializeComponent();
            _patientService = patientService;
            patientToUpdate = patient;

            FirstNameTextBox.Text = patientToUpdate.FirstName;
            LastNameTextBox.Text = patientToUpdate.LastName;
            DateOfBirthDatePicker.SelectedDate = patientToUpdate.DOB;
            AddressTextBox.Text = patientToUpdate.Address;

            // Set the gender radio buttons based on the doctor's gender, if applicable
            if (patientToUpdate.Gender == "Male")
            {
                MaleRadioBtn.IsChecked = true;
            }
            else if (patientToUpdate.Gender == "Female")
            {
                FemaleRadioBtn.IsChecked = true;
            }

            MobileNoTextBox.Text = patientToUpdate.MobileNo;
            EmailTextBox.Text = patient.EmailID;

        }

        private async void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            patientToUpdate.FirstName = FirstNameTextBox.Text;
            patientToUpdate.LastName = LastNameTextBox.Text;
            patientToUpdate.DOB = DateOfBirthDatePicker.SelectedDate;
            patientToUpdate.Gender = MaleRadioBtn.IsChecked == true ? "Male" : "Female";
            patientToUpdate.Address = AddressTextBox.Text;
            patientToUpdate.MobileNo = MobileNoTextBox.Text;
            patientToUpdate.EmailID = EmailTextBox.Text;

            // Call the DoctorService to update the doctor
            bool success = await _patientService.UpdatePatientAsync(patientToUpdate);

            if (success)
            {
                // Handle successful update (e.g., show a success message)
                MessageBox.Show("Patient updated successfully.");
            }
            else
            {
                // Handle the case where the update failed (e.g., show an error message)
                MessageBox.Show("Failed to update the Patient.");
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
