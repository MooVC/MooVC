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
    using MooVC.Syntax.CSharp.Syntax;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Field_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a field declaration model.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    [Fluentify]
    [Valuify]
    public sealed partial class Field
        : IEnumerable<Qualifier>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Field Undefined = new Field();

        private const string Separator = " ";

        /// <summary>
        /// Initializes a new instance of the Field class.
        /// </summary>
        internal Field()
        {
        }

        /// <summary>
        /// Gets the attributes associated with the Property.
        /// </summary>
        /// <value>The attributes.</value>
        [Descriptor("AttributedWith")]
        public ImmutableArray<Attribute> Attributes { get; internal set; } = ImmutableArray<Attribute>.Empty;

        /// <summary>
        /// Gets the default on the Field.
        /// </summary>
        /// <value>The default.</value>
        public Snippet Default { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Field is read only.
        /// </summary>
        /// <value>A value indicating whether the Field is read only.</value>
        public bool IsReadOnly { get; internal set; } = true;

        /// <summary>
        /// Gets a value indicating whether the Field is static.
        /// </summary>
        /// <value>A value indicating whether the Field is static.</value>
        public bool IsStatic { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the Field is undefined.
        /// </summary>
        /// <value>A value indicating whether the Field is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the name on the Field.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Variable Name { get; internal set; } = Variable.Unnamed;

        /// <summary>
        /// Gets the scope on the Field.
        /// </summary>
        /// <value>The scope.</value>
        public Scopes Scope { get; internal set; } = Scopes.Private;

        /// <summary>
        /// Gets the type on the Field.
        /// </summary>
        /// <value>The type.</value>
        [Descriptor("OfType")]
        public Symbol Type { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Defines an implicit conversion from <see cref="Field" /> to <see cref="string" />.
        /// </summary>
        /// <param name="field">The <see cref="Field" /> value to convert.</param>
        /// <returns>The converted <see cref="string" /> value.</returns>
        public static implicit operator string(Field field)
        {
            Guard.Against.Conversion<Field, string>(field);

            return field.ToString();
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Field" /> to <see cref="Snippet" />.
        /// </summary>
        /// <param name="field">The <see cref="Field" /> value to convert.</param>
        /// <returns>The converted <see cref="Snippet" /> value.</returns>
        public static implicit operator Snippet(Field field)
        {
            Guard.Against.Conversion<Field, Snippet>(field);

            return Snippet.From(field);
        }

        /// <summary>
        /// Defines an implicit conversion to <see cref="Field" />.
        /// </summary>
        /// <param name="field">The value to convert.</param>
        /// <returns>The converted <see cref="Field" /> value.</returns>
        public static implicit operator Field((Variable Name, Symbol Type) field)
        {
            Guard.Against.Conversion<(Variable Name, Symbol Type), Field>(field);

            return new Field()
                .Named(field.Name)
                .OfType(field.Type);
        }

        /// <summary>
        /// Returns an enumerator that iterates through all symbols contained in the attributes collection, followed by
        /// the type symbol.
        /// </summary>
        /// <remarks>The enumerator yields each symbol from the attributes in order, and then yields the
        /// type symbol as the final element. The order of enumeration is determined by the order of the attributes and
        /// the type.</remarks>
        /// <returns>An enumerator that can be used to iterate through the collection of symbols, including all attribute symbols
        /// and the type symbol.</returns>
        public IEnumerator<Qualifier> GetEnumerator()
        {
            foreach (Qualifier qualifier in Attributes.SelectMany(attribute => attribute)
                .Concat(Type))
            {
                yield return qualifier;
            }
        }

        /// <summary>
        /// Returns the string representation of the field declaration.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Options.Default);
        }

        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Type.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Options), nameof(Snippet), nameof(Field)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            var attributes = Attributes.ToSnippet(options);
            string signature = GetSignature(options);

            if (!Default.IsEmpty)
            {
                signature = $"{signature} = {Default}";
            }

            signature = string.Concat(signature, ';');

            return Snippet
                .From(options, signature)
                .Prepend(options, attributes);
        }

        /// <summary>
        /// Validates the Field.
        /// </summary>
        /// <remarks>Required members include: Default, Name, Type.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Default.IsMultiLine)
            {
                results = results.Append(new ValidationResult(
                    ValidateDefaultRequired.Format(nameof(Default), nameof(Field)),
                    new[] { nameof(Default) }));
            }

            return validationContext
                .Include(nameof(Name), _ => !Name.IsUnnamed, results, Name)
                .And(nameof(Type), _ => !Type.IsUndefined, Type)
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

        private string GetSignature(Type.Options options)
        {
            var name = Name.ToSnippet(Variable.Options.Pascal);
            string scope = Scope;
            string type = Type.ToSnippet(options);
            string @static = IsStatic.Static();
            string @readonly = IsReadOnly.ReadOnly();

            return Separator.Combine(scope, @static, @readonly, type, name);
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Field)} {{ " +
                $"{nameof(Attributes)} = `{DebuggerDisplayFormatter.Format(Attributes)}`, " +
                $"{nameof(Default)} = `{DebuggerDisplayFormatter.Format(Default)}`, " +
                $"{nameof(IsReadOnly)} = `{DebuggerDisplayFormatter.Format(IsReadOnly)}`, " +
                $"{nameof(IsStatic)} = `{DebuggerDisplayFormatter.Format(IsStatic)}`, " +
                $"{nameof(IsUndefined)} = `{DebuggerDisplayFormatter.Format(IsUndefined)}`, " +
                $"{nameof(Name)} = `{DebuggerDisplayFormatter.Format(Name)}`, " +
                $"{nameof(Scope)} = `{DebuggerDisplayFormatter.Format(Scope)}`, " +
                $"{nameof(Type)} = `{DebuggerDisplayFormatter.Format(Type)}` }}";
        }
    }
}