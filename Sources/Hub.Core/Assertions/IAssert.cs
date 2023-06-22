using System;

namespace Hub.Core.Assertions
{
    public interface IAssert
    {
        void AreEqual(double expected, double actual, double delta);

        void AreEqual(double expected, double actual, double delta, string message);

        void AreEqual(object expected, object actual);

        void AreEqual(object expected, object actual, string message);

        void AreEqual<T>(T expected, T actual);

        void AreEqual<T>(T expected, T actual, string message);

        void AreNotEqual(object expected, object actual);

        void AreNotEqual(object expected, object actual, string message);

        void AreNotEqual<T>(T expected, T actual);

        void AreNotEqual<T>(T expected, T actual, string message);

        void IsFalse(bool condition);

        void IsFalse(bool condition, string message);

        void IsTrue(bool condition);

        void IsTrue(bool condition, string message);

        void IsTrue(bool condition, string message, params object[] parameters);

        void IsNull(object value);

        void IsNull(object value, string message);

        void IsNotNull(object value);

        void IsNotNull(object value, string message);

        void Fail(string message);

        void Fail(string message, params object[] parameters);

        void IsInstanceOfType(object value, Type expectedType);

        void IsInstanceOfType(object value, Type expectedType, string message);

        void AreDateTimesEqual(DateTime? expectedDate, DateTime? actualDate, int deltaSeconds);

        void AreDateTimesEqual(DateTime? expectedDate, DateTime? actualDate, int deltaSeconds, string message);

        void Multiple(params Action[] assertions) => Assert.Multiple(assertions);
    }
}
