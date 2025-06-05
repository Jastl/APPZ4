using System;
using System.Windows;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;
using System.Linq;

namespace FitnessClub.UI
{
    public partial class VisitDialog : Window
    {
        private readonly Visit _visit;
        private readonly IMembershipService _membershipService;

        public VisitDialog(Visit visit, IMembershipService membershipService)
        {
            InitializeComponent();
            _visit = visit;
            _membershipService = membershipService;
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                var clients = await _membershipService.GetAllClientsAsync();
                clientComboBox.ItemsSource = clients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clients: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void clientComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (clientComboBox.SelectedItem is Client selectedClient)
            {
                try
                {
                    var memberships = await _membershipService.GetClientMembershipsAsync(selectedClient.Id);
                    var validMemberships = memberships.Where(m => m.EndDate >= DateTime.Today);
                    membershipComboBox.ItemsSource = validMemberships;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading memberships: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (clientComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a client", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (membershipComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a membership", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _visit.Client = (Client)clientComboBox.SelectedItem;
            _visit.Membership = (Membership)membershipComboBox.SelectedItem;
            _visit.Club = _visit.Membership.Club;

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