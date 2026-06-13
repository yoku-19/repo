using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookLibrary
{
    public class Meeting : Event
    {
        public string WithWhom { get; set; }

        public string Topic { get; set; }

        public Meeting(string dateTime, string location, string withWhom, string topic)
            : base(dateTime, location)
        {
            WithWhom = withWhom;
            Topic = topic;
        }

        public override string Remind()
        {
            return $"Встреча с {WithWhom}. Тема: {Topic}. " +
                   $"{DateTime:g}, место: {Location}.";
        }
    }
}
