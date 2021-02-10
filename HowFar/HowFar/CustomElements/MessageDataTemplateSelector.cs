using HowFar.Models;
using Xamarin.Forms;

namespace HowFar.CustomElements
{
    public class MessageDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SentTemplate { get; set; }
        public DataTemplate RecievedTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Message)item).Sender == ((App)App.Current).Username ? SentTemplate : RecievedTemplate;
        }
    }
}
