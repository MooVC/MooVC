namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Fluentify;
    using MooVC.Linq;
    using Valuify;

    [Fluentify]
    [Valuify]
    public sealed partial class Attribute
        : IValidatableObject
    {
        private const string Separator = ", ";

        public ImmutableArray<Argument> Arguments { get; set; } = ImmutableArray<Argument>.Empty;

        public Symbol Name { get; set; } = Symbol.Unspecified;

        public Specifier Target { get; set; } = Specifier.None;

        public override string ToString()
        {
            if (Name.IsUnspecified)
            {
                return string.Empty;
            }

            var value = new StringBuilder();

            if (Target != Specifier.None)
            {
                value = value.Append($"{Target}:");
            }

            value = value.Append(Name);

            string arguments = string.Empty;

            if (!Arguments.IsDefaultOrEmpty)
            {
                arguments = Separator.Combine(Arguments, argument => argument.ToString(Argument.Options.Declaration));

                value = value.Append($"({arguments})");
            }

            return $"[{value}]";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}