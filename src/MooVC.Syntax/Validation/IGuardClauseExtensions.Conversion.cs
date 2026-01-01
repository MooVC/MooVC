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
        /// Performs the T To operation for the validation helper.
        /// </summary>
        public static void Conversion<TFrom, TTo>(this IGuardClause clause, TFrom from)
        {
            _ = clause.Null(from, message: ConvertToIdentifierRequired.Format(typeof(TFrom), typeof(TTo)));
        }
    }
}