using MedLink.Logic.Services;
using medLinkMaui.ViewModel;
using medLinkMaui.View;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace medLinkMaui
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // services
            builder.Services.AddSingleton<BiometricsService>();
            builder.Services.AddSingleton<DoctorsService>();
            builder.Services.AddSingleton<IllnessesService>();
            builder.Services.AddSingleton<InsurancesService>();
            builder.Services.AddSingleton<OperationsService>();
            builder.Services.AddSingleton<PatientsService>();
            builder.Services.AddSingleton<SurgeriesService>();
            builder.Services.AddSingleton<UsersService>();
            builder.Services.AddSingleton<VisitsService>();

            // view models
            builder.Services.AddSingleton<PatientsViewModel>();
            builder.Services.AddTransient<PatientDetailsViewModel>();   

            // pages/views
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<DetailsPage>();
            builder.Services.AddSingleton<CreatePatientPage>();
            builder.Services.AddSingleton<DownloadedPage>();
            builder.Services.AddSingleton<DataManagementPage>();

            // Trying to remove underline from Entry on Android
            /*Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
#if ANDROID
#endif
            });*/

#if DEBUG
            builder.Logging.AddDebug();
            // HTTP Client
            builder.Services.AddSingleton(new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            })
            {
                BaseAddress = new Uri("https://10.0.2.2:7000/api/") // Android
                /*BaseAddress = new Uri("https://localhost:7000/api/")*/ // Windows
            });
#endif
            return builder.Build();
        }
    }
}


