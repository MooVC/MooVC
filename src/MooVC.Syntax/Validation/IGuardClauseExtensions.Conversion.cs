namespace MooVC.Syntax.Validation
{
    using System;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.Validation.IGuardClauseExtensions_Resources;

    /// <summary>
    /// Represents a validation helper i guard clause extensions.
    /// </summary>
    public static partial class IGuardClauseExtensions
    {
        /// <summary>
        /// Performs the t to operation for the validation helper.
        /// </summary>
        /// <param name="clause">The clause.</param>
        /// <param name="from">The from.</param>
        /// <typeparam name="TFrom">The type from which the conversion is to occur.</typeparam>
        /// <typeparam name="TTo">The type to which the conversion is to occur.</typeparam>
        /// <returns>The conversion t from.</returns>
        public static void Conversion<TFrom, TTo>(this IGuardClause clause, TFrom from)
        {
            _ = clause.Null(from, message: ConvertToIdentifierRequired.Format(typeof(TFrom), typeof(TTo)));
        }
    }
}