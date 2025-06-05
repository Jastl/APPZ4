using System;
using System.Windows;
using System.Windows.Controls;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Entities;

namespace FitnessClub.UI.Pages
{
    public partial class VisitsPage : Page
    {
        private readonly IVisitService _visitService;
        private readonly IMembershipService _membershipService;

        public VisitsPage(IVisitService visitService, IMembershipService membershipService)
        {
            InitializeComponent();
            _visitService = visitService;
            _membershipService = membershipService;
            LoadVisits();
        }

        private async void LoadVisits()
        {
            try
            {
                var visits = await _visitService.GetAllVisitsAsync();
                visitsGrid.ItemsSource = visits;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading visits: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegisterVisit_Click(object sender, RoutedEventArgs e)
        {
            var visit = new Visit { VisitTime = DateTime.Now };
            var dialog = new VisitDialog(visit, _membershipService);
            
            if (dialog.ShowDialog() == true)
            {
                _visitService.RegisterVisitAsync(visit);
                LoadVisits();
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadVisits();
        }
    }
} 