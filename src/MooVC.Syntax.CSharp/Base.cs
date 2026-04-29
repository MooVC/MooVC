namespace MooVC.Syntax.CSharp
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Base_Resources;
    using CType = System.Type;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a base-type clause entry used in class and record declarations.
    /// </summary>
    [AutoInitializeWith(nameof(Unspecified))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    [Fluentify]
    [Valuify]
    public sealed partial class Base
        : IEnumerable<Qualifier>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Base Unspecified = new Base();

        /// <summary>
        /// Initializes a new instance of the Base class.
        /// </summary>
        internal Base()
        {
        }

        /// <summary>
        /// Gets the arguments on the Base.
        /// </summary>
        /// <value>The arguments.</value>
        public ImmutableArray<Token> Arguments { get; internal set; } = ImmutableArray<Token>.Empty;

        /// <summary>
        /// Gets the name on the Base.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Qualification Name { get; internal set; } = Qualification.Unnamed;

        /// <summary>
        /// Gets a value indicating whether the Base is undefined.
        /// </summary>
        /// <value>A value indicating whether the Base is undefined.</value>
        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        /// <summary>
        /// Defines an implicit conversion from <see cref="Base" /> to <see cref="string" />.
        /// </summary>
        /// <param name="@base">The <see cref="Base" /> value to convert.</param>
        /// <returns>The converted <see cref="string" /> value.</returns>
        public static implicit operator string(Base @base)
        {
            Guard.Against.Conversion<Base, string>(@base);

            return @base.ToString();
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Base" /> to <see cref="Snippet" />.
        /// </summary>
        /// <param name="@base">The <see cref="Base" /> value to convert.</param>
        /// <returns>The converted <see cref="Snippet" /> value.</returns>
        public static implicit operator Snippet(Base @base)
        {
            Guard.Against.Conversion<Base, Snippet>(@base);

            return @base.ToSnippet(Type.Options.Default);
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Qualification" /> to <see cref="Base" />.
        /// </summary>
        /// <param name="qualification">The <see cref="Qualification" /> value to convert.</param>
        /// <returns>The converted <see cref="Base" /> value.</returns>
        public static implicit operator Base(Qualification qualification)
        {
            Guard.Against.Conversion<Qualification, Base>(qualification);

            return new Base()
                .Named(qualification);
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Symbol" /> to <see cref="Base" />.
        /// </summary>
        /// <param name="symbol">The <see cref="Symbol" /> value to convert.</param>
        /// <returns>The converted <see cref="Base" /> value.</returns>
        public static implicit operator Base(Symbol symbol)
        {
            Guard.Against.Conversion<Symbol, Base>(symbol);

            return new Base()
                .Enumerate((argument, @base) => @base.WithArguments(argument), symbol.Arguments)
                .Named(symbol.Name);
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="CType" /> to <see cref="Base" />.
        /// </summary>
        /// <param name="type">The <see cref="CType" /> value to convert.</param>
        /// <returns>The converted <see cref="Base" /> value.</returns>
        public static implicit operator Base(CType type)
        {
            Guard.Against.Conversion<CType, Base>(type);

            return new Base()
                .Enumerate((argument, @base) => @base.WithArguments(argument), type.GetGenericArguments())
                .Named(type);
        }

        /// <summary>
        /// Defines an implicit conversion to <see cref="Base" />.
        /// </summary>
        /// <param name="name">The value to convert.</param>
        /// <returns>The converted <see cref="Base" /> value.</returns>
        public static implicit operator Base((Moniker Name, Qualifier Qualifier) name)
        {
            Guard.Against.Conversion<(Moniker Name, Qualifier Qualifier), Base>(name);

            return new Base()
                .Named((Moniker: name.Name, name.Qualifier));
        }

        /// <summary>
        /// Returns an enumerator that iterates through all symbols contained in the constraints.
        /// </summary>
        /// <remarks>
        /// The enumerator iterates over all symbols from each constraint in the order they appear.
        /// The collection should not be modified during enumeration.
        /// </remarks>
        /// <returns>An enumerator that can be used to iterate through the collection of symbols.</returns>
        public IEnumerator<Qualifier> GetEnumerator()
        {
            foreach (Qualifier qualifier in Arguments.SelectMany(argument => argument))
            {
                yield return qualifier;
            }

            if (!Name.Qualifier.IsUnqualified)
            {
                yield return Name.Qualifier;
            }
        }

        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Type.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Type.Options), nameof(Type), nameof(Declaration)));

            if (IsUnspecified)
            {
                return Snippet.Empty;
            }

            string signature = Name.ToSnippet(options);

            if (!Arguments.IsDefaultOrEmpty)
            {
                const string Separator = ", ";

                IEnumerable<string> arguments = Arguments.Select(argument => argument
                    .ToSnippet(options)
                    .ToString());

                string list = string.Join(Separator, arguments);

                signature = $"{signature}<{list}>";
            }

            return Snippet.From(options, signature);
        }

        /// <summary>
        /// Returns the string representation of the base type reference.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Type.Options.Default);
        }

        /// <summary>
        /// Validates the base type reference.
        /// </summary>
        /// <remarks>Required members include: Arguments, Name.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Arguments.IsDefaultOrEmpty, nameof(Arguments), argument => !argument.IsUnspecified, Arguments)
                .And(nameof(Name), _ => !Name.IsUnnamed, Name)
                .Results;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Base)} {{ " +
                $"{nameof(Arguments)} = {DebuggerDisplayFormatter.Format(Arguments)}, " +
                $"{nameof(IsUnspecified)} = {DebuggerDisplayFormatter.Format(IsUnspecified)}, " +
                $"{nameof(Name)} = {DebuggerDisplayFormatter.Format(Name)} }}";
        }
    }
}