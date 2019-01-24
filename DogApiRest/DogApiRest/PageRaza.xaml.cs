using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace DogApiRest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageRaza : ContentPage
	{
        private const string Url = "http://makeup-api.herokuapp.com/api/v1/products.json";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Razas> _post;
        public PageRaza ()
		{
			InitializeComponent ();
        }
        protected override async void OnAppearing()
        {
            string content = await client.GetStringAsync(Url);
            List<Razas> raza = JsonConvert.DeserializeObject<List<Razas>>(content);
            _post = new ObservableCollection<Razas>(raza);
            lstRazas.ItemsSource = _post;
            base.OnAppearing();
        }

        private void lstRazas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectItem = e.SelectedItem;
            var _raza = selectItem as Razas;

            Navigation.PushAsync(
                new PageSubRaza(_raza)
                );
        }
    }
}