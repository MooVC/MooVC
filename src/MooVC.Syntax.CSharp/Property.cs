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
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Property_Resources;
    using static MooVC.Syntax.Snippet.Options.Blocks;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a property declaration model.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    [Fluentify]
    [Valuify]
    public sealed partial class Property
        : IEnumerable<Qualifier>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Property Undefined = new Property();

        private const string Separator = " ";

        /// <summary>
        /// Initializes a new instance of the Property class.
        /// </summary>
        internal Property()
        {
        }

        /// <summary>
        /// Gets the attributes associated with the Property.
        /// </summary>
        /// <value>The attributes.</value>
        [Descriptor("AttributedWith")]
        public ImmutableArray<Attribute> Attributes { get; internal set; } = ImmutableArray<Attribute>.Empty;

        /// <summary>
        /// Gets the behaviours on the Property.
        /// </summary>
        /// <value>The behaviours.</value>
        public Methods Behaviours { get; internal set; } = Methods.Default;

        /// <summary>
        /// Gets the default on the Property.
        /// </summary>
        /// <value>The default.</value>
        public Snippet Default { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the extensibility on the Property.
        /// </summary>
        /// <value>The extensibility.</value>
        public Modifiers Extensibility { get; internal set; } = Modifiers.Implicit;

        /// <summary>
        /// Gets a value indicating whether the Property is undefined.
        /// </summary>
        /// <value>A value indicating whether the Property is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the name on the Property.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Name Name { get; internal set; } = Name.Unnamed;

        /// <summary>
        /// Gets the scope on the Property.
        /// </summary>
        /// <value>The scope.</value>
        public Scopes Scope { get; internal set; } = Scopes.Public;

        /// <summary>
        /// Gets the type on the Property.
        /// </summary>
        /// <value>The type.</value>
        [Descriptor("OfType")]
        public Symbol Type { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Defines an implicit conversion from <see cref="Property" /> to <see cref="string" />.
        /// </summary>
        /// <param name="property">The <see cref="Property" /> value to convert.</param>
        /// <returns>The converted <see cref="string" /> value.</returns>
        public static implicit operator string(Property property)
        {
            Guard.Against.Conversion<Property, string>(property);

            return property.ToString();
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Property" /> to <see cref="Snippet" />.
        /// </summary>
        /// <param name="property">The <see cref="Property" /> value to convert.</param>
        /// <returns>The converted <see cref="Snippet" /> value.</returns>
        public static implicit operator Snippet(Property property)
        {
            Guard.Against.Conversion<Property, Snippet>(property);

            return Snippet.From(property.ToString());
        }

        /// <summary>
        /// Defines an implicit conversion to <see cref="Property" />.
        /// </summary>
        /// <param name="property">The value to convert.</param>
        /// <returns>The converted <see cref="Property" /> value.</returns>
        public static implicit operator Property((Name Name, Symbol Type) property)
        {
            Guard.Against.Conversion<(Name Name, Symbol Type), Property>(property);

            return new Property()
                .Named(property.Name)
                .OfType(property.Type);
        }

        /// <summary>
        /// Returns an enumerator that iterates through all symbols contained in the attributes and the type.
        /// </summary>
        /// <remarks>
        /// The enumerator yields all symbols from each attribute in order, followed by the type symbol.
        /// The order of enumeration is consistent with the order of the attributes and type as stored in the collection.
        /// </remarks>
        /// <returns>An enumerator that can be used to iterate through the collection of symbols, including those from the
        /// attributes and the type.</returns>
        public IEnumerator<Qualifier> GetEnumerator()
        {
            foreach (Qualifier qualifier in Attributes.SelectMany(attribute => attribute)
                .Concat(Type))
            {
                yield return qualifier;
            }
        }

        /// <summary>
        /// Returns the string representation of the property declaration.
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
        public Snippet ToSnippet(Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Options), nameof(Snippet), nameof(Property)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            var attributes = Attributes.ToSnippet(options);
            Snippet signature = GetSignature(options);
            var behaviours = Behaviours.ToSnippet(options, Scope);
            Snippet.Options body = FormatBlockStyle(behaviours, options);

            signature = behaviours.Block(body, signature);

            if (!Default.IsEmpty)
            {
                signature = signature.Append(body, $" = {Default}");
            }

            return signature.Prepend(options, attributes);
        }

        /// <summary>
        /// Validates the Property.
        /// </summary>
        /// <remarks>Required members include: Extensibility, Default, Name, Type.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (!Extensibility.IsPermitted(
                Modifiers.Abstract,
                Modifiers.Implicit,
                Modifiers.Override,
                Modifiers.Sealed + Modifiers.Override,
                Modifiers.Virtual))
            {
                results = results.Append(new ValidationResult(
                    ValidateExtensibilityInvalid.Format(nameof(Extensibility), Extensibility, nameof(Event)),
                    new[] { nameof(Extensibility) }));
            }

            if (Default.IsMultiLine)
            {
                results = results.Append(new ValidationResult(
                    ValidateDefaultRequired.Format(nameof(Default), nameof(Property)),
                    new[] { nameof(Default) }));
            }

            return validationContext
                .IncludeIf(!Attributes.IsDefaultOrEmpty, nameof(Attributes), attribute => !attribute.IsUnspecified, results, Attributes)
                .And(nameof(Name), _ => !Name.IsUnnamed, Name)
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

        private Snippet.Options FormatBlockStyle(Snippet behaviours, Options options)
        {
            bool isSingleLineBraces = behaviours.IsSingleLine
                && options.Snippets.Block.Inline.IsLambda
                && (Behaviours.Get.IsEmpty || !Behaviours.Set.Mode.IsReadOnly);

            if (isSingleLineBraces)
            {
                return options.Snippets
                    .WithBlock(block => block
                        .WithInline(Styles.SingleLine));
            }

            return options.Snippets;
        }

        private Snippet GetSignature(Options options)
        {
            string extensibility = Extensibility;
            string name = Name;
            string scope = Scope.ToString(options.Implied);
            string type = Type.ToSnippet(options);
            string signature = Separator.Combine(scope, extensibility, type, name);

            return Snippet.From(options, signature);
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Property)} {{ {nameof(Attributes)} = {DebuggerDisplayFormatter.Format(Attributes)}, {nameof(Behaviours)} = {DebuggerDisplayFormatter.Format(Behaviours)}, {nameof(Default)} = {DebuggerDisplayFormatter.Format(Default)}, {nameof(Extensibility)} = {DebuggerDisplayFormatter.Format(Extensibility)}, {nameof(IsUndefined)} = {DebuggerDisplayFormatter.Format(IsUndefined)}, {nameof(Name)} = {DebuggerDisplayFormatter.Format(Name)}, {nameof(Scope)} = {DebuggerDisplayFormatter.Format(Scope)}, {nameof(Type)} = {DebuggerDisplayFormatter.Format(Type)} }}";
        }
    }
}