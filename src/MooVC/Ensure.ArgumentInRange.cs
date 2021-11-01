namespace MooVC
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public static partial class Ensure
    {
        public static T ArgumentInRange<T>(
            T argument,
            string argumentName,
            T? end = default,
            T? start = default)
            where T : struct, IComparable<T>
        {
            if (start.HasValue && argument.CompareTo(start.Value) < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, default);
            }

            if (end.HasValue && argument.CompareTo(end.Value) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, default);
            }

            return argument;
        }

        public static T ArgumentInRange<T>(
           [NotNull] T? argument,
           string argumentName,
           T? end = default,
           T? start = default)
           where T : struct, IComparable<T>
        {
            T actual = ArgumentNotNull(argument, argumentName);

            return ArgumentInRange(
                actual,
                argumentName,
                end: end,
                start: start);
        }
    }
}