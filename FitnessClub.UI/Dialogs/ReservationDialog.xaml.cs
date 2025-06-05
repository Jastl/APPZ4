using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;

namespace FitnessClub.UI
{
    public partial class ReservationDialog : Window
    {
        private readonly int _clubId;
        private readonly DateTime _date;
        private readonly IScheduleService _scheduleService;
        private readonly IMembershipService _membershipService;
        private readonly IReservationService _reservationService;
        private Schedule _selectedSchedule;

        public ReservationDialog(
            int clubId,
            DateTime date,
            IScheduleService scheduleService,
            IMembershipService membershipService,
            IReservationService reservationService)
        {
            InitializeComponent();
            _clubId = clubId;
            _date = date;
            _scheduleService = scheduleService;
            _membershipService = membershipService;
            _reservationService = reservationService;

            LoadClients();
            LoadSchedules();
        }

        private async void LoadClients()
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

        private async void LoadSchedules()
        {
            try
            {
                var schedules = await _scheduleService.GetSchedulesByDateRangeAsync(
                    _clubId,
                    _date,
                    _date.AddDays(1).AddSeconds(-1));

                var schedulesWithSpots = new List<dynamic>();
                foreach (var schedule in schedules)
                {
                    var availableSpots = await _scheduleService.GetAvailableSpotsAsync(schedule.Id);
                    if (availableSpots > 0) // Only show schedules with available spots
                    {
                        schedulesWithSpots.Add(new
                        {
                            schedule.Id,
                            schedule.ActivityName,
                            schedule.StartTime,
                            schedule.EndTime,
                            AvailableSpots = availableSpots,
                            Schedule = schedule
                        });
                    }
                }

                scheduleGrid.ItemsSource = schedulesWithSpots;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading schedules: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void clientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSaveButton();
        }

        private void scheduleGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = scheduleGrid.SelectedItem as dynamic;
            _selectedSchedule = selectedItem?.Schedule as Schedule;
            UpdateSaveButton();
        }

        private void UpdateSaveButton()
        {
            btnSave.IsEnabled = clientComboBox.SelectedItem != null && _selectedSchedule != null;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (clientComboBox.SelectedItem == null || _selectedSchedule == null)
                return;

            try
            {
                var reservation = new Reservation
                {
                    ClientId = (int)clientComboBox.SelectedValue,
                    ScheduleId = _selectedSchedule.Id,
                    ReservationTime = DateTime.Now,
                    IsConfirmed = false
                };

                await _reservationService.CreateReservationAsync(reservation);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error making reservation: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
} 