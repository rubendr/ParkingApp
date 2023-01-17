using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMobileFrontend.ViewModels
{
    public partial class ParkingViewModel : ObservableObject
    {

        [ObservableProperty]
        private int slot;
        [ObservableProperty]
        private string vehicleNo;
        [ObservableProperty]
        private string vehicleType;
        [ObservableProperty]
        private string vehicleColor;
        [ObservableProperty]
        private string status;

        [RelayCommand()]
        private void PostCheckIn()
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Clear();
                var parkingdata = new Models.ParkingModel()
                {
                    Slot = Slot,
                    VehicleNo = VehicleNo,
                    Status = Status,
                    VehicleColor = VehicleColor,
                    VehicleType = VehicleType
                };
                string json = System.Text.Json.JsonSerializer.Serialize(parkingdata);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var resp = client.PostAsync(new Uri(@"http://192.168.8.137:9999/api/parking"), content).Result;
                resp.EnsureSuccessStatusCode();
                if (resp.IsSuccessStatusCode)
                {
                    var respok = resp.Content.ReadFromJsonAsync<Models.ResponseModel>().Result;
                    if (respok.Success == true)
                    {
                        Shell.Current.DisplayAlert("Info", "Vehicle Number: " + VehicleNo + " Check In Posted Success!", "OK");
                        client.CancelPendingRequests();
                        client.Dispose();
                    }
                    else
                    {
                        Shell.Current.DisplayAlert("Error", respok.Message, "OK");
                        client.CancelPendingRequests();
                        client.Dispose();
                    };
                }
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }

        }
        [RelayCommand()]
        private void PostCheckOut()
        {
            Shell.Current.DisplayAlert("Info", "Vehicle Number: " + VehicleNo + " Check Out Posted Success!", "OK");
        }


    }
}
