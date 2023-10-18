using HMS.App.IServices;
using HMS.Domain.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFHospitalManagementSystem.AdminView.Views
{
    public partial class UpdateDoctorModal : Window
    {
        private readonly IDoctorService _doctorService;
        private Doctor doctorToUpdate;

        public UpdateDoctorModal(IDoctorService doctorService, Doctor doctor)
        {
            InitializeComponent();
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
            doctorToUpdate = doctor ?? throw new ArgumentNullException(nameof(doctor)); ;

            // Initialize your UI elements with doctor data for updating
            FirstNameTextBox.Text = doctorToUpdate.FirstName;
            LastNameTextBox.Text = doctorToUpdate.LastName;
            DateOfBirthDatePicker.SelectedDate = doctorToUpdate.DateOfBirth;

            // Set the gender radio buttons based on the doctor's gender, if applicable
            if (doctorToUpdate.Gender == "Male")
            {
                MaleRadioBtn.IsChecked = true;
            }
            else if (doctorToUpdate.Gender == "Female")
            {
                FemaleRadioBtn.IsChecked = true;
            }
            
            MobileNoTextBox.Text = doctorToUpdate.MobileNo;
            EmailTextBox.Text = doctorToUpdate.Email;
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
            // Retrieve the selected specialization from the ComboBox
            var selectedComboBoxItem = SpecializationComboBox.SelectedItem as ComboBoxItem;

            if (selectedComboBoxItem != null)
            {
                return selectedComboBoxItem.Content.ToString() ?? string.Empty;
            }

            return "No Specialization"; // Return null or handle the case when no specialization is selected
        }

        private async void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            doctorToUpdate.FirstName = FirstNameTextBox.Text;
            doctorToUpdate.LastName = LastNameTextBox.Text;
            doctorToUpdate.DateOfBirth = DateOfBirthDatePicker.SelectedDate;
            doctorToUpdate.Gender = MaleRadioBtn.IsChecked == true ? "Male" : "Female";
            doctorToUpdate.Specialization = GetSelectedSpecialization();
            doctorToUpdate.MobileNo = MobileNoTextBox.Text;
            doctorToUpdate.Email = EmailTextBox.Text;

            // Call the DoctorService to update the doctor
            bool success = await _doctorService.UpdateDoctorAsync(doctorToUpdate);

            if (success)
            {
                // Handle successful update (e.g., show a success message)
                MessageBox.Show("Doctor updated successfully.");
            }
            else
            {
                // Handle the case where the update failed (e.g., show an error message)
                MessageBox.Show("Failed to update the doctor.");
            }
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }

}

