using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FitnessClub.DAL;
using FitnessClub.DAL.Interfaces;
using FitnessClub.BLL.Interfaces;
using FitnessClub.BLL.Services;
using Microsoft.Extensions.Configuration;
using System.IO;
using FitnessClub.UI.Pages;
using FitnessClub.UI.Dialogs;

namespace FitnessClub.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private ServiceProvider serviceProvider;

    public App()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        serviceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // Database
        services.AddDbContext<FitnessClubContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlOptions => sqlOptions.EnableRetryOnFailure()
                    .CommandTimeout(30)
                    .EnableRetryOnFailure(3)
                    .MaxBatchSize(1));
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        }, ServiceLifetime.Scoped);

        // DAL
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // BLL
        services.AddScoped<IClubService, ClubService>();
        services.AddScoped<IMembershipService, MembershipService>();
        services.AddScoped<IVisitService, VisitService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IScheduleService, ScheduleService>();

        // UI
        services.AddTransient<MainWindow>();
        services.AddTransient<MembersPage>();
        services.AddTransient<ClubsPage>();
        services.AddTransient<SchedulePage>();
        services.AddTransient<ReservationPage>();
        services.AddTransient<VisitsPage>();
        services.AddTransient<MembershipDialog>();
        services.AddTransient<ReservationDialog>();
        services.AddTransient<ScheduleDialog>();
        services.AddTransient<ClientMembershipsDialog>();
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}

