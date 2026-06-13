using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookLibrary
{
    public class Event
    {
        public DateTime DateTime { get; set; }

        public string Location { get; set; }

        public Event(string dateTime, string location)
        {
            if (!DateTime.TryParse(dateTime, out DateTime dt))
                throw new ArgumentException("Неверный формат даты и времени");
            DateTime = dt;
            Location = location;
        }

        public virtual string Remind()
        {
            return $"Событие {DateTime:g} в {Location}.";
        }
    }
}
