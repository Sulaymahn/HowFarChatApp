using HowFar.CustomInterfaces;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(IStorage))]
namespace HowFar.Droid.Implementations
{
    public class StorageDroid : IStorage
    {
        private string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private const string usernameFileName = "username";

        public string GetUsername()
        {
            try
            {
                string content = File.ReadAllText(usernameFileName);
                return content;
            }
            catch (FileNotFoundException e)
            {
                return string.Empty;
            }
        }

        public async void SetUsername(string username)
        {
            using var writer = File.CreateText(usernameFileName);
            await writer.WriteAsync(username);
        }
    }
}