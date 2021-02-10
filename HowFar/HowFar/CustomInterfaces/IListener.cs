using System;
using System.Collections.Generic;
using System.Text;

namespace HowFar.CustomInterfaces
{
    public interface IListener
    {
        public void Create();
        public event EventHandler<IMessageEventArgs> messageRetrieved;
    }
}
