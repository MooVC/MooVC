namespace MooVC.Syntax.CSharp
{
    using System.Text;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.CSharp.StringExtensions_Resources;

    internal static partial class StringExtensions
    {
        public static string Combine(this string separator, params string[] values)
        {
            _ = Guard.Against.NullOrEmpty(separator, message: CombineSeparatorRequired);
            _ = Guard.Against.Null(values, message: CombineValuesRequired.Format(separator));

            var builder = new StringBuilder();
            int lastIndex = values.Length - 1;

            for (int index = 0; index < values.Length; index++)
            {
                builder = builder.Append(values[index]);

                if (index < lastIndex)
                {
                    builder = builder.Append(separator);
                }
            }

            return builder.ToString();
        }
    }
}