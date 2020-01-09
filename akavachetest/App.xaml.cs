using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using Xamarin.Forms;

namespace akavachetest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Registrations.Start("TEST");
            //var token = GetToken().Result;
            //MainPage = new MainPage();
            SetMainPage();
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
          
        }

        private async void SetMainPage()
        {
            var token = await GetToken();
            MainPage = new MainPage();
        }

        private async Task<string> GetToken()
        {
            try
            {
                var token = await BlobCache.Secure.GetObject<string>("access_token");
                Debug.WriteLine($"Token: {token}");
                return token;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error: {e.Message}");
                return null;
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
