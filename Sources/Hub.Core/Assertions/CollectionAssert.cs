using Hub.Core.Infrastructure.IOC;
using System;
using System.Collections;

namespace Hub.Core.Assertions
{
    public sealed class CollectionAssert
    {
        private static readonly ICollectionAssert _collectionAssert;

        static CollectionAssert() => _collectionAssert = ServicesCollection.Current.Resolve<ICollectionAssert>();

        public static void AllItemsAreInstancesOfType(ICollection collection, Type expectedType) => _collectionAssert.AllItemsAreInstancesOfType(collection, expectedType);

        public static void AllItemsAreInstancesOfType(ICollection collection, Type expectedType, string message) => _collectionAssert.AllItemsAreInstancesOfType(collection, expectedType, message);

        public static void AllItemsAreNotNull(ICollection collection) => _collectionAssert.AllItemsAreNotNull(collection);

        public static void AllItemsAreNotNull(ICollection collection, string message) => _collectionAssert.AllItemsAreNotNull(collection, message);

        public static void AllItemsAreUnique(ICollection collection) => _collectionAssert.AllItemsAreUnique(collection);

        public static void AllItemsAreUnique(ICollection collection, string message) => _collectionAssert.AllItemsAreUnique(collection, message);

        public static void AreEqual(ICollection expected, ICollection actual) => _collectionAssert.AreEqual(expected, actual);

        public static void AreEqual(ICollection expected, ICollection actual, IComparer comparer) => _collectionAssert.AreEqual(expected, actual, comparer);

        public static void AreEqual(ICollection expected, ICollection actual, string message) => _collectionAssert.AreEqual(expected, actual, message);

        public static void AreEqual(ICollection expected, ICollection actual, IComparer comparer, string message) => _collectionAssert.AreEqual(expected, actual, comparer, message);

        public static void AreEquivalent(ICollection expected, ICollection actual) => _collectionAssert.AreEquivalent(expected, actual);

        public static void AreEquivalent(ICollection expected, ICollection actual, string message) => _collectionAssert.AreEquivalent(expected, actual, message);

        public static void AreNotEqual(ICollection notExpected, ICollection actual) => _collectionAssert.AreNotEqual(notExpected, actual);

        public static void AreNotEqual(ICollection notExpected, ICollection actual, IComparer comparer) => _collectionAssert.AreNotEqual(notExpected, actual, comparer);

        public static void AreNotEqual(ICollection notExpected, ICollection actual, string message) => _collectionAssert.AreNotEqual(notExpected, actual, message);

        public static void AreNotEqual(ICollection notExpected, ICollection actual, IComparer comparer, string message) => _collectionAssert.AreNotEqual(notExpected, actual, comparer, message);

        public static void AreNotEquivalent(ICollection expected, ICollection actual) => _collectionAssert.AreNotEquivalent(expected, actual);

        public static void AreNotEquivalent(ICollection expected, ICollection actual, string message) => _collectionAssert.AreNotEquivalent(expected, actual, message);

        public static void Contains(ICollection collection, object element) => _collectionAssert.Contains(collection, element);

        public static void Contains(ICollection collection, object element, string message) => _collectionAssert.Contains(collection, element, message);

        public static void DoesNotContain(ICollection collection, object element) => _collectionAssert.DoesNotContain(collection, element);

        public static void DoesNotContain(ICollection collection, object element, string message) => _collectionAssert.DoesNotContain(collection, element, message);

        public static void IsNotSubsetOf(ICollection subset, ICollection superset) => _collectionAssert.IsNotSubsetOf(subset, superset);

        public static void IsNotSubsetOf(ICollection subset, ICollection superset, string message) => _collectionAssert.IsNotSubsetOf(subset, superset, message);

        public static void IsSubsetOf(ICollection subset, ICollection superset) => _collectionAssert.IsSubsetOf(subset, superset);

        public static void IsSubsetOf(ICollection subset, ICollection superset, string message) => _collectionAssert.IsSubsetOf(subset, superset, message);
    }
}
