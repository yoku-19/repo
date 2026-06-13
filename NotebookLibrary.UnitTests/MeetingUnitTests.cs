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
    public class MeetingUnitTests
    {
        private Meeting CreateTestMeeting()
        {
            return new Meeting("15.07.2025 10:30", "Офис на Садовой", "Иван Петров", "Подписание договора");
        }

        [Test]
        public void ConstructorTest()
        {
            var m = CreateTestMeeting();

            Assert.That(m.WithWhom, Is.EqualTo("Иван Петров"));
            Assert.That(m.Topic, Is.EqualTo("Подписание договора"));
            Assert.That(m.Location, Is.EqualTo("Офис на Садовой"));
        }

        [Test]
        public void RemindTest()
        {
            var m = CreateTestMeeting();
            var result = m.Remind();

            Assert.That(result, Does.Contain("Иван Петров"));
            Assert.That(result, Does.Contain("Подписание договора"));
            Assert.That(result, Does.Contain("Офис на Садовой"));
        }

        [Test]
        public void RemindOverridesBaseMethod()
        {
            Event e = new Meeting("15.07.2025 10:30", "Офис на Садовой", "Иван Петров", "Подписание договора");
            var result = e.Remind();

            Assert.That(result, Does.Contain("Встреча"));
        }
    }
}