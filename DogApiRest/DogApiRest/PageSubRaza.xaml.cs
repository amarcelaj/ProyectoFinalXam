using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DogApiRest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageSubRaza : ContentPage
	{
        private const string Url = "http://makeup-api.herokuapp.com/api/v1/products.json?brand=";
        string maquillaje;
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Razas> _post;
        public PageSubRaza()
		{
			InitializeComponent ();
            BindingContext = this;
        }
        public PageSubRaza(Razas raza)
        {
            BindingContext = raza;
            InitializeComponent();
            maquillaje = raza.brand;
        }
        protected override async void OnAppearing()
        {
            string content = await client.GetStringAsync(Url+maquillaje);
            List<Razas> subraza = JsonConvert.DeserializeObject<List<Razas>>(content);
            _post = new ObservableCollection<Razas>(subraza);
            lstSubRazas.ItemsSource = _post;
            base.OnAppearing();
        }
        private void lstSubRazas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectItem = e.SelectedItem;
            var _raza = selectItem as Razas;
            Razas sub = new Razas();
            Navigation.PushAsync(
                new PageImage(_raza)
                );
        }
    }
}