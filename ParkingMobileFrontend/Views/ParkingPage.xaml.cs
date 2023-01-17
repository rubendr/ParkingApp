namespace ParkingMobileFrontend.Views;

public partial class ParkingPage : ContentPage
{
	public ParkingPage()
	{
		InitializeComponent();
		BindingContext = new ViewModels.ParkingViewModel();
	}
}