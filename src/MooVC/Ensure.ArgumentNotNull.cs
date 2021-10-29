namespace MooVC
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public static partial class Ensure
    {
        public static T ArgumentNotNull<T>(
            [NotNull] T? argument,
            string argumentName)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName);
            }

            return argument;
        }

        public static T ArgumentNotNull<T>(
            [NotNull] T? argument,
            string argumentName,
            string message)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName, message);
            }

            return argument;
        }
    }
}