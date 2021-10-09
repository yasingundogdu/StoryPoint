using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoryPoint
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        public ResultPage(string result)
        {
            InitializeComponent();

            lblResult.Text = result;
        }


        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            await Icon.RotateTo(-360, 200, Easing.Linear);
            await Icon.RotateTo(0,0);

            Application.Current.MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#9575CD")
            };
        }
    }
}