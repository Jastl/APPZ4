using System.Windows;
using FitnessClub.DAL.Entities;

namespace FitnessClub.UI
{
    public partial class MemberDialog : Window
    {
        private readonly Client _member;

        public MemberDialog(Client member)
        {
            InitializeComponent();
            _member = member;
            DataContext = _member;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_member.FirstName))
            {
                MessageBox.Show("First name is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(_member.LastName))
            {
                MessageBox.Show("Last name is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(_member.Email))
            {
                MessageBox.Show("Email is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
} 