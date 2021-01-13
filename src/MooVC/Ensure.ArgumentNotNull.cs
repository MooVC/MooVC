namespace MooVC
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public static partial class Ensure
    {
        public static void ArgumentNotNull<T>(
            [NotNull] T? argument,
            string argumentName)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void ArgumentNotNull<T>(
            [NotNull] T? argument,
            string argumentName,
            string message)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }
    }
}