using MedLink.Logic.Services;
using medLinkMaui.ViewModel;
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
            builder.Services.AddSingleton<PatientViewModel>();

            // pages/views
            builder.Services.AddSingleton<MainPage>();

            
#if DEBUG
            builder.Logging.AddDebug();
            // HTTP Client
            builder.Services.AddSingleton(new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            })
            {
                BaseAddress = new Uri("https://10.0.2.2:7000/api/")
            });
#endif
            return builder.Build();
        }
    }
}
