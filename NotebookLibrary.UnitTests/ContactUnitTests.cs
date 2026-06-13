using System;
using NUnit.Framework;
using NotebookLibrary;

namespace NotebookLibrary.UnitTests
{
    [TestFixture]
    public class ContactUnitTests
    {
        private Contact CreateTestContact()
        {
            return new Contact("Иван", "Иванов", "ул. Ленина, 1", ContactGroup.Friends);
        }

        [Test]
        public void ConstructorTest()
        {
            var contact = CreateTestContact();

            Assert.That(contact.Name, Is.EqualTo("Иван"));
            Assert.That(contact.Surname, Is.EqualTo("Иванов"));
            Assert.That(contact.Address, Is.EqualTo("ул. Ленина, 1"));
            Assert.That(contact.Group, Is.EqualTo(ContactGroup.Friends));
            Assert.That(contact.Id, Is.GreaterThan(0));
        }

        [Test]
        public void GetInfoTest()
        {
            var contact = CreateTestContact();
            contact.Phone = "89001234567";
            contact.Notes = "Школьный друг";

            var info = contact.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("Иван Иванов"));
            Assert.That(info[1], Does.Contain("Друзья"));
            Assert.That(info[1], Does.Contain("ул. Ленина, 1"));
            Assert.That(info[1], Does.Contain("89001234567"));
            Assert.That(info[1], Does.Contain("Школьный друг"));
        }

        [Test]
        public void ConstructorThrowsOnEmptyName()
        {
            Assert.Throws<ArgumentException>(() =>
                new Contact("", "Иванов", "ул. Ленина, 1", ContactGroup.None));
        }

        [Test]
        public void PhoneAndNotesAreNullByDefault()
        {
            var contact = CreateTestContact();

            Assert.That(contact.Phone, Is.Null);
            Assert.That(contact.Notes, Is.Null);
        }
    }
}