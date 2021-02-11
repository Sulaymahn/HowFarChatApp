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
using HowFar.CustomInterfaces;
using HowFar.Droid.Helpers;
using Xamarin.Forms;
using Firebase;
using Firebase.Database;
using Java.Util;
using HowFar.Models;

[assembly: Dependency(typeof(HowFar.Droid.Implementations.MessageSender))]
namespace HowFar.Droid.Implementations
{
    public class MessageSender : ISender
    {
        public async void Send(Models.Message message)
        {
            HashMap messageInfo = new HashMap();
            messageInfo.Put("sender", message.Sender);
            messageInfo.Put("content", message.Content);
            messageInfo.Put("time", message.Time);
            messageInfo.Put("date", message.Date);

            DatabaseReference messageReference = AppDataHelper.GetDatabase().GetReference("Chat").Push();
            await messageReference.SetValueAsync(messageInfo);
        }
    }
}