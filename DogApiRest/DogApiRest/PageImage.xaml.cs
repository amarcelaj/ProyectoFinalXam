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
	public partial class PageImage : ContentPage
	{
        private const string Url = "http://makeup-api.herokuapp.com/api/v1/products.json?brand=";
        string maquillaje;
        string productType = "&product_type =";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Razas> _post;
        public PageImage (Razas subraza)
		{
            BindingContext = subraza;
			InitializeComponent ();
            maquillaje = subraza.brand;
            productType += subraza.product_type;
		}
        protected override async void OnAppearing()
        {
            string content = await client.GetStringAsync(Url + maquillaje + productType);
            List<Razas> subraza = JsonConvert.DeserializeObject<List<Razas>>(content);
            _post = new ObservableCollection<Razas>(subraza);
            lstImagen.ItemsSource = _post;
            base.OnAppearing();
        }

    }
}