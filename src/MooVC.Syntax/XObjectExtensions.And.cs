namespace MooVC.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    internal static partial class XObjectExtensions
    {
        public static IEnumerable<XObject> And<T1, T2>(this IEnumerable<T1> first, IEnumerable<T2> second)
            where T1 : XObject
            where T2 : XObject
        {
            return first.Cast<XObject>().And(second);
        }

        public static IEnumerable<XObject> And<T>(this IEnumerable<XObject> first, IEnumerable<T> second)
            where T : XObject
        {
            return first.Concat(second);
        }

        public static IEnumerable<XObject> And<T>(this IEnumerable<XObject> first, T second)
            where T : XObject
        {
            return first.Concat(new XObject[] { second });
        }
    }
}