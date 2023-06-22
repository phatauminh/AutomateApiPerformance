using System;
using System.Collections;
using NU = NUnit.Framework;

namespace Hub.Core.Assertions
{
    public class NUnitCollectionAssert : ICollectionAssert
    {
        public void AllItemsAreInstancesOfType(ICollection collection, Type expectedType) => NU.CollectionAssert.AllItemsAreInstancesOfType(collection, expectedType);
        public void AllItemsAreInstancesOfType(ICollection collection, Type expectedType, string message) => NU.CollectionAssert.AllItemsAreInstancesOfType(collection, expectedType, message);
        public void AllItemsAreNotNull(ICollection collection) => NU.CollectionAssert.AllItemsAreNotNull(collection);
        public void AllItemsAreNotNull(ICollection collection, string message) => NU.CollectionAssert.AllItemsAreNotNull(collection, message);
        public void AllItemsAreUnique(ICollection collection) => NU.CollectionAssert.AllItemsAreUnique(collection);
        public void AllItemsAreUnique(ICollection collection, string message) => NU.CollectionAssert.AllItemsAreUnique(collection, message);
        public void AreEqual(ICollection expected, ICollection actual) => NU.CollectionAssert.AreEqual(expected, actual);
        public void AreEqual(ICollection expected, ICollection actual, IComparer comparer) => NU.CollectionAssert.AreEqual(expected, actual, comparer);
        public void AreEqual(ICollection expected, ICollection actual, string message) => NU.CollectionAssert.AreEqual(expected, actual, message);
        public void AreEqual(ICollection expected, ICollection actual, IComparer comparer, string message) => NU.CollectionAssert.AreEqual(expected, actual, comparer, message);
        public void AreEquivalent(ICollection expected, ICollection actual) => NU.CollectionAssert.AreEquivalent(expected, actual);
        public void AreEquivalent(ICollection expected, ICollection actual, string message) => NU.CollectionAssert.AreEquivalent(expected, actual, message);
        public void AreNotEqual(ICollection notExpected, ICollection actual) => NU.CollectionAssert.AreNotEqual(notExpected, actual);
        public void AreNotEqual(ICollection notExpected, ICollection actual, IComparer comparer) => NU.CollectionAssert.AreNotEqual(notExpected, actual, comparer);
        public void AreNotEqual(ICollection notExpected, ICollection actual, string message) => NU.CollectionAssert.AreNotEqual(notExpected, actual, message);
        public void AreNotEqual(ICollection notExpected, ICollection actual, IComparer comparer, string message) => NU.CollectionAssert.AreNotEqual(notExpected, actual, comparer, message);
        public void AreNotEquivalent(ICollection expected, ICollection actual) => NU.CollectionAssert.AreNotEquivalent(expected, actual);
        public void AreNotEquivalent(ICollection expected, ICollection actual, string message) => NU.CollectionAssert.AreNotEquivalent(expected, actual, message);
        public void Contains(ICollection collection, object element) => NU.CollectionAssert.Contains(collection, element);
        public void Contains(ICollection collection, object element, string message) => NU.CollectionAssert.Contains(collection, element, message);
        public void DoesNotContain(ICollection collection, object element) => NU.CollectionAssert.DoesNotContain(collection, element);
        public void DoesNotContain(ICollection collection, object element, string message) => NU.CollectionAssert.DoesNotContain(collection, element, message);
        public void IsNotSubsetOf(ICollection subset, ICollection superset) => NU.CollectionAssert.IsNotSubsetOf(subset, superset);
        public void IsNotSubsetOf(ICollection subset, ICollection superset, string message) => NU.CollectionAssert.IsNotSubsetOf(subset, superset, message);
        public void IsSubsetOf(ICollection subset, ICollection superset) => NU.CollectionAssert.IsSubsetOf(subset, superset);
        public void IsSubsetOf(ICollection subset, ICollection superset, string message) => NU.CollectionAssert.IsSubsetOf(subset, superset, message);
    }
}
