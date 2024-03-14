using Microsoft.EntityFrameworkCore;
using ProjecTrail.Database;
using ProjecTrail.MessageClasses;
using ProjecTrail.Models;
using ProjecTrail.View;
using ProjecTrail.ViewModel;

namespace ProjecTrail;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}


