using medLinkMaui.ViewModel;

namespace medLinkMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage(PatientViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }       
    }
}
