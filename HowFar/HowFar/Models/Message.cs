using System;

namespace HowFar.Models
{
    public class Message
    {
        public string Sender { get; set; }
        public string Content { get; set; }
        public string ID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public Message(bool newDate)
        {
            if (newDate)
            {
                DateTime dt = DateTime.Now;
                Date = dt.ToString("g");
                Time = dt.ToString("t");
            }
        }
    }
}
