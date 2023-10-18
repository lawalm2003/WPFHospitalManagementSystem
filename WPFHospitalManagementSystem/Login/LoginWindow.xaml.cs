using HMS.App.IServices;
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
using WPFHospitalManagementSystem.AdminView.Pages;
using WPFHospitalManagementSystem.Login;

namespace WPFHospitalManagementSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserService _userService; // Inject your IUserService
        private readonly IDoctorService _doctorService; // Inject your IDoctorService
        private readonly IPatientService _patientService; // Inject your IPatientService
        private readonly IAdminService _adminService; // Inject your IAdminService
        private readonly IReceptionService _receptionService;

        public LoginWindow()
        {
            InitializeComponent();
            ContentFrame.Content = new LoginForm(_userService, _doctorService, _patientService, _adminService, _receptionService);
        }
        public LoginWindow(IUserService userService, IDoctorService doctorService, IPatientService patientService, IAdminService adminService, IReceptionService receptionService)
        {
           

            _userService = userService;
            _doctorService = doctorService;
            _patientService = patientService;
            _adminService = adminService;
            _receptionService = receptionService;

            
        }

     

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void LoginRadioBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new LoginForm(_userService, _doctorService, _patientService, _adminService, _receptionService);
        }

        private void RegisterRadioBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new RegisterForm( _doctorService, _patientService, _adminService, _receptionService, _userService);
        }
    }
}
