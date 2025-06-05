using System;
using System.Windows;
using System.Windows.Controls;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;
using FitnessClub.UI.Dialogs;

namespace FitnessClub.UI.Pages
{
    public partial class MembershipsPage : Page
    {
        private readonly IMembershipService _membershipService;

        public MembershipsPage(IMembershipService membershipService)
        {
            InitializeComponent();
            _membershipService = membershipService;
            LoadMemberships();
        }

        private async void LoadMemberships()
        {
            try
            {
                var memberships = await _membershipService.GetAllMembershipsAsync();
                membershipsGrid.ItemsSource = memberships;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading memberships: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void btnAddMembership_Click(object sender, RoutedEventArgs e)
        {
            var membership = new Membership { StartDate = DateTime.Today };
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

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadMemberships();
        }

        private void membershipsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change if needed
        }
    }
} 