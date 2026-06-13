using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookLibrary
{
    public class Birthday : Event
    {
        public string PersonName { get; set; }

        public readonly int BirthYear;

        public int Age => DateTime.Now.Year - BirthYear;
        public Birthday(string dateTime, string location, string personName, int birthYear)
            : base(dateTime, location)
        {
            PersonName = personName;
            BirthYear = birthYear;
        }

        public override string Remind()
        {
            return $"День рождения! {PersonName} исполняется {Age} лет. " +
                   $"{DateTime:g}, место: {Location}.";
        }
    }
}
