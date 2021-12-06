namespace MooVC
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using MooVC.Collections.Generic;
    using MooVC.Linq;

    public static partial class Ensure
    {
        public static Guid ArgumentNotEmpty(
            [NotNull] Guid? argument,
            string argumentName)
        {
            return ArgumentIsAcceptable(
                argument,
                argumentName,
                predicate: value => value != Guid.Empty);
        }

        public static TimeSpan ArgumentNotEmpty(
            [NotNull] TimeSpan? argument,
            string argumentName)
        {
            return ArgumentIsAcceptable(
                argument,
                argumentName,
                predicate: value => value > TimeSpan.Zero);
        }

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

        public static Guid ArgumentNotEmpty(
           [NotNull] Guid? argument,
           string argumentName,
           string message)
        {
            return ArgumentIsAcceptable(
                argument,
                argumentName,
                predicate: value => value != Guid.Empty,
                message);
        }

        public static TimeSpan ArgumentNotEmpty(
           [NotNull] TimeSpan? argument,
           string argumentName,
           string message)
        {
            return ArgumentIsAcceptable(
                argument,
                argumentName,
                predicate: value => value > TimeSpan.Zero,
                message);
        }

        public static T[] ArgumentNotEmpty<T>(
            [NotNull] IEnumerable<T>? argument,
            string argumentName,
            string message,
            Func<T, bool>? predicate = default)
        {
            _ = ArgumentNotNull(argument, argumentName, message);

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