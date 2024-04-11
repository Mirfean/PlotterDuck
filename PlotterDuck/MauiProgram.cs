using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Storage;

namespace PlotterDuck
{
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
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("P:\\Projects\\.Net\\PlotterDuck\\PlotterDuck\\Resources\\plotterduck-firebase-adminsdk.json"),
                ProjectId = "plotterduck",
            });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
