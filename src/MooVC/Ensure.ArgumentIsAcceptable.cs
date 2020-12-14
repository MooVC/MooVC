namespace MooVC
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public static partial class Ensure
    {
        public static void ArgumentIsAcceptable<T>(
            [NotNull] T? argument,
            string argumentName,
            Func<T?, bool> predicate)
        {
            ArgumentNotNull(argument, argumentName);

            if (!predicate(argument))
            {
                throw new ArgumentException(argumentName);
            }
        }

        public static void ArgumentIsAcceptable<T>(
            [NotNull] T? argument,
            string argumentName,
            Func<T?, bool> predicate,
            string message)
        {
            ArgumentNotNull(argument, argumentName, message);

            if (!predicate(argument))
            {
                throw new ArgumentException(message, argumentName);
            }
        }
    }
}