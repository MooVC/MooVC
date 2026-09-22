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
    using static MooVC.Syntax.CSharp.Extension_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# 14 extension block containing instance or static extension methods.
    /// </summary>
    /// <remarks>
    /// Add the block to <see cref="Class.Extensions" /> on a non-generic, top-level static class.
    /// Instance methods require a named receiver; static methods may use an unnamed receiver.
    /// </remarks>
    [AutoInitializeWith(nameof(Undefined))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    [Fluentify]
    [Valuify]
    public sealed partial class Extension
        : IEnumerable<Qualifier>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined extension block.
        /// </summary>
        public static readonly Extension Undefined = new Extension();

        /// <summary>
        /// Initializes a new instance of the Extension class.
        /// </summary>
        internal Extension()
        {
        }

        /// <summary>
        /// Gets the generic parameters and constraints of the extension block.
        /// </summary>
        /// <value>The generic parameters.</value>
        public ImmutableArray<Generic> Arguments { get; internal set; } = ImmutableArray<Generic>.Empty;

        /// <summary>
        /// Gets a value indicating whether the extension block is undefined.
        /// </summary>
        /// <value>A value indicating whether the extension block is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the extension methods declared in the block.
        /// </summary>
        /// <value>The extension methods.</value>
        public ImmutableArray<Method> Methods { get; internal set; } = ImmutableArray<Method>.Empty;

        /// <summary>
        /// Gets the receiver, including its type, optional name, attributes, and passing mode.
        /// </summary>
        /// <value>The receiver parameter.</value>
        [Descriptor("Extends")]
        public Parameter Receiver { get; internal set; } = Parameter.Undefined;

        /// <summary>
        /// Defines an implicit conversion from <see cref="Extension" /> to <see cref="string" />.
        /// </summary>
        /// <param name="extension">The extension block to convert.</param>
        /// <returns>The rendered extension block.</returns>
        public static implicit operator string(Extension extension)
        {
            Guard.Against.Conversion<Extension, string>(extension);

            return extension.ToString();
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Extension" /> to <see cref="Snippet" />.
        /// </summary>
        /// <param name="extension">The extension block to convert.</param>
        /// <returns>The rendered extension block.</returns>
        public static implicit operator Snippet(Extension extension)
        {
            Guard.Against.Conversion<Extension, Snippet>(extension);

            return Snippet.From(extension);
        }

        /// <summary>
        /// Returns an enumerator over qualifiers referenced by the block.
        /// </summary>
        /// <returns>The receiver, constraint, and method qualifiers.</returns>
        public IEnumerator<Qualifier> GetEnumerator()
        {
            return Arguments
                .SelectMany(argument => argument)
                .Concat(Receiver)
                .Concat(Methods.SelectMany(method => method))
                .GetEnumerator();
        }

        /// <summary>
        /// Returns the C# source representation of the extension block.
        /// </summary>
        /// <returns>The rendered extension block.</returns>
        public override string ToString()
        {
            return ToSnippet(Type.Options.Default);
        }

        /// <summary>
        /// Renders the extension block using the containing type's formatting options.
        /// </summary>
        /// <param name="options">The type formatting options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Type.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(typeof(Extension)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            Parameter.Options parameters = Parameter.Options.Camel
                .WithQualifications(options.Qualifications)
                .WithSnippets(options.Snippets);

            var receiver = Receiver.ToSnippet(parameters);
            var arguments = Arguments.ToSnippet(Generic.Names, options);
            string generics = arguments.IsEmpty ? string.Empty : $"<{arguments}>";
            var signature = Snippet.From(options, $"extension{generics}({receiver})");
            Snippet clauses = Snippet.Empty.Combine(options, Arguments.Select(argument => argument.ToSnippet(options)).ToArray());

            if (!clauses.IsEmpty)
            {
                signature = clauses
                    .Shift(options)
                    .Prepend(options, signature);
            }

            return Methods
                .ToSnippet(options)
                .Block(options, signature);
        }

        /// <summary>
        /// Validates the receiver, generic parameters, and extension methods.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = ValidateReceiver();

            if (Methods.Any(method => !method.Extensibility.IsPermitted(Modifiers.Implicit, Modifiers.Static)))
            {
                results = results.Append(new ValidationResult(ValidateMethodsInvalid, new[] { nameof(Methods) }));
            }

            return validationContext
                .IncludeIf(!Arguments.IsDefaultOrEmpty, nameof(Arguments), argument => !argument.IsUndefined, results, Arguments)
                .AndIf(!Methods.IsDefaultOrEmpty, nameof(Methods), method => !method.IsUndefined, Methods)
                .AndIf(!Receiver.Attributes.IsDefaultOrEmpty, nameof(Receiver.Attributes), attribute => !attribute.IsUnspecified, Receiver.Attributes)
                .AndIf(!Receiver.Name.IsUnnamed, nameof(Receiver.Name), Receiver.Name)
                .And(nameof(Receiver.Type), _ => !Receiver.Type.IsUndefined, Receiver.Type)
                .Results;
        }

        /// <summary>
        /// Returns an enumerator over qualifiers referenced by the block.
        /// </summary>
        /// <returns>The qualifier enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Extension)} {{ " +
                $"{nameof(Arguments)} = `{DebuggerDisplayFormatter.Format(Arguments)}`, " +
                $"{nameof(IsUndefined)} = `{DebuggerDisplayFormatter.Format(IsUndefined)}`, " +
                $"{nameof(Methods)} = `{DebuggerDisplayFormatter.Format(Methods)}`, " +
                $"{nameof(Receiver)} = `{DebuggerDisplayFormatter.Format(Receiver)}` }}";
        }

        private IEnumerable<ValidationResult> ValidateReceiver()
        {
            if (!Receiver.Default.IsEmpty)
            {
                yield return new ValidationResult(ValidateReceiverDefaultInvalid, new[] { nameof(Receiver) });
            }

            if (Receiver.Modifier == Parameter.Modes.Out
                || Receiver.Modifier == Parameter.Modes.Params
                || Receiver.Modifier == Parameter.Modes.This
                || (Receiver.Name.IsUnnamed && !Receiver.Modifier.IsNone))
            {
                yield return new ValidationResult(ValidateReceiverModifierInvalid, new[] { nameof(Receiver) });
            }

            if (Receiver.Name.IsUnnamed && Methods.Any(method => method.Extensibility != Modifiers.Static))
            {
                yield return new ValidationResult(ValidateReceiverNameRequired, new[] { nameof(Receiver) });
            }
        }
    }
}