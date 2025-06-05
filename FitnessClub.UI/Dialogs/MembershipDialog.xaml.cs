using System;
using System.Windows;
using System.Windows.Controls;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;

namespace FitnessClub.UI.Dialogs
{
    public partial class MembershipDialog : Window
    {
        private readonly Membership _membership;
        private readonly IMembershipService _membershipService;

        public MembershipDialog(Membership membership, IMembershipService membershipService)
        {
            InitializeComponent();
            _membership = membership;
            _membershipService = membershipService;

            LoadClubs();
            InitializeData();
        }

        private async void LoadClubs()
        {
            try
            {
                var clubs = await _membershipService.GetAllClubsAsync();
                clubComboBox.ItemsSource = clubs;
                clubComboBox.SelectedValue = _membership.ClubId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clubs: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InitializeData()
        {
            startDatePicker.SelectedDate = _membership.StartDate;
            endDatePicker.SelectedDate = DateTime.Today;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (clubComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a club", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!startDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a start date", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!endDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select an end date", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (startDatePicker.SelectedDate.Value > endDatePicker.SelectedDate.Value)
            {
                MessageBox.Show("End date must be after start date", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _membership.ClubId = (int)clubComboBox.SelectedValue;
            _membership.StartDate = startDatePicker.SelectedDate.Value;
            _membership.EndDate = endDatePicker.SelectedDate.Value;

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