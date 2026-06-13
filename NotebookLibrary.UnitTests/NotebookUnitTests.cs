using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NotebookLibrary;

namespace NotebookLibrary.UnitTests
{
    [TestFixture]
    public class NotebookUnitTests
    {
        private Notebook _notebook;
        private Contact[] _contacts;

        [SetUp]
        public void Setup()
        {
            _contacts = new[]
            {
                new Contact("Alice", "Anderson", "addr1", ContactGroup.Work),
                new Contact("Bob",   "Brown",    "addr2", ContactGroup.Friends),
                new Contact("Carol", "Clark",    "addr3", ContactGroup.Family),
            };

            _notebook = new Notebook("My Notebook", _contacts);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(_notebook.Title, Is.EqualTo("My Notebook"));
        }

        [Test]
        public void CountTest()
        {
            Assert.That(_notebook.Count, Is.EqualTo(3));
        }

        [Test]
        public void IEnumerable_ForeachWorksCorrectly()
        {
            var i = 0;
            foreach (var contact in _notebook)
            {
                Assert.That(contact, Is.SameAs(_contacts[i]));
                i++;
            }

            Assert.That(i, Is.EqualTo(3));
        }

        [Test]
        public void IEnumerable_CanBeUsedInLinq()
        {
            var found = new List<Contact>();
            foreach (var c in _notebook)
                if (c.Group == ContactGroup.Work)
                    found.Add(c);

            Assert.That(found.Count, Is.EqualTo(1));
            Assert.That(found[0].Name, Is.EqualTo("Alice"));
        }
    }
}