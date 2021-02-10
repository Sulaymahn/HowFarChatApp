using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.sender.Send(new Message { Sender = "Sulaiman", Content = searchEntry.Text });
            searchEntry.Text = "";
        }
    }
}