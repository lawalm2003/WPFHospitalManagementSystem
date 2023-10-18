using HMS.App.IServices;
using HMS.Domain.IRepositories;
using HMS.Infrastructure.Services;
using HMS.Persistence.EFCore;
using HMS.Persistence.Repositories;
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
using WPFHospitalManagementSystem.ReceptionistView.Pages;
using WPFHospitalManagementSystem.View;

namespace WPFHospitalManagementSystem.ReceptionistView
{
    public partial class MainReceptionistWindow : Window
    {
        public AddPatientPage addPatientPage { get; private set; }

        private readonly IPatientService _patientService;
        private IPatientRepo _patientRepo;
        public MainReceptionistWindow()
        {
            InitializeComponent();
            var dbContext = new HMSContext();

            _patientRepo = new PatientRepo(dbContext);
            _patientService = new PatientService(_patientRepo);

            ContentFrame.Content = new ReceptionistProfilePage();
            addPatientPage = new AddPatientPage(_patientService);
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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = addPatientPage;
        }

        private void DetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new ReceptionistProfilePage();
        }

        private void BillRadBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
