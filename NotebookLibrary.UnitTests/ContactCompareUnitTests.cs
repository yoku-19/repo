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
    public class ContactCompareUnitTests
    {
        [Test]
        public void CompareTo_DifferentSurnames_SortsBySurname()
        {
            var alice = new Contact("Alice", "Anderson", "addr1", ContactGroup.Work);
            var bob = new Contact("Bob", "Brown", "addr2", ContactGroup.Work);

            Assert.That(alice.CompareTo(bob), Is.LessThan(0));
            Assert.That(bob.CompareTo(alice), Is.GreaterThan(0));
        }

        [Test]
        public void CompareTo_SameSurname_SortsByName()
        {
            var alice = new Contact("Alice", "Smith", "addr1", ContactGroup.Work);
            var bob = new Contact("Bob", "Smith", "addr2", ContactGroup.Work);

            Assert.That(alice.CompareTo(bob), Is.LessThan(0));
            Assert.That(bob.CompareTo(alice), Is.GreaterThan(0));
        }

        [Test]
        public void CompareTo_SameContact_ReturnsZero()
        {
            var alice = new Contact("Alice", "Smith", "addr1", ContactGroup.Work);

            Assert.That(alice.CompareTo(alice), Is.EqualTo(0));
        }

        [Test]
        public void Sort_ContactList_SortedCorrectly()
        {
            var contacts = new[]
            {
                new Contact("Bob",   "Smith",    "addr1", ContactGroup.Work),
                new Contact("Alice", "Anderson", "addr2", ContactGroup.Friends),
                new Contact("Alice", "Smith",    "addr3", ContactGroup.Family),
            };

            System.Array.Sort(contacts);

            Assert.That(contacts[0].Surname, Is.EqualTo("Anderson"));
            Assert.That(contacts[1].Name, Is.EqualTo("Alice"));
            Assert.That(contacts[2].Name, Is.EqualTo("Bob"));
        }
    }
}