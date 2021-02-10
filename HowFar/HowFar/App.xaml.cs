using Xamarin.Forms;
using HowFar.Pages;
using HowFar.Models;

namespace HowFar
{
    public partial class App : Application
    {
        public string Username = Storage.GetInstance().GetUsername();

        public App()
        {
            InitializeComponent();
            Storage.GetInstance().usernameChanged += App_usernameChanged;
            MainPage = new NavigationPage(new MenuPage());
        }

        private void App_usernameChanged(object sender, CustomElements.UsernameChangedEventArgs e)
        {
            Username = e.Username;
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
