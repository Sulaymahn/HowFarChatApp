using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HowFar.CustomElements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageBox : ContentView
    {
        public event EventHandler<TextEventArgs> TextCompleted;
        public string EntryText
        {
            get { return boxEntry.Text; }
            set { boxEntry.Text = value; }
        }

        public class TextEventArgs : EventArgs
        {
            public string Text { get; set; }
        }

        public MessageBox()
        {
            InitializeComponent();
            boxEntry.Completed += BoxEntry_Completed;
        }

        private void BoxEntry_Completed(object sender, EventArgs e)
        {
            TextCompleted?.Invoke(this, new TextEventArgs { Text = EntryText });
        }
    }
}