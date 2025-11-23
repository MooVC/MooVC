namespace MooVC.Syntax.CSharp.Concepts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fluentify;
    using Valuify;

    [Fluentify]
    [Valuify]
    public sealed partial class Record
        : Construct
    {
        public static readonly Record Undefined = new Record();

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