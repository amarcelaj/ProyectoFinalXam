using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DogApiRest
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void btnIngreso_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(
                new PageRaza()
                );
        }
    }
}
