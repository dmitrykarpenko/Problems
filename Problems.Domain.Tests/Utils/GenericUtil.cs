using Problems.Domain.Tests.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Problems.Domain.Tests.Utils
{
    public static class GenericUtil
    {
        public static ExecutionResult<TResult> Execute<TResult>(Func<TResult> action)
        {
            var start = DateTime.UtcNow;
            var result = action();
            var end = DateTime.UtcNow;

            return new ExecutionResult<TResult> { Result = result, TimeSpent = end - start };
        }

        public static string CreateString(params (char, int)[] chars) => CreateString((IEnumerable<(char, int)>)chars);
        public static string CreateString(IEnumerable<(char, int)> chars) => new string(CreateArray(chars));

        public static T[] CreateArrayFromEnumerables<T>(params (IEnumerable<T>, int)[] itemCollections) =>
            CreateEnumerableFromTuples(itemCollections).ToArray();

        public static T[] CreateArrayFromEnumerables<T>(params IEnumerable<(T, int)>[] itemCollections) =>
            CreateEnumerable(itemCollections).ToArray();

        public static T[] CreateArray<T>(params (T, int)[] items) => CreateEnumerable(items).ToArray();
        public static T[] CreateArray<T>(IEnumerable<(T, int)> items) => CreateEnumerable(items).ToArray();

        public static IEnumerable<T> CreateEnumerableFromTuples<T>(IEnumerable<(IEnumerable<T>, int)> itemCollections)
        {
            IEnumerable<T> allItems = new T[0];
            foreach (var items in itemCollections)
                for (int i = 0; i < items.Item2; ++i)
                    allItems = allItems.Concat(items.Item1);

            return allItems;
        }

        public static IEnumerable<T> CreateEnumerable<T>(IEnumerable<IEnumerable<(T, int)>> itemCollections) =>
            CreateEnumerable(itemCollections.SelectMany(items => items));

        public static IEnumerable<T> CreateEnumerable<T>(IEnumerable<(T, int)> items)
        {
            foreach (var item in items)
                for (int i = 0; i < item.Item2; ++i)
                    yield return item.Item1;
        }
    }
}
