using HMS.App.IServices;
using HMS.Domain.Model;
using Microsoft.VisualBasic.ApplicationServices;
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
using User = HMS.Domain.Model.User;

namespace WPFHospitalManagementSystem.Login
{
    /// <summary>
    /// Interaction logic for RegisterForm.xaml
    /// </summary>
    public partial class RegisterForm : Page
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAdminService _adminService;
        private readonly IReceptionService _receptionistService;
        private readonly IUserService _userservice;
        public RegisterForm(IDoctorService doctorService, IPatientService patientService,
            IAdminService adminService, IReceptionService receptionistService, IUserService userservice)
        {
            _doctorService = doctorService;
            _patientService = patientService;
            _adminService = adminService;
            _userservice = userservice;
            _receptionistService = receptionistService;

            InitializeComponent();
        }


        private async Task<bool> IsUserIdUniqueAsync(string userId)
        {
            bool isUniqueDoctor = !await _doctorService.IsDoctorIdUniqueAsync(userId);
            bool isUniquePatient = !await _patientService.IsPatientIdUniqueAsync(userId);
            bool isUniqueAdmin = !await _adminService.IsAdminIdUniqueAsync(userId);
            bool isUniqueReceptionist = !await _receptionistService.IsReceptionistIdUniqueAsync(userId);

            return isUniqueDoctor && isUniquePatient && isUniqueAdmin && isUniqueReceptionist; 
        }

        private async void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string userId = UserIdRegTxtbox.Text;
            string password = PasswordRegTxtBox.Password;
            string confirmPassword = ConPasswordRegTxtBox.Password;

            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both UserId and Password.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Password and Confirm Password do not match. Please re-enter them.");
                return;
            }

            bool isUnique = await IsUserIdUniqueAsync(userId);

            if (isUnique)
            {
                // The UserId is unique; display a message
                MessageBox.Show("No userId found. Please enter a different UserId.");
            }
            else
            {
                var user = new User
                {
                    UserId = userId,
                    Password = password
                };

                bool success = await _userservice.CreateUserAsync(user);

                if (success)
                {
                    // Handle successful creation (e.g., show a success message)
                    MessageBox.Show("User Registered successfully.");
                }
                else
                {
                    // Handle the case where creation failed (e.g., show an error message)
                    MessageBox.Show("Failed to Register User.");
                }
            }
        }
    }
}
