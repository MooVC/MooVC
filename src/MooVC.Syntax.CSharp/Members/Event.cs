namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Event_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Event
        : IValidatableObject
    {
        public static readonly Event Undefined = new Event();
        private const string Separator = " ";

        internal Event()
        {
        }

        public Methods Behaviours { get; internal set; } = Methods.Default;

        public Extensibility Extensibility { get; internal set; } = Extensibility.Implicit;

        public Symbol Handler { get; internal set; } = Symbol.Unspecified;

        [Ignore]
        public bool IsUndefind => this == Undefined;

        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        public Scope Scope { get; internal set; } = Scope.Public;

        public static implicit operator string(Event @event)
        {
            Guard.Against.Conversion<Event, string>(@event);

            return @event.ToString();
        }

        public static implicit operator Snippet(Event @event)
        {
            Guard.Against.Conversion<Event, Snippet>(@event);

            return Snippet.From(@event);
        }

        public override string ToString()
        {
            return ToString(Snippet.Options.Default);
        }

        public string ToString(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Event)));

            if (IsUndefind)
            {
                return string.Empty;
            }

            string extensibility = Extensibility;
            string handler = Handler;
            string name = Name.ToString(Identifier.Options.Pascal);
            string scope = Scope;
            string signature = Separator.Combine(scope, extensibility, "event", handler, name);

            Snippet methods = Behaviours;

            if (methods.IsEmpty)
            {
                return string.Concat(signature, ";");
            }

            return methods
                .Block(options, Snippet.From(options, signature))
                .ToString();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefind)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Handler), Handler)
                .And(nameof(Name), _ => !Name.IsUnnamed, Name)
                .Results;
        }
    }
}