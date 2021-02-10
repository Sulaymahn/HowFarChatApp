using HowFar.CustomElements;
using HowFar.CustomInterfaces;
using System;
using Xamarin.Forms;

namespace HowFar.Models
{
    public class Storage
    {
        public IStorage storage = DependencyService.Get<IStorage>();

        public event EventHandler<UsernameChangedEventArgs> usernameChanged;

        private static Storage instance;

        private Storage()
        {

        }

        public static Storage GetInstance()
        {
            if(instance == null)
            {
                instance = new Storage();
            }
            return instance;
        }

        public string GetUsername()
        {
            return storage.GetUsername();
        }

        public void SetUsername(string name)
        {
            storage.SetUsername(name);
            usernameChanged?.Invoke(this, new UsernameChangedEventArgs { Username=name});
        }
    }
}
