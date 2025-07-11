using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Http;
using medLinkMaui.ViewModel;
using MedLink.Logic.Services;

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
            builder.Services.AddHttpClient("MedLinkApi", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5260/api/");
            });
#endif

            return builder.Build();
        }
    }
}
