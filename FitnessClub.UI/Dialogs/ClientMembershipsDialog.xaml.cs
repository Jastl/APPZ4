using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;

namespace FitnessClub.UI.Dialogs
{
    public partial class ClientMembershipsDialog : Window
    {
        private readonly Client _client;
        private readonly IMembershipService _membershipService;

        public ClientMembershipsDialog(Client client, IMembershipService membershipService)
        {
            InitializeComponent();
            _client = client;
            _membershipService = membershipService;
            Title = $"Memberships - {_client.FirstName} {_client.LastName}";
            LoadMemberships();
        }

        private async void LoadMemberships()
        {
            try
            {
                var memberships = await _membershipService.GetClientMembershipsAsync(_client.Id);
                membershipsGrid.ItemsSource = memberships;

                if (!memberships.Any())
                {
                    MessageBox.Show("This client has no memberships.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading memberships: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadMemberships();
        }

        private async void btnAddMembership_Click(object sender, RoutedEventArgs e)
        {
            var membership = new Membership 
            { 
                ClientId = _client.Id,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddMonths(1)
            };

            var dialog = new MembershipDialog(membership, _membershipService);
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    await _membershipService.CreateMembershipAsync(membership);
                    LoadMemberships();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating membership: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void btnEditMembership_Click(object sender, RoutedEventArgs e)
        {
            var membership = ((FrameworkElement)sender).DataContext as Membership;
            if (membership == null) return;

            var dialog = new MembershipDialog(membership, _membershipService);
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    await _membershipService.UpdateMembershipAsync(membership);
                    LoadMemberships();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating membership: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void btnDeleteMembership_Click(object sender, RoutedEventArgs e)
        {
            var membership = ((FrameworkElement)sender).DataContext as Membership;
            if (membership == null) return;

            var result = MessageBox.Show(
                "Are you sure you want to delete this membership?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    await _membershipService.DeleteMembershipAsync(membership.Id);
                    LoadMemberships();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting membership: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
} 