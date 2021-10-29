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