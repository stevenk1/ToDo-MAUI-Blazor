using Microsoft.AspNetCore.Components.WebView.Maui;
using Todo.Db;
using ToDo.Services;
using ToDo.Data;

namespace ToDo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddTransient<TaskRepository>();
        builder.Services.AddTransient<TaskService>();
        return builder.Build();
    }
}

