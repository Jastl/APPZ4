using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;

namespace FitnessClub.UI.Pages
{
    public partial class SchedulePage : Page
    {
        private readonly IScheduleService _scheduleService;
        private readonly IMembershipService _membershipService;

        public SchedulePage(IScheduleService scheduleService, IMembershipService membershipService)
        {
            InitializeComponent();
            _scheduleService = scheduleService;
            _membershipService = membershipService;
            
            startDatePicker.SelectedDate = DateTime.Today;
            endDatePicker.SelectedDate = DateTime.Today.AddDays(7);
            
            LoadClubs();
        }

        private async void LoadClubs()
        {
            try
            {
                var clubs = await _membershipService.GetAllClubsAsync();
                clubComboBox.ItemsSource = clubs;
                if (clubs.Any())
                {
                    clubComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clubs: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void LoadSchedules()
        {
            if (clubComboBox.SelectedItem == null || startDatePicker.SelectedDate == null || endDatePicker.SelectedDate == null)
                return;

            try
            {
                var clubId = (int)clubComboBox.SelectedValue;
                var schedules = await _scheduleService.GetSchedulesByDateRangeAsync(
                    clubId,
                    startDatePicker.SelectedDate.Value,
                    endDatePicker.SelectedDate.Value.AddDays(1).AddSeconds(-1));

                var schedulesWithSpots = new List<dynamic>();
                foreach (var schedule in schedules)
                {
                    var availableSpots = await _scheduleService.GetAvailableSpotsAsync(schedule.Id);
                    schedulesWithSpots.Add(new
                    {
                        schedule.Id,
                        schedule.ActivityName,
                        schedule.StartTime,
                        schedule.EndTime,
                        schedule.MaxParticipants,
                        AvailableSpots = availableSpots
                    });
                }

                scheduleGrid.ItemsSource = schedulesWithSpots;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading schedules: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (clubComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a club first", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var schedule = new Schedule
            {
                ClubId = (int)clubComboBox.SelectedValue,
                StartTime = DateTime.Now.Date.AddHours(DateTime.Now.Hour + 1),
                EndTime = DateTime.Now.Date.AddHours(DateTime.Now.Hour + 2)
            };

            var dialog = new ScheduleDialog(schedule);
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    _scheduleService.CreateScheduleAsync(schedule);
                    LoadSchedules();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating schedule: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEditSchedule_Click(object sender, RoutedEventArgs e)
        {
            var schedule = ((FrameworkElement)sender).DataContext as dynamic;
            if (schedule == null)
                return;

            var scheduleEntity = new Schedule
            {
                Id = schedule.Id,
                ActivityName = schedule.ActivityName,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                MaxParticipants = schedule.MaxParticipants,
                ClubId = (int)clubComboBox.SelectedValue
            };

            var dialog = new ScheduleDialog(scheduleEntity);
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    _scheduleService.UpdateScheduleAsync(scheduleEntity);
                    LoadSchedules();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating schedule: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void btnDeleteSchedule_Click(object sender, RoutedEventArgs e)
        {
            var schedule = ((FrameworkElement)sender).DataContext as dynamic;
            if (schedule == null)
                return;

            var result = MessageBox.Show(
                "Are you sure you want to delete this schedule?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    await _scheduleService.DeleteScheduleAsync(schedule.Id);
                    LoadSchedules();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting schedule: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadSchedules();
        }

        private void clubComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadSchedules();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (startDatePicker.SelectedDate > endDatePicker.SelectedDate)
            {
                if (sender == startDatePicker)
                    endDatePicker.SelectedDate = startDatePicker.SelectedDate;
                else
                    startDatePicker.SelectedDate = endDatePicker.SelectedDate;
            }
            LoadSchedules();
        }
    }
} 