namespace MooVC
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using MooVC.Collections.Generic;
    using MooVC.Linq;

    public static partial class Ensure
    {
        public static T[] ArgumentNotEmpty<T>(
            [NotNull] IEnumerable<T>? argument,
            string argumentName,
            Func<T, bool>? predicate = default)
        {
            return ArgumentNotEmpty(
                argument,
                argumentName,
                default!,
                predicate: predicate);
        }

        public static T[] ArgumentNotEmpty<T>(
            [NotNull] IEnumerable<T>? argument,
            string argumentName,
            string message,
            Func<T, bool>? predicate = default)
        {
            ArgumentNotNull(argument, argumentName, message);

            predicate ??= element => element is { };

            T[] snapshot = argument.Snapshot(predicate: predicate);

            if (snapshot.IsEmpty())
            {
                throw new ArgumentException(message, argumentName);
            }

            return snapshot;
        }
    }
}