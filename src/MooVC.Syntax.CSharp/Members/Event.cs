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

        public Methods Behaviours { get; set; } = Methods.Default;

        public Symbol Handler { get; set; } = Symbol.Unspecified;

        [Ignore]
        public bool IsUndefind => this == Undefined;

        public bool IsStatic { get; set; }

        public Identifier Name { get; set; } = Identifier.Unnamed;

        public Scope Scope { get; set; } = Scope.Public;

        public static implicit operator string(Event @event)
        {
            if (@event is null)
            {
                @event = Undefined;
            }

            return @event.ToString();
        }

        public static implicit operator Snippet(Event @event)
        {
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

            string handler = Handler;
            string name = Name;
            string scope = Scope;
            string signature = $"{scope} event {handler} {name}";

            Snippet methods = Behaviours;

            if (methods.IsEmpty)
            {
                return string.Concat(signature, ";");
            }

            if (methods.IsSingleLine)
            {
                return $"{signature} {{ {methods} }}";
            }

            return methods
                .Block(options, Snippet.From(signature, options))
                .ToString();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefind)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Name.IsUnnamed)
            {
                results = results.Append(new ValidationResult(ValidateNameRequired.Format(nameof(Name), nameof(Event)), new[] { nameof(Name) }));
            }

            return validationContext
                .Include(nameof(Handler), results, Handler)
                .And(nameof(Name), Name)
                .Results;
        }
    }
}