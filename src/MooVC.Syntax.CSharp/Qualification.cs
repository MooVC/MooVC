namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Qualification_Resources;
    using Ignore = Valuify.IgnoreAttribute;
    using Kind = System.Type;

    /// <summary>
    /// Represents a C# syntax element symbol.
    /// </summary>
    [AutoInitializeWith(nameof(Unnamed))]
    [Fluentify]
    [Valuify]
    public sealed partial class Qualification
        : IComparable<Qualification>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Qualification Unnamed = new Qualification();

        internal Qualification()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the Name is undefined.
        /// </summary>
        /// <value>A value indicating whether the Name is undefined.</value>
        [Ignore]
        public bool IsUnnamed => this == Unnamed;

        /// <summary>
        /// Gets the moniker on the Name.
        /// </summary>
        /// <value>The moniker.</value>
        [Descriptor("KnownAs")]
        public Moniker Moniker { get; internal set; } = Moniker.Unnamed;

        /// <summary>
        /// Gets the qualifier on the Name.
        /// </summary>
        /// <value>The qualifier.</value>
        [Descriptor("From")]
        public Qualifier Qualifier { get; internal set; } = Qualifier.Unqualified;

        /// <summary>
        /// Defines the string operator for the Name.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Qualification symbol)
        {
            Guard.Against.Conversion<Qualification, string>(symbol);

            return symbol.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Name.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Qualification symbol)
        {
            Guard.Against.Conversion<Qualification, Snippet>(symbol);

            return Snippet.From(symbol);
        }

        /// <summary>
        /// Defines the Name operator for the moniker.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <returns>The qualification.</returns>
        public static implicit operator Qualification(string moniker)
        {
            Guard.Against.Conversion<string, Qualification>(moniker);

            return new Qualification()
                .KnownAs(moniker);
        }

        /// <summary>
        /// Defines the Name operator for the moniker.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <returns>The qualification.</returns>
        public static implicit operator Qualification(Moniker moniker)
        {
            Guard.Against.Conversion<Moniker, Qualification>(moniker);

            return new Qualification()
                .KnownAs(moniker);
        }

        /// <summary>
        /// Defines the Name operator for the Name.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The symbol.</returns>
        public static implicit operator Qualification(Kind type)
        {
            Guard.Against.Conversion<Kind, Qualification>(type);

            return new Qualification()
                .From(type)
                .KnownAs(type);
        }

        /// <summary>
        /// Implicitly converts a tuple containing a name and qualifier to an Name instance.
        /// </summary>
        /// <param name="name">The tuple containing the name and qualifier to be converted into an Name.</param>
        /// <returns>The Name.</returns>
        public static implicit operator Qualification((Moniker Moniker, Qualifier Qualifier) name)
        {
            Guard.Against.Conversion<(Moniker Moniker, Qualifier Qualifier), Qualification>(name);

            return new Qualification()
                .From(name.Qualifier)
                .KnownAs(name.Moniker);
        }

        /// <summary>
        /// Defines the less than operator for the Name.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator <(Qualification left, Qualification right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Defines the greater than operator for the Name.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator >(Qualification left, Qualification right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Defines the less than or equal to operator for the Name.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator <=(Qualification left, Qualification right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Defines the greater than or equal to operator for the Name.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator >=(Qualification left, Qualification right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Compares this Name to another instance.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>A signed integer indicating relative order.</returns>
        public int CompareTo(Qualification other)
        {
            return other is null
                ? 1
                : Moniker.CompareTo(other.Moniker);
        }

        /// <summary>
        /// Returns the string representation of the Name.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToString(Options.Default);
        }

        /// <summary>
        /// Creates a snippet representation of the C# syntax element.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Options options)
        {
            return ToString(options);
        }

        /// <summary>
        /// Validates the Name.
        /// </summary>
        /// <remarks>Required members include: Arguments, Name, Qualifier.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnnamed)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Moniker), _ => !Moniker.IsUnnamed, Moniker)
                .And(nameof(Qualifier), Qualifier)
                .Results;
        }

        private string ToString(Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Qualification)));

            if (IsUnnamed)
            {
                return string.Empty;
            }

            string signature = Moniker;

            if (!Aliases.IsSystem(signature))
            {
                signature = GetQualifiedSignature(options, signature);
            }

            return signature;
        }

        private Snippet GetQualifiedSignature(Options options, string signature)
        {
            if (Qualifier.IsUnqualified || options.Format == Options.Formats.Minimum)
            {
                const int SuffixLength = 9;

                if (signature.Length > SuffixLength && signature.EndsWith(nameof(Attribute)))
                {
                    signature = signature.Substring(0, signature.Length - SuffixLength);
                }

                return signature;
            }

            signature = $"{Qualifier}.{signature}";

            if (options.Format == Options.Formats.Global)
            {
                return $"global::{signature}";
            }

            return signature;
        }
    }
}