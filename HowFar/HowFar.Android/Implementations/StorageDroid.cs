using HowFar.CustomInterfaces;
using HowFar.Models;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Storage))]
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
                string path = Path.Combine(docsPath , usernameFileName);
                string content = File.ReadAllText(path);
                return content;
            }
            catch (FileNotFoundException)
            {
                return string.Empty;
            }
        }

        public async void SetUsername(string username)
        {
            string path = Path.Combine(docsPath, usernameFileName);
            using var writer = File.CreateText(path);
            await writer.WriteAsync(username);
        }
    }
}