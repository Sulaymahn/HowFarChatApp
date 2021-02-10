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
using Firebase;
using Firebase.Database;

namespace HowFar.Droid.Helpers
{
    public static class AppDataHelper
    {
        public static FirebaseDatabase GetDatabase()
        {
            FirebaseDatabase database;
            var app = FirebaseApp.InitializeApp(Application.Context);

            if(app == null)
            {
                var option = new FirebaseOptions.Builder()
                    .SetApplicationId("chatcars-b8cdb")
                    .SetApiKey("AIzaSyAWByCwEBcBCHeuc30GbQWuwmXaWGMYeHQ")
                    .SetDatabaseUrl("https://chatcars-b8cdb-default-rtdb.firebaseio.com/")
                    .SetStorageBucket("chatcars-b8cdb.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, option);
                database = FirebaseDatabase.GetInstance(app);
            }
            else
            {
                database = FirebaseDatabase.GetInstance(app);
            }

            return database;
        }
    }
}