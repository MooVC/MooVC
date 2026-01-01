namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Indexer_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a c# member syntax indexer.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Indexer
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Indexer.
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
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the behaviours on the Indexer.
        /// </summary>
        public Methods Behaviours { get; internal set; } = Methods.Default;

        /// <summary>
        /// Gets or sets the extensibility on the Indexer.
        /// </summary>
        public Extensibility Extensibility { get; internal set; } = Extensibility.Implicit;

        /// <summary>
        /// Gets or sets the parameter on the Indexer.
        /// </summary>
        [Descriptor("Accepts")]
        public Parameter Parameter { get; internal set; } = Parameter.Undefined;

        /// <summary>
        /// Gets or sets the result on the Indexer.
        /// </summary>
        [Descriptor("Returns")]
        public Result Result { get; internal set; } = Result.Void;

        /// <summary>
        /// Gets or sets the scope on the Indexer.
        /// </summary>
        public Scope Scope { get; internal set; } = Scope.Public;

        /// <summary>
        /// Defines the string operator for the Indexer.
        /// </summary>
        public static implicit operator string(Indexer indexer)
        {
            Guard.Against.Conversion<Indexer, string>(indexer);

            return indexer.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Indexer.
        /// </summary>
        public static implicit operator Snippet(Indexer indexer)
        {
            Guard.Against.Conversion<Indexer, Snippet>(indexer);

            return Snippet.From(indexer);
        }

        /// <summary>
        /// Returns the string representation of the Indexer.
        /// </summary>
        public override string ToString()
        {
            return ToSnippet(Snippet.Options.Default);
        }

        /// <summary>
        /// Creates a code snippet representation of the c# member syntax.
        /// </summary>
        public Snippet ToSnippet(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Indexer)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            Snippet signature = GetSignature();
            var methods = Behaviours.ToSnippet(options);

            if (methods.IsSingleLine && options.Block.Inline.IsLambda)
            {
                options = options.WithBlock(block => block
                    .WithInline(inline => Snippet.BlockOptions.InlineStyle.SingleLineBraces));
            }

            return methods.Block(options, signature);
        }

        /// <summary>
        /// Validates the Indexer and returns validation results.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Behaviours.IsDefault || Behaviours.Get.IsEmpty)
            {
                results = results.Append(new ValidationResult(
                    ValidateBehavioursRequired.Format(nameof(Behaviours), nameof(Indexer), nameof(Methods.Get)),
                    new[] { nameof(Behaviours) }));
            }

            if (!Extensibility.IsPermitted(
                Extensibility.Abstract,
                Extensibility.Implicit,
                Extensibility.Override,
                Extensibility.Sealed + Extensibility.Override,
                Extensibility.Virtual))
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

            return validationContext
                .Include(nameof(Parameter), _ => !Parameter.IsUndefined, results, Parameter)
                .Results;
        }

        private Snippet GetSignature()
        {
            string extensibility = Extensibility;
            string parameter = Parameter;
            string result = Result.WithMode(Result.Modality.Synchronous);
            string scope = Scope;
            string signature = Separator.Combine(scope, extensibility, result, $"this[{parameter}]");

            return Snippet.From(signature);
        }
    }
}