using Microsoft.EntityFrameworkCore;
using ProjecTrail.MessageClasses;
using ProjecTrail.Models;
using ProjecTrail.View;
using ProjecTrail.ViewModel;

namespace ProjecTrail;

public partial class MainPage : ContentPage
{
    public MainPageViewModel ViewModel => BindingContext as MainPageViewModel;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel?.LoadProjectsFromDatabase();
    }

    private async void OnCreateNewProjectClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NewProjectModalPage());
        // Kein Aufruf von LoadProjectsFromDatabase hier, das ViewModel kümmert sich darum.
    }
}


