using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookLibrary
{
    public class Notebook : IEnumerable<Contact>
    {
        public string Title { get; set; }

        public int Count => _contacts.Count;

        private List<Contact> _contacts;

        public Notebook(string title, IEnumerable<Contact> contacts)
        {
            Title = title;
            _contacts = new List<Contact>();

            foreach (var contact in contacts)
                _contacts.Add(contact);
        }

        public IEnumerator<Contact> GetEnumerator() => _contacts.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
