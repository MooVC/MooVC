namespace MooVC.Syntax.CSharp.Concepts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public sealed class Solution
            : Construct
    {
        public override bool IsUndefined => throw new System.NotImplementedException();

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}