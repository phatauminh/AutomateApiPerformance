using System;
using NU = NUnit.Framework;

namespace Hub.Core.Assertions
{
    public class NUnitAssert : IAssert
    {
        public void AreDateTimesEqual(DateTime? expectedDate, DateTime? actualDate, int deltaSeconds) => NU.Assert.That(actualDate, NU.Is.EqualTo(actualDate).Within(deltaSeconds).Seconds);

        public void AreDateTimesEqual(DateTime? expectedDate, DateTime? actualDate, int deltaSeconds, string message) => NU.Assert.That(actualDate, NU.Is.EqualTo(actualDate).Within(deltaSeconds).Seconds, message);

        public void AreEqual(double expected, double actual, double delta) => NU.Assert.AreEqual(expected, actual, delta);

        public void AreEqual(double expected, double actual, double delta, string message) => NU.Assert.AreEqual(expected, actual, delta, message);

        public void AreEqual(object expected, object actual) => NU.Assert.That(actual, NU.Is.EqualTo(expected));

        public void AreEqual(object expected, object actual, string message) => NU.Assert.That(actual, NU.Is.EqualTo(expected), message);

        public void AreEqual<T>(T expected, T actual) => NU.Assert.That(actual, NU.Is.EqualTo(expected));

        public void AreEqual<T>(T expected, T actual, string message) => NU.Assert.That(actual, NU.Is.EqualTo(expected), message);

        public void AreNotEqual(object expected, object actual) => NU.Assert.That(actual, NU.Is.Not.EqualTo(expected));

        public void AreNotEqual(object expected, object actual, string message) => NU.Assert.That(actual, NU.Is.Not.EqualTo(expected), message);

        public void AreNotEqual<T>(T expected, T actual) => NU.Assert.That(actual, NU.Is.Not.EqualTo(expected));

        public void AreNotEqual<T>(T expected, T actual, string message) => NU.Assert.That(actual, NU.Is.Not.EqualTo(expected), message);

        public void Fail(string message) => NU.Assert.Fail(message);

        public void Fail(string message, params object[] parameters) => NU.Assert.Fail(message, parameters);

        public void IsFalse(bool condition) => NU.Assert.That(condition, NU.Is.False);

        public void IsFalse(bool condition, string message) => NU.Assert.That(condition, NU.Is.False, message);

        public void IsInstanceOfType(object value, Type expectedType) => NU.Assert.That(value, NU.Is.AssignableTo(expectedType));

        public void IsInstanceOfType(object value, Type expectedType, string message) => NU.Assert.That(value, NU.Is.AssignableTo(expectedType), message);

        public void IsNotNull(object value) => NU.Assert.That(value, NU.Is.Not.Null);

        public void IsNotNull(object value, string message) => NU.Assert.That(value, NU.Is.Not.Null, message);

        public void IsNull(object value) => NU.Assert.That(value, NU.Is.Null);

        public void IsNull(object value, string message) => NU.Assert.That(value, NU.Is.Null, message);

        public void IsTrue(bool condition) => NU.Assert.That(condition, NU.Is.True);

        public void IsTrue(bool condition, string message) => NU.Assert.That(condition, NU.Is.True, message);

        public void IsTrue(bool condition, string message, params object[] parameters) => NU.Assert.That(condition, NU.Is.True, string.Format(message, parameters));

        public void Multiple(params Action[] assertions) => Assert.Multiple(assertions);
    }
}
