using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace WebView_OnProgressChanged;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureMauiHandlers(registerHandlerMappers)
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static void registerHandlerMappers(IMauiHandlersCollection handlers)
    {
        handlers.AddCompatibilityRenderer(typeof(CustomWebView), typeof(Platforms.Droid.CustomWebViewHandler));
        handlers.AddHandler(typeof(TimePicker), typeof(Platforms.Droid.TimePickerWithFocusHandler));
    }
}
