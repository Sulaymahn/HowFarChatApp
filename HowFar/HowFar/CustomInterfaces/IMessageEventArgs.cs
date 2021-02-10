using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using HowFar.Models;

namespace HowFar.CustomInterfaces
{
    public interface IMessageEventArgs 
    {
        public ObservableCollection<Message> messages { get; set; }
    }
}
