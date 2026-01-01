namespace MooVC.Syntax.Validation
{
    using System;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.Validation.IGuardClauseExtensions_Resources;

    public static partial class IGuardClauseExtensions
    {
        public static void Conversion<TFrom, TTo>(this IGuardClause clause, TFrom from)
        {
            _ = clause.Null(from, message: ConvertToIdentifierRequired.Format(typeof(TFrom), typeof(TTo)));
        }
    }
}