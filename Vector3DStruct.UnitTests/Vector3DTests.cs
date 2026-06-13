using System;
using NUnit.Framework;
using Vector3DStruct;

namespace Vector3DStruct.UnitTests
{
    [TestFixture]
    public class Vector3DTests
    {
        private const double Eps = 1e-13;

        private Vector3D MakeVector() => new Vector3D(1.0, 2.0, 3.0);

        [Test]
        public void ConstructorTest()
        {
            var v = MakeVector();
            Assert.That(v.X, Is.EqualTo(1.0).Within(Eps));
            Assert.That(v.Y, Is.EqualTo(2.0).Within(Eps));
            Assert.That(v.Z, Is.EqualTo(3.0).Within(Eps));
        }

        [Test]
        public void LengthTest()
        {
            var v = new Vector3D(1.0, 2.0, 2.0);
            Assert.That(v.Length, Is.EqualTo(3.0).Within(Eps));
        }

        [Test]
        public void Length_ZeroVector_IsZero()
        {
            var v = new Vector3D(0, 0, 0);
            Assert.That(v.Length, Is.EqualTo(0.0).Within(Eps));
        }

        [Test]
        public void ToStringTest()
        {
            var v = new Vector3D(1.0, 2.0, 3.0);
            Assert.That(v.ToString(), Is.EqualTo("(1; 2; 3)"));
        }

        [Test]
        public void Equals_SameCoordinates_ReturnsTrue()
        {
            var a = new Vector3D(1.0, 2.0, 3.0);
            var b = new Vector3D(1.0, 2.0, 3.0);
            Assert.That(a.Equals(b), Is.True);
        }

        [Test]
        public void Equals_DifferentCoordinates_ReturnsFalse()
        {
            var a = new Vector3D(1.0, 2.0, 3.0);
            var b = new Vector3D(1.0, 2.0, 4.0);
            Assert.That(a.Equals(b), Is.False);
        }

        [Test]
        public void Equals_WrongType_ThrowsArgumentException()
        {
            var v = MakeVector();
            Assert.That(() => v.Equals("not a vector"), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCode_EqualVectors_SameHash()
        {
            var a = new Vector3D(1.0, 2.0, 3.0);
            var b = new Vector3D(1.0, 2.0, 3.0);
            Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
        }

        [Test]
        public void EqualityOperatorsTest()
        {
            var a = new Vector3D(1.0, 2.0, 3.0);
            var b = new Vector3D(1.0, 2.0, 3.0);
            var c = new Vector3D(0.0, 0.0, 0.0);

            Assert.That(a == b, Is.True);
            Assert.That(a != b, Is.False);
            Assert.That(a == c, Is.False);
            Assert.That(a != c, Is.True);
        }

        [TestCase(1, 2, 3, 4, 5, 6, 5, 7, 9)]
        [TestCase(1, 0, -1, -1, 0, 1, 0, 0, 0)]
        public void AdditionTest(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double rx, double ry, double rz)
        {
            var a = new Vector3D(x1, y1, z1);
            var b = new Vector3D(x2, y2, z2);
            var expected = new Vector3D(rx, ry, rz);
            Assert.That(a + b, Is.EqualTo(expected));
        }

        [TestCase(5, 7, 9, 4, 5, 6, 1, 2, 3)]
        [TestCase(1, 1, 1, 1, 1, 1, 0, 0, 0)]
        public void SubtractionTest(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double rx, double ry, double rz)
        {
            var a = new Vector3D(x1, y1, z1);
            var b = new Vector3D(x2, y2, z2);
            var expected = new Vector3D(rx, ry, rz);
            Assert.That(a - b, Is.EqualTo(expected));
        }

        [TestCase(2.0, 1, 2, 3, 2, 4, 6)]
        [TestCase(0.5, 2, 4, 6, 1, 2, 3)]
        [TestCase(0.0, 1, 2, 3, 0, 0, 0)]
        public void MultiplicationTest(double lambda,
            double x, double y, double z,
            double rx, double ry, double rz)
        {
            var v = new Vector3D(x, y, z);
            var expected = new Vector3D(rx, ry, rz);
            Assert.That(lambda * v, Is.EqualTo(expected));
            Assert.That(v * lambda, Is.EqualTo(expected));
        }

        [Test]
        public void DotProductTest()
        {
            var a = new Vector3D(1, 2, 3);
            var b = new Vector3D(4, 5, 6);
            Assert.That(Vector3D.Dot(a, b), Is.EqualTo(32.0).Within(Eps));
        }

        [Test]
        public void DotProduct_PerpendicularVectors_IsZero()
        {
            var x = new Vector3D(1, 0, 0);
            var y = new Vector3D(0, 1, 0);
            Assert.That(Vector3D.Dot(x, y), Is.EqualTo(0.0).Within(Eps));
        }

        [Test]
        public void CrossProductTest()
        {
            var x = new Vector3D(1, 0, 0);
            var y = new Vector3D(0, 1, 0);
            var expected = new Vector3D(0, 0, 1);
            Assert.That(x ^ y, Is.EqualTo(expected));
        }

        [Test]
        public void CrossProduct_ParallelVectors_IsZero()
        {
            var a = new Vector3D(1, 2, 3);
            var b = new Vector3D(2, 4, 6);
            var expected = new Vector3D(0, 0, 0);
            Assert.That(a ^ b, Is.EqualTo(expected));
        }
    }
}