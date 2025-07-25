using medLinkMaui.ViewModel;

namespace medLinkMaui.View;

public partial class CreatePatientPage : ContentPage
{
	public CreatePatientPage(CreatePatientViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}