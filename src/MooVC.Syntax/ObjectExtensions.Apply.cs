namespace MooVC.Syntax
{
    using System;

    internal static partial class ObjectExtensions
    {
        public static T Apply<T>(this T source, Func<T, T> action)
        {
            if (action is null)
            {
                return source;
            }

            return action(source);
        }
    }
}