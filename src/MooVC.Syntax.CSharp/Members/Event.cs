namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Event_Resources;
    using Identifier = MooVC.Syntax.Elements.Identifier;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a c# member syntax event.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Event
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Event.
        /// </summary>
        public static readonly Event Undefined = new Event();
        private const string Separator = " ";

        /// <summary>
        /// Initializes a new instance of the Event class.
        /// </summary>
        internal Event()
        {
        }

        /// <summary>
        /// Gets or sets the behaviours on the Event.
        /// </summary>
        public Methods Behaviours { get; internal set; } = Methods.Default;

        /// <summary>
        /// Gets or sets the extensibility on the Event.
        /// </summary>
        public Extensibility Extensibility { get; internal set; } = Extensibility.Implicit;

        /// <summary>
        /// Gets or sets the handler on the Event.
        /// </summary>
        public Symbol Handler { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Gets a value indicating whether the Event is undefind.
        /// </summary>
        [Ignore]
        public bool IsUndefind => this == Undefined;

        /// <summary>
        /// Gets or sets the name on the Event.
        /// </summary>
        [Descriptor("Named")]
        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        /// <summary>
        /// Gets or sets the scope on the Event.
        /// </summary>
        public Scope Scope { get; internal set; } = Scope.Public;

        /// <summary>
        /// Defines the string operator for the Event.
        /// </summary>
        public static implicit operator string(Event @event)
        {
            Guard.Against.Conversion<Event, string>(@event);

            return @event.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Event.
        /// </summary>
        public static implicit operator Snippet(Event @event)
        {
            Guard.Against.Conversion<Event, Snippet>(@event);

            return Snippet.From(@event);
        }

        /// <summary>
        /// Returns the string representation of the Event.
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
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Event)));

            if (IsUndefind)
            {
                return Snippet.Empty;
            }

            string extensibility = Extensibility;
            string handler = Handler;
            var name = Name.ToSnippet(Identifier.Options.Pascal);
            string scope = Scope;
            string signature = Separator.Combine(scope, extensibility, "event", handler, name);
            var methods = Behaviours.ToSnippet(options);

            if (methods.IsEmpty)
            {
                return string.Concat(signature, ";");
            }

            if (methods.IsSingleLine && options.Block.Inline.IsLambda)
            {
                options = options.WithBlock(block => block
                    .WithInline(inline => Snippet.BlockOptions.InlineStyle.SingleLineBraces));
            }

            return methods.Block(options, Snippet.From(options, signature));
        }

        /// <summary>
        /// Validates the Event and returns validation results.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefind)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

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

            return validationContext
                .Include(nameof(Handler), results, Handler)
                .And(nameof(Name), _ => !Name.IsUnnamed, Name)
                .Results;
        }
    }
}