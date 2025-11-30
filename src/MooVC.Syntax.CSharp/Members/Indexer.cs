namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Indexer
        : IValidatableObject
    {
        public static readonly Indexer Undefined = new Indexer();
        private const string Separator = " ";

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Parameter Parameter { get; set; } = Parameter.Undefined;

        public Result Result { get; set; } = Result.Void;

        public Scope Scope { get; set; } = Scope.Public;

        public static implicit operator string(Indexer indexer)
        {
            Guard.Against.Conversion<Indexer, string>(indexer);

            return indexer.ToString();
        }

        public static implicit operator Snippet(Indexer indexer)
        {
            Guard.Against.Conversion<Indexer, Snippet>(indexer);

            return Snippet.From(indexer);
        }

        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            string parameter = Parameter;
            string result = Result;
            string scope = Scope;

            return Separator.Combine(scope, parameter, result);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            throw new NotImplementedException();
        }
    }
}