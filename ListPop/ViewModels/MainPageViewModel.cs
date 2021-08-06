using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ListPop.Models;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using ListPop.Views;

namespace ListPop.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Vehicle> _vehicles = new ObservableCollection<Vehicle>();
        public ObservableCollection<Vehicle> Vehicles { get { return _vehicles; } set { _vehicles = value; OnPropertyChanged(nameof(Vehicles)); } }

        public ICommand RemoveVehicle => new Command<Vehicle>(async (model) =>
        {
            /* Most Basic 
            var answer = await Application.Current.MainPage.DisplayAlert("Remove Vehicle", "Are you sure you want to remove this vehicle?", "Yes", "No");

            if(answer)
                Vehicles.Remove(model);
            */

            /* Plugin Pop */
            await PopupNavigation.Instance.PushAsync(new CustomVehiclePopup(new CustomVehiclePopupViewModel(model)));
            

        });

        public MainPageViewModel()
        {
            Vehicles = new ObservableCollection<Vehicle>()
            {
                new Vehicle(){ ID = 1, Year = 2021, Make = "Ford", Model = "Fiesta", Color = "Red" },
                new Vehicle(){ ID = 2, Year = 2020, Make = "Chevy", Model = "Volt", Color = "Black" },
                new Vehicle(){ ID = 3, Year = 2020, Make = "Toyota", Model = "Tundra", Color = "Gray" },
                new Vehicle(){ ID = 4, Year = 2018, Make = "Mazda", Model = "6", Color = "Blue" }
            };

            MessagingCenter.Subscribe<Vehicle>(this, "UpdateVehicleList", async (val) =>
            {
                var vehicleRef = Vehicles.Where(x => x.ID == val.ID).FirstOrDefault();

                if(vehicleRef != null)
                    Vehicles.Remove(vehicleRef);
            });
        }
    }
}
