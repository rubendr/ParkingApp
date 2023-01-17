using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMobileFrontend.ViewModels
{
    public partial class AppViewModel : ObservableObject
    {

        [RelayCommand()]
        private void CheckInParking()
        {
            Shell.Current.Navigation.PushAsync(new Views.ParkingPage());
            Shell.Current.FlyoutIsPresented = false;
        }

        [RelayCommand()]
        private void CheckOutParking()
        {
            Shell.Current.Navigation.PushAsync(new Views.ParkingPage());
            Shell.Current.FlyoutIsPresented = false;
        }


    }
}
