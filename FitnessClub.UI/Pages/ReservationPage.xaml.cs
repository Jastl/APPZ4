using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;

namespace FitnessClub.UI.Pages
{
    public partial class ReservationPage : Page
    {
        private readonly IReservationService _reservationService;
        private readonly IScheduleService _scheduleService;
        private readonly IMembershipService _membershipService;

        public ReservationPage(
            IReservationService reservationService,
            IScheduleService scheduleService,
            IMembershipService membershipService)
        {
            InitializeComponent();
            _reservationService = reservationService;
            _scheduleService = scheduleService;
            _membershipService = membershipService;

            datePicker.SelectedDate = DateTime.Today;
            LoadClubs();
        }

        private async void LoadClubs()
        {
            try
            {
                var clubs = await _membershipService.GetAllClubsAsync();
                clubComboBox.ItemsSource = clubs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clubs: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void LoadReservations()
        {
            if (clubComboBox.SelectedItem == null || !datePicker.SelectedDate.HasValue)
                return;

            try
            {
                var clubId = (int)clubComboBox.SelectedValue;
                var date = datePicker.SelectedDate.Value;
                var schedules = await _scheduleService.GetSchedulesByDateRangeAsync(
                    clubId,
                    date,
                    date.AddDays(1).AddSeconds(-1));

                var allReservations = await Task.WhenAll(
                    schedules.Select(s => _reservationService.GetScheduleReservationsAsync(s.Id)));

                reservationsGrid.ItemsSource = allReservations.SelectMany(r => r);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservations: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnMakeReservation_Click(object sender, RoutedEventArgs e)
        {
            if (clubComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a club first", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var dialog = new ReservationDialog(
                (int)clubComboBox.SelectedValue,
                datePicker.SelectedDate ?? DateTime.Today,
                _scheduleService,
                _membershipService,
                _reservationService);

            if (dialog.ShowDialog() == true)
            {
                LoadReservations();
            }
        }

        private async void btnCancelReservation_Click(object sender, RoutedEventArgs e)
        {
            var reservation = ((FrameworkElement)sender).DataContext as Reservation;
            if (reservation == null)
                return;

            var result = MessageBox.Show(
                "Are you sure you want to cancel this reservation?",
                "Confirm Cancellation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    await _reservationService.DeleteReservationAsync(reservation.Id);
                    LoadReservations();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error canceling reservation: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadReservations();
        }

        private void clubComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadReservations();
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadReservations();
        }
    }
} 