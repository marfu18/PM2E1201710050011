using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Geolocator;

namespace PM2E1201710050011
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {
           
            if (!double.TryParse(txtLatitud.Text, out double lat))
                return;
            if (!double.TryParse(txtLongitud.Text, out double lng))
                return;
            if (DesUbica.Text == "")
            {
                await DisplayAlert("Alerta", "Debe describir la Descripcion", "Ok");
                return;
            }
            if (NombreUbica.Text == "")
            {
                await DisplayAlert("Alerta", "Debe describir Ubicacion", "Ok");
                return;
            }
            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                Name = NombreUbica.Text,
                NavigationMode = NavigationMode.None
                
                });
        }

        
        private void btnSalvadas_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(Connectivity.NetworkAccess !=NetworkAccess.Internet)
            {
                DisplayAlert("GPS desactivado", "", "Ok");
                return;
            }
            else
            {
                DisplayAlert("GPS Activado", "Cuenta con Internet", "Ok");
            }

        }
    }
}
