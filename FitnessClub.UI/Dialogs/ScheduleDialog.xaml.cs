using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FitnessClub.DAL.Entities;

namespace FitnessClub.UI
{
    public partial class ScheduleDialog : Window
    {
        private readonly Schedule _schedule;
        private readonly List<TimeSpan> _timeSlots;

        public ScheduleDialog(Schedule schedule)
        {
            InitializeComponent();
            _schedule = schedule;
            DataContext = _schedule;

            // Generate time slots every 30 minutes
            _timeSlots = new List<TimeSpan>();
            for (int hour = 6; hour < 23; hour++) // 6 AM to 10 PM
            {
                _timeSlots.Add(new TimeSpan(hour, 0, 0));
                _timeSlots.Add(new TimeSpan(hour, 30, 0));
            }

            startTimeComboBox.ItemsSource = _timeSlots.Select(t => t.ToString(@"hh\:mm"));
            endTimeComboBox.ItemsSource = _timeSlots.Select(t => t.ToString(@"hh\:mm"));

            // Set initial values
            startDatePicker.SelectedDate = _schedule.StartTime;
            endDatePicker.SelectedDate = _schedule.EndTime;

            var startTime = _schedule.StartTime.TimeOfDay;
            var endTime = _schedule.EndTime.TimeOfDay;

            startTimeComboBox.SelectedItem = _timeSlots
                .FirstOrDefault(t => t.Hours == startTime.Hours && t.Minutes == startTime.Minutes)
                .ToString(@"hh\:mm");

            endTimeComboBox.SelectedItem = _timeSlots
                .FirstOrDefault(t => t.Hours == endTime.Hours && t.Minutes == endTime.Minutes)
                .ToString(@"hh\:mm");
        }

        private void startTimeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateStartTime();
        }

        private void endTimeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateEndTime();
        }

        private void UpdateStartTime()
        {
            if (startDatePicker.SelectedDate.HasValue && startTimeComboBox.SelectedItem != null)
            {
                var time = TimeSpan.Parse(startTimeComboBox.SelectedItem.ToString());
                _schedule.StartTime = startDatePicker.SelectedDate.Value.Date + time;
            }
        }

        private void UpdateEndTime()
        {
            if (endDatePicker.SelectedDate.HasValue && endTimeComboBox.SelectedItem != null)
            {
                var time = TimeSpan.Parse(endTimeComboBox.SelectedItem.ToString());
                _schedule.EndTime = endDatePicker.SelectedDate.Value.Date + time;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_schedule.ActivityName))
            {
                MessageBox.Show("Please enter an activity name", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_schedule.MaxParticipants <= 0)
            {
                MessageBox.Show("Maximum participants must be greater than 0", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_schedule.StartTime >= _schedule.EndTime)
            {
                MessageBox.Show("End time must be after start time", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
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