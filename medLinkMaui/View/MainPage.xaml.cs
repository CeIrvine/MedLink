using medLinkMaui.ViewModel;

namespace medLinkMaui
{
    public partial class MainPage : ContentPage
    {
        private PatientViewModel ViewModel => BindingContext as PatientViewModel;

        public MainPage(PatientViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }     
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel != null)
                await ViewModel.GetPatientsCommand.ExecuteAsync(null);
        }
    }
}
