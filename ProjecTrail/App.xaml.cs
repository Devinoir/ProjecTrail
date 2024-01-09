namespace ProjecTrail;

public partial class App : Application
{
    public static AppDbContext DbContext { get; private set; }

    public App()
    {
        InitializeComponent();

        DbContext = new AppDbContext();
        MainPage = new MainPage();
        ServiceProvider.DialogService = new DialogService();
    }
}
