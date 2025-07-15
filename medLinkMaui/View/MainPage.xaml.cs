using medLinkMaui.ViewModel;

namespace medLinkMaui.View
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

        private void OnSearchToggleClicked(object sender, EventArgs e)
        {
            PatientSearchBar.IsVisible = !PatientSearchBar.IsVisible;
        }

        private void OnSearchPressed(object sender, EventArgs e)
        {
/*            ViewModel?.SearchPatientsCommand.Execute(PatientSearchBar.Text);*/        
        }
    }
}
