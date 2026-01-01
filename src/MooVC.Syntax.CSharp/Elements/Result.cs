namespace MooVC.Syntax.CSharp.Elements
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Elements.Result_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Result
        : IValidatableObject
    {
        public static readonly Result Task = new Result { Type = typeof(Task) };
        public static readonly Result Undefined = new Result();
        public static readonly Result Void = new Result { Mode = Modality.Synchronous };

        private const string Separator = " ";

        internal Result()
        {
        }

        [Ignore]
        public bool IsTask => this == Task;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        [Ignore]
        public bool IsVoid => this == Void;

        public Kind Modifier { get; internal set; } = Kind.None;

        public Modality Mode { get; internal set; } = Modality.Asynchronous;

        [Descriptor("OfType")]
        public Symbol Type { get; internal set; } = Symbol.Undefined;

        public static implicit operator Result(Type type)
        {
            Guard.Against.Conversion<Type, Result>(type);

            return new Result { Type = type };
        }

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
            if (IsUndefined)
            {
                return string.Empty;
            }

            string modifier = Modifier;
            string mode = Mode;
            string type = Type;

            return Separator.Combine(mode, modifier, type);
        }

        public Snippet ToSnippet(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Result)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            return Snippet.From(options, ToString());
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Modifier == Kind.None && Type == Symbol.Undefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Type), _ => !Type.IsUndefined, Type)
                .Results;
        }
    }
}