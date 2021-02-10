using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using HowFar.CustomInterfaces;
using HowFar.Droid.Helpers;
using HowFar.Droid.Implementations;
using Xamarin.Forms;
using System.Collections.ObjectModel;

[assembly: Dependency(typeof(HowFar.Droid.EventListeners.MessageListener))]
namespace HowFar.Droid.EventListeners
{
    public class MessageListener : Java.Lang.Object, IValueEventListener, IListener
    {
        public ObservableCollection<Models.Message> messages = new ObservableCollection<Models.Message>();

        public event EventHandler<IMessageEventArgs> messageRetrieved;

        public void OnCancelled(DatabaseError error)
        {

        }

        public void OnDataChange(DataSnapshot snapshot)
        {
            if(snapshot.Value != null)
            {
                var child = snapshot.Children.ToEnumerable<DataSnapshot>();
                messages.Clear();
                foreach(DataSnapshot messageData in child)
                {
                    Models.Message message = new Models.Message();
                    message.ID = messageData.Key;
                    message.Sender = messageData.Child("sender").Value.ToString();
                    message.Content = messageData.Child("content").Value.ToString();
                    messages.Add(message);
                }

                messageRetrieved?.Invoke(this, new MessageEventArgs { messages = this.messages});
            }
        }

        public void Create()
        {
            DatabaseReference messageRef = AppDataHelper.GetDatabase().GetReference("Chat");
            messageRef.AddValueEventListener(this);
        }
    }
}