using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;
using FitnessClub.UI.Dialogs;

namespace FitnessClub.UI.Pages
{
    public partial class MembersPage : Page
    {
        private readonly IMembershipService _membershipService;

        public MembersPage(IMembershipService membershipService)
        {
            InitializeComponent();
            _membershipService = membershipService;
            LoadMembers();
        }

        private async void LoadMembers()
        {
            try
            {
                var clients = await _membershipService.GetAllClientsAsync();
                if (!clients.Any())
                {
                    MessageBox.Show("No clients found in the database.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                membersGrid.ItemsSource = clients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clients: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void btnAddMember_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client();
            var dialog = new MemberDialog(client);
            
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    await _membershipService.CreateClientAsync(client);
                    LoadMembers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating client: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void btnEditMember_Click(object sender, RoutedEventArgs e)
        {
            var client = ((FrameworkElement)sender).DataContext as Client;
            if (client == null) return;

            var dialog = new MemberDialog(client);
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    await _membershipService.UpdateClientAsync(client);
                    LoadMembers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating client: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void btnDeleteMember_Click(object sender, RoutedEventArgs e)
        {
            var client = ((FrameworkElement)sender).DataContext as Client;
            if (client == null) return;

            var result = MessageBox.Show(
                "Are you sure you want to delete this client?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    await _membershipService.DeleteClientAsync(client.Id);
                    LoadMembers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting client: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnViewMemberships_Click(object sender, RoutedEventArgs e)
        {
            var client = ((FrameworkElement)sender).DataContext as Client;
            if (client == null) return;

            var dialog = new ClientMembershipsDialog(client, _membershipService);
            dialog.ShowDialog();
            LoadMembers(); // Refresh after viewing/modifying memberships
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadMembers();
        }

        private void membersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change if needed
        }
    }
} 