namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Valuify;

    [Fluentify]
    [Valuify]
    public sealed partial class Result
        : IValidatableObject
    {
        public static readonly Result Task = new Result { Type = typeof(Task) };
        public static readonly Result Void = new Result { Mode = Modality.Synchronous };

        private const string Separator = " ";

        public bool IsTask => this == Task;

        public bool IsVoid => this == Void;

        public Kind Modifier { get; set; } = Kind.None;

        public Modality Mode { get; set; } = Modality.Asynchronous;

        public Symbol Type { get; set; } = Symbol.Unspecified;

        public static implicit operator string(Result result)
        {
            Guard.Against.Conversion<Result, string>(result);

            return result.ToString();
        }

        public static implicit operator Snippet(Result result)
        {
            Guard.Against.Conversion<Result, Snippet>(result);

            return Snippet.From(result);
        }

        public override string ToString()
        {
            string modifier = Modifier;
            string mode = Mode;
            string type = Type;

            return Separator.Combine(mode, modifier, type);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Modifier == Kind.None && Type == Symbol.Unspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Type), _ => !Type.IsUnspecified, Type)
                .Results;
        }
    }
}