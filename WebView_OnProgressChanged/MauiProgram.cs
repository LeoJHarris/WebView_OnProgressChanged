﻿using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using WebView_OnProgressChanged.Controls;

namespace WebView_OnProgressChanged;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiCompatibility()
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
        _ = handlers.AddCompatibilityRenderer(typeof(SharedCustomWebViewRenderer), typeof(Platforms.Droid.CustomWebViewRenderer));
        _ = handlers.AddHandler(typeof(SharedCustomWebViewHandler), typeof(Platforms.Droid.CustomWebViewHandler));
    }
}
