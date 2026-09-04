namespace MooVC.Syntax.Validation
{
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.Validation.IGuardClauseExtensions_Resources;

    /// <summary>
    /// Provides guard clause extensions related to conversion validation.
    /// </summary>
    public static partial class IGuardClauseExtensions
    {
        /// <summary>
        /// Verifies that the source value for a conversion is not <see langword="null" />.
        /// </summary>
        /// <param name="clause">The clause.</param>
        /// <param name="from">The source value that is intended to be converted.</param>
        /// <typeparam name="TFrom">The type from which the conversion is to occur.</typeparam>
        /// <typeparam name="TTo">The type to which the conversion is to occur.</typeparam>
        public static void Conversion<TFrom, TTo>(this IGuardClause clause, TFrom from)
        {
            _ = clause.Null(from, message: ConvertToIdentifierRequired.Format(typeof(TFrom), typeof(TTo)));
        }
    }
}