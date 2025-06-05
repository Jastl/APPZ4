using System;
using System.Windows;
using System.Windows.Controls;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;

namespace FitnessClub.UI.Pages
{
    public partial class ClubsPage : Page
    {
        private readonly IClubService _clubService;

        public ClubsPage(IClubService clubService)
        {
            InitializeComponent();
            _clubService = clubService;
            LoadClubs();
        }

        private async void LoadClubs()
        {
            try
            {
                var clubs = await _clubService.GetAllClubsAsync();
                clubsGrid.ItemsSource = clubs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clubs: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddClub_Click(object sender, RoutedEventArgs e)
        {
            var club = new Club();
            var dialog = new ClubDialog(club);
            
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    _clubService.CreateClubAsync(club);
                    LoadClubs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating club: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEditClub_Click(object sender, RoutedEventArgs e)
        {
            var club = (Club)((Button)sender).DataContext;
            var dialog = new ClubDialog(club);
            
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    _clubService.UpdateClubAsync(club);
                    LoadClubs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating club: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void btnDeleteClub_Click(object sender, RoutedEventArgs e)
        {
            var club = (Club)((Button)sender).DataContext;
            
            if (MessageBox.Show($"Are you sure you want to delete club '{club.Name}'?", "Confirm Delete", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    await _clubService.DeleteClubAsync(club.Id);
                    LoadClubs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting club: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadClubs();
        }

        private void clubsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change if needed
        }
    }
} 