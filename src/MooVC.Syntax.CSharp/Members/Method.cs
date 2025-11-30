namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Method
        : IValidatableObject
    {
        public static readonly Method Undefined = new Method();

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Result Result { get; set; } = Result.Task;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}