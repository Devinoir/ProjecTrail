using Microsoft.EntityFrameworkCore;
using ProjecTrail.Database;
using ProjecTrail.ViewModel;

namespace ProjecTrail;

public partial class App : Application
{

    public App()
    {
        InitializeComponent();

        // Resolve ProjectDatabase from the service provider
        var projectDatabase = MauiProgram.App.Services.GetService<ProjectDatabase>();

        // Ensure that projectDatabase is not null
        if (projectDatabase == null)
        {
            throw new InvalidOperationException("ProjectDatabase could not be resolved.");
        }

        // Use the resolved ProjectDatabase to create MainPageViewModel
        var mainPageViewModel = new MainPageViewModel(projectDatabase);
        MainPage = new NavigationPage(new MainPage(mainPageViewModel));

        ServiceProvider.DialogService = new DialogService();
    }
}
