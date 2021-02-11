using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HowFar.Models;
using HowFar.CustomInterfaces;
using System.Collections.ObjectModel;

namespace HowFar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        private readonly ISender sender = DependencyService.Get<ISender>();
        private readonly IListener listener = DependencyService.Get<IListener>();


        public ObservableCollection<Message> messageList = new ObservableCollection<Message>();

        public MenuPage()
        {
            InitializeComponent();
            RetrieveData();
            if (((App)App.Current).Username == string.Empty)
            {
                Navigation.PushModalAsync(new ProfilePage(), true);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = messageList;
        }

        public void RetrieveData()
        {
            listener.Create();
            listener.messageRetrieved += Listener_messageRetrieved;
        }

        private void Listener_messageRetrieved(object sender, IMessageEventArgs e)
        {
            messageList = e.messages;
            collectionView.ItemsSource = messageList;
        }

        private void searchEntry_Completed(object sender, EventArgs e)
        {
            this.sender.Send(new Message(true) { Sender = ((App)App.Current).Username, Content = searchEntry.Text });
            searchEntry.Text = "";
        }

        private async void Profile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(), true);
        }
    }
}