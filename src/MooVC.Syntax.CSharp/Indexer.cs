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
    using static MooVC.Syntax.CSharp.Indexer_Resources;
    using static MooVC.Syntax.Snippet.Options.Blocks;
    using DescriptorIgnore = Fluentify.IgnoreAttribute;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents an indexer declaration model.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    [Fluentify]
    [Valuify]
    public sealed partial class Indexer
        : IEnumerable<Qualifier>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Indexer Undefined = new Indexer();
        private const string Separator = " ";

        /// <summary>
        /// Initializes a new instance of the Indexer class.
        /// </summary>
        internal Indexer()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the Indexer is undefined.
        /// </summary>
        /// <value>A value indicating whether the Indexer is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the behaviours on the Indexer.
        /// </summary>
        /// <value>The behaviours.</value>
        public Methods Behaviours { get; internal set; } = Methods.Default;

        /// <summary>
        /// Gets the interface that this indexer explicitly implements.
        /// </summary>
        /// <value>The interface type or an undefined symbol for an ordinary indexer.</value>
        public Symbol ExplicitInterface { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Gets the extensibility on the Indexer.
        /// </summary>
        /// <value>The extensibility.</value>
        public Modifiers Extensibility { get; internal set; } = Modifiers.Implicit;

        /// <summary>
        /// Gets the first parameter on the indexer.
        /// </summary>
        /// <value>The first parameter or an undefined parameter if there are none.</value>
        [DescriptorIgnore]
        [Ignore]
        public Parameter Parameter
        {
            get => Parameters.IsDefaultOrEmpty ? Parameter.Undefined : Parameters[0];
            internal set => Parameters = value.IsUndefined ? ImmutableArray<Parameter>.Empty : ImmutableArray.Create(value);
        }

        /// <summary>
        /// Gets the ordered parameters on the indexer.
        /// </summary>
        /// <value>The indexer parameters.</value>
        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

        /// <summary>
        /// Gets the result on the Indexer.
        /// </summary>
        /// <value>The result.</value>
        [Descriptor("Returns")]
        public Result Result { get; internal set; } = Result.Void;

        /// <summary>
        /// Gets the scope on the Indexer.
        /// </summary>
        /// <value>The scope.</value>
        public Scopes Scope { get; internal set; } = Scopes.Public;

        /// <summary>
        /// Defines an implicit conversion from <see cref="Indexer" /> to <see cref="string" />.
        /// </summary>
        /// <param name="indexer">The <see cref="Indexer" /> value to convert.</param>
        /// <returns>The converted <see cref="string" /> value.</returns>
        public static implicit operator string(Indexer indexer)
        {
            Guard.Against.Conversion<Indexer, string>(indexer);

            return indexer.ToString();
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Indexer" /> to <see cref="Snippet" />.
        /// </summary>
        /// <param name="indexer">The <see cref="Indexer" /> value to convert.</param>
        /// <returns>The converted <see cref="Snippet" /> value.</returns>
        public static implicit operator Snippet(Indexer indexer)
        {
            Guard.Against.Conversion<Indexer, Snippet>(indexer);

            return Snippet.From(indexer);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of symbols, including both parameters and results.
        /// </summary>
        /// <returns>An enumerator for the combined sequence of parameter and result symbols.</returns>
        public IEnumerator<Qualifier> GetEnumerator()
        {
            foreach (Qualifier qualifier in ExplicitInterface.Concat(Parameters.SelectMany(parameter => parameter)).Concat(Result))
            {
                yield return qualifier;
            }
        }

        /// <summary>
        /// Returns the string representation of the Indexer.
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
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(typeof(Indexer)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            Snippet signature = GetSignature(options);
            var methods = Behaviours.ToSnippet(options, Scope);
            Snippet.Options snippets = FormatBlockStyle(methods, options);

            return methods.Block(snippets, signature);
        }

        /// <summary>
        /// Validates the Indexer.
        /// </summary>
        /// <remarks>Required members include: Behaviours, Extensibility, Result, Parameters.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if ((!Behaviours.HasGetter || Behaviours.Get.IsEmpty) && Behaviours.Set.IsEmpty)
            {
                results = results.Append(new ValidationResult(
                    ValidateBehavioursRequired.Format(nameof(Behaviours), nameof(Indexer), $"{nameof(Methods.Get)}/{nameof(Methods.Set)}"),
                    new[] { nameof(Behaviours) }));
            }

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

            if (Result.IsVoid)
            {
                results = results.Append(new ValidationResult(
                    ValidateResultRequired.Format(nameof(Result), nameof(Indexer)),
                    new[] { nameof(Result) }));
            }

            ImmutableArray<Parameter> parameters = Parameters.IsDefaultOrEmpty
                ? ImmutableArray.Create(Parameter.Undefined)
                : Parameters;

            return validationContext
                .Include(nameof(Parameters), parameter => !parameter.IsUndefined, results, parameters)
                .AndIf(!ExplicitInterface.IsUndefined, nameof(ExplicitInterface), ExplicitInterface)
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

        private static Snippet.Options FormatBlockStyle(Snippet methods, Snippet.Options options)
        {
            if (methods.IsSingleLine && options.Block.Inline.IsLambda)
            {
                return options.WithBlock(block => block
                   .WithInline(Styles.SingleLine));
            }

            return options;
        }

        private Snippet GetSignature(Options options)
        {
            string extensibility = Extensibility;
            string parameters = Parameters.ToSnippet(options);
            string result = Result.WithMode(Result.Modes.Synchronous).ToSnippet(options);
            string scope = ExplicitInterface.IsUndefined ? Scope.ToString(options) : string.Empty;
            string name = ExplicitInterface.IsUndefined ? "this" : $"{ExplicitInterface.ToSnippet(options)}.this";
            string signature = Separator.Combine(scope, extensibility, result, $"{name}[{parameters}]");

            return Snippet.From(options, signature);
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Indexer)} {{ " +
                $"{nameof(Behaviours)} = `{DebuggerDisplayFormatter.Format(Behaviours)}`, " +
                $"{nameof(ExplicitInterface)} = `{DebuggerDisplayFormatter.Format(ExplicitInterface)}`, " +
                $"{nameof(Extensibility)} = `{DebuggerDisplayFormatter.Format(Extensibility)}`, " +
                $"{nameof(IsUndefined)} = `{DebuggerDisplayFormatter.Format(IsUndefined)}`, " +
                $"{nameof(Parameters)} = `{DebuggerDisplayFormatter.Format(Parameters)}`, " +
                $"{nameof(Result)} = `{DebuggerDisplayFormatter.Format(Result)}`, " +
                $"{nameof(Scope)} = `{DebuggerDisplayFormatter.Format(Scope)}` }}";
        }
    }
}