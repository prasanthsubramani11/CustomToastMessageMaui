using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;



#if WINDOWS
using Toast.Platforms.Windows;
#elif ANDROID
using static Toast.Platforms.Services.ToastMessageService.ToastMessageAndroid;
#elif IOS
using Toast.Platforms.iOS.Services;
#endif
using Toast.Services;

namespace Toast
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
#if WINDOWS
            builder.Services.AddSingleton<IToastService, ToastServiceWindows>();
#elif ANDROID
            builder.Services.AddSingleton<IToastService, ToastServiceAndroid>();
#elif IOS
    builder.Services.AddSingleton<IToastService, ToastServiceiOS>();
#endif



            return builder.Build();
        }
    }
}
