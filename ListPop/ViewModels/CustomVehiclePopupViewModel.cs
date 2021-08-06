
using System.Windows.Input;
using ListPop.Models;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ListPop.ViewModels
{
    public class CustomVehiclePopupViewModel : BaseViewModel
    {
        private Vehicle _selectedVehicle;
        public Vehicle SelectedVehicle { get { return _selectedVehicle; } set { _selectedVehicle = value; OnPropertyChanged(nameof(SelectedVehicle)); } }

        public ICommand RemoveVehicle => new Command(async () =>
        {
            MessagingCenter.Send(SelectedVehicle, "UpdateVehicleList");
            await PopupNavigation.Instance.PopAsync();
        });

        public ICommand CloseWindow => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
        });

        public CustomVehiclePopupViewModel() { }
        public CustomVehiclePopupViewModel(Vehicle vehicle)
        {
            SelectedVehicle = vehicle;
        }
    }
}
