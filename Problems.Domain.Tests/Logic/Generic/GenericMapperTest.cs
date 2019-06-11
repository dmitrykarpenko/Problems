using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Domain.Tests.Logic.Generic
{
    [TestClass]
    public class GenericMapperTest
    {
        [TestMethod]
        public void Map_Test()
        {
            var s = new S();

            B b = MapperExtensions.Map<S, D1>(s);

            var d1 = new D1();
            MapperExtensions.Map<S, B>(s, d1);

            s.Map<S, B>(d1);

            var b2 = s.Map<S, B>();

            DS ds = new DS();

            var b3 = ds.Map<S, B>();
        }

        //private class D2 : D1 { } 
        private class D1 : B { }
        private class B { }

        private class DS : S { }
        private class S { }
    }

    public static class MapperExtensions
    {
        public static TDest Map<TSource, TDest>(this TSource s)
        {
            return default(TDest);
        }
        public static TDest Map<TSource, TDest>(this TSource s, TDest d)
        {
            return d;
        }
    }
}
