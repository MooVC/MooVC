namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Event_Resources;
    using Identifier = MooVC.Syntax.Elements.Identifier;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# member syntax event.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Event
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
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
        /// Gets the behaviours on the Event.
        /// </summary>
        /// <value>The behaviours.</value>
        public Methods Behaviours { get; internal set; } = Methods.Default;

        /// <summary>
        /// Gets the extensibility on the Event.
        /// </summary>
        /// <value>The extensibility.</value>
        public Extensibility Extensibility { get; internal set; } = Extensibility.Implicit;

        /// <summary>
        /// Gets the handler on the Event.
        /// </summary>
        /// <value>The handler.</value>
        public Symbol Handler { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Gets a value indicating whether the Event is undefind.
        /// </summary>
        /// <value>A value indicating whether the Event is undefind.</value>
        [Ignore]
        public bool IsUndefind => this == Undefined;

        /// <summary>
        /// Gets the name on the Event.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        /// <summary>
        /// Gets the scope on the Event.
        /// </summary>
        /// <value>The scope.</value>
        public Scope Scope { get; internal set; } = Scope.Public;

        /// <summary>
        /// Defines the string operator for the Event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Event @event)
        {
            Guard.Against.Conversion<Event, string>(@event);

            return @event.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Event @event)
        {
            Guard.Against.Conversion<Event, Snippet>(@event);

            return Snippet.From(@event);
        }

        /// <summary>
        /// Returns the string representation of the Event.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Snippet.Options.Default);
        }

        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
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
        /// Validates the Event.
        /// </summary>
        /// <remarks>Required members include: Extensibility, Handler, Name.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
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