using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFHospitalManagementSystem.CustomControl
{
    public partial class CustomTextbox : UserControl
    {
        public CustomTextbox()
        {
            InitializeComponent();
            this.DataContext= this;
        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(CustomTextbox), new PropertyMetadata(""));

        public string Text
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();
            txtInput.Focus();
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePlaceholderVisibility();
        }

        private void UpdatePlaceholderVisibility()
        {
            tbPlaceHolder.Visibility = string.IsNullOrEmpty(txtInput.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        // Additional attached property to set placeholder foreground color
        public static readonly DependencyProperty PlaceholderForegroundProperty =
            DependencyProperty.RegisterAttached("PlaceholderForeground", typeof(Brush), typeof(CustomTextbox), new PropertyMetadata(Brushes.Gray));

        public static void SetPlaceholderForeground(UIElement element, Brush value)
        {
            element.SetValue(PlaceholderForegroundProperty, value);
        }

        public static Brush GetPlaceholderForeground(UIElement element)
        {
            return (Brush)element.GetValue(PlaceholderForegroundProperty);
        }
    }
}
