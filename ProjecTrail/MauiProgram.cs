using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjecTrail.Database;
using ProjecTrail.View;
using ProjecTrail.ViewModel;

namespace ProjecTrail;

public static class MauiProgram
{
    public static MauiApp App { get; private set; }

    public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<ProjectDetailPage>();
        builder.Services.AddTransient<NewProjectModalPage>();

        builder.Services.AddSingleton<ProjectDatabase>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        App = builder.Build();

        return App;
	}
}
