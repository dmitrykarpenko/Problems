using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Domain.Tests.Utils
{
    public static class AssertUtil
    {
        public const int _greaterOrder = 2;
        public static void AssertMuchGreater(TimeSpan greater, TimeSpan smaller)
        {
            AssertGreater(greater, smaller * _greaterOrder, "Is not much greater: ");
        }
        public static void AssertSlightlyGreater(TimeSpan greater, TimeSpan smaller)
        {
            AssertGreater(greater, smaller, "Is not greater: ");
            AssertGreater(smaller * _greaterOrder, greater, "Is greater but not slightly: ");
        }

        public const float _roughlyEqualOrder = 4;
        public static void AssertRoughlyEqual(TimeSpan first, TimeSpan second,
            float roughlyEqualOrder = _roughlyEqualOrder)
        {
            // e.g. "y > x / 4" and "y < 4 * x" wedge
            AssertGreater(first * roughlyEqualOrder, second);
            AssertGreater(second * roughlyEqualOrder, first);
        }

        public static void AssertGreater(TimeSpan greater, TimeSpan smaller, string errorStart = null) =>
            Assert.IsTrue(greater > smaller, GetAssertGreaterError(greater, smaller, errorStart));

        public static string GetAssertGreaterError(TimeSpan greater, TimeSpan smaller, string errorStart = null) =>
            $"{errorStart}{greater} should be greater than {smaller}";
        
        /// <summary>
        /// Would also compare the elements themselves.
        /// </summary>
        /// <typeparam name="TCollectionElement">collections' element type</typeparam>
        /// <param name="properCollection">a collection of proper elements ("arranged")</param>
        /// <param name="collection">a collection of elements to "assert" (algorithm output)</param>
        public static void AssertCollection<TCollectionElement>(IEnumerable<TCollectionElement> properCollection,
                IEnumerable<TCollectionElement> collection) =>
            AssertCollection(properCollection, collection, e => e);

        public static void AssertCollection<TCollectionElement, TProp>(IEnumerable<TCollectionElement> properCollection,
                IEnumerable<TCollectionElement> collection,
                params Func<TCollectionElement, TProp>[] elementPropsSelectors) =>
            AssertCollection(properCollection, collection, (IList<Func<TCollectionElement, TProp>>)elementPropsSelectors);

        // should be made public if required
        private static void AssertCollection<TCollectionElement, TProp>(IEnumerable<TCollectionElement> properCollection,
            IEnumerable<TCollectionElement> collection,
            IList<Func<TCollectionElement, TProp>> elementPropsSelectors)
        {
            AssertDifferentReferences(properCollection, collection, nameof(collection) +
                " should be created, thus should not have the same reference as " + nameof(properCollection));
            Assert.IsNotNull(properCollection, nameof(properCollection) + " should not be null");
            Assert.IsNotNull(collection, nameof(collection) + " should not be null");
            Assert.AreEqual(properCollection.Count(), collection.Count(),
                nameof(properCollection) + " and " + nameof(collection) + " should have equal elements' counts");

            var compares = properCollection.Zip(collection,
                (pe, e) => new { ProperElement = pe, Element = e });

            foreach (var compare in compares)
                AssertPropsEquality(compare.ProperElement, compare.Element, elementPropsSelectors,
                    "Collections' elements' parts should be equal");
        }

        public static void AssertDifferentReferences<TDto>(TDto properDto, TDto dto, string message = null)
        {
            /// dto creation process knows nothing about the <paramref name="properDto"/> object
            /// (that should be created on "Arrange"),
            /// so a new <paramref name="dto"/> object should be created
            Assert.IsFalse(object.ReferenceEquals(properDto, dto), message);
        }

        public static void AssertPropsEquality<TDto, TProp>(TDto properDto, TDto dto,
                params Func<TDto, TProp>[] dtoPropsSelectors) =>
            AssertPropsEquality(properDto, dto, dtoPropsSelectors);

        // should be made public if required
        private static void AssertPropsEquality<TDto, TProp>(TDto properDto, TDto dto,
            IList<Func<TDto, TProp>> dtoPropsSelectors,
            string message = null)
        {
            Assert.IsTrue(dtoPropsSelectors.Any());

            foreach (var s in dtoPropsSelectors)
                Assert.AreEqual(s(properDto), s(dto), message);
        }
    }
}
