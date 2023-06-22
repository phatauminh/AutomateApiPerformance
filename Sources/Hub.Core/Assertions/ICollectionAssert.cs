using System;
using System.Collections;

namespace Hub.Core.Assertions
{
    public interface ICollectionAssert
    {
        void AllItemsAreInstancesOfType(ICollection collection, Type expectedType);

        void AllItemsAreInstancesOfType(ICollection collection, Type expectedType, string message);

        void AllItemsAreNotNull(ICollection collection);

        void AllItemsAreNotNull(ICollection collection, string message);

        void AllItemsAreUnique(ICollection collection);

        void AllItemsAreUnique(ICollection collection, string message);

        void AreEqual(ICollection expected, ICollection actual);

        void AreEqual(ICollection expected, ICollection actual, IComparer comparer);

        void AreEqual(ICollection expected, ICollection actual, string message);

        void AreEqual(ICollection expected, ICollection actual, IComparer comparer, string message);

        void AreEquivalent(ICollection expected, ICollection actual);

        void AreEquivalent(ICollection expected, ICollection actual, string message);

        void AreNotEqual(ICollection notExpected, ICollection actual);

        void AreNotEqual(ICollection notExpected, ICollection actual, IComparer comparer);

        void AreNotEqual(ICollection notExpected, ICollection actual, string message);

        void AreNotEqual(ICollection notExpected, ICollection actual, IComparer comparer, string message);

        void AreNotEquivalent(ICollection expected, ICollection actual);

        void AreNotEquivalent(ICollection expected, ICollection actual, string message);

        void Contains(ICollection collection, object element);

        void Contains(ICollection collection, object element, string message);

        void DoesNotContain(ICollection collection, object element);

        void DoesNotContain(ICollection collection, object element, string message);

        void IsNotSubsetOf(ICollection subset, ICollection superset);

        void IsNotSubsetOf(ICollection subset, ICollection superset, string message);

        void IsSubsetOf(ICollection subset, ICollection superset);

        void IsSubsetOf(ICollection subset, ICollection superset, string message);
    }
}
