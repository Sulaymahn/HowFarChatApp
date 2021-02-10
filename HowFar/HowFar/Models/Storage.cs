using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using HowFar.CustomInterfaces;
using Xamarin.Forms;

namespace HowFar.Models
{
    public class Storage
    {
        public IStorage storage = DependencyService.Get<IStorage>();
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
        }
    }
}
