using medLinkMaui.ViewModel;
using System.Threading.Tasks;

namespace medLinkMaui.View
{
    public partial class MainPage : ContentPage
    {
        private PatientViewModel ViewModel => BindingContext as PatientViewModel;

        double _lastScrollY = 0;

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
            await PatientSearchBar.FadeTo(1, 200);
        }

        private void OnCollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            double currentY = e.VerticalOffset;

            if (currentY > _lastScrollY + 5)
            {
                HideSearchBar();
            }
            else if (currentY < _lastScrollY - 5)
            {
                ShowSearchBar();
            }

            _lastScrollY = currentY;
        }

        private async void HideSearchBar()
        {
            if (PatientSearchBar.TranslationY == 0)
            {
                PatientSearchBar.IsVisible = false;
                CollectionSpacer.HeightRequest = 0;
                await PatientSearchBar.TranslateTo(0, -60, 200, Easing.CubicIn);
                await PatientSearchBar.FadeTo(0, 150, Easing.CubicIn);
            }
        }

        private async void ShowSearchBar()
        {
            if (PatientSearchBar.TranslationY < 0)
            {
                PatientSearchBar.IsVisible = true;
                CollectionSpacer.HeightRequest = 50; 
                await PatientSearchBar.FadeTo(1, 150, Easing.CubicOut);
                await PatientSearchBar.TranslateTo(0, 0, 200, Easing.CubicOut);
            }
        }        

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.SearchKeyword = e.NewTextValue;
        }
    }
}
