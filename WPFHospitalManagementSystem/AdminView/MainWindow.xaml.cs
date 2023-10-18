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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFHospitalManagementSystem.AdminView.Pages;
using WPFHospitalManagementSystem.View;

namespace WPFHospitalManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AddPage addPage { get; private set; }

        private readonly IDoctorService _doctorService;
        private IDoctorRepo doctorRepo_repo;
        public MainWindow()
        {
            InitializeComponent();

            var dbContext = new HMSContext();

            doctorRepo_repo = new DoctorRepo(dbContext);
            _doctorService = new DoctorService(doctorRepo_repo);

            ContentFrame.Content = new DashboardPage();
            addPage = new AddPage(_doctorService);

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
            ContentFrame.Content = addPage;
        }

        private void BillRadBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void DashboardBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new DashboardPage();
        }
    }
}
