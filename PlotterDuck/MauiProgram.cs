using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Storage;
using Google.Cloud.Storage.V1;
using System.Resources;
using PlotterDuck.Components.Models;
using PlotterDuck.Components.Models.Firebase;
using Firebase.Auth.Providers;
using Firebase.Auth;

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


            #region My code

            if(PlatformHelper.IsAndroid())
            {
				
			}
            else
            {
				var GOOGLE_APPLICATION_CREDENTIALS = PlatformHelper.getCredentials();
				GoogleAuthCloudServices googleAuthCloudService = new GoogleAuthCloudServices();

				FirebaseApp.Create(new AppOptions()
				{
					//Credential = GoogleCredential.GetApplicationDefault(),
					Credential = GoogleCredential.FromFile(GOOGLE_APPLICATION_CREDENTIALS),
					ProjectId = "plotterduck",
				});
			}

            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyA9z_SEEU6m-pFW9mplFcYhWEzKkxCtB3E",
                AuthDomain = "plotterduck.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));

            #endregion

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
