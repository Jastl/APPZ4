using System.Windows;
using FitnessClub.DAL.Entities;

namespace FitnessClub.UI
{
    public partial class ClubDialog : Window
    {
        private readonly Club _club;

        public ClubDialog(Club club)
        {
            InitializeComponent();
            _club = club;
            DataContext = _club;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_club.Name))
            {
                MessageBox.Show("Name is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
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