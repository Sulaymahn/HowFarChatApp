using Xamarin.Forms;
using HowFar.Pages;
using HowFar.Models;

namespace HowFar
{
    public partial class App : Application
    {
        public readonly string Username = Storage.GetInstance().GetUsername();

        public App()
        {
            InitializeComponent();
            if(Username == string.Empty)
            {
                MainPage = new ProfilePage();
            }
            else
            {
                MainPage = new NavigationPage(new MenuPage());
            }
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
