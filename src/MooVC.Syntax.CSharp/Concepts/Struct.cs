namespace MooVC.Syntax.CSharp.Concepts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fluentify;
    using Valuify;

    [Fluentify]
    [Valuify]
    public sealed partial class Struct
        : Construct
    {
        public static readonly Struct Undefined = new Struct();

        public override bool IsUndefined => this == Undefined;

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return base.Validate(validationContext);
        }
    }
}