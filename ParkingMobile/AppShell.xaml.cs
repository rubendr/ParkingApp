namespace ParkingMobileFrontend
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new ViewModels.AppViewModel();
        }
    }
}