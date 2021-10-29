namespace MooVC
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public static partial class Ensure
    {
        public static T ArgumentIsAcceptable<T>(
            [NotNull] T? argument,
            string argumentName,
            Func<T, bool> predicate)
            where T : struct
        {
            T actual = ArgumentNotNull(argument, argumentName);

            if (!predicate(actual))
            {
                throw new ArgumentException(default, argumentName);
            }

            return actual;
        }

        public static T ArgumentIsAcceptable<T>(
            [NotNull] T? argument,
            string argumentName,
            Func<T, bool> predicate)
            where T : class
        {
            _ = ArgumentNotNull(argument, argumentName);

            if (!predicate(argument))
            {
                throw new ArgumentException(default, argumentName);
            }

            return argument;
        }

        public static T ArgumentIsAcceptable<T>(
            [NotNull] T? argument,
            string argumentName,
            Func<T, bool> predicate,
            string message)
            where T : struct
        {
            T actual = ArgumentNotNull(argument, argumentName, message);

            if (!predicate(actual))
            {
                throw new ArgumentException(message, argumentName);
            }

            return actual;
        }

        public static T ArgumentIsAcceptable<T>(
            [NotNull] T? argument,
            string argumentName,
            Func<T, bool> predicate,
            string message)
            where T : class
        {
            _ = ArgumentNotNull(argument, argumentName, message);

            if (!predicate(argument))
            {
                throw new ArgumentException(message, argumentName);
            }

            return argument;
        }
    }
}