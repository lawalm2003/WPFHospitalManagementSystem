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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFHospitalManagementSystem.ReceptionistView;

namespace WPFHospitalManagementSystem.Login
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Page
    {
        private readonly IUserService _userService; // Inject your IUserService
        private readonly IDoctorService _doctorService; // Inject your IDoctorService
        private readonly IPatientService _patientService; // Inject your IPatientService
        private readonly IAdminService _adminService; // Inject your IAdminService
        private readonly IReceptionService _receptionService;
        public IEnumerable<User>? Users { get; private set; }

        public LoginForm(IUserService userService, IDoctorService doctorService, IPatientService patientService, IAdminService adminService, IReceptionService receptionService)
        {
            InitializeComponent();

            _userService = userService;
            _doctorService = doctorService;
            _patientService = patientService;
            _adminService = adminService;
            _receptionService = receptionService;
        }

            private Role DetermineUserRole(string userId)
        {
            // Assume that you have a way to determine the user's role based on their UserId
            // Replace this logic with your actual implementation
            if (userId.StartsWith("P")) // Example: UserIds for patients start with "P"
            {
                return Role.Patient;
            }
            else if (userId.StartsWith("D")) // Example: UserIds for doctors start with "D"
            {
                return Role.Doctor;
            }
            else if (userId.StartsWith("A")) // Example: UserIds for admins start with "A"
            {
                return Role.Admin;
            }
            else if (userId.StartsWith("R")) // Example: UserIds for receptionists start with "R"
            {
                return Role.Receptionist;
            }

            // If none of the above conditions match, return Unknown
            return Role.Unknown;
        }


        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

            string userId = UserIdTxtBox.Text;
            string password = PasswordTxtBox.Password;

            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both UserId and Password.");
                return;
            }
            
            // Call the UserService to validate the user's credentials
             Users = await _userService.GetAllUserAsync();

            var input = new User { UserId = userId, Password = password };

            var matchingUser = Users.FirstOrDefault(user => user.UserId == input.UserId && user.Password == input.Password);


            if (matchingUser != null)
            {
                // User is authenticated; now determine their role
                Role userRole = DetermineUserRole(userId);

                if (userRole != Role.Unknown)
                {
                    // Navigate to the appropriate dashboard based on the user's role
                    switch (userRole)
                    {
                        case Role.Patient:
                            // Retrieve the patient's data from the Patient table
                            var patient = _patientService.GetPatientByIdAsync(userId);
                            if (patient != null)
                            {
                               
                            }
                            break;


                        case Role.Doctor:                           
                            var doctor = _doctorService.GetDoctorByIdAsync(userId);
                            if (doctor != null)
                            {
                               
                            }
                            break;


                        case Role.Admin:
                            // Navigate to the admin's dashboard
                            MainWindow mainwindow = new MainWindow();
                            mainwindow.ShowDialog();
                            break;


                        case Role.Receptionist:
                            // Retrieve the receptionist's data from the Receptionist table
                            var receptionist = _receptionService.GetReceptionByIdAsync(userId);
                            if (receptionist != null)
                            {
                                // Navigate to the receptionist's dashboard with the receptionist data
                                MainReceptionistWindow receptionistWindow = new MainReceptionistWindow();
                                receptionistWindow.ShowDialog();
                            }
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Unknown user role. Please contact the administrator.");
                }
            }
            else
            {
                MessageBox.Show("Invalid UserId or Password. Please try again.");
            }
        }

    }
}

