using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FitnessClub.BLL.Interfaces;
using FitnessClub.UI.Pages;
using FitnessClub.DAL.Entities;
using FitnessClub.UI.Dialogs;

namespace FitnessClub.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IClubService _clubService;
    private readonly IMembershipService _membershipService;
    private readonly IVisitService _visitService;
    private readonly IScheduleService _scheduleService;
    private readonly IReservationService _reservationService;

    public MainWindow(
        IClubService clubService,
        IMembershipService membershipService,
        IVisitService visitService,
        IScheduleService scheduleService,
        IReservationService reservationService)
    {
        InitializeComponent();
        _clubService = clubService;
        _membershipService = membershipService;
        _visitService = visitService;
        _scheduleService = scheduleService;
        _reservationService = reservationService;

        // Navigate to clubs page by default
        ViewClubs_Click(this, new RoutedEventArgs());
    }

    private void ViewClubs_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new ClubsPage(_clubService));
    }

    private void AddClub_Click(object sender, RoutedEventArgs e)
    {
        var club = new Club();
        var dialog = new ClubDialog(club);
        
        if (dialog.ShowDialog() == true)
        {
            _clubService.CreateClubAsync(club);
            ViewClubs_Click(this, new RoutedEventArgs());
        }
    }

    private void ViewMembers_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new MembersPage(_membershipService));
    }

    private void AddMember_Click(object sender, RoutedEventArgs e)
    {
        var member = new Client();
        var dialog = new MemberDialog(member);
        
        if (dialog.ShowDialog() == true)
        {
            _membershipService.CreateClientAsync(member);
            ViewMembers_Click(this, new RoutedEventArgs());
        }
    }

    private void ViewMemberships_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new MembershipsPage(_membershipService));
    }

    private void AddMembership_Click(object sender, RoutedEventArgs e)
    {
        var membership = new Membership { StartDate = DateTime.Today };
        var dialog = new MembershipDialog(membership, _membershipService);
        
        if (dialog.ShowDialog() == true)
        {
            _membershipService.CreateMembershipAsync(membership);
            ViewMemberships_Click(this, new RoutedEventArgs());
        }
    }

    private void ViewSchedule_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new SchedulePage(_scheduleService, _membershipService));
    }

    private void MakeReservation_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new ReservationPage(_reservationService, _scheduleService, _membershipService));
    }

    private void ViewVisits_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new VisitsPage(_visitService, _membershipService));
    }

    private void RegisterVisit_Click(object sender, RoutedEventArgs e)
    {
        var visit = new Visit { VisitTime = System.DateTime.Now };
        var dialog = new VisitDialog(visit, _membershipService);
        
        if (dialog.ShowDialog() == true)
        {
            _visitService.CreateVisitAsync(visit);
            ViewVisits_Click(this, new RoutedEventArgs());
        }
    }
}