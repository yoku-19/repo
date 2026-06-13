using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookLibrary
{
    public class Contact : IComparable<Contact>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public ContactGroup Group { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public readonly int Id;
        private static int _nextId = 1;

        public Contact(string name, string surname, string address, ContactGroup group)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty");
            if (string.IsNullOrWhiteSpace(surname))
                throw new ArgumentException("Surname cannot be empty");

            Name = name;
            Surname = surname;
            Address = address;
            Group = group;
            Id = _nextId++;
        }

        public int CompareTo(Contact other)
        {
            if (other == null) return 1;

            if (Surname != other.Surname)
                return Surname.CompareTo(other.Surname);

            return Name.CompareTo(other.Name);
        }

        public virtual string[] GetInfo()
        {
            string groupName;
            switch (Group)
            {
                case ContactGroup.Family: groupName = "Семья"; break;
                case ContactGroup.Friends: groupName = "Друзья"; break;
                case ContactGroup.Acquaintances: groupName = "Знакомые"; break;
                case ContactGroup.Work: groupName = "Работа"; break;
                default: groupName = "Без группы"; break;
            }

            var info = new string[2];
            info[0] = $"{Name} {Surname}";
            info[1] = $"ID: {Id}. Group: {groupName}. Address: {Address}. " +
                      $"Phone: {Phone ?? "not set"}. Notes: {Notes ?? "none"}.";
            return info;
        }
    }
}