namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
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

        public override string ToString()
        {
            if (IsUndefind)
            {
                return string.Empty;
            }

            string handler = Handler;
            string name = Name;
            string scope = Scope;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}