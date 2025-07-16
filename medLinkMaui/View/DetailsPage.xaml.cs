using medLinkMaui.ViewModel;

namespace medLinkMaui.View;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(PatientDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}