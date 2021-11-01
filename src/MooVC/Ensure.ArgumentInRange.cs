namespace MooVC
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using static System.String;

    public static partial class Ensure
    {
        public static T ArgumentInRange<T>(
            T argument,
            string argumentName,
            T? end = default,
            T? start = default)
            where T : struct, IComparable<T>
        {
            return ArgumentInRange(
                argument,
                argumentName,
                Empty,
                end: end,
                start: start);
        }

        public static T ArgumentInRange<T>(
            T argument,
            string argumentName,
            string message,
            T? end = default,
            T? start = default)
            where T : struct, IComparable<T>
        {
            if (start.HasValue && argument.CompareTo(start.Value) < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message);
            }

            if (end.HasValue && argument.CompareTo(end.Value) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message);
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

        public static T ArgumentInRange<T>(
           [NotNull] T? argument,
           string argumentName,
           string message,
           T? end = default,
           T? start = default)
           where T : struct, IComparable<T>
        {
            T actual = ArgumentNotNull(argument, argumentName, message);

            return ArgumentInRange(
                actual,
                argumentName,
                message,
                end: end,
                start: start);
        }
    }
}