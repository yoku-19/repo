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
    public class BirthdayUnitTests
    {
        private Birthday CreateTestBirthday()
        {
            return new Birthday("20.06.2025 15:00", "ул. Ленина, 5", "Анна", 1995);
        }

        [Test]
        public void ConstructorTest()
        {
            var b = CreateTestBirthday();

            Assert.That(b.PersonName, Is.EqualTo("Анна"));
            Assert.That(b.BirthYear, Is.EqualTo(1995));
            Assert.That(b.Location, Is.EqualTo("ул. Ленина, 5"));
            Assert.That(b.Age, Is.EqualTo(DateTime.Now.Year - 1995));
        }

        [Test]
        public void RemindTest()
        {
            var b = CreateTestBirthday();
            var result = b.Remind();

            Assert.That(result, Does.Contain("Анна"));
            Assert.That(result, Does.Contain((DateTime.Now.Year - 1995).ToString()));
            Assert.That(result, Does.Contain("ул. Ленина, 5"));
        }

        [Test]
        public void RemindOverridesBaseMethod()
        {
            Event e = new Birthday("20.06.2025 15:00", "ул. Ленина, 5", "Анна", 1995);
            var result = e.Remind();

            Assert.That(result, Does.Contain("День рождения"));
        }
    }
}
