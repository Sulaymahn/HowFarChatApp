using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HowFar.CustomInterfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(HowFar.Droid.Implementations.MessageEventArgs))]
namespace HowFar.Droid.Implementations
{
    public class MessageEventArgs : EventArgs, IMessageEventArgs
    {
        public ObservableCollection<Models.Message> messages { get; set; }
    }
}