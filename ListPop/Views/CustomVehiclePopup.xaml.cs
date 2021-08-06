
using ListPop.ViewModels;

namespace ListPop.Views
{
    public partial class CustomVehiclePopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public CustomVehiclePopup()
        {
            InitializeComponent();
        }
        public CustomVehiclePopup(CustomVehiclePopupViewModel viewmodel)
        {
            InitializeComponent();
            this.BindingContext = viewmodel;
        }
    }
}
